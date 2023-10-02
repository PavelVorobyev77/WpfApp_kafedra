using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_kafedra
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFInputForm_Click(object sender, RoutedEventArgs e)
        {
            FInputForm fInputForm = new FInputForm();
            fInputForm.Show();
            Close();
        }

        private void SearchProfessors_Click(object sender, RoutedEventArgs e)
        {
            SearchTeachersForm steachForm = new SearchTeachersForm();
            steachForm.Show();
            Close();
        }
    }
}
