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
    public partial class PruebaConexion : Form
    {
        public PruebaConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Server=PC-SAMUEL\SMONTIVERO;Database=DiariosPrueba;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT TOP 5 [NroCliente], [ApellidoNombre],[Credito] FROM[DiariosPrueba].[dbo].[Clientes]";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + "\n";
            }
            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
