using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_kafedra
{
    /// <summary>
    /// Логика взаимодействия для TFaculties.xaml
    /// </summary>
    public partial class TFaculties : Window
    {
        private string connectionString = "Server=DESKTOP-BK1T0PD\\SQLEXPRESS;Database=21.102-8_Kafedra;Trusted_Connection=True;";
        public TFaculties()
        {
            InitializeComponent();
            LoadFaculties();
        }

        private void LoadFaculties()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Faculties";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable("Faculties");
                    adapter.Fill(dataTable);

                    DataGrid.ItemsSource = dataTable.DefaultView;
                    adapter.Update(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
