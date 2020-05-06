using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerrajeria_2
{  
    public partial class Cliente : Form
    {

        Validaciones V = new Validaciones();
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        public void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtCorreo.Text = "";
            txtDomicilio.Text = "";
            txtRazon.Text = "";
            txtRFC.Text = "";
            txtTelefono.Text = "";
        }

        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }
    }
}
