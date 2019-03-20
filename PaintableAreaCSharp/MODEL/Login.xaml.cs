
using System;
using System.Windows;


namespace Blastman
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
        private void LoginProcedure()
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                cldDB.P_LOGIN(txtUserName.Text, txtPassword.Password);





                AddinGlobal.LoggedIn = true;
                AddinGlobal.CurrentUser = txtUserName.Text;
                foreach (InventorButton iBtn in AddinGlobal.ButtonList)
                {
                    if (iBtn.ButtonDef.DisplayName != "Prihlásiť")
                        iBtn.ButtonDef.Enabled = true;
                    if (iBtn.ButtonDef.DisplayName == "Prihlásiť")
                        iBtn.ButtonDef.Enabled = false;
                }

                this.Close();
            }
            else
                throw new Exception("Zadajte meno a heslo.");
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginProcedure();

            }
            catch (Exception ex)
            {
                lblInfo.Content = ex.Message;

            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                try
                {
                    LoginProcedure();

                }
                catch (Exception ex)
                {
                    lblInfo.Content = ex.Message;

                }
            }
        }

        private void TxtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.SelectAll();
        }
    }
}
