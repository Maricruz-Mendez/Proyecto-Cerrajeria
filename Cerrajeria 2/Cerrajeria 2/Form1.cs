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
    public partial class Empleado : Form
    {
        Validaciones V = new Validaciones();
        bool CorreoErroneo = false;
        bool ContraValida = false;
        bool cmbSeleccion = false;
        

        public Empleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            string patron = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(txtCorreo.Text, patron))
            {
                errorProvider1.Clear();
                //CorreoErroneo = true;
                CorreoErroneo = false;
            }
            else
            {
                errorProvider1.SetError(this.txtCorreo, "Escriba un correo válido");
                //CorreoErroneo = false;
                CorreoErroneo = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (V.ValidarFormulario(this, errorProvider2) == false && CorreoErroneo == false && ContraValida && cmbSeleccion) 
            {
                MessageBox.Show("Datos Asignados correctamente");
                //Se agrega a la base de datos
                LimpiarCampos();
                errorProvider2.Clear();

            }
            else
            {
                MessageBox.Show("No se agregaron los datos");
            }
        }

        //METODOS
        public void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCelular.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cmbTipoUsuario.Text = "";
            txtUsuario.Text = "";
            txtConfContra.Text = "";
            txtCorreo.Text = "";
            txtConfContra.Text = "";
            txtContra.Text = "";

        }

        private void txtConfContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text != txtConfContra.Text)
            {
                errorProvider3.SetError(this.txtConfContra,"Las contraseñas no coinciden");
                ContraValida = false;
            }
            else
            {
                errorProvider3.Clear();
                ContraValida = true;
            }
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSeleccion = true;
           
        }

        private void cmbTipoUsuario_Leave(object sender, EventArgs e)
        {
            if (cmbSeleccion)
            {
                //NADA
                errorProvider4.Clear();
            }
            else
            {
                errorProvider4.SetError(cmbTipoUsuario, "Seleccione un tipo de Usuario");
            }
        }
    }
}
