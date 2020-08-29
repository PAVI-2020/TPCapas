using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPCapas.BusinessLayer;
using TPCapas.Clases;

namespace TPCapas {
	public partial class frmLogin : Form {
		public frmLogin() {
			InitializeComponent();
		}

		private void btnAceptar_Click(object sender, EventArgs e) {
			string username = txtUsuario.Text;
			string pass = txtContra.Text;

			if (!SanitizarInputs())
				return;

			UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
			Usuario u = usuarioBusiness.ValidarUsuario(username, pass);

			if (u == null)
				MessageBox.Show("ERROR", "Usuario o contraseña invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else {
				MessageBox.Show("OK", "Login validado", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
			}
		}

		private bool SanitizarInputs() {
			if (txtUsuario.Text == "") {
				MessageBox.Show("Input no valido", "Inserte su usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			} else if (txtContra.Text == "") {
				MessageBox.Show("Input no valido", "Inserte su contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void btnCancelar_Click(object sender, EventArgs e) {
			MessageBox.Show("OK", "Bye", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Close();
		}
	}
}
