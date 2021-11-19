using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Logika interakcji dla klasy ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        string randomcode;
        public static string to;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnforgetpass(object sender, RoutedEventArgs e)
        {
            string from, pass, messagebody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtemail.Text).ToString();
            from = "szkolakarolina417@gmail.com";
            pass = ".Phineasflynn417";
            messagebody = $"Twój kod do resetu hasła to {randomcode}";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Kod resetowania hasła";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Kod wysłany z sukcesem. :) ");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Coś nie poszło. :C");
            }
        }

        private void btncode(object sender, EventArgs e)
        {

            if (randomcode == (txtcode.Text).ToString())
            {
                to = txtemail.Text;

                ResetPassword dashboard = new ResetPassword();
                this.Hide();
                dashboard.Show();
               
               

            }
            else 
            {
                MessageBox.Show("Zły kod");

            }
        }
    }
}
