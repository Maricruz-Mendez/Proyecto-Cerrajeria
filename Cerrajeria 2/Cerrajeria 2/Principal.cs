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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            Conexion c = new Conexion();
        }
        
        private void btnRegistros_Click(object sender, EventArgs e)
        {
            btnCliente.Visible = true;
            btnEmpleado.Visible = true;
            DesactivarConsultas();
        }

        private void btnTrabajos_Click(object sender, EventArgs e)
        {
            btnCliente.Visible = false;
            btnEmpleado.Visible = false;
            DesactivarConsultas();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            btnCliente.Visible = false;
            btnEmpleado.Visible = false;
            DesactivarConsultas();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            btnCliente.Visible = false;
            btnEmpleado.Visible = false;
            btnConsulta.Visible = true;
            btnReporte.Visible = true;
        }
       
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            btnCCliente.Visible = true;
            btnCFecha.Visible = true;
            btnCTrabajo.Visible = true;
            DesactivarR();
        }
       
        private void btnReporte_Click(object sender, EventArgs e)
        {
            btnLLave.Visible = true;
            btnMes.Visible = true;
            btnSemana.Visible = true;
            DesactivarC();
        }

        #region METODOS 
        //METODOS DE ACTIVACION DE PESTÑAS DE CONSULTAS
        public void DesactivarConsultas()
        {
            btnConsulta.Visible = false;
            btnReporte.Visible = false;
            DesactivarC();
            DesactivarR();

        }

        public void DesactivarR()
        {
            btnLLave.Visible = false;
            btnSemana.Visible = false;
            btnMes.Visible = false;
        }

        public void DesactivarC()
        {
            btnCCliente.Visible = false;
            btnCTrabajo.Visible = false;
            btnCFecha.Visible = false;
        }

        #endregion

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Cliente FormularioCliente = new Cliente();
            FormularioCliente.Show();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            Empleado FormularioEmpleado = new Empleado();
            FormularioEmpleado.Show();
        }
    }


}
