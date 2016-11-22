using Facebook2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Facebook2.Controllers
{
    public class DatosController : Controller
    {
        // GET: Datos
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationDbContext db = new ApplicationDbContext();
        usuario u = new usuario();
        public JsonResult Datos(Publicacion json)
        {
            Publicacion a = new Publicacion();

            u = db.usuarios.Find(json.User);
            json.User = u.Name;
            json.userimg = u.Picture;

            db.Publicacions.Add(json);
            db.SaveChanges();

            return Json(JsonConvert.SerializeObject(db.Publicacions, Formatting.Indented));
        }


        public JsonResult Compartir()
        {
            return Json(JsonConvert.SerializeObject(db.Publicacions, Formatting.Indented));
        }


        public JsonResult Like(Publicacion json)
        {
            Publicacion a = db.Publicacions.Find(json.publicationId);
            a.Like = a.Like + 1;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();

            return Json(JsonConvert.SerializeObject(db.Publicacions, Formatting.Indented));



        }

        public JsonResult Comentar(comments json)
        {
            u = db.usuarios.Find(json.user);
            json.user = u.Name;
            json.userimg = u.Picture;
            db.comments.Add(json);
            db.SaveChanges();

            Publicacion a = db.Publicacions.Find(json.Publication_id);
            a.comments = a.comments + 1;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();

            return Json(JsonConvert.SerializeObject(db.comments, Formatting.Indented));


        }


        public JsonResult Comentarios()
        {

            return Json(JsonConvert.SerializeObject(db.comments, Formatting.Indented));


        }
    }
}