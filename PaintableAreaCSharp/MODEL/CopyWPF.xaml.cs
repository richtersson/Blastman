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

namespace Blastman
{
    /// <summary>
    /// Interaction logic for CopyWPF.xaml
    /// </summary>
    public partial class CopyWPF : Window
    {
        public CopyWPF()
        {
            InitializeComponent();
        }
        public event Action<string> Name;

        
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
            
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewName != null && txtNewName.Text != "")
            {
                Name(txtNewName.Text);
                DialogResult = true;
                this.Close();
            }
            else { }


        }
    }
}
