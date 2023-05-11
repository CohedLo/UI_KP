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
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : Page
    {
        public EventPage()
        {
            InitializeComponent();
            //Variables.Panel(Почта, post);
            SqlConnection connection = new SqlConnection(@"Data Source=DBSRV\MAM2022; Initial Catalog=AMHA; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Event";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Event");
            dataAdp.Fill(dt);
            EventGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DBSRV\MAM2022;Initial Catalog=AMHA;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command2 = "insert into Event values (@ID, @Событие, @Date, @Days, @Город)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@№", SqlDbType.Int).Value = AddNum.Text;
            cmd.Parameters.Add("@Событие", SqlDbType.VarChar, 30).Value = AddEvent.Text;
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = AddDate.Text;
            cmd.Parameters.Add("@Days", SqlDbType.VarChar, 30).Value = AddDays.Text;
            cmd.Parameters.Add("@Город", SqlDbType.VarChar, 30).Value = AddCity.Text;       
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            Wind.Visibility = Visibility.Hidden;
            EventGrid.ItemsSource = null;
            EventGrid.ItemsSource = AppData.db.Event.ToList();
        }
        private void EvButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventPage());
        }
        private void ActButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Active());
        }
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartiPage());
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartiPage());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Wind.Visibility = Visibility.Hidden;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Wind.Visibility = Visibility.Visible;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Auto nav = new Auto();
            NavigationService.Navigate(nav);
        }
    }
}
