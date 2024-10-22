﻿using System;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }




        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            MainClass mc = new MainClass();

            if (!validateInputs())
            {
                return;
            }

            TickNoteEntities TNotedb = new TickNoteEntities();


            var user = TNotedb.userAccounts.Where(x => x.username == tbUsername.Text).FirstOrDefault();

            if (user != null)
            {
                if (user.password == mc.Encrypt(tbPassword.Text))
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();

                    mw.CurrentUser = tbUsername.Text;
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Incorrect Password, Please try again!", "Incorrect Password", MessageBoxButton.OK, MessageBoxImage.Stop);

               

                }
            }
            else
            {
                MessageBox.Show("This User does not exist!", "Username not found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        public bool validateInputs()
        {
            bool result = true;

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                lblUsername.Foreground = new SolidColorBrush(Colors.Red);
                lblUsername.Content = "Please enter a valid username";
                result = false;
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                lblPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblPassword.Content = "Please enter a valid password";
                result = false;
            }

            return result;

        }

    }
}
