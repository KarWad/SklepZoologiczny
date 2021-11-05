using System;
using System.Collections.Generic;
using System.Data;
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

namespace SklepZoologiczny
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLDEVELOPER; Initial Catalog=LoginDB; Integrated Security=True;");
        private string connectionString;

        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void btnSumbit_Click(object sender, RoutedEventArgs e)
        {
            if (txtun.Text == "" || txtpsw.Password == "")
                MessageBox.Show("Proszę uzupełnij wszystkie luki");
            else if (txtpsw.Password != txtcompsw.Password)
                MessageBox.Show("Hasła się różnią od siebie. Popraw!"); ;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("UserName", txtun.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Password", txtpsw.Password.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Rejestracja przebiegła pomyślnie");
                Clear();

                LoginScreen dashboard = new LoginScreen();
                dashboard.Show();
                Close();
            }
        }
        void Clear()
        {
            txtun.Text = txtpsw.Password = txtcompsw.Password = "";
        }

    }

}