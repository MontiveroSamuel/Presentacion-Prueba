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
    public partial class Nuevo_Empleado : Form
    {
        public Nuevo_Empleado()
        {
            InitializeComponent();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //Crear aux
            String sqlQuery, connectionString;
            SqlConnection connection;

            //Conexion a db
            connectionString = @"Server=PC-SAMUEL\SMONTIVERO;Database=Autos para 5;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);

            //Busqueda de coincidencia

            sqlQuery = "SELECT [Id_Empleado], [Nombre], [Direccion], [Barrio].[Descripcion] AS Barrio, [Ciudad].[Descripcion] AS Ciudad, [Provincia].[Descripcion] AS Provincia, Telefonos_Empleados.Telefono AS Telefono, [DNI], [Empleado].[Fecha_de_Inicio], [Empleado].[Observaciones]" +
                    "FROM[Autos para 5].[dbo].[Empleado] JOIN [Autos para 5].[dbo].[Ubicacion_Empleados] ON [Empleado].[Id_UbicacionEmpleados] = [Ubicacion_Empleados].[Id_UbicacionEmpleados] " +
                    "JOIN[Autos para 5].[dbo].[Barrio] ON [Ubicacion_Empleados].[Id_Barrio] = [Barrio].[Id_Barrio] JOIN [Autos para 5].[dbo].[Ciudad] ON [Barrio].[Id_Ciudad] = [Ciudad].[Id_Ciudad] " +
                    "JOIN[Autos para 5].[dbo].[Provincia] ON [Ciudad].[Id_Ciudad] = [Provincia].[Id_Provincia] JOIN [Autos para 5].[dbo].[Telefonos_Empleados] ON [Empleado].[Id_TelefEmpleados] = [Telefonos_Empleados].[Id_TelefEmpleados] WHERE [Nombre] LIKE '%" + txtBuscador.Text + "%' AND [Empleado].[Id_Estado] = 1";


            //Abrir conexion
            connection.Open();
            //Adaptar datos y crear dataTable que va a llenar la DataViewGrid
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlQuery, connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            //Mandar datos a DVG
            dgvBuscaEmpleado.DataSource = dt;


            //Cerrar conexion

            connection.Close();
        
    }

        private void dgvBuscaEmpleado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
