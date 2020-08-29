using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCapas.Clases;
using TPCapas.DataAccess;

namespace TPCapas.BusinessLayer {
	public class UsuarioBusiness {
		
		public Usuario ValidarUsuario(string nombre, string pass) {
			UsuarioDatos usuarioDatos = new UsuarioDatos();
			Usuario ret = usuarioDatos.GetUsuario(nombre);

			return (ret != null && ret.Password == pass) ? ret : null;
		}
	}
}
