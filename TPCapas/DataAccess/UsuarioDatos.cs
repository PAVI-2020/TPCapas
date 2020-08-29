using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPCapas.Clases;

namespace TPCapas.DataAccess {
	public class UsuarioDatos {
		const string TABLA = "Usuarios";

		public Usuario GetUsuario(string nombre) {
			Usuario ret = new Usuario();

			string columnas = "id_usuario, usuario, password, email, estado";
			string condiciones = "borrado = 0";

			Datos datos = new Datos();
			DataTable tablas = datos.ConsultarTabla(columnas, TABLA, condiciones);

			if (tablas.Rows.Count <= 0)
				return null;

			return ConvertirUsuario(tablas.Rows[0]);
		}

		private Usuario ConvertirUsuario(DataRow input) {
			Usuario res = new Usuario {
				IdUsuario = int.Parse(input["id_usuario"].ToString()),
				N_usuario = input["usuario"].ToString(),
				Mail = input["email"].ToString(),
				Estado = input["estado"].ToString(),
				Password = input["password"].ToString()
			};

			return res;
		}
	}
}
