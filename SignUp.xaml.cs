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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        MainClass mc = new MainClass();

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (!checkInputs()) { return; }
            //MessageBox.Show(mc.Encrypt(tbPassword.Text));

            TickNoteEntities db = new TickNoteEntities();
            userAccount userAccObj = new userAccount()
            {
                username = tbUsername.Text,
                email = tbEmail.Text,
                password = mc.Encrypt(tbPassword.Text)
            };
            db.userAccounts.Add(userAccObj);
            db.SaveChanges();

            MessageBox.Show("Account created successfully");

            this.Close();
        }

        public bool isEmailValid(string email)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                return false;
            }
            else
            {

                int counter = 0;
                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        counter++;
                    }
                    else if (email[i] == '.')
                    {
                        counter++;
                    }
                }


                if (counter == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        public bool checkInputs()
        {
            bool result = true;

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                lblUsername.Foreground = new SolidColorBrush(Colors.Red);
                lblUsername.Content = "Please enter a valid username";
                result = false;
            }

            if (!isEmailValid(tbEmail.Text))
            {
                lblEmail.Foreground = new SolidColorBrush(Colors.Red);
                lblEmail.Content = "Please enter a valid email address";
                result = false;
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                lblPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblPassword.Content = "Please enter a password";
                result = false;
            }

            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                lblConfirmPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblConfirmPassword.Content = "Passwords do not match";
                result = false;
            }
            

            return result;

        }

    }
}
