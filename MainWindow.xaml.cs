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
        public int CurrentUserId;
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

            TickNoteEntities TNotedb = new TickNoteEntities();



         
            AddModule addModule = new AddModule();

            var user = TNotedb.userAccounts.Where(x => x.username == CurrentUser).FirstOrDefault();
            addModule.userId = user.userId;
            addModule.ShowDialog();


            //TickNoteEntities TNotedb = new TickNoteEntities();

            var modules = from m in TNotedb.modules
                          select m;
            this.dgModules.ItemsSource = modules.ToList();

        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {

            var user = TNotedb.userAccounts.Where(x => x.username == CurrentUser).FirstOrDefault();
            CurrentUserId = user.userId;

            AddSession addSession = new AddSession();
            addSession.userId = CurrentUserId;
            
            addSession.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //    TickNoteEntities TNotedb = new TickNoteEntities();
            //    this.dgModule.ItemsSource = TNotedb.modules.ToList();

            //var modules = from m in TNotedb.modules
            //              select m;
            //this.dgModule.ItemsSource = modules.ToList();
        }

        private void btnRefreshModules_Click(object sender, RoutedEventArgs e)
        {
            TickNoteEntities TNotedb = new TickNoteEntities();
            this.dgModules.ItemsSource = TNotedb.modules.ToList();
        }

        private void btnRefreshSessions_Click(object sender, RoutedEventArgs e)
        {

            TickNoteEntities TNotedb = new TickNoteEntities();
            this.dgSession.ItemsSource = TNotedb.studySessions.ToList();
        }
    }
}
