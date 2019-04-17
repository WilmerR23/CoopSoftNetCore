using CoopSoftNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopSoftNetCore.Helper
{
    public class DataHelper
    {
        public static List<UsuarioEntity> LoadData(string page)
        {
            List<UsuarioEntity> Usuarios = new List<UsuarioEntity>();

            for (int a = 0; a < 25; a++)
            {
                Usuarios.Add(new UsuarioEntity()
                {
                    NombreUsuario = $"Kwil0{a + 1} - {page}",
                    Email = "kwilram23@gmail.com"
                });
            }
            return Usuarios;
        }
    }
}
