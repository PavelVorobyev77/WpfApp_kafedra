using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp_kafedra
{
    public partial class SearchTeachersForm : Window
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public SearchTeachersForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            FillComboBoxes();
            InitializeDataGrid();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=DESKTOP-BK1T0PD\\SQLEXPRESS;Initial Catalog=21.102-8_Kafedra;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            dataTable = new DataTable();
        }

        private void FillComboBoxes()
        {
            // Заполните cmbKafedra данными из вашей базы данных
            string query = "SELECT DISTINCT KafedraID FROM Teachers";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbKafedra.Items.Add(reader["KafedraID"].ToString());
            }
            connection.Close();

            string positionQuery = "SELECT DISTINCT Position FROM Teachers";
            SqlCommand positionCmd = new SqlCommand(positionQuery, connection);
            connection.Open();
            SqlDataReader positionReader = positionCmd.ExecuteReader();
            while (positionReader.Read())
            {
                cmbPosition.Items.Add(positionReader["Position"].ToString());
            }
            connection.Close();

            string AcRankQuery = "SELECT DISTINCT AcademicRank FROM Teachers";
            SqlCommand AcRankCmd = new SqlCommand(AcRankQuery, connection);
            connection.Open();
            SqlDataReader AcRankReader = AcRankCmd.ExecuteReader();
            while (AcRankReader.Read())
            {
                cmbAcademicRank.Items.Add(AcRankReader["AcademicRank"].ToString());
            }
            connection.Close();

            string EmpRateQuery = "SELECT DISTINCT EmploymentRate FROM Teachers";
            SqlCommand EmpRateCmd = new SqlCommand(EmpRateQuery, connection);
            connection.Open();
            SqlDataReader EmpRateReader = EmpRateCmd.ExecuteReader();
            while (EmpRateReader.Read())
            {
                cmbEmploymentRate.Items.Add(EmpRateReader["EmploymentRate"].ToString());
            }
            connection.Close();

            string YOfEXQuery = "SELECT DISTINCT YearsOfExperience FROM Teachers";
            SqlCommand YOfEXCmd = new SqlCommand(YOfEXQuery, connection);
            connection.Open();
            SqlDataReader YOfEXReader = YOfEXCmd.ExecuteReader();
            while (YOfEXReader.Read())
            {
                cmbYearsOfExperience.Items.Add(YOfEXReader["YearsOfExperience"].ToString());
            }
            connection.Close();

            string AgeQuery = "SELECT DISTINCT Age FROM Teachers";
            SqlCommand AgeCmd = new SqlCommand(AgeQuery, connection);
            connection.Open();
            SqlDataReader AgeReader = AgeCmd.ExecuteReader();
            while (AgeReader.Read())
            {
                cmbAge.Items.Add(AgeReader["Age"].ToString());
            }
            connection.Close();

            string AddressQuery = "SELECT DISTINCT Address FROM Teachers";
            SqlCommand AddressCmd = new SqlCommand(AddressQuery, connection);
            connection.Open();
            SqlDataReader AddressReader = AddressCmd.ExecuteReader();
            while (AddressReader.Read())
            {
                cmbAddress.Items.Add(AddressReader["Address"].ToString());
            }
            connection.Close();



            // Заполните остальные ComboBox данными из вашей базы данных
            // Подобным образом заполните другие комбо-боксы данными из базы данных
        }

        private void InitializeDataGrid()
        {
            // Очищайте DataTable перед загрузкой данных
            dataTable.Clear();

            // Загрузите все данные в DataGrid при загрузке формы
            string query = "SELECT * FROM Teachers";
            SqlCommand cmd = new SqlCommand(query, connection);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            // Примените фильтры на основе ввода пользователя и обновите DataGrid соответственно
            int selectedKafedraID = cmbKafedra.SelectedIndex >= 0 ? Convert.ToInt32(cmbKafedra.SelectedItem) : 0;
            string teacherFFilter = txtF.Text.Trim();
            string teacherIFilter = txtI.Text.Trim();
            string teacherOFilter = txtO.Text.Trim();
            string positionFilter = cmbPosition.SelectedItem?.ToString();
            string academicRankFilter = cmbAcademicRank.SelectedItem?.ToString();
            string ageFilter = cmbAge.SelectedItem?.ToString();
            string yearsOfExperienceFilter = cmbYearsOfExperience.SelectedItem?.ToString();
            string employmentRateFilter = cmbEmploymentRate.SelectedItem?.ToString();
            string addressFilter = cmbAddress.SelectedItem?.ToString();

            // Постройте SQL-запрос на основе выбранных фильтров
            string query = "SELECT * FROM Teachers WHERE 1 = 1";

            if (selectedKafedraID > 0)
            {
                query += " AND KafedraID = @KafedraID";
            }
            if (!string.IsNullOrEmpty(teacherFFilter))
            {
                query += " AND Teacher_surname LIKE @TeacherF";
            }
            if (!string.IsNullOrEmpty(teacherIFilter))
            {
                query += " AND Teacher_name LIKE @TeacherI";
            }
            if (!string.IsNullOrEmpty(teacherOFilter))
            {
                query += " AND Teacher_patronymic LIKE @TeacherO";
            }
            if (!string.IsNullOrEmpty(positionFilter))
            {
                query += " AND Position LIKE @Position";
            }
            if (!string.IsNullOrEmpty(academicRankFilter))
            {
                query += " AND AcademicRank LIKE @AcademicRank";
            }
            if (!string.IsNullOrEmpty(ageFilter))
            {
                query += " AND Age LIKE @Age";
            }
            if (!string.IsNullOrEmpty(yearsOfExperienceFilter))
            {
                query += " AND YearsOfExperience LIKE @YearsOfExperience";
            }
            if (!string.IsNullOrEmpty(employmentRateFilter))
            {
                query += " AND EmploymentRate LIKE @EmploymentRate";
            }
            if (!string.IsNullOrEmpty(addressFilter))
            {
                query += " AND Address LIKE @Address";
            }

            // Создайте и настройте SqlCommand
            SqlCommand cmd = new SqlCommand(query, connection);

            // Добавьте параметр кафедры, если он был выбран
            if (selectedKafedraID > 0)
            {
                cmd.Parameters.AddWithValue("@KafedraID", selectedKafedraID);
            }

            cmd.Parameters.AddWithValue("@TeacherF", $"%{teacherFFilter}%");
            cmd.Parameters.AddWithValue("@TeacherI", $"%{teacherIFilter}%");
            cmd.Parameters.AddWithValue("@TeacherO", $"%{teacherOFilter}%");
            cmd.Parameters.AddWithValue("@Position", $"%{positionFilter}%");
            cmd.Parameters.AddWithValue("@AcademicRank", $"%{academicRankFilter}%");
            cmd.Parameters.AddWithValue("@Age", $"%{ageFilter}%");
            cmd.Parameters.AddWithValue("@YearsOfExperience", $"{yearsOfExperienceFilter}");
            cmd.Parameters.AddWithValue("@EmploymentRate", $"%{employmentRateFilter}%");
            cmd.Parameters.AddWithValue("@Address", $"%{addressFilter}%");

            // Загрузите отфильтрованные данные в DataTable и обновите DataGrid
            dataTable.Clear();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            // Очистите все фильтры и загрузите исходные данные в DataGrid
            cmbKafedra.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbAcademicRank.SelectedIndex = -1;
            cmbAge.SelectedIndex = -1;
            cmbYearsOfExperience.SelectedIndex = -1;
            cmbEmploymentRate.SelectedIndex = -1;
            cmbAddress.SelectedIndex = -1;
            txtF.Clear();
            txtI.Clear();
            txtO.Clear();
            InitializeDataGrid();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            Close();
        }
    }
}


