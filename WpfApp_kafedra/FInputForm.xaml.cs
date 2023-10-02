using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class FInputForm : Window
    {
        // Здесь нужно указать строку подключения к вашей БД 
        private string connectionString = "Data Source=DESKTOP-BK1T0PD\\SQLEXPRESS;Initial Catalog=21.102-8_Kafedra;Integrated Security=True";

        public FInputForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            Close();
        }
        private void FacultButton_Click(object sender, RoutedEventArgs e)
        {
            TFaculties TfacForm = new TFaculties();
            TfacForm.Show();
        }


        private void UpdateFaculty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Faculties SET FacultyName = @FacultyName, DeanFIO = @DeanFIO, DeanOfficeRoomNumber = @DeanOfficeRoom, DeanOfficePhone = @DeanOfficePhone WHERE FacultyID = @FacultyID";
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@FacultyName", FacultyNameTextBox.Text);
                    command.Parameters.AddWithValue("@DeanFIO", DeanFIOTexBox.Text);
                    command.Parameters.AddWithValue("@DeanOfficeRoom", DeanOfficeRoomTextBox.Text);
                    command.Parameters.AddWithValue("@DeanOfficePhone", DeanOfficePhoneTextBox.Text);
                    command.Parameters.AddWithValue("@FacultyID", FacultyCodeTextBox.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Изменения внесены");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось внести изменения");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void NewFaculty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT MAX(FacultyID) FROM Faculties";
                    SqlCommand command = new SqlCommand(sql, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int nextID = Convert.ToInt32(result) + 1;
                        FacultyCodeTextBox.Text = nextID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void AddFaculty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Faculties (FacultyID, FacultyName, DeanFIO, DeanOfficeRoomNumber, DeanOfficePhone) VALUES (@FacultyID, @FacultyName, @DeanFIO, @DeanOfficeRoom, @DeanOfficePhone)";
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@FacultyID", FacultyCodeTextBox.Text);
                    command.Parameters.AddWithValue("@FacultyName", FacultyNameTextBox.Text);
                    command.Parameters.AddWithValue("@DeanFIO", DeanFIOTexBox.Text);
                    command.Parameters.AddWithValue("@DeanOfficeRoom", DeanOfficeRoomTextBox.Text);
                    command.Parameters.AddWithValue("@DeanOfficePhone", DeanOfficePhoneTextBox.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Новая запись была добавлена в таблицу БД");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить запись в таблицу БД");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void DeleteFaculty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Faculties WHERE FacultyID = @FacultyID";
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@FacultyID", FacultyCodeTextBox.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись из таблицы БД удалена");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить запись из таблицы БД");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
