using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facebook2.Models
{
    public class Usuarios_Data
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        usuario usuario = new usuario();

        public void Guardar(string Id, string Name, string Picture)
        {
           
            usuario.Name = Name;
            usuario.id = Id;
            usuario.Picture = Picture;
           db.usuarios.Add(usuario);
           db.SaveChanges();
        }


    }
}