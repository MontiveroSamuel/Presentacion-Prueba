using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_Prueba
{
    public partial class CrearEmpleado : Form
    {
        public CrearEmpleado()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Al generar cambios en texto mostrar el cuadro de busqueda
            dgvBuscaEmpleado.Show();
            //Crear aux
            String sqlQuery, connectionString;
            SqlConnection connection;
            
            //Conexion a db
            connectionString = @"Server=PC-SAMUEL\SMONTIVERO;Database=Autos para 5;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);

            //Busqueda de coincidencia

            sqlQuery = "SELECT [Id_Empleado], [Id_Estado], [Nombre], [DNI], [Fecha_de_Inicio] FROM [Autos para 5].[dbo].[Empleado] WHERE [Nombre] LIKE '%"+ txtBuscador.Text +"%'";

            //Abrir conexion
            connection.Open();
            //Adaptar datos y llenar DataViewGrid
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlQuery, connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dgvBuscaEmpleado.DataSource = dt;

            //Ocultar tabla si buscador queda en blanco
            if (txtBuscador.Text == "")
            {
                dgvBuscaEmpleado.Hide();
            }

            //Cierre conexion

            connection.Close();
        }
    }
}
