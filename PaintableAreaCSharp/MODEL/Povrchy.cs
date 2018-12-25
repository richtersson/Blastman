using Inventor;
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
    public partial class Povrchy : Form
    {
        private Predpis_kontroly oPk;
        private Typ_pohladu oTyp;
       
        public Povrchy(Predpis_kontroly pk)
        {
            InitializeComponent();
            oPk = pk;
        }

        private void Povrchy_Load(object sender, EventArgs e)
        {
            //tabulka na prezeranie
            if (oPk.Stav!=0)
            {
                btnDelete.Visible = false;
                btnPridatPovrch.Visible = false;
                dataGridViewPovrchy.ReadOnly = true;
            }
            
            //binding controls
            dataGridViewPovrchy.DataSource = oPk.Povrchy;
            btnPridatPovrch.Enabled = false;

            
            dataGridViewPovrchy.Columns["Polomer1"].Visible = false;
            dataGridViewPovrchy.Columns["Polomer2"].Visible = false;
            dataGridViewPovrchy.Columns["Vyska1"].Visible = false;
            dataGridViewPovrchy.Columns["Vyska2"].Visible = false;

            dataGridViewPovrchy.Columns["Typ_pohladu"].HeaderText = "Typ pohľadu";
            dataGridViewPovrchy.Columns["Typ_pohladu"].ReadOnly = true;
            dataGridViewPovrchy.Columns["Text"].HeaderText = "Prítomnosť textu";
            
            dataGridViewPovrchy.Columns["Drazka"].HeaderText = "Prítomnosť drážky";


            //filter
            if (chBoxBottom.Checked)
            {
                //filter
                dataGridViewPovrchy.ClearSelection();
                foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
                {
                    if (oRow.Cells[0].Value.ToString().Contains("kBottom"))
                    {
                        oRow.Visible = true;
                    }
                    else
                    {
                        dataGridViewPovrchy.CurrentCell = null;
                        oRow.Visible = false;
                    }
                }
            }
            if (chBoxTop.Checked)
            {
                //filter
                dataGridViewPovrchy.ClearSelection();
                foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
                {
                    if (oRow.Cells[0].Value.ToString().Contains("kTop"))
                    {
                        oRow.Visible = true;
                    }
                    else
                    {
                        dataGridViewPovrchy.CurrentCell = null;
                        oRow.Visible = false;
                    }
                }
            }
            if (chBoxBottom.Checked)
            {
                //filter
                dataGridViewPovrchy.ClearSelection();
                foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
                {
                    if (oRow.Cells[0].Value.ToString().Contains("kSide"))
                    {
                        oRow.Visible = true;
                    }
                    else
                    {
                        dataGridViewPovrchy.CurrentCell = null;
                        oRow.Visible = false;
                    }
                }
            }
        }


        private void btnPridatPovrch_Click(object sender, EventArgs e)
        {
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            this.Hide();
            List<Face> oFaces = AddinGlobal.GetFaceMultiple(SelectionFilterEnum.kPartFaceFilter);
            foreach (Face oFace in oFaces)
            {
                if (oFace != null)
                {
                    try
                    {
                        Povrch oPovrch = new Povrch(oFace, oTyp, oPk.lContext);
                        oPk.Povrchy.Add(oPovrch);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                   
                }
            }

            
            this.Show();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewPovrchy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridViewPovrchy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (dataGridViewPovrchy.Columns[e.ColumnIndex].Name == "Typ_pohladu")
            {
                Typ_pohladu enumValue = (Typ_pohladu)e.Value;
                string enumstring = enumValue.ToString(0);
                e.Value = enumstring;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPovrchy.SelectedCells != null)
            {
                foreach (DataGridViewCell oCell in dataGridViewPovrchy.SelectedCells)
                {
                    DataGridViewRow oRow = oCell.OwningRow;

                    Povrch vybraneMeranie = (Povrch)oRow.DataBoundItem;
                    oPk.Povrchy.Remove(vybraneMeranie);
                }
                dataGridViewPovrchy.Refresh();
            }
        }

        private void chBoxTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxTop.Checked)
            {
                AddinGlobal.oSetFaces.Clear();
                oTyp = Typ_pohladu.kTop;
                AddinGlobal.SetCameraToView(ViewOrientationTypeEnum.kRightViewOrientation);
                btnPridatPovrch.Enabled = true;
                chBoxSide.Checked = false;
                chBoxBottom.Checked = false;
                dataGridViewPovrchy.Columns["Text"].Visible = true;

                dataGridViewPovrchy.Columns["Drazka"].Visible = true;

                //filter
                dataGridViewPovrchy.ClearSelection();
                foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
                {
                    if (oRow.Cells[0].Value.ToString().Contains("kTop"))
                    {
                        oRow.Visible = true;
                    }
                    else
                    {
                        dataGridViewPovrchy.CurrentCell = null;
                        oRow.Visible = false;
                    }
                }

            }
        }

        private void chBoxBottom_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxBottom.Checked)
            {
                AddinGlobal.oSetFaces.Clear();
                oTyp = Typ_pohladu.kBottom;
                AddinGlobal.SetCameraToView(ViewOrientationTypeEnum.kLeftViewOrientation);
                btnPridatPovrch.Enabled = true;
                chBoxTop.Checked = false;
                chBoxSide.Checked = false;
                dataGridViewPovrchy.Columns["Text"].Visible = true;

                dataGridViewPovrchy.Columns["Drazka"].Visible = true;

            }

            //filter
            dataGridViewPovrchy.ClearSelection();
            foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
            {
                if (oRow.Cells[0].Value.ToString().Contains("kBottom"))
                {
                    oRow.Visible = true;
                }
                else
                {
                    dataGridViewPovrchy.CurrentCell = null;
                    oRow.Visible = false;
                }
            }
        }

        private void chBoxSide_CheckedChanged(object sender, EventArgs e)
        {
            AddinGlobal.oSetFaces.Clear();
            
            if (chBoxSide.Checked)
            {
                AddinGlobal.oSetFaces.Clear();
                oTyp = Typ_pohladu.kSide;
                AddinGlobal.SetCameraToView(ViewOrientationTypeEnum.kFrontViewOrientation);
                btnPridatPovrch.Enabled = true;
                chBoxTop.Checked = false;
                chBoxBottom.Checked = false;
                dataGridViewPovrchy.Columns["Text"].Visible = false;

                dataGridViewPovrchy.Columns["Drazka"].Visible = false;

            }
            //filter
            dataGridViewPovrchy.ClearSelection();
            foreach (DataGridViewRow oRow in dataGridViewPovrchy.Rows)
            {
                if (oRow.Cells[0].Value.ToString().Contains("kSide"))
                {
                    oRow.Visible = true;
                }
                else
                {
                    dataGridViewPovrchy.CurrentCell = null;
                    oRow.Visible = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewPovrchy_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dataGridViewPovrchy.Rows.GetRowCount(DataGridViewElementStates.Selected);
            AddinGlobal.oSetFaces.Clear();
            if (selectedRowCount > 0)
            {
               
                foreach (DataGridViewRow oRow in dataGridViewPovrchy.SelectedRows)
                {
                    if (oRow.Visible == true)
                    {
                        Povrch vybraneMeranie = (Povrch)oRow.DataBoundItem;

                        Face oFace1 = AddinGlobal.GetFaceFromReferenceKey(vybraneMeranie.Face1RefKey, AddinGlobal.lContextHelper) as Face;
                        AddinGlobal.oSetFaces.AddItem(oFace1);
                    }
                }
                
            }
        }
    }
}
