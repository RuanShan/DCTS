using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DCTS.DB;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using DCTS.Uti;
using System.Collections;

namespace DCTS.Bus
{
    //http://www.cnblogs.com/kesalin/archive/2012/04/18/open_xml_word.html
    class CustomerTripWordExporterEx
    {
        long TripId { get; set; }

        Trip trip;
        List<TripDay> days;
        List<DayLocation> dayLocations;
        List<WordprocessingDocument> filledTemplates;
        List<MemoryStream> filledTemplateStreams = new List<MemoryStream>();
        List<Ticket> ticketList;
        List<ComboLocation> ticketLocations;
        List<Supplier> supplierList;
        List<Customer> customerList;

        public CustomerTripWordExporterEx(long trip_id)
        {
            TripId = trip_id;

            using (var ctx = new DctsEntities())
            {
                trip = ctx.Trips.Find(TripId);
                days = ctx.TripDays.Include("Schedules").Where(o => o.trip_id == TripId).OrderBy(o => o.day).ToList();
                dayLocations = ctx.DayLocations.Include("TripDay").Include("ComboLocation").Where(o => o.trip_id == TripId).OrderBy(o => o.TripDay.day).ThenBy(o => o.position).ToList();
                ticketList = trip.Tickets.ToList();
                
                
                var locationIds = new List<int>();
                locationIds.AddRange(ticketList.Select(o => o.from_location_id).ToArray());
                locationIds.AddRange(ticketList.Select(o => o.to_location_id).ToArray());
                locationIds = locationIds.Where(o => o > 0).ToList();

                ticketLocations = ctx.ComboLocations.Where(o => locationIds.Contains(o.id)).ToList();

                var supplierIds = ticketList.Select(o => o.supplier_id).ToArray();
                supplierList = ctx.Suppliers.Where(o => supplierIds.Contains(o.id)).ToList();

                customerList = trip.TripCustomers.Select(o => o.Customer).ToList();
            }

            filledTemplates = new List<WordprocessingDocument>();
            filledTemplateStreams = new List<MemoryStream>();
        }



        //导出word
        public bool ExportWord()
        {
            var sources = new List<WordprocessingDocument>();

            using (var db = new DctsEntities())
            {
                // 准备模板
                Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict = new Dictionary<ComboLocationEnum, WordprocessingDocument>();
                ComboLocationEnum[] templateTypes = { ComboLocationEnum.TripSummary, ComboLocationEnum.DaySummary, ComboLocationEnum.Flight, ComboLocationEnum.Train,ComboLocationEnum.Rental,
                                                    ComboLocationEnum.DeepOnline, ComboLocationEnum.FlightList, ComboLocationEnum.HotelList, ComboLocationEnum.RentalList,
                                                    ComboLocationEnum.InsuranceList, ComboLocationEnum.OtherList};
                foreach (var type in templateTypes)
                {
                    var path = LocationTemplate.GetPath(type);
                    var template = WordprocessingDocument.Open(path, false);
                    tmplDict[type] = template;

                }

                var tripSumaryTemplate = tmplDict[ComboLocationEnum.TripSummary];
                var daySumaryTemplate = tmplDict[ComboLocationEnum.DaySummary];

                //cloned templates/base as template
                string layout = LocationTemplate.LayoutRelativePath;
                string tripPath = EntityPathHelper.TripWordFilePath(this.TripId);
                File.Copy(layout, tripPath, true);

                using (WordprocessingDocument document = WordprocessingDocument.Open(tripPath, true))
                {
                    // 初识国家
                    // Google使用说明
                    // 处理路书行程概要
                    HandleTripSummary(tripSumaryTemplate);
                    {
                        foreach (var day in this.days)
                        {
                            //处理每天行程概要
                            HandleDaySummary(daySumaryTemplate, day);
                            //处理每天的票务
                            HandleDayTickets(tmplDict, day);
                            var daylocations = dayLocations.Where(o => o.day_id == day.id).ToList();
                            foreach (var dl in daylocations)
                            {
                                HandleLocation(dl.ComboLocation, null);
                            }
                        }
                        //线上查询说明
                        //机票列表
                        var tickets = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Flight).ToList();
                        HanldeFlightTicketList(tmplDict, tickets);
                        //酒店列表
                        tickets = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Hotal).ToList();
                        HanldeHotelTicketList(tmplDict, tickets);
                        //租车列表
                        tickets = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Rental).ToList();
                        HanldeRentalTicketList(tmplDict, tickets);
                        //保险列表
                        tickets = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Insurance).ToList();
                        HanldeInsuranceTicketList(tmplDict, tickets);
                        //交通及活动列表
                        tickets = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Activity || o.ttype == (int)SupplierEnum.Train).ToList();
                        if (tickets != null && tickets.Count > 0)
                            HanldeOtherTicketList(tmplDict, tickets);
                    }
                    //合并文档
                    WordTemplateHelper.MergeDoc(filledTemplateStreams, document);
                    document.Save();//保存
                }

                var trip = db.Trips.Find(TripId);

                trip.word_created_at = DateTime.Now;

                foreach (var kv in tmplDict)
                {
                    kv.Value.Close();
                }
                db.SaveChanges();
            }
            return true;
        }

        // params
        //   doc: 添加行程概览到路书
        public void HandleTripSummary(WordprocessingDocument template)
        {
            string[] tripKeys = { "days" };
            string[] specKeys = { "trip_startend", "trip_dayLocations" };
            var stream = new MemoryStream();
            var tripSumary = template.Clone(stream, true) as WordprocessingDocument;

            WordTemplateHelper.ReplaceTextWithProperty<Trip>(tripSumary, tripKeys, trip);

            foreach (string key in specKeys)
            {
                string wrappedKey = "%" + key + "%";
                if (key == "trip_startend")
                {
                    WordTemplateHelper.ReplaceText(tripSumary, wrappedKey, WordTemplateHelper.DisplayStartAndEndDate(trip));
                }
            }

            var mainDoc = tripSumary.MainDocumentPart.Document;
            //look for one specific table here
            Table dayTable = mainDoc.Body.Descendants<Table>().FirstOrDefault();
            if (dayTable != null)
            {
                //Row 0 and 1 are Headers
                //Row 2 is pattern
                var rows = dayTable.Elements<TableRow>().ToList();
                if (rows.Count > 2)
                {
                    //get the Pattern row for duplication
                    var rowPattern = rows.Last();
                    //交通票务类型
                    int[] ticketTypes = { (int)SupplierEnum.Flight, (int)SupplierEnum.Activity, (int)SupplierEnum.Train, (int)SupplierEnum.Hotal };

                    //处理每日内容
                    for (int i = 0; i < this.days.Count; i++)
                    {
                        var day = days[i];
                        var date = trip.start_at.GetValueOrDefault().AddDays(day.day - 1).Date;
                        var locations = this.dayLocations.Where(o => o.day_id == day.id).ToList();
                        // 按开始时间升序排列
                        var tickets = this.ticketList.Where(o => (o.start_at.GetValueOrDefault(DateTime.Now).Date == date) && ticketTypes.Contains(o.ttype)).OrderBy(o => o.start_at).ToList();
                        //InsertRow performs a copy, so we get markup in new line ready for replacements

                        var rowCopy = rowPattern.CloneNode(true) as TableRow;

                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_day%", day.day.ToString());
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_date%", String.Format("{0:yyyyMMdd}", date));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_weekday%", String.Format("{0:ddd}", date));

                        //处理每日城市
                        //var locationCities = new List<DayLocationView>();
                        //foreach (var ticket in tickets)
                        //{ 
                        //    if( ticket.ttype == (int)SupplierEnum.Flight)
                        //    {
                        //        var from_location = ticketLocations.FirstOrDefault(o => o.id == ticket.from_location_id);
                        //        var to_location = ticketLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                        //        if (from_location!=null && to_location!=null)
                        //        {
                        //            locationCities.Add(new DayLocationView() { start_at = ticket.start_at, city = from_location.city });
                        //            locationCities.Add(new DayLocationView() { start_at = ticket.end_at, city = to_location.city });
                        //        }
                        //    }
                        //    if (ticket.ttype == (int)SupplierEnum.Activity || ticket.ttype == (int)SupplierEnum.Hotal)
                        //    {
                        //        var from_location = ticketLocations.FirstOrDefault(o => o.id == ticket.from_location_id);
                        //        if (from_location != null)
                        //        {
                        //            locationCities.Add(new DayLocationView() { start_at = ticket.start_at, city = from_location.city });
                        //        }
                        //    }
                        //    if (ticket.ttype == (int)SupplierEnum.Train)
                        //    {
                        //        locationCities.Add(new DayLocationView() { start_at = ticket.start_at, city = ticket.from_place });
                        //        locationCities.Add(new DayLocationView() { start_at = ticket.end_at, city = ticket.to_place });                                
                        //    }                            
                        //}
                        //foreach (var location in locations)
                        //{
                        //    var startAt = location.start_at.GetValueOrDefault(DateTime.Now);
                        //    locationCities.Add(new DayLocationView() { start_at = new DateTime(date.Year, date.Month, date.Day, startAt.Hour, startAt.Minute, 0), city = location.ComboLocation.city });
                        //}
                        var cell = rowCopy.Elements<TableCell>().ElementAt(2);
                        var pattern = cell.Descendants<Paragraph>().Last();
                        if (day.cities != null)
                        {

                            var cities = day.cities.Split("- ".ToArray());
                            for (int j = 0; j < cities.Count(); j++)
                            {
                                var t = cities[j];
                                if (j > 0)
                                { // 插入 ‘|’
                                    Paragraph pipe = pattern.CloneNode(true) as Paragraph;
                                    WordTemplateHelper.ReplaceText<Paragraph>(pipe, "%day_cities%", "|");
                                    pattern.InsertBeforeSelf(pipe);
                                }
                                Paragraph cloned = pattern.CloneNode(true) as Paragraph;
                                WordTemplateHelper.ReplaceText<Paragraph>(cloned, "%day_cities%", string.Format("{0}", t));
                                pattern.InsertBeforeSelf(cloned);
                            }
                            if (cities.Count() > 0)
                            {
                                pattern.Remove();
                            }
                            else
                            {
                                pattern.RemoveAllChildren();
                            }
                        }
                        else
                        {
                            pattern.RemoveAllChildren();
                        }

                        //处理每日行程简略
                        cell = rowCopy.Elements<TableCell>().ElementAt(3);
                        pattern = cell.Descendants<Paragraph>().Last();
                        var ticketTitles = tickets.Select(o => new DayLocationView() { title = o.title, start_at = o.start_at }).ToList();
                        var scenicTitles = locations.Where(o => o.ComboLocation.ltype == (int)ComboLocationEnum.Scenic).Select(o => new DayLocationView() { title = o.ComboLocation.title, start_at = o.start_at }).Distinct().ToArray();
                        ticketTitles.AddRange(scenicTitles);
                        ticketTitles = ticketTitles.OrderBy(o => o.start_at).ToList();
                        int index = 0;
                        for (int j = 0; j < ticketTitles.Count(); j++)
                        {
                            var t = ticketTitles[j];
                            if (t.title != null)
                            {
                                Paragraph cloned = pattern.CloneNode(true) as Paragraph;
                                WordTemplateHelper.ReplaceText<Paragraph>(cloned, "%day_location%", string.Format("{0}. {1}", index + 1, t.title));
                                pattern.InsertBeforeSelf(cloned);
                                index++;
                            }
                        }

                        if (index > 0)
                        {
                            pattern.Remove();
                        }
                        else
                        {
                            //如果没有活动，不能删除 pattern， 否则文档会出错。
                            pattern.RemoveAllChildren();
                        }
                        //处理每日住宿, 有的住宿可能是多晚，这里需要查找所有的住宿ticket
                        var hotelTicket = this.ticketList.Where(o => o.ttype == (int)SupplierEnum.Hotal && o.start_at < date.AddDays(1)).OrderBy(o => o.start_at).LastOrDefault();
                        var hotelReplaced = false;
                        if (hotelTicket != null)
                        {
                            // 检查入住时间是否有效
                            DateTime endAt = hotelTicket.start_at.Value.AddDays(hotelTicket.days - 1);
                            if (endAt > date)
                            {
                                var location = ticketLocations.Where(o => o.id == hotelTicket.to_location_id).FirstOrDefault();
                                if (location != null)
                                {
                                    WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_hotel%", location.title);
                                    hotelReplaced = true;
                                }
                            }
                        }

                        if (!hotelReplaced)
                        {
                            WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_hotel%", "");
                        }
                        dayTable.AppendChild(rowCopy);
                    }

                    //pattern row is at the end now, can be removed from table
                    rowPattern.Remove();

                }
                // 处理行程概要图片
                if (trip.image_path != null)
                {
                    var image = tripSumary.MainDocumentPart.ImageParts.FirstOrDefault();
                    //Image img = duplicated.Images[0];

                    string imagePath = EntityPathHelper.LocationImagePathEx(trip);
                    if (image != null && File.Exists(imagePath))
                    {
                        string relID = tripSumary.MainDocumentPart.GetIdOfPart(image);
                        //image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                        WordTemplateHelper.UpdateImage(tripSumary, relID, imagePath);
                        //不要调整尺寸，下面的内容会分页不准。
                        //WordTemplateHelper.ResizeImage(sumary, relID, imagePath);
                    }
                }
            }
            else
            {
                Console.WriteLine("\tError, couldn't find table with caption ORDER_TABLE in document");
            }
            tripSumary.Save();
            //string path = EntityPathHelper.TripWordFilePath(TripId, "summary");
            //tripSumary.SaveAs(path);
            this.filledTemplates.Add(tripSumary);
            this.filledTemplateStreams.Add(stream);

        }

        //处理每日行程
        public void HandleDaySummary(WordprocessingDocument template, TripDay day)
        {

            string[] keys = { "day" };
            string[] specKeys = { "day_date", "day_locations", "day_lweekday" };
            var stream = new MemoryStream();
            var sumary = template.Clone(stream, true) as WordprocessingDocument;
            //替换一般属性
            WordTemplateHelper.ReplaceTextWithProperty<TripDay>(sumary, keys, day);
            //替换特殊文本
            var date = this.trip.start_at.GetValueOrDefault().AddDays(day.day - 1);
            var locations = this.dayLocations.Where(o => o.day_id == day.id).ToList();


            //2017年6月1日
            WordTemplateHelper.ReplaceText(sumary, "%day_date%", WordTemplateHelper.DisplayDate(date));
            //星期四
            WordTemplateHelper.ReplaceText(sumary, "%day_lweekday%", WordTemplateHelper.DisplayLongWeekDay(date));
            //北京-阿姆斯特丹-罗马
            //string.Join("-", locations.Select(o=>o.ComboLocation.city).ToArray())
            WordTemplateHelper.ReplaceText(sumary, "%day_cities%", (day.cities != null ? day.cities : ""));

            var mainDoc = sumary.MainDocumentPart.Document;

            Table dayTable = mainDoc.Body.Descendants<Table>().LastOrDefault();
            if (dayTable != null)
            {
                //Row 0 is pattern
                var rows = dayTable.Elements<TableRow>().ToList();
                if (rows.Count > 0)
                {
                    //get the Pattern row for duplication
                    var rowPattern = rows.Last();
                    var schedules = day.Schedules.OrderBy(o => o.start_at).ToList();
                    foreach (var schedule in schedules)
                    {
                        var rowCopy = rowPattern.CloneNode(true) as TableRow;
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%schedule_start_at%", String.Format("{0:HH:mm}", schedule.start_at));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%schedule_title%", schedule.title);
                        rowPattern.InsertBeforeSelf(rowCopy);

                    }
                    rowPattern.Remove();
                }
            }
            var patternTip = mainDoc.Descendants<Paragraph>().Where(o => o.InnerText.Contains("%day_tip%")).LastOrDefault();
            if (patternTip != null && day.tips != null)
            {
                foreach (string line in day.tips.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var tipCopy = patternTip.CloneNode(true) as Paragraph;
                    WordTemplateHelper.ReplaceText<Paragraph>(tipCopy, "%day_tip%", line);
                    patternTip.InsertBeforeSelf(tipCopy);
                }
                patternTip.Remove();
            }


            // 处理每日行程图片
            if (day.image_path != null)
            {
                var image = sumary.MainDocumentPart.ImageParts.LastOrDefault();
                //Image img = duplicated.Images[0];

                string imagePath = EntityPathHelper.LocationImagePathEx(day);
                if (image != null && File.Exists(imagePath))
                {
                    string relID = sumary.MainDocumentPart.GetIdOfPart(image);
                    //image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    WordTemplateHelper.UpdateImage(sumary, relID, imagePath);
                    //不要调整尺寸，下面的内容会分页不准。
                    //WordTemplateHelper.ResizeImage(sumary, relID, imagePath);
                }
            }
            sumary.Save();

            this.filledTemplates.Add(sumary);
            this.filledTemplateStreams.Add(stream);
        }

        //处理每个地点
        public void HandleLocation(ComboLocation combolocation, Ticket ticket)
        {
            string[] locationKeys = {"nation","city", "area", "title", "local_title", "address", "local_address", "latlng", "route", "contact", "tips", "open_close_more",
                              // 景点
                                "open_at", "close_at", "ticket",
                               //住宿
                               "wifi", "parking", "reception", "kitchen",
                               // 
                               "recommended_dishes"
                            };
            string[] specKeys = { "openning_hours" };
            var wrappedKeys = locationKeys.Select(o => "%" + o + "%").ToList();

            var location = combolocation;
            var locationType = (ComboLocationEnum)location.ltype;
            string templatePath = LocationTemplate.GetPath(location);

            if (templatePath.Length == 0)
            {
                return;
            }

            using (var template = WordprocessingDocument.Open(templatePath, false))
            {

                var type = location.GetType();
                var stream = new MemoryStream();
                var duplicated = template.Clone(stream, true) as WordprocessingDocument;
                //https://stackoverflow.com/questions/19094388/openxml-replace-text-in-all-document

                if (locationType != ComboLocationEnum.Blank)
                {
                    WordTemplateHelper.ReplaceTextWithProperty<ComboLocation>(duplicated, locationKeys, location);
                    
                    foreach (string key in specKeys)
                    {
                        string wrappedKey = "%" + key + "%";

                        if (key == "openning_hours")
                        {
                            WordTemplateHelper.ReplaceText(duplicated, wrappedKey, ComboLoactionBusiness.DisplayOpeningHours(location));
                        }
                    }
                    if (location.image_path !=null && location.image_path.Length > 0)
                    {
                        var image = duplicated.MainDocumentPart.ImageParts.ElementAtOrDefault(0);
                        //Image img = duplicated.Images[0];

                        string imagePath = EntityPathHelper.LocationImagePathEx(location);
                        if (image != null && File.Exists(imagePath))
                        {
                            string relID = duplicated.MainDocumentPart.GetIdOfPart(image);
                            //image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                            WordTemplateHelper.UpdateImage(duplicated, relID, imagePath);
                            WordTemplateHelper.ResizeImage(duplicated, relID, imagePath);

                        }
                    }

                    if (locationType == ComboLocationEnum.Hotel && ticket != null)
                    {
                        // 入住时间（startenddate） 20160906-20160908， 入住晚数(days)： 2晚， 
                        // 预定姓名(customer_name)： 张三 李四， 预订房型(room)：大床房，早餐(breakfirst)：有
                        var startat = ticket.start_at.GetValueOrDefault(DateTime.Now);
                        var endat = startat.AddDays(ticket.days);
                        string startend = String.Format("{0:yyyyMMdd}-{1:yyyyMMdd}", startat, endat);

                        WordTemplateHelper.ReplaceText(duplicated, "%startenddate%", startend);
                        WordTemplateHelper.ReplaceText(duplicated, "%ticket_days%", ticket.days.ToString());
                        WordTemplateHelper.ReplaceText(duplicated, "%ticket_room%", ticket.room);
                        WordTemplateHelper.ReplaceText(duplicated, "%ticket_breakfirst%", ticket.breakfirst);
                        //如果在这个时间，这个地点只有一张票，
                        int ticketCount = this.ticketList.Where(o => o.start_at == ticket.start_at && o.to_location_id == ticket.to_location_id).Count();
                        if (ticketCount <= 1)
                        {
                            Table hotelTable = duplicated.MainDocumentPart.Document.Body.Descendants<Table>().ElementAt(1);

                            var nameRow = hotelTable.Elements<TableRow>().ElementAt(1);
                            var nameCell = nameRow.Elements<TableCell>().ElementAt(1);
                            if (nameCell != null)
                            {
                                var pattern = nameCell.Descendants<Paragraph>().Last();

                                for (var i = 0; i < customerList.Count; i++)
                                {
                                    var customer = customerList[i];
                                    var cloned = pattern.CloneNode(true) as Paragraph;
                                    WordTemplateHelper.ReplaceText<Paragraph>(cloned, "%customer_name%", customer.name);
                                    pattern.InsertBeforeSelf(cloned);
                                }
                                pattern.Remove();
                            }

                        }
                        else
                        {
                            var customer = this.customerList.FirstOrDefault(o => o.id == ticket.customer_id);
                            if (customer != null)
                            {
                                WordTemplateHelper.ReplaceText(duplicated, "%customer_name%", customer.name);
                            }
                        }
                    }
                    duplicated.Save();
                }

                this.filledTemplates.Add(duplicated);
                this.filledTemplateStreams.Add(stream);
                //document.InsertDocument(duplicated);
            }

        }

        public void HandleDayTickets(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, TripDay tripDay)
        {
            var date = this.trip.start_at.GetValueOrDefault().AddDays(tripDay.day - 1);

            var dayTickets = ticketList.Where(o => o.start_at.Value.Date == date.Date).ToList();

            var groupedTickets = dayTickets.Distinct((p, p1) => p.start_at == p1.start_at).GroupBy(o => o.ttype);

            foreach (var group in groupedTickets)
            {
                if (group.Key == (int)SupplierEnum.Flight)
                {
                    HanldeFlightTickets(tmplDict, group.ToList());

                }
                if (group.Key == (int)SupplierEnum.Hotal || group.Key == (int)SupplierEnum.Activity)
                {
                    foreach (var ticket in group.ToList())
                    {
                        var combolocation = ticketLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                        if (combolocation != null)
                        {
                            HandleLocation(combolocation, ticket);
                        }
                    }
                }
                if (group.Key == (int)SupplierEnum.Rental)
                {
                    HanldeRentalTickets(tmplDict, group.ToList());

                }
            }

        }

        // 处理每日租车
        public void HanldeRentalTickets(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.Rental];
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;

            var mainDoc = template.MainDocumentPart.Document;
            //look for one specific table here
            Table table = mainDoc.Body.Descendants<Table>().LastOrDefault();
            if (table != null)
            {
                //这里每日租车应该只有一个
                for (var i = 0; i < tickets.Count; i++)
                {
                    var ticket = tickets[i];
                    var supplier = this.supplierList.First(o => o.id == ticket.supplier_id);
                    var cloned = table.CloneNode(true) as Table;

                    if (supplier != null)
                    {
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_num%", ticket.num);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_route%", ticket.route);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_place%", ticket.from_place);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_place%", ticket.to_place);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_address%", ticket.from_address);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_address%", ticket.to_address);
                        if (ticket.from_latlng != null)
                        {
                            WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_latlng%", ticket.from_latlng.Split(" ".ToCharArray()));
                        }
                        if (ticket.from_latlng != null)
                        {
                            WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_latlng%", ticket.to_latlng.Split(" ".ToCharArray()));
                        }

                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_start_time%", String.Format("{0:yyyyMMdd HH:mm}", ticket.start_at.GetValueOrDefault()));
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_end_time%", String.Format("{0:yyyyMMdd HH:mm}", ticket.end_at.GetValueOrDefault()));
                        //替换图片
                        if (supplier.image_path != null && supplier.image_path.Length>0)
                        {
                            string file = EntityPathHelper.LocationImagePathEx(supplier);
                            if (File.Exists(file))
                            {
                                string relId = WordTemplateHelper.InsertPicture(template, file);
                                var blip = cloned.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().LastOrDefault();
                                blip.Embed.InnerText = relId;
                            }
                        }
                        
                    }

                    var customer = this.customerList.FirstOrDefault(o => o.id == ticket.customer_id);
                    if (customer != null)
                    {
                        WordTemplateHelper.ReplaceText(cloned, "%customer_name%", customer.name);
                    }

                    if (i != 0)
                    {
                        table.InsertBeforeSelf(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.TextWrapping })));
                    }
                    table.InsertBeforeSelf(cloned);
                }
                table.Remove();
            }
            //由于未知原因，以下保存的文档是可读的，template.SaveAs(path)， 但是 template.Save(); 再由 MergeDoc 产生的文档不可读。
            //所以这里新创建MemoryStream，再clone。
            template.Save();
            // 机票文档
            MemoryStream newStream = new MemoryStream();
            template.Clone(newStream);
            stream.Close();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(newStream);



        }

        // 处理每日机票
        public void HanldeFlightTickets(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.Flight];
            string[] specKeys = { "ticket_date", "tick_from_city", "tick_to_city", "tick_from_airport", "tick_to_airport", "tick_start_time", "tick_end_time" };
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            List<int> airportIds = new List<int>();

            var mainDoc = template.MainDocumentPart.Document;
            //look for one specific table here
            Table table = mainDoc.Body.Descendants<Table>().LastOrDefault();
            if (table != null)
            {
                for (var i = 0; i < tickets.Count; i++)
                {
                    var ticket = tickets[i];
                    var supplier = this.supplierList.First(o => o.id == ticket.supplier_id);
                    var cloned = table.CloneNode(true) as Table;
                    var from_location = ticketLocations.FirstOrDefault(o => o.id == ticket.from_location_id);
                    var to_location = ticketLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                    if (from_location != null && to_location != null)
                    {
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_num%", ticket.num);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_date%", WordTemplateHelper.DisplayDate(ticket.start_at.GetValueOrDefault()));
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_city%", from_location.city);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_city%", to_location.city);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_airport%", from_location.title);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_airport%", to_location.title);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_start_time%", WordTemplateHelper.DisplayTime(ticket.start_at.GetValueOrDefault()));
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_end_time%", WordTemplateHelper.DisplayTime(ticket.end_at.GetValueOrDefault()));
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_from_address%", ticket.from_address);
                        WordTemplateHelper.ReplaceText<Table>(cloned, "%ticket_to_address%", ticket.to_address);

                        //替换图片
                        if (supplier.image_path != null)
                        {
                            string file = EntityPathHelper.LocationImagePathEx(supplier);
                            if (File.Exists(file))
                            {
                                string relId = WordTemplateHelper.InsertPicture(template, file);
                                var blip = cloned.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().FirstOrDefault();
                                blip.Embed.InnerText = relId;
                            }
                        }
                        airportIds.Add(ticket.from_location_id);
                        airportIds.Add(ticket.to_location_id);
                    }
                    if (i != 0)
                    {
                        table.InsertBeforeSelf(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.TextWrapping })));
                    }
                    table.InsertBeforeSelf(cloned);
                }
                table.Remove();
            }
            //由于未知原因，以下保存的文档是可读的，template.SaveAs(path)， 但是 template.Save(); 再由 MergeDoc 产生的文档不可读。
            //所以这里新创建MemoryStream，再clone。
            template.Save();
            // 机票文档
            MemoryStream newStream = new MemoryStream();
            template.Clone(newStream);
            stream.Close();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(newStream);

            // 机场文档
            foreach (var aid in airportIds.Distinct())
            {
                var location = ticketLocations.Find(o => o.id == aid);
                if (location.word != null && File.Exists(EntityPathHelper.LocationWordPath(location)))
                {
                    var airportStream = new MemoryStream(File.ReadAllBytes(EntityPathHelper.LocationWordPath(location)));
                    this.filledTemplateStreams.Add(airportStream);
                }
            }

        }

        // 处理电子机票列表
        public void HanldeFlightTicketList(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.FlightList];
            string[] specKeys = { "ticket_date", "tick_from_city", "tick_to_city", "tick_from_airport", "tick_to_airport", "tick_start_time", "tick_end_time" };
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            var customerIds = tickets.Select(o => o.customer_id).ToList();
            var supplierIds = tickets.Select(o => o.supplier_id).ToList();
            var customers = this.customerList.Where(o => customerIds.Contains(o.id)).ToList();
            var mainDoc = template.MainDocumentPart.Document;

            var supplierNames = this.supplierList.Where(o => supplierIds.Contains(o.id)).Select(o => o.name).ToList();
            WordTemplateHelper.ReplaceText<Document>(mainDoc, "%supplier_names%", string.Join("/", supplierNames));

            Table customerTable = mainDoc.Body.Descendants<Table>().ElementAt(1);
            if (customerTable != null)
            {
                var rowPattern = customerTable.Elements<TableRow>().Last();
                if (rowPattern != null)
                {
                    for (var i = 0; i < customers.Count; i++)
                    {
                        var customer = customers[i];
                        var cloned = rowPattern.CloneNode(true) as TableRow;
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_i%", (i + 1).ToString());
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_name%", customer.name);
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_enname%", customer.enname);
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_passport%", customer.passport);
                        rowPattern.InsertBeforeSelf(cloned);
                    }
                    rowPattern.Remove();
                }
            }

            Table ticketTable = mainDoc.Body.Descendants<Table>().ElementAt(2);
            //处理机票
            if (ticketTable != null)
            {
                var rowPattern = ticketTable.Elements<TableRow>().Last();
                if (rowPattern != null)
                {
                    for (var i = 0; i < tickets.Count; i++)
                    {
                        var ticket = tickets[i];
                        var cloned = rowPattern.CloneNode(true) as TableRow;
                        var from_location = ticketLocations.FirstOrDefault(o => o.id == ticket.from_location_id);
                        var to_location = ticketLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                        if (from_location != null && to_location != null)
                        {
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_i%", (i + 1).ToString());
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_date%", string.Format("{0:MMdd}", ticket.start_at.GetValueOrDefault()));
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_num%", ticket.num);
                            //0601
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_from_city%", from_location.city);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_to_city%", to_location.city);

                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_start_time%", WordTemplateHelper.DisplayTime(ticket.start_at.GetValueOrDefault()));
                            string endAt = (ticket.start_at.Value.Date == ticket.end_at.Value.Date ? string.Format("{0:HH:mm}", ticket.end_at.Value) : string.Format("{0:HH:mm}+1", ticket.end_at.Value));
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_end_time%", endAt);

                        }

                        rowPattern.InsertBeforeSelf(cloned);
                    }
                    rowPattern.Remove();
                }
            }


            template.Save();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(stream);

        }

        // 处理酒店列表
        public void HanldeHotelTicketList(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.HotelList];
            string[] specKeys = { "ticket_date", "ticket_from_city", "ticket_to_city", "ticket_from_airport", "ticket_to_airport", "ticket_start_time", "ticket_end_time" };
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            var customerIds = tickets.Select(o => o.customer_id).ToList();
            var supplierIds = tickets.Select(o => o.supplier_id).ToList();
            var customers = this.customerList.Where(o => customerIds.Contains(o.id)).ToList();
            var mainDoc = template.MainDocumentPart.Document;


            Table ticketTable = mainDoc.Body.Descendants<Table>().LastOrDefault();
            //处理机票
            if (ticketTable != null)
            {
                var rowPattern = ticketTable.Elements<TableRow>().Last();
                if (rowPattern != null)
                {
                    for (var i = 0; i < tickets.Count; i++)
                    {
                        var ticket = tickets[i];
                        var cloned = rowPattern.CloneNode(true) as TableRow;
                        var to_location = ticketLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                        if (to_location != null)
                        {
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_i%", (i + 1).ToString());
                            //0607-0609
                            var end_at = ticket.start_at.GetValueOrDefault(DateTime.Now).AddDays(ticket.days - 1);
                            var s = String.Format("{0:MM.dd}-{1:MM.dd}", ticket.start_at, end_at);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_startenddate%", s);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_days%", ticket.days.ToString());
                            //0601
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%location_city%", to_location.city);

                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%location_title%", to_location.title);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_breakfirst%", ticket.breakfirst);

                        }

                        rowPattern.InsertBeforeSelf(cloned);
                    }
                    rowPattern.Remove();
                }
            }


            template.Save();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(stream);

        }

        // 处理租车列表
        public void HanldeRentalTicketList(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.RentalList];
            string[] specKeys = { "ticket_date", "ticket_from_city", "ticket_to_city", "ticket_from_airport", "ticket_to_airport", "ticket_start_time", "ticket_end_time" };
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            var customerIds = tickets.Select(o => o.customer_id).ToList();
            var supplierIds = tickets.Select(o => o.supplier_id).ToList();
            var customers = this.customerList.Where(o => customerIds.Contains(o.id)).ToList();
            var mainDoc = template.MainDocumentPart.Document;

            var supplierNames = this.supplierList.Where(o => supplierIds.Contains(o.id)).Select(o => o.name).ToList();
            WordTemplateHelper.ReplaceText<Document>(mainDoc, "%supplier_names%", string.Join("/", supplierNames));

            Table ticketTable = mainDoc.Body.Descendants<Table>().LastOrDefault();
            //处理租车
            if (ticketTable != null)
            {
                var rowPattern = ticketTable.Elements<TableRow>().Last();
                if (rowPattern != null)
                {
                    for (var i = 0; i < tickets.Count; i++)
                    {
                        var ticket = tickets[i];
                        var cloned = rowPattern.CloneNode(true) as TableRow;

                        var end_at = ticket.start_at.GetValueOrDefault(DateTime.Now).AddDays(ticket.days - 1);
                        //2017.06.07-06.09            
                        var s = String.Format("{0:MM.dd}~{1:MM.dd}", ticket.start_at, end_at);
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_i%", (i + 1).ToString());
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_startenddate%", s);
                        s = String.Format("{0:HH:mm}/{1:HH:mm}", ticket.start_at, end_at);
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_startendtime%", s);
                        //0601
                        s = string.Format("{0}/{1}", ticket.from_place, ticket.to_place);
                        WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_fromtoplace%", s);
                        rowPattern.InsertBeforeSelf(cloned);
                    }
                    rowPattern.Remove();
                }
            }


            template.Save();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(stream);

        }

        // 处理保险列表
        public void HanldeInsuranceTicketList(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.InsuranceList];
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            var customerIds = tickets.Select(o => o.customer_id).ToList();
            var supplierIds = tickets.Select(o => o.supplier_id).ToList();
            var customers = this.customerList.Where(o => customerIds.Contains(o.id)).ToList();
            var mainDoc = template.MainDocumentPart.Document;
            var supplier = this.supplierList.Where(o => supplierIds.Contains(o.id)).FirstOrDefault();
            if (supplier != null)
            {
                WordTemplateHelper.ReplaceText<Document>(mainDoc, "%supplier_name%", supplier.name);
                WordTemplateHelper.ReplaceText<Document>(mainDoc, "%supplier_csh%", supplier.csh);
                var ticket = tickets.FirstOrDefault();
                if (ticket != null)
                {
                    WordTemplateHelper.ReplaceText<Document>(mainDoc, "%ticket_title%", ticket.title);
                }
                Table customerTable = mainDoc.Body.Descendants<Table>().ElementAt(1);
                if (customerTable != null)
                {
                    var rowPattern = customerTable.Elements<TableRow>().Last();
                    if (rowPattern != null)
                    {
                        for (var i = 0; i < customers.Count; i++)
                        {
                            var customer = customers[i];
                            var cloned = rowPattern.CloneNode(true) as TableRow;
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_i%", (i + 1).ToString());
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_name%", customer.name);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_enname%", customer.enname);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%customer_passport%", customer.passport);
                            rowPattern.InsertBeforeSelf(cloned);
                        }
                        rowPattern.Remove();
                    }
                }

            }
            template.Save();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(stream);

        }


        // 处理活动列表
        public void HanldeOtherTicketList(Dictionary<ComboLocationEnum, WordprocessingDocument> tmplDict, List<Ticket> tickets)
        {
            WordprocessingDocument ticketTemplate = tmplDict[ComboLocationEnum.OtherList];
            var stream = new MemoryStream();
            var template = ticketTemplate.Clone(stream, true) as WordprocessingDocument;
            var customerIds = tickets.Select(o => o.customer_id).ToList();
            var supplierIds = tickets.Select(o => o.supplier_id).ToList();
            var customers = this.customerList.Where(o => customerIds.Contains(o.id)).ToList();
            var mainDoc = template.MainDocumentPart.Document;

            Table ticketTable = mainDoc.Body.Descendants<Table>().ElementAt(1);
            //处理活动
            if (ticketTable != null)
            {
                var rowPattern = ticketTable.Elements<TableRow>().Last();
                if (rowPattern != null)
                {
                    for (var i = 0; i < tickets.Count; i++)
                    {
                        var ticket = tickets[i];
                        var cloned = rowPattern.CloneNode(true) as TableRow;
                        {
                            var s = (ticket.ttype == (int)SupplierEnum.Activity ? "活动" : "火车");
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_type%", s);
                            if (ticket.ttype == (int)SupplierEnum.Train)
                            {
                                var end_at = ticket.end_at.GetValueOrDefault(DateTime.Now);
                                s = string.Format("{0:yyyy.MM.dd HHmm}-{1:HHmm}", ticket.start_at, end_at);
                            }
                            else
                            {
                                s = string.Format("{0:yyyy.MM.dd}", ticket.start_at);
                            }
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_fulldatetime%", s);
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_num%", ticket.num);
                            //0601
                            WordTemplateHelper.ReplaceText<TableRow>(cloned, "%ticket_fromto%", string.Format("{0}-{1}", ticket.from_place, ticket.to_place));

                        }

                        rowPattern.InsertBeforeSelf(cloned);
                    }
                    rowPattern.Remove();
                }
            }


            template.Save();
            this.filledTemplates.Add(template);
            this.filledTemplateStreams.Add(stream);

        }


        // params
        //   doc: 添加行程概览到路书
        public void HandleTripSummaryBak(WordprocessingDocument template)
        {
            string[] tripKeys = { "days" };
            string[] specKeys = { "trip_startend", "trip_dayLocations" };
            var stream = new MemoryStream();
            var tripSumary = template.Clone(stream, true) as WordprocessingDocument;

            WordTemplateHelper.ReplaceTextWithProperty<Trip>(tripSumary, tripKeys, trip);

            foreach (string key in specKeys)
            {
                string wrappedKey = "%" + key + "%";
                if (key == "trip_startend")
                {
                    WordTemplateHelper.ReplaceText(tripSumary, wrappedKey, WordTemplateHelper.DisplayStartAndEndDate(trip));
                }
            }

            var mainDoc = tripSumary.MainDocumentPart.Document;
            //look for one specific table here
            Table dayTable = mainDoc.Body.Descendants<Table>().FirstOrDefault();
            if (dayTable != null)
            {
                //Row 0 and 1 are Headers
                //Row 2 is pattern
                var rows = dayTable.Elements<TableRow>().ToList();
                if (rows.Count > 2)
                {
                    //get the Pattern row for duplication
                    var rowPattern = rows.Last();
                    //
                    for (int i = 0; i < this.days.Count; i++)
                    {
                        var day = days[i];
                        var date = trip.start_at.GetValueOrDefault().AddDays(day.day - 1);
                        var locations = this.dayLocations.Where(o => o.day_id == day.id).ToList();
                        //InsertRow performs a copy, so we get markup in new line ready for replacements

                        var rowCopy = rowPattern.CloneNode(true) as TableRow;

                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_day%", day.day.ToString());
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_date%", String.Format("{0:yyyyMMdd}", date));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_weekday%", String.Format("{0:ddd}", date));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_cities%", WordTemplateHelper.DisplayDayCities(locations));

                        var cell = rowCopy.Elements<TableCell>().ElementAt(3);

                        var pattern = cell.Descendants<Paragraph>().Last();
                        var titles = locations.Select(o => o.ComboLocation.title).Distinct().ToArray();
                        var patternNumPr = pattern.Descendants<NumberingProperties>().Last();
                        int newNumId = Convert.ToInt32(string.Format("{0:yyyy}{1}", DateTime.Now, i));
                        if (patternNumPr != null)
                        {
                            // copy AbstractNum Numbering as well
                            var numIn = tripSumary.MainDocumentPart.NumberingDefinitionsPart.Numbering.Descendants<NumberingInstance>().Where(o => o.NumberID.Value == patternNumPr.NumberingId.Val).FirstOrDefault();
                            var absNum = tripSumary.MainDocumentPart.NumberingDefinitionsPart.Numbering.Descendants<AbstractNum>().Where(o => o.AbstractNumberId.Value == numIn.AbstractNumId.Val).FirstOrDefault();

                            var clonedAbsNum = absNum.CloneNode(true) as AbstractNum;
                            var clonedNumIn = numIn.CloneNode(true) as NumberingInstance;
                            clonedAbsNum.AbstractNumberId = newNumId;
                            clonedNumIn.NumberID = newNumId;
                            clonedNumIn.AbstractNumId.Val = newNumId;
                            LevelOverride levelOverride = new LevelOverride() { LevelIndex = 0 };
                            levelOverride.Append(new StartOverrideNumberingValue() { Val = 1 });
                            clonedNumIn.Append(levelOverride);
                            absNum.InsertAfterSelf(clonedAbsNum);
                            numIn.InsertAfterSelf(clonedNumIn);
                        }
                        for (int j = 0; j < titles.Count(); j++)
                        {
                            var t = titles[j];
                            Paragraph cloned = null;
                            // 如果是最后一个就不用clone, 直接使用pattern
                            var isLast = (j == titles.Count() - 1);
                            if (isLast)
                            {
                                cloned = pattern;
                            }
                            else
                            {
                                cloned = pattern.CloneNode(true) as Paragraph;
                                pattern.InsertBeforeSelf(cloned);
                            }
                            var numPr = cloned.Descendants<NumberingProperties>().Last();
                            numPr.NumberingId.Val = newNumId;
                            WordTemplateHelper.ReplaceText<Paragraph>(cloned, "%day_location%", t);
                            //if (j > 0)
                            //{
                            //    pattern.InsertBeforeSelf(new Break());
                            //}
                            //pattern.InsertBeforeSelf(cloned);                            
                        }
                        // should not remove it at all, or docx mass up, malfunction
                        if (titles.Count() == 0)
                        {
                            pattern.RemoveAllChildren();
                        }

                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_hotel%", WordTemplateHelper.DisplayDayHotel(locations));

                        dayTable.AppendChild(rowCopy);
                    }

                    //pattern row is at the end now, can be removed from table
                    rowPattern.Remove();

                }
                // 处理行程概要图片

                if (trip.image_path != null)
                {
                    var image = tripSumary.MainDocumentPart.ImageParts.FirstOrDefault();
                    //Image img = duplicated.Images[0];

                    string imagePath = EntityPathHelper.LocationImagePathEx(trip);
                    if (image != null && File.Exists(imagePath))
                    {
                        string relID = tripSumary.MainDocumentPart.GetIdOfPart(image);
                        //image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                        WordTemplateHelper.UpdateImage(tripSumary, relID, imagePath);
                        //不要调整尺寸，下面的内容会分页不准。
                        //WordTemplateHelper.ResizeImage(sumary, relID, imagePath);
                    }
                }
            }
            else
            {
                Console.WriteLine("\tError, couldn't find table with caption ORDER_TABLE in document");
            }
            tripSumary.Save();
            //string path = EntityPathHelper.TripWordFilePath(TripId, "summary");
            //tripSumary.SaveAs(path);
            this.filledTemplates.Add(tripSumary);
            this.filledTemplateStreams.Add(stream);

        }

        public bool ExporScheduleWord()
        {
            //cloned templates/base as template
            string layout = LocationTemplate.ScheduleRelativePath;
            string tripPath = EntityPathHelper.TripWordFilePath(this.TripId, "schedule");
            //拷贝节点信息核对表模板文件
            File.Copy(layout, tripPath, true);

            using (WordprocessingDocument document = WordprocessingDocument.Open(tripPath, true))
            {

                // 客户信息表格
                var mainDoc = document.MainDocumentPart.Document;
                var tables = mainDoc.Body.Descendants<Table>();
                //look for one specific table here
                Table tripTable = tables.ElementAt(0);
                Table customerTable = tables.ElementAt(1);
                Table flightTable = tables.ElementAt(2);
                Table hotelTable = tables.ElementAt(3);
                Table insureTable = tables.ElementAt(4);
                Table wifiTable = tables.ElementAt(5);
                Table rentalTable = tables.ElementAt(6);
                Table activityTable = tables.ElementAt(7);

                if (tripTable != null)
                {
                    //Row 0 and 1 are Headers
                    //Row 2 is pattern
                    //客户编号	目的国家	签证国家	出行方式
                    //trip.id   trip.countries, trip.national_visa, trip.travel_style


                }
                if (customerTable != null)
                {
                    //姓名	生日	 护照号码	有效期
                    var rows = tripTable.Elements<TableRow>().ToList();

                }

                // 交通信息表格
                if (flightTable != null)
                {
                    //序号	交通 	日期 	交通编码	 出发地	 时间	抵达地	时间	 时长	行李额
                    var rows = flightTable.Elements<TableRow>().ToList();

                }
                // 住宿信息
                if (hotelTable != null)
                {
                    //序号	入住 	晚	城市	 酒店	早餐	 价格
                    var rows = hotelTable.Elements<TableRow>().ToList();

                }
                // 保险信息
                if (insureTable != null)
                {
                    //保险名称	生效日	天数
                    var rows = insureTable.Elements<TableRow>().ToList();

                }
                // WIFI信息
                if (wifiTable != null)
                {
                    //提取点 	日期	 归还点	 日期	使用天数	 生效日期	有效天数
                    var rows = wifiTable.Elements<TableRow>().ToList();

                }
                // 租车信息
                if (wifiTable != null)
                {
                    //提取点 	日期	 归还点	 日期	使用天数	 生效日期	有效天数
                    var rows = wifiTable.Elements<TableRow>().ToList();

                }
                // 活动信息
                if (activityTable != null)
                {
                    //提取点 	日期	 归还点	 日期	使用天数	 生效日期	有效天数
                    var rows = activityTable.Elements<TableRow>().ToList();

                }
                // 交付清单

            }
            return true;
        }

        ~CustomerTripWordExporterEx()
        {
            foreach (var stream in filledTemplateStreams)
            {
                stream.Close();
            }
        }

    }
}
