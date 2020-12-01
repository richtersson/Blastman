﻿
using Inventor;
using System;
using System.IO;
using System.Linq;
using System.Windows;


namespace Blastman
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class NewProgram : Window
    {
        private string ModelPath = null;
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
        private bool ProgramNameOccupied(string programname)
        {
            string[] subdirs = Directory.GetDirectories(AddinGlobal.BlastmanModelFolder)
                            .Select(System.IO.Path.GetFileName)
                            .ToArray();
            return subdirs.Contains(programname);
        }
        private void Run()
        {
            try
            {
                if (String.IsNullOrEmpty(txtProgram.Text) || String.IsNullOrEmpty(txtModelPath.Text))
                {
                    throw new Exception("Nie je zadaný názov.");

                }
                else if (ProgramNameOccupied(txtProgram.Text))
                {
                    throw new Exception("Program s týmto názvom existuje. Zvoľte iný názov.");
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
                    System.IO.Directory.CreateDirectory(AddinGlobal.BlastmanModelFolder + @"\" + txtProgram.Text + @"\MODEL");
                    string ModelPathCopy = AddinGlobal.BlastmanModelFolder + @"\" + txtProgram.Text + @"\MODEL\" + System.IO.Path.GetFileName(ModelPath);
                    System.IO.File.Copy(ModelPath, ModelPathCopy);
                    cldDB.P_PROGRAM_INSERT(txtProgram.Text, DateTime.Now.ToShortDateString());
                    this.Close();
                    AssemblyDocument oAssemblyDoc = (AssemblyDocument)AddinGlobal.InventorApp.Documents.Open(newAssemblyFile);
                    Matrix oPositionMatrix = AddinGlobal.InventorApp.TransientGeometry.CreateMatrix();

                    //STEP FILES
                    if (System.IO.Path.GetExtension(ModelPathCopy) == ".stp" || System.IO.Path.GetExtension(ModelPathCopy) == ".step")
                    {
                        //                    Dim oDoc As AssemblyDocument
                        //Set oDoc = ThisApplication.ActiveDocument


                        //Dim oAssyCompDef As AssemblyComponentDefinition
                        //Set oAssyCompDef = oDoc.ComponentDefinition


                        //'Create the ImportedGenericComponentDefinition based on a Step file
                        //Dim oImportedGenericCompDef As ImportedGenericComponentDefinition
                        //Set oImportedGenericCompDef = oAssyCompDef.ImportedComponents.CreateDefinition(_
                        //    "C:\Autodesk\autodesk_inventor_2019_samples_dlm\Models\Assemblies\Stapler\Stapler.stp")
                        ImportedGenericComponentDefinition oStepFileDef = (ImportedGenericComponentDefinition)oAssemblyDoc.ComponentDefinition.ImportedComponents.CreateDefinition(ModelPathCopy);
                        oStepFileDef.ReferenceModel = true;
                        ImportedComponent oStepComp = oAssemblyDoc.ComponentDefinition.ImportedComponents.Add((ImportedComponentDefinition)oStepFileDef);
                       

                        //'Set the ReferenceModel to associatively import the Step file
                        //'True is the default value
                        //oImportedGenericCompDef.ReferenceModel = True


                        //'Import the Step file to assembly
                        //Dim oImportedComp As ImportedComponent
                        //Set oImportedComp = oAssyCompDef.ImportedComponents.Add(oImportedGenericCompDef)
                        //Dim oOcc As ComponentOccurrence
                        //'The last occurrence should be the one we just added
                        //Set oOcc = oAssyCompDef.Occurrences(oAssyCompDef.Occurrences.Count)

                    }
                    else
                    {
                        ComponentOccurrence oMachinedComp = oAssemblyDoc.ComponentDefinition.Occurrences.Add(ModelPathCopy, oPositionMatrix);
                    }

                    AddinGlobal.InventorApp.SilentOperation = true;
                    oAssemblyDoc.Save2();
                    AddinGlobal.InventorApp.SilentOperation = false;
                    Blastman_program oBlastman = new Blastman_program(AddinGlobal.InventorApp, txtProgram.Text, 0);
                    AddinGlobal.AktivnyBlastmanProgram = oBlastman;
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
            dlg.Filter = "IPT (*.ipt)|*.ipt|IAM (*.iam)|*.iam|STEP (*.step,*.stp)|*.step;*.stp";
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
