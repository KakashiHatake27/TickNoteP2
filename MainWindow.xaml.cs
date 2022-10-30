using System;
using System.Collections.Generic;
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

namespace ProgPoeTickNotePart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string CurrentUser;
        public TickNoteEntities TNotedb = new TickNoteEntities();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();
            }
        }

        private void imgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();
            }
        }

        private void btnAddModule_Click(object sender, RoutedEventArgs e)
        {
     
            var users = from d in TNotedb.userAccounts
                        select d;

            this.dgUsers.ItemsSource = users.ToList();
            MessageBox.Show("Got db");

            MessageBox.Show("Done!!");
            lbUserName.Content = CurrentUser;
            
            /*
             
                    //testing the connection to the ADO.NEt of DB set 
            personsEntities db = new personsEntities();
            //pull the data
            var persons = from d in db.People
                          select d;
            this.dgStudents.ItemsSource = persons.ToList();
             */

        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
