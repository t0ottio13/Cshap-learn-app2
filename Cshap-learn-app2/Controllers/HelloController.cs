using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cshap_learn_app2.Controllers
{
    public class HelloController : Controller
    {
        //public List<string> list;

        //public HelloController()
        //{
        //    list = new List<string>();
        //    list.Add("japan");
        //    list.Add("USA");
        //    list.Add("UK");
        //}

        //[Route("Hello/{id?}/{name?}")]

        //// GET: /<controller>/
        ///
        //[HttpGet("Hello/{id?}/{name?}")]
        //public IActionResult Index(int id, string name)
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["message"] = "※テーブルの表示";
            ViewData["header"] = new string[] { "id", "name", "mail" };
            ViewData["data"] = new string[][]
            {
                new string[]{"1","Taro","taro@yamada"},
                new string[]{"2","Hanako","hanako@flower"},
                new string[]{"3","Sachiko", "sachiko@happy" }
            };
            return View();

            //ViewData["message"] = "※セッションにIDとNameを保存しました。";
            //MyData ob = new MyData(id, name);
            //HttpContext.Session.Set("object", ObjectToBytes(ob));
            //ViewData["object"] = ob;

            //HttpContext.Session.SetInt32("id", id);
            //HttpContext.Session.SetString("name", name);

            //ViewData["message"] = "id = " + id + ", name = " + name;
            //ViewData["message"] = "Select item:";
            //ViewData["list"] =  new string[] {};
            //ViewData["listdata"] = list;

            //ViewData["Message"] = "Input your name";
            //ViewData["name"] = "";
            //ViewData["mail"] = "";
            //ViewData["tel"] = "";
            return View();
        }

        [HttpGet]
        public IActionResult Other()
        {
            //ViewData["id"] = HttpContext.Session.GetInt32("id");
            //ViewData["name"] = HttpContext.Session.GetString("name");
            ViewData["message"] = "保存されたセッションの値を表示します。";
            byte[] ob = HttpContext.Session.Get("object");
            ViewData["object"] = BytesToObject(ob);


            return View("Index");
        }

        // convert object to byte[].
        private byte[] ObjectToBytes(Object ob)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ob);
            return ms.ToArray();
        }

        // convert byte[] to Object.
        private Object BytesToObject(byte[] arr)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arr, 0, arr.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return (Object)bf.Deserialize(ms);

        }


        //public IActionResult Form()
        //{
        //    //string[] res = (string[])Request.Form["list"];
        //    //string msg = "※";
        //    //foreach(var item in res)
        //    //{
        //    //    msg += "「" + item + "」";
        //    //}

        //    //ViewData["message"] = msg + " selected.";
        //    //ViewData["list"] = Request.Form["list"];
        //    //ViewData["listdata"] = list;

        //    //ViewData["message"] = '"' + Request.Form["list"] + '"'
        //    //    + " selected.";
        //    //ViewData["list"] = Request.Form["list"];
        //    //ViewData["listdata"] = list;

        //    //ViewData["Message"] = Request.Form["msg"];
        //    //return View("Index");

        //    //ViewData["name"] = Request.Form["name"];
        //    //ViewData["mail"] = Request.Form["mail"];
        //    //ViewData["tel"] = Request.Form["tel"];
        //    //ViewData["Message"] = ViewData["name"] + "," +
        //    //    ViewData["mail"] + "," + ViewData["tel"];
        //    return View("Index");
        //}
    }

    [Serializable]
    class MyData
    {
        public int Id = 0;
        public string Name = "";

        public MyData(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "<" + Id + ":" + Name + ">";
        }
    }
}
