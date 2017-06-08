using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
   
    public enum ComboLocationEnum
    {   // 空白页，   景点，   餐厅，  住宿，  国家， 火车，飞机（机票说明）,                    租车
        Blank = 0, Scenic = 1, Dining = 5, Hotel = 9, Country = 10, Airport=11, Flight = 16, Train = 17, Rental = 18, WIFI = 19,
        //  一封信，目录， 出行必备, Google,
        Letter = 101, Index = 102, Preparation = 103, Google = 126,
        //  线上查询说明，机票列表，酒店列表，租车列表，交通列表，活动列表，                           保险，退税
        DeepOnline = 120, AirList = 121, HotelList = 122, CarList = 123, TrainList = 125, ActivityList=127, InsuranceList = 129, TaxReturn = 181
         
    }

    // id	ltype	nation	city	area	title	local_title	img	address	local_address	latlng	route	contact	
    // open_at	close_at	open_close_more	ticket	room	dinner	wifi	parking	reception	kitchen	dishes	recommended_dishes	tips	guidance

    // 序号  类型    国家    城市    区域     中文名称 当地语言名称    图片  地址   当地语言地址 经纬度  如何抵达    联系方式 
    // 开始时间  结束时间  营业时间说明  门票  房型  早餐   WIFI 停车场  前台 厨房 菜系 推荐菜单 小贴士

    static class ComboLocationSchema
    {
        static string[] enColumns = {"id",	"ltype", "nation",	"city",	"area",	"title", "local_title",
                                    "img",	"address",	"local_address",	"latlng",	"route",	"contact"};
        public static Dictionary<string, string> ColumnNameDictionary = new Dictionary<string, string>() { 
          { "id", "id"},            {"序号", "id" },
          { "ltype", "ltype"},    {"类型", "ltype" },
          { "nation", "nation"},    {"国家", "nation" },
          { "city", "city"},        {"城市", "city" },
          { "area", "area"},         {"区域", "area" },
          { "title", "title"},      {"中文名称", "title" },
          { "local_title", "local_title"}, {"当地语言名称", "local_title" },
          { "img", "img"},          {"图片", "img" },
          { "address", "address"},  {"地址", "address" },
          { "local_address", "local_address"}, {"当地语言地址", "local_address" },
          { "latlng", "latlng"},    {"经纬度", "latlng" },
          { "route", "route"},      {"如何抵达", "route" },
          { "contact", "contact"},  {"联系方式", "contact" },
          { "open_at", "open_at"},  {"开始时间", "open_at" },
          { "close_at", "close_at"}, {"结束时间", "close_at" },
          { "open_close_more", "open_close_more"}, {"营业时间说明", "open_close_more" },
          { "ticket", "ticket"},    {"门票", "ticket" },
          { "room", "room"},        {"房型", "room" },
          { "dinner", "dinner"},    {"早餐", "dinner" },
          { "wifi", "wifi"},        {"WIFI", "wifi" },
          { "parking", "parking"},  {"停车场", "parking" },
          { "reception", "reception"}, {"前台", "reception" },
          { "kitchen", "kitchen"},  {"厨房", "kitchen" },
          { "dishes", "dishes"},    {"菜系", "dishes" },
          { "recommended_dishes", "recommended_dishes"}, {"推荐菜单", "recommended_dishes" },
          { "tips", "tips"},        {"小贴士", "tips" },
          { "guidance", "guidance"}, {"游玩方式", "guidance" },          
          { "word", "word"}, {"Word模板", "word" },          
         
    
        };
        public static Dictionary<string, string> diningColumnNameDictionary = new Dictionary<string, string>() { 
          { "id", "id"},            {"序号", "id" },
          { "ltype", "ltype"},    {"类型", "ltype" },
          { "nation", "nation"},    {"国家", "nation" },
          { "city", "city"},        {"城市", "city" },
          { "area", "area"},         {"区域", "area" },
          { "title", "title"},      {"餐厅名称", "title" },
          { "local_title", "local_title"}, {"当地语言名称", "local_title" },
          { "img", "img"},          {"图片", "img" },
          { "address", "address"},  {"地址", "address" },
          { "local_address", "local_address"}, {"当地语言地址", "local_address" },
          { "latlng", "latlng"},    {"经纬度", "latlng" },
          { "route", "route"},      {"如何抵达(周围特征)", "route" },
          { "contact", "contact"},  {"联系方式", "contact" },
          { "open_at", "open_at"},  {"开始时间", "open_at" },
          { "close_at", "close_at"}, {"结束时间", "close_at" },
          { "open_close_more", "open_close_more"}, {"营业时间", "open_close_more" },
          { "ticket", "ticket"},    {"门票", "ticket" },
          { "room", "room"},        {"房型", "room" },
          { "dinner", "dinner"},    {"早餐", "dinner" },
          { "wifi", "wifi"},        {"WIFI", "wifi" },
          { "parking", "parking"},  {"停车场", "parking" },
          { "reception", "reception"}, {"前台", "reception" },
          { "kitchen", "kitchen"},  {"厨房", "kitchen" },
          { "dishes", "dishes"},    {"菜系", "dishes" },
          { "recommended_dishes", "recommended_dishes"}, {"推荐菜单", "recommended_dishes" },
          { "tips", "tips"},        {"深度Tlps", "tips" },
          { "guidance", "guidance"}, {"游玩方式", "guidance" },          
         
    
        };
        public static Dictionary<string, string> hotelColumnNameDictionary = new Dictionary<string, string>() { 
          { "id", "id"},            {"序号", "id" },
          { "ltype", "ltype"},    {"类型", "ltype" },
          { "nation", "nation"},    {"国家", "nation" },
          { "city", "city"},        {"城市", "city" },      
          { "title", "title"},      {"中文名称", "title" },
          { "local_title", "local_title"}, {"英文名称", "local_title" },
          { "img", "img"},          {"图片", "img" },
          { "room", "room"},        {"预定房型", "room" },
          { "dinner", "dinner"},    {"早餐", "dinner" },
          { "latlng", "latlng"},    {"经纬度", "latlng" },
          { "address", "address"},  {"地址", "address" },
          { "route", "route"},      {"如何抵达", "route" },
          { "contact", "contact"},  {"联系方式", "contact" },
          { "wifi", "wifi"},        {"WIFI", "wifi" },
          { "parking", "parking"},  {"停车位", "parking" },
          { "reception", "reception"}, {"前台", "reception" },
          { "kitchen", "kitchen"},  {"厨房", "kitchen" },
          { "tips", "tips"},        {"深度TIPS", "tips" },
    
        };
        public static Dictionary<string, string> ScenicCnNameDictionary = new Dictionary<string, string>() { 
          { "id", "序号"},    
          { "ltype", "类型"},    
          { "nation", "国家"},  
          { "city", "城市"},   
          { "area", "区域"},   
          { "title", "中文名称"},
          { "local_title", "当地语言名称"}, 
          { "img", "图片"},         
          { "address", "地址"}, 
          { "local_address", "当地语言地址"}, 
          { "latlng", "经纬度"},  
          { "route", "如何抵达"}, 
          { "contact", "联系方式"},
          { "open_at", "开始时间"},
          { "close_at", "结束时间"},
          { "open_close_more", "营业时间说明"}, 
          { "ticket", "门票"},  
          { "room", "房型"},    
          { "dinner", "早餐"},  
          { "wifi", "WIFI"},    
          { "parking", "停车场"},
          { "reception", "前台"}, 
          { "kitchen", "厨房"},  
          { "dishes", "菜系"},   
          { "recommended_dishes", "推荐菜单"}, 
          { "tips", "小贴士"},  
          { "guidance", "游玩方式"}
        };

        public static Dictionary<string, string> LocationCnNameDictionary = new Dictionary<string, string>() { 
          { "id", "序号"},    
          { "ltype", "类型"},    
          { "nation", "国家"},  
          { "city", "城市"},   
          { "area", "区域"},   
          { "title", "中文名称"},
          { "local_title", "当地语言名称"}, 
          { "img", "图片"},         
          { "address", "地址"}, 
          { "local_address", "当地语言地址"}, 
          { "latlng", "经纬度"},  
          { "route", "如何抵达"}, 
          { "contact", "联系方式"},
          { "open_at", "开始时间"},
          { "close_at", "结束时间"},
          { "open_close_more", "营业时间说明"}, 
          { "ticket", "门票"},  
          { "room", "房型"},    
          { "dinner", "早餐"},  
          { "wifi", "WIFI"},    
          { "parking", "停车场"},
          { "reception", "前台"}, 
          { "kitchen", "厨房"},  
          { "dishes", "菜系"},   
          { "recommended_dishes", "推荐菜单"}, 
          { "tips", "小贴士"},  
          { "guidance", "游玩方式"}
        };
        public static Dictionary<string, string> CustomterCnNameDictionary = new Dictionary<string, string>() { 
          { "id", "序号"},    
          { "name", "名字"},    
          { "gender", "性别"},   
          { "birthday", "生日"},   
          { "enname", "英文姓名"},
          { "passport", "护照号码"}
         
        };

        static void LocationColumnInfo()
        {

        }
    }
}
