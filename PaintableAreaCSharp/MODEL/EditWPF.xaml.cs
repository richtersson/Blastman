
using Inventor;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Blastman
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class EditWPF : Window
    {
        private string ModelPath=null;
        private ObservableCollection<Blastman_program> programlist;

        public ObservableCollection<Blastman_program> ProgramList
        {
            get => programlist; set
            {
                if (value != programlist)
                {
                    programlist = value;
                    OnPropertyChanged("ProgramList");


                }
            }
        }

        public EditWPF()
        {
            InitializeComponent();
            programlist = new ObservableCollection<Blastman_program>();
            try
            {
                
                DataTable dt = cldDB.P_PROGRAMYNEEXPORTOVANE();
                foreach (DataRow row in dt.Rows)
                {
                    Blastman_program oProgram = new Blastman_program(AddinGlobal.InventorApp);
                    oProgram.ProgramName = (string)row["name"];
                    oProgram.ProgramDescription =Convert.ToString(row["programDesc"]) ?? null;
                    oProgram.State = (int)row["state"];

                    oProgram.CreationDate = Convert.ToString(row["creationDate"]) ?? null;

                    programlist.Add(oProgram);


                }
                this.DataContext = this;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            
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
            txtFind.Focus();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }


        

        private void TxtFind_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterPointsTableHidingRows(txtFind.Text);
        }
        private void FilterPointsTableHidingRows(string filterstring)
        {
            if (this.dtgProgramList.SelectionUnit != DataGridSelectionUnit.FullRow)
                this.dtgProgramList.SelectedCells.Clear();

            if (this.dtgProgramList.SelectionMode != DataGridSelectionMode.Single) //if the Extended mode
                this.dtgProgramList.SelectedItems.Clear();
            else
                this.dtgProgramList.SelectedItem = null;

            for (int i = 0; i < dtgProgramList.Items.Count; i++)
            {
                DataGridRow oRow = (DataGridRow)dtgProgramList.ItemContainerGenerator
                                                           .ContainerFromIndex(i);


            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            

            if (dtgProgramList.SelectedItem != null)
            {
                Blastman_program oPosition = dtgProgramList.SelectedItem as Blastman_program;
                MessageBoxResult result = System.Windows.MessageBox.Show("Naozaj chcete vymazať neúplný program " + oPosition.ProgramName + "?", "Upozornenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Do this
                    cldDB.P_NEUPLNYPROGRAM_DEL(oPosition.ProgramName);
                    programlist.Remove(oPosition);

                   //TODO
                   //VYMAZAŤ DÁTA Z DISKU
                   
                }
                else if (result == MessageBoxResult.No)
                {
                    return;
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                

            }
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dtgProgramList.SelectedItem != null)
            {
                Blastman_program oProgram = dtgProgramList.SelectedItem as Blastman_program;

                string ModelPath = AddinGlobal.BlastmanModelFolder + @"\" + oProgram.ProgramName + @"\" + oProgram.ProgramName + ".iam";
                if (ModelPath != null)
                {
                    AddinGlobal.InventorApp.Documents.Open(ModelPath);
                    oProgram.MapParameters();
                    this.Close();

                    Create oCreate = new Create(oProgram);
                    oCreate.Show();

                }



            }
        }
    }
}
