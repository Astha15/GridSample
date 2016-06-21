using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridSample.Controllers;
using GridSample.Models;
using System.Web.Script.Serialization;
namespace GridSample.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetResult()
        {
            AlertsEntities4 db = new AlertsEntities4();
                
                 var res1 = (from ad in db.AlertDetails
                       join rs in db.ResolutionTables on ad.AlertGuid equals rs.AlertGuid
                       where rs.ResolutionState == 0
                       select new
                       {
                           ad.AlertGuid,
                           ad.AlertName,
                           ad.AlertDescription,
                           ad.Severity,
                           ad.Priority,
                           ad.Category,
                           ad.RaisedDateTime,
                           ad.RepeatCount
                       }
                       );
                var res2 = (from ad in db.AlertDetails
                         join rs in db.ResolutionTables on ad.AlertGuid equals rs.AlertGuid
                         where rs.ResolutionState == 255
                         select new
                         {
                             ad.AlertGuid,
                             ad.AlertName,
                             ad.AlertDescription,
                             ad.Severity,
                             ad.Priority,
                             ad.Category,
                             ad.RaisedDateTime,
                             ad.RepeatCount
                         }
                        );
            var res = (from ad in res1
                       where !res2.Any(r => r.AlertGuid == ad.AlertGuid)
                       select new
                       {
                           ad.AlertName,
                           ad.AlertDescription,
                           ad.Severity,
                           ad.Priority,
                           ad.Category,
                           ad.RaisedDateTime,
                           ad.RepeatCount
                       });
            return new JsonResult { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        [HttpPost]
        public bool SendMail(string recipient)
        {
            var result = GetResult();
            string body = new JavaScriptSerializer().Serialize(result.Data);
            Mailing mail = new Mailing("username", "password");
            var res = mail.SendMail(recipient, body);
            return res;
        }
    }
}