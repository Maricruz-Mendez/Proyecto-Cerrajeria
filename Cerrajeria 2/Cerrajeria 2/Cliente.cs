using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cerrajeria_2
{  
    public partial class Cliente : Form
    {

        Validaciones V = new Validaciones();
        bool CorreoErroneo = false;
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
            if (V.ValidarFormulario(this, errorProvider2) == false && CorreoErroneo == false)
            {
                MessageBox.Show("Datos Asignados correctamente");
                //Se agrega a la base de datos
                LimpiarCampos();
                errorProvider2.Clear();
                LimpiarCampos();

            }
            else
            {
                MessageBox.Show("No se agregaron los datos");
            }


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


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            string patron = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(txtCorreo.Text, patron))
            {
                errorProvider1.Clear();
                CorreoErroneo = false;
            }
            else
            {
                errorProvider1.SetError(this.txtCorreo, "Escriba un correo válido");
                CorreoErroneo = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }
    }
}
