using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace Cerrajeria_2
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=34.71.252.51;Initial Catalog=Cerrajeria_Hns;Persist Security Info=True;User ID=sqlserver;Password=J@ce17100199");
                cn.Open();
                MessageBox.Show("Conectado");

            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public string RegistrarEmpleado(string NomUsuario, string Contrasena, string Nombre, string Apellido_P, string Apellido_M, string FNacimiento, string F_Registro, string Direccion,int Telefono)
        {
            string salida = "Se agregaron los datos";

            try
            {
                //  cmd = new SqlCommand("insert into Empleados (NomUsuario,Contrasena,Nombre,Apellido_P,Apellido_M,F_Nacimiento,F_Registro,Direccion,Telefono) values ('" + NomUsuario + "','" + Contrasena + "','" + Nombre + "','" + Apellido_P + "','" + Apellido_M + "','" + FNacimiento + "','" + F_Registro + "','" + Direccion + "'," + Telefono + ")",cn);
                //cmd = new SqlCommand("insert into Empleados (NomUsuario,Contrasena,Nombre,Apellido_P,Apellido_M,F_Nacimiento,F_Registro,Direccion,Telefono) values ('" + NomUsuario + "','" + "convert(varbinary,"+ Contrasena.ToString()+")" + "','" + Nombre + "','" + Apellido_P + "','" + Apellido_M + "','" + FNacimiento + "','" + F_Registro + "','" + Direccion + "'," + Telefono + ")", cn);
                //cmd = new SqlCommand("insert into Empleados (NomUsuario,Contrasena,Nombre,Apellido_P,Apellido_M,F_Nacimiento,F_Registro,Direccion,Telefono) values ("+);
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                salida= "No se insertaron los datos: "+e.ToString();
            }

            return salida;
        }

       public static string GETSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("0:x2", stream[i]);

            }
            return sb.ToString();
        }


    }
}
