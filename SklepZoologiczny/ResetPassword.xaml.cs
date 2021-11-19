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
    /// Logika interakcji dla klasy ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        string email = ForgetPassword.to;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnsafepsw(object sender, RoutedEventArgs e)
        {
            string password = txtpsw.Password;
            if (txtpsw.Password == txtcompsw.Password)
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLDEVELOPER; Initial Catalog=LoginDB; Integrated Security=True;");
                sqlCon.Open();
                string query = "update [tblUser] set [Password]='" + password + "'where Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Hasło zmieniono z sukcesem. :)");
                LoginScreen dashboard = new LoginScreen();
                dashboard.Show();
                this.Hide();
            }
                else
                {
                    MessageBox.Show("Twoje hasło nie zostało zmienione. :C");
                }

            } 
        }
    }
