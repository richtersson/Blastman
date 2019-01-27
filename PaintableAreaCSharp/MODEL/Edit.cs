using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blastman
{
    public partial class Edit : Form
    {
        DataTable dt;
        BindingSource bs = new BindingSource();
        
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            //dt = Database.P_VYKRESYSPREDPISOM();
            //bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            FormatDataGridView();
            

        }
        private void FormatDataGridView()
        {
            foreach (DataGridViewRow oRow in dataGridView1.Rows)
            {
                if (oRow.Cells[1].Value.ToString() == "0")
                {
                    oRow.Visible = true;
                }
                else
                {
                    dataGridView1.CurrentCell = null;
                    oRow.Visible = false;
                }
            }
            dataGridView1.Columns["VYK_CISLO_QMS"].HeaderText = "Číslo výkresu";
            dataGridView1.Columns["PRK_STAV"].HeaderText = "Stav";
            dataGridView1.Columns["PRK_NAZOV"].HeaderText = "Názov";
            dataGridView1.Columns["PRK_DATUM_ZADAL"].HeaderText = "Dátum vytvorenia";
            dataGridView1.Columns["PRK_DATUM_EXPORT"].Visible = false;
            foreach (DataGridViewRow oRow in dataGridView1.Rows)
            {
                if (oRow.Visible == true)
                {
                    oRow.Selected = true;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCisloVykresuFind_TextChanged(object sender, EventArgs e)
        {
            FilterPointsTableHidingRows(txtCisloVykresuFind.Text);
        }
        private void FilterPointsTableHidingRows(string filterstring)
        {
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow oRow in dataGridView1.Rows)
            {
                if (oRow.Cells[0].Value.ToString().StartsWith(filterstring, true, null))
                {
                    oRow.Visible = true;
                }
                else
                {
                    dataGridView1.CurrentCell = null;
                    oRow.Visible = false;
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                DataGridViewRow oRow = dataGridView1.SelectedRows[0];
                string ModelPath=null;
                //Database.P_PREDPISKONTROLA_SEL(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int32.Parse(oRow.Cells[1].Value.ToString()), out ModelPath);
                if (ModelPath != null)
                {
                    AddinGlobal.InventorApp.Documents.Open(ModelPath);
                    Predpis_kontroly oPK = new Predpis_kontroly(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int16.Parse(oRow.Cells[1].Value.ToString()), ModelPath);
                    oPK.Rebuild();
                    AddinGlobal.AktivnyPredpisKontroly = oPK;
                    BasicInterface oBI = new BasicInterface(AddinGlobal.AktivnyPredpisKontroly);
                    this.Close();
                    oBI.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
                    
                }
                else return;
            }
            else
                MessageBox.Show("Nie je vybraté žiadne číslo výkresu");
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns[1].Visible = false;
            if (e.ColumnIndex==1)
            {
                if (e.Value.ToString()=="0")
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow = dataGridView1.Rows[e.RowIndex];
                    oRow.Visible = false;
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOpen_Click(this, EventArgs.Empty);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count!=0)
            {
                DataGridViewRow oRow = dataGridView1.SelectedRows[0];
                string ModelPath=null;
                //Database.P_PREDPISKONTROLA_SEL(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int32.Parse(oRow.Cells[1].Value.ToString()), out ModelPath);
                if (ModelPath != null)
                {

                    
                    string oldnumber = oRow.Cells[0].Value.ToString();
                    string oldnazov = oRow.Cells[2].Value.ToString();
                    int stav = Int32.Parse(oRow.Cells[1].Value.ToString());
                    this.Close();
                    Copy cp = new Copy(oldnumber, oldnazov, stav, ModelPath);
                    cp.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));


                }
                else return;
            }
            else
                MessageBox.Show("Nie je vybraté žiadne číslo výkresu");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow oRow = dataGridView1.SelectedRows[0];


                DialogResult dialogResult = MessageBox.Show("Naozaj chcete vymazať neúplný predpis pre číslo výkresu " + oRow.Cells[0].Value.ToString()+ "?", "Upozornenie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                    try
                    {
                        //Database.P_NEUPLNYPREDPIS_DEL(oRow.Cells[0].Value.ToString());
                    }
                    catch(Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    //dt = Database.P_VYKRESYSPREDPISOM();
                    //bs.DataSource = dt;
                    dataGridView1.DataSource = bs;
                    FormatDataGridView();
                    dataGridView1.Update();
                    dataGridView1.Refresh();

                }
            else if (dialogResult == DialogResult.No)
            {
               
            }
                
            }

        }
    }
}
