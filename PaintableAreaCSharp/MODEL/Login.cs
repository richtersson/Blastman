using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KybCrypt;

namespace Blastman
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
                try
                {
                    LoginProcedure();
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
           
           
            

        }
        private void MapAndUnmapDrive()
        {
            //Database.P_VIRT_DISK_SEL();
            try
            {
                AddinGlobal.UnMapDrive();
            }
            catch (Exception ex)
            {
                try
                {
                    AddinGlobal.MapDrive();
                }
                catch
                {
                    throw new Exception("Nepodarilo sa pripojiť sieťový disk W. Prihlásenie do NAI zlyhalo.");
                }
            }
        }
        private void LoginProcedure ()
        {
            //Database.P_LOGIN(textBox1.Text, textBox2.Text);
            MapAndUnmapDrive();


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

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    LoginProcedure();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    LoginProcedure();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    LoginProcedure();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }
    }
}
