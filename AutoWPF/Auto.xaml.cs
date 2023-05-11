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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoWPF.DataBase;
using WPF_RegistrationForm;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace AutoWPF
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        private string captchaText;
        public Auto()
        {
            InitializeComponent();
            GenerateCaptcha(4);
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            if (txtCaptcha.Text == captchaText)
            {
                var CurrentUser = AppData.db.Folk.FirstOrDefault(u => u.почта == txtMail.Text && u.пароль == txtPassword.Password);
                MessageBox.Show($"{CurrentUser.GetType()}");

                if (CurrentUser == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    Variables.TypeUser = CheckTypeUser(txtMail.Text);
                    MessageBox.Show("Вы авторизовались как: " + Variables.TypeUser);
                }
            }
            else
            {
                MessageBox.Show("Неверный текст с капчи!");
                GenerateCaptcha(4);
                txtCaptcha.Text = "";
            }
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha(captchaText.Length);
            txtCaptcha.Text = "";
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        { 
        
        }
            
        private void GenerateCaptcha(int digits)
        {
            // Generate a random string for the CAPTCHA text
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[4];
            rng.GetBytes(data);
            int value = BitConverter.ToInt32(data, 0) % 10000;
            captchaText = value.ToString("D4");

            // Create an image of the CAPTCHA text
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("https://dummyimage.com/200x80/000/fff&text=" + captchaText);
            bitmap.EndInit();
            captchaImage.Source = bitmap;
        }

       
        public string CheckTypeUser(string Username)
        {
            string connectionString = @"Data Source=DBSRV\MAM2022;Initial Catalog=AMHA;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select Роль from Folk left join Folk on Роль = Роль where ФИО = @ФИО";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@ФИО", SqlDbType.VarChar, 40).Value = Username;
            string result = Convert.ToString(cmd.ExecuteScalar());
            return result;
        }
    }
}
