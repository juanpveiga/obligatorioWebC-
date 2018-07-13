using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Usuario
    {
        private string nombreUsuario;
        private string password;
        private string perfil;

        public string NombreUsuario
        {
            get
            {
                return this.nombreUsuario;
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
        }
        public string Perfil
        {
            get
            {
                return this.perfil;
            }
        }
        public Usuario(string nombre, string pass,
            string perfil)
        {
            this.nombreUsuario = nombre;
            this.password = pass;
            this.perfil = perfil;
        }
    }
}

