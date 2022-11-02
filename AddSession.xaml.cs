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
using System.Windows.Shapes;

namespace ProgPoeTickNotePart2
{
    /// <summary>
    /// Interaction logic for AddSession.xaml
    /// </summary>
    public partial class AddSession : Window
    {

        public int userId;

        public AddSession()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            saveSession();

            MessageBox.Show("Session added successfully");
            this.Close();   
        }


        public async void saveSession()
        {

            TickNoteEntities db = new TickNoteEntities();

            studySession sessionObj = new studySession()
            {
                userId = userId,
                studyDate = dpStudyDate.DisplayDate,
                module = tbModuleCode.Text,
                hoursWorked = Convert.ToInt32(tbHours.Text)
            };


            db.studySessions.Add(sessionObj);
            await db.SaveChangesAsync();
        }

    }
}
