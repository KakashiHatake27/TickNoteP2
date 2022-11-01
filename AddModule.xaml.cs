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
    /// Interaction logic for AddModule.xaml
    /// </summary>
    public partial class AddModule : Window
    {
        public AddModule()
        {
            InitializeComponent();
        }



        public int userId;

        private void btnAddModule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User id: " + userId.ToString());

            TickNoteEntities db = new TickNoteEntities();
            module moduleObj = new module()
            {
                moduleCode = tbModuleCode.Text,
                moduleName = tbModuleName.Text,
                userId = userId,
                credits = Convert.ToInt32(tbCredits.Text),
                classes = Convert.ToInt32(tbClasses.Text)
            };

            db.modules.Add(moduleObj);
            db.SaveChanges();



            MessageBox.Show("Module added successfully");
            this.Close();
        }
    }
}
