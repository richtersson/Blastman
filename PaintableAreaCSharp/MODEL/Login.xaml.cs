
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
                foreach (InventorButton iBtn in AddinGlobal.ButtonList)
                {
                    if (iBtn.ButtonDef.DisplayName != "Prihlásiť")
                        iBtn.ButtonDef.Enabled = true;
                    if (iBtn.ButtonDef.DisplayName == "Prihlásiť")
                        iBtn.ButtonDef.Enabled = false;
                }

                this.Close();
            }
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
    }
}
