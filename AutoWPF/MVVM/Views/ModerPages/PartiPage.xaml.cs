using AutoWPF.DataBase;
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

namespace AutoWPF.MVVM.Views.ModerPages
{
    /// <summary>
    /// Логика взаимодействия для PartiPage.xaml
    /// </summary>
    public partial class PartiPage : Page
    {       
        public PartiPage()
        {
            InitializeComponent();
            //Variables.Panel(Почта, post);
            SqlConnection connection = new SqlConnection(@"Data Source=DBSRV\MAM2022; Initial Catalog=AMHA; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Folk";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Folk");
            dataAdp.Fill(dt);
            PartiGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DBSRV\MAM2022;Initial Catalog=AMHA;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command2 = "insert into Folk values (@ID, @ФИО, @Почта, @Дата рождения, @Страна, @Телефон,@Пароль,@Фото,@Пол)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = AddId.Text;
            cmd.Parameters.Add("@ФИО", SqlDbType.VarChar, 30).Value = AddName.Text;
            cmd.Parameters.Add("@Почта", SqlDbType.Date).Value = AddMail.Text;
            cmd.Parameters.Add("@Дата рождения", SqlDbType.VarChar, 30).Value = AddDate.Text;
            cmd.Parameters.Add("@Страна", SqlDbType.VarChar, 30).Value = AddCountry.Text;
            cmd.Parameters.Add("@Телефон", SqlDbType.VarChar, 30).Value = AddPhone.Text;
            cmd.Parameters.Add("@Пароль", SqlDbType.VarChar, 30).Value = AddPass.Text;
            cmd.Parameters.Add("@Фото", SqlDbType.VarChar, 30).Value = AddPhoto.Text;
            cmd.Parameters.Add("@Пол", SqlDbType.VarChar, 30).Value = AddPol.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            Wind.Visibility = Visibility.Hidden;
            PartiGrid.ItemsSource = null;
            PartiGrid.ItemsSource = AppData.db.Folk.ToList();
        }
        private void ActButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Active());
        }
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartiPage());
        }
        private void EvButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventPage());
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Wind.Visibility = Visibility.Visible;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Wind.Visibility = Visibility.Hidden;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Auto nav = new Auto();
            NavigationService.Navigate(nav);
        }
    }
}
