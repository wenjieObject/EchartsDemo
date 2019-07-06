using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EchartsDemo.Controllers
{
    public class EchartsController : Controller
    {
        //注入的方式获取连接字符串 注释
        //private readonly ConnectionStrings _connectionStrings;

        //public EchartsController(IOptions<ConnectionStrings> connectionStrings)
        //{
        //    _connectionStrings = connectionStrings.Value;
        //}

        public IActionResult Index()
        {
            //sqlHelper.constr = _connectionStrings.DbConn; //注入的方式获取连接字符串
            var sqlStr = " select  * from bdta_material where rownum<100 ";
            var count= sqlHelper.GetDataTable(sqlStr);
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public JsonResult GetTestData()
        {
            List<TestData> tmps = new List<TestData>();

            for(int i = 0; i < 10; i++)
            {
                TestData tmp = new TestData();
                tmp.dateTime = i.ToString();
                tmp.valueOfTime = (2000 + i)*i;
                tmps.Add(tmp);
            }

            return Json(tmps);

        }

        
        public ActionResult GetData(int limit, int offset)
        {
            var data = new List<object>(){new { ID=1, Name="Arbet", Sex="男"},
                new { ID= 2, Name="Arbet1", Sex="女" },
                new {ID=3, Name="Arbet2",Sex="男" },
                new {ID=4, Name="Arbet3",Sex="女" },
                new {ID=5, Name="Arbet4",Sex="男" },
                new {ID=6, Name="Arbet5",Sex="男" },
                new {ID=7, Name="Arbet6",Sex="女" },
                new {ID=8, Name="Arbet7",Sex="男" },
                new { ID=9, Name="Arbet1", Sex="女" },
                new {ID=10, Name="Arbet2",Sex="男" },
                new {ID=11, Name="Arbet3",Sex="女" },
                new {ID=12, Name="Arbet4",Sex="男" },
                new {ID=13, Name="Arbet5",Sex="男" },
                new {ID=14, Name="Arbet6",Sex="女" },
                new {ID=15, Name="Arbet7",Sex="男" }
            };
            var total = data.Count;
            var rows = data.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows });
        }

    }


    public class TestData
    {
        public string dateTime { get; set; }

        public decimal valueOfTime { get; set; }
    }
        


}