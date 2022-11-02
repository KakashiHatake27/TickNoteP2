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



            //MessageBox.Show("User id: " + userId.ToString());

            saveSession();

            //TickNoteEntities db = new TickNoteEntities();
            //module moduleObj = new module()
            //{
            //    moduleCode = tbModuleCode.Text,
            //    moduleName = tbModuleName.Text,
            //    userId = userId,
            //    credits = Convert.ToInt32(tbCredits.Text),
            //    classes = Convert.ToInt32(tbClasses.Text)
            //};

            //db.modules.Add(moduleObj);
            //db.SaveChanges();



            //MessageBox.Show("Module added successfully");
            //this.Close();

        }


        public async void saveSession()
        {

            TickNoteEntities db = new TickNoteEntities();

            studySession sessionObj = new studySession()
            {
                userId = userId,
                studyDate = dpStudyDate.DisplayDate,
                module = tbModule.Text,
                hoursWorked = Convert.ToInt32(tbHours.Text)
            };


            db.studySessions.Add(sessionObj);
            await db.SaveChangesAsync();
        }

    }
}
