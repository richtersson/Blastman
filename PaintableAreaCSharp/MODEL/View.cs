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
    public partial class View : Form
    {
        private DataTable dt;
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            //dt = Database.P_VYKRESYSPREDPISOM();
            //dataGridView1.DataSource = dt;
            foreach (DataGridViewRow oRow in dataGridView1.Rows)
            {
                if (oRow.Cells[1].Value.ToString() == "1")
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
            dataGridView1.Columns["PRK_STAV"].Visible = false;
            dataGridView1.Columns["PRK_NAZOV"].Visible = false;
            dataGridView1.Columns["PRK_DATUM_EXPORT"].HeaderText = "Dátum exportu";
            dataGridView1.Columns["PRK_DATUM_ZADAL"].Visible = false;
            foreach (DataGridViewRow oRow in dataGridView1.Rows)
            {
                if (oRow.Visible == true)
                {
                    oRow.Selected = true;
                    FormatDatagridView2(oRow);
                    break;
                }
            }

        }

        

       

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "PRK_STAV")
            {
              if (e.Value.ToString()=="1")
                e.Value = "P";
                if (e.Value.ToString() == "2")
                    e.Value = "N";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                DataGridViewRow oRow = dataGridView2.SelectedRows[0];
                string ModelPath=null;
                //Database.P_PREDPISKONTROLA_SEL(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int32.Parse(oRow.Cells[1].Value.ToString()), out ModelPath);
                if (ModelPath != null)
                {
                    AddinGlobal.InventorApp.Documents.Open(ModelPath);
                    Predpis_kontroly oPK = new Predpis_kontroly(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int16.Parse((oRow.Cells[1].Value.ToString())),  ModelPath);
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

      

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow oRow = dataGridView1.Rows[e.RowIndex];

                FormatDatagridView2(oRow);



            }
        }
        private void FormatDatagridView2 (DataGridViewRow oRow)
        {
            string CisloVykresu = oRow.Cells[0].Value.ToString();


            DataTable dtodvodene = new DataTable();
            dtodvodene = dt.Copy();
            dtodvodene.Columns.Add("ConvertedExportDate", typeof(DateTime));
            foreach (DataRow dr in dtodvodene.Rows)
            {
                try
                {
                    dr["ConvertedExportDate"] = Convert.ToDateTime(dr["PRK_DATUM_EXPORT"]);
                }
                catch
                {
                    dr["ConvertedExportDate"] = DBNull.Value;
                }

            }
            foreach (DataRow oRow2 in dtodvodene.Rows)
            {
                if (oRow2[0].ToString() != CisloVykresu)
                {
                    oRow2.Delete();
                }

            }

            //dataGridView2.DataSource = dtodvodene;
           
            DataView view = dtodvodene.DefaultView;
            view.Sort = "PRK_STAV ASC, ConvertedExportDate DESC";
            dataGridView2.DataSource = view; //rebind the data source
            dataGridView2.Columns["VYK_CISLO_QMS"].Visible = false;
            dataGridView2.Columns["PRK_STAV"].HeaderText = "Platnosť";
            dataGridView2.Columns["PRK_NAZOV"].HeaderText = "Názov predpisu";
            dataGridView2.Columns["PRK_DATUM_EXPORT"].Visible = false;
            dataGridView2.Columns["PRK_DATUM_EXPORT"].HeaderText = "Dátum exportu";
            dataGridView2.Columns["ConvertedExportDate"].Visible = true;
            dataGridView2.Columns["ConvertedExportDate"].HeaderText = "Dátum exportu";
            dataGridView2.Columns["ConvertedExportDate"].DisplayIndex = 4;
            dataGridView2.Columns["PRK_DATUM_ZADAL"].HeaderText = "Dátum vytvorenia";
            //dataGridView2.Sort(this.dataGridView2.Columns["PRK_STAV"], ListSortDirection.Descending);
        }

        

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                DataGridViewRow oRow = dataGridView2.SelectedRows[0];
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

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2_Click(this, EventArgs.Empty);
        }

        private void btnNewVersion_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                DataGridViewRow oRow = dataGridView2.SelectedRows[0];
                string ModelPath=null;
                //Database.P_PREDPISKONTROLA_SEL(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), Int32.Parse(oRow.Cells[1].Value.ToString()), out ModelPath);
                if (ModelPath != null)
                {


                    string oldnumber = oRow.Cells[0].Value.ToString();
                    string oldnazov = oRow.Cells[2].Value.ToString();
                    int stav = Int32.Parse(oRow.Cells[1].Value.ToString());
                    this.Close();
                    NewVersion nw = new NewVersion(oldnumber,oldnazov, stav, ModelPath);
                    nw.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));


                }
                else return;
            }
            else
                MessageBox.Show("Nie je vybraté žiadne číslo výkresu");
          
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow oRow = dataGridView2.Rows[e.RowIndex];
                int stav = Int32.Parse(oRow.Cells[1].Value.ToString());
                if (stav==0)
                {
                    btnCopy.Enabled = false;
                    btnNewVersion.Enabled = false;
                    button2.Text = "Otvoriť";
                }
                else
                {
                    btnCopy.Enabled = true;
                    btnNewVersion.Enabled = true;
                    button2.Text = "Prezerať";
                }







            }
        }
    }
}
