
using Inventor;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Data;

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
           
                // Refresh the view to apply filters.
                CollectionViewSource.GetDefaultView(dtgProgramList.ItemsSource).Refresh();
           
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
       

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Blastman_program t = e.Item as Blastman_program;
            if (t != null)
            // If filter is turned on, filter completed items.
            {
                if (t.ProgramName.Contains(txtFind.Text))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
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
                    DataTable dtPositions = cldDB.P_POSITION_SEL(oProgram.ProgramName);
                    foreach (DataRow row in dtPositions.Rows)
                    {
                        

                        oProgram.PositionList.Add(new PositionConfiguration(AddinGlobal.InventorApp, (int)row["positionNumber"],(double)row["P1_X"], (double)row["P2_Y"], (double)row["P3_C"], (double)row["P4_Z"], (double)row["P5_A1"], (double)row["P6_A2"], (double)row["P7_A3"], (double)row["P8_A4"], (string)row["time_or_axle"], (string)row["joint_speed"], (string)row["blasting_state"], (string)row["swing_axle"], (string)row["swing_angle"], (string)row["swing_speed"]));


                    }


                    Create oCreate = new Create(oProgram);
                    oCreate.Show();

                }



            }
        }

        private void CollectionViewSource_Filter_1(object sender, FilterEventArgs e)
        {

        }
    }
}
