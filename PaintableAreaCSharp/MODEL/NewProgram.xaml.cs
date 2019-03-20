
using Inventor;
using System;
using System.IO;
using System.Windows;


namespace Blastman
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class NewProgram : Window
    {
        private string ModelPath=null;
        public NewProgram()
        {
            InitializeComponent();
        }
        

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            Run();
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
            txtProgram.Focus();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Run();
            }
        }
        private void Run()
        {
            try
            {
                if (String.IsNullOrEmpty(txtProgram.Text)|| String.IsNullOrEmpty(txtModelPath.Text))
                {
                    throw new Exception("Nie je zadaný názov.");

                }
                else
                {
                    string Path = AddinGlobal.BlastmanModelFolder + @"\" + txtProgram.Text;
                    if (Directory.Exists(Path))
                    {

                    }
                    else
                    {
                        // Try to create the directory.
                        try
                        {
                            DirectoryInfo di = Directory.CreateDirectory(Path);
                        }
                        catch
                        {
                            throw new Exception("Nie je možné vytvoriť zložku pre program. Skontrolujte umiestnenie " + AddinGlobal.BlastmanModelFolder);
                        }
                    }

                        string newAssemblyFile = AddinGlobal.BlastmanModelFolder + @"\" + txtProgram.Text + @"\" + txtProgram.Text + ".iam";
                        System.IO.File.Copy(AddinGlobal.BlastmanModelFolder + @"\Library\Blastman_PS2.iam", newAssemblyFile);

                        cldDB.P_PROGRAM_INSERT(txtProgram.Text, DateTime.Now.ToShortDateString());
                        this.Close();
                        AssemblyDocument oAssemblyDoc = (AssemblyDocument)AddinGlobal.InventorApp.Documents.Open(newAssemblyFile);
                        Matrix oPositionMatrix = AddinGlobal.InventorApp.TransientGeometry.CreateMatrix();
                        ComponentOccurrence oMachinedComp = oAssemblyDoc.ComponentDefinition.Occurrences.Add(ModelPath, oPositionMatrix);
                    AddinGlobal.InventorApp.SilentOperation = true;
                        oAssemblyDoc.Save2();
                    AddinGlobal.InventorApp.SilentOperation = false;
                    Blastman_program oBlastman = new Blastman_program(AddinGlobal.InventorApp, txtProgram.Text,0);

                        Create oCreate = new Create(oBlastman);
                        oCreate.Show();
                    
                }


            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;

            }
        }

        private void BtnModel_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            //dlg.DefaultExt = ".ipt";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Multiselect = false;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                ModelPath = dlg.FileName;
                txtModelPath.Text = dlg.FileName;
            }
        }
    }
}
