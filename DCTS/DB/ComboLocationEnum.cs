using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    enum ComboLocationEnum { Blank = 0,  Scenic = 1, Dining = 5, Hotel = 9 }
    

    // id	ltype	nation	city	area	title	local_title	img	address	local_address	latlng	route	contact	
    // open_at	close_at	open_close_more	ticket	room	dinner	wifi	parking	reception	kitchen	dishes	recommended_dishes	tips	guidance
            
    // 序号  类型    国家    城市    区域     中文名称 当地语言名称    图片  地址   当地语言地址 经纬度  如何抵达    联系方式 
    // 开始时间  结束时间  营业时间说明  门票  房型  早餐   WIFI 停车场  前台 厨房 菜系 推荐菜单 小贴士

    static class ComboLocationSchema
    {
        static string[]  enColumns = {"id",	"ltype", "nation",	"city",	"area",	"title", "local_title",
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
        static void LocationColumnInfo()
        {

        }
    }
}
