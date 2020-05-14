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
        Conexion miConexion = new Conexion();
        bool CorreoErroneo = false;
        bool ContraValida = false;

        

        public Empleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }



        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            if (V.ValidarFormulario(this, errorProvider2) == false && CorreoErroneo == false && ContraValida) 
            {
                //MessageBox.Show("Datos Asignados correctamente");
                //Se agrega a la base de datos
                MessageBox.Show(miConexion.RegistrarEmpleado(txtUsuario.Text, txtContra.Text, txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, dtmNacimiento.Text, hoy.ToShortDateString(), txtDireccion.Text, int.Parse(txtTelefono.Text)));

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
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtUsuario.Text = "";
            txtConfContra.Text = "";
            txtConfContra.Text = "";
            txtContra.Text = "";
            txtApellidoM.Text = "";
            txtApellidoP.Text = "";

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

        private void txtApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }

        private void txtApellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }
    }
}
