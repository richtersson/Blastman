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
    public partial class Tabulka_rezov : Form
    {
        public Tabulka_rezov()
        {
            InitializeComponent();
        }

        private void Tabulka_rezov_Load(object sender, EventArgs e)
        {

            //tabulka na prezeranie
            if (AddinGlobal.AktivnyPredpisKontroly.Stav != 0)
            {
                btnPridatRez.Enabled = false;
                btnVymazatRez.Enabled = false;
                dataGridViewTabulkaRezov.ReadOnly = true;
            }


            if (AddinGlobal.oSetWorkplanes == null)
            {
                Inventor.Color oBlue = AddinGlobal.InventorApp.TransientObjects.CreateColor(0, 255, 0, 0.25);
                AddinGlobal.oSetWorkplanes = AddinGlobal.InventorApp.ActiveDocument.CreateHighlightSet();
                AddinGlobal.oSetWorkplanes.Color = oBlue;
            }
            else
                AddinGlobal.oSetWorkplanes.Clear();
            AddinGlobal.oSetFaces.Clear();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;
            if (AddinGlobal.rezy == null)
            {
                AddinGlobal.rezy = new Rezy();
            }

            dataGridViewTabulkaRezov.DataSource = AddinGlobal.rezy.ZoznamRezov;
            dataGridViewTabulkaRezov.Columns["TypRezu"].Visible = false;
            dataGridViewTabulkaRezov.Columns["PlaneRefKey"].Visible = false;
            dataGridViewTabulkaRezov.Columns["ID_Rezu"].Visible = false;
            dataGridViewTabulkaRezov.Columns["DXF"].Visible = false;
            dataGridViewTabulkaRezov.Columns["Origin"].Visible = false;
            dataGridViewTabulkaRezov.Columns["X"].Visible = false;
            dataGridViewTabulkaRezov.Columns["Y"].Visible = false;
            dataGridViewTabulkaRezov.Columns["Z"].Visible = false;
            dataGridViewTabulkaRezov.Columns["LavyBod"].Visible = false;
            dataGridViewTabulkaRezov.Columns["PravyBod"].Visible = false;
            dataGridViewTabulkaRezov.Columns["LavyBodRefKey"].Visible = false;
            dataGridViewTabulkaRezov.Columns["PravyBodRefKey"].Visible = false;

            dataGridViewTabulkaRezov.Columns["NazovRoviny"].HeaderText = "Názov rezovej roviny";
            dataGridViewTabulkaRezov.Columns["NazovRezu"].HeaderText = "Názov rezu";
            dataGridViewTabulkaRezov.Columns["Perioda"].HeaderText = "Perióda opakovanie v deg";

            dataGridViewTabulkaRezov.Columns["NazovRezu"].DisplayIndex = 0;
            dataGridViewTabulkaRezov.Columns["NazovRoviny"].DisplayIndex = 2;
            dataGridViewTabulkaRezov.Columns["Perioda"].DisplayIndex = 1;

            dataGridViewTabulkaRezov.Columns["NazovRoviny"].ReadOnly = true;

            //columns for point buttons in editable state
            if (AddinGlobal.AktivnyPredpisKontroly.Stav != 0)
            {
                DataGridViewTextBoxColumn btn = new DataGridViewTextBoxColumn();
                btn.DisplayIndex = 4;
                dataGridViewTabulkaRezov.Columns.Add(btn);
                btn.HeaderText = "Ľavý bod";
                
                btn.Name = "btnLavyBod";


                DataGridViewTextBoxColumn btn2 = new DataGridViewTextBoxColumn();
                btn2.DisplayIndex = 5;
                dataGridViewTabulkaRezov.Columns.Add(btn2);
                btn2.HeaderText = "Pravý bod";

                btn2.Name = "btnPravyBod";
            
            }
            else
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.DisplayIndex = 4;
                dataGridViewTabulkaRezov.Columns.Add(btn);
                btn.HeaderText = "Ľavý bod";
                btn.Text = "Vybrať bod";
                btn.Name = "btnLavyBod";
                btn.FlatStyle = FlatStyle.Popup;
                btn.UseColumnTextForButtonValue = false;

                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn2.DisplayIndex = 5;
                dataGridViewTabulkaRezov.Columns.Add(btn2);
                btn2.HeaderText = "Pravý bod";
                btn2.Text = "Vybrať bod";
                btn2.Name = "btnPravyBod";
                btn2.FlatStyle = FlatStyle.Popup;
                
                btn2.UseColumnTextForButtonValue = false;
            }
            FormatButtons();

        }

        private void FormatButtons()
        {
            foreach (DataGridViewRow row in dataGridViewTabulkaRezov.Rows)
            {
                Rez oRez = (Rez)row.DataBoundItem;


                DataGridViewCell cell = row.Cells["btnLavyBod"];//Column Index
                if (oRez.LavyBodRefKey == "" || oRez.LavyBodRefKey == null)
                {
                    cell.Value = "Vybrať bod";

                    cell.Style.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    cell.Value = "Bod je vybratý";
                    cell.Style.BackColor = System.Drawing.Color.FromName(KnownColor.Window.ToString());
                }

                DataGridViewCell cell2 = row.Cells["btnPravyBod"];//Column Index
                if (oRez.PravyBodRefKey == "" || oRez.PravyBodRefKey == null)
                {
                    cell2.Value = "Vybrať bod";
                    cell2.Style.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    cell2.Value = "Bod je vybratý";
                    cell2.Style.BackColor = System.Drawing.Color.FromName(KnownColor.Window.ToString());
                }

                if (oRez.TypRezu == Typ_rezu.kCharakteristicky || oRez.TypRezu == Typ_rezu.kPolohovaci||!(oRez.Origin.X == 0 && oRez.Origin.Y == 0 && oRez.Origin.Z == 0))
                {

                    var dataGridViewCellStyle2 = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                    cell.Style = dataGridViewCellStyle2;
                    cell2.Style = dataGridViewCellStyle2;
                }
              
            }
        }

        private void btnPridatRez_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;   
            try
            {
                Rez rez = new Rez(Typ_rezu.kPomocny);

                AddinGlobal.rezy.ZoznamRezov.Add(rez);
                dataGridViewTabulkaRezov.Refresh();
                FormatButtons();
            }
            catch
            { }
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;
            this.Show();

        }

        private void btnVymazatRez_Click(object sender, EventArgs e)
        {
            if (dataGridViewTabulkaRezov.SelectedCells != null)
            {
                foreach (DataGridViewCell oCell in dataGridViewTabulkaRezov.SelectedCells)
                {
                    DataGridViewRow oRow = oCell.OwningRow;

                    Rez oRez = (Rez)oRow.DataBoundItem;

                    foreach (Meranie oMeranie in AddinGlobal.AktivnyPredpisKontroly.Merania)
                    {
                        if (oMeranie.Rez1 == oRez || oMeranie.Rez2 == oRez)
                        {
                            MessageBox.Show("Vybraný rez je použitý v meraniach. Vymazanie nie je dovolené. Vymažte najprv dotknuté merania.");
                            return;
                        }
                    }

                    AddinGlobal.rezy.ZoznamRezov.Remove(oRez);
                }
                dataGridViewTabulkaRezov.Refresh();
            }
        }

       

        private void Tabulka_rezov_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddinGlobal.oSetFaces.Clear();
            AddinGlobal.oSetWorkplanes.Clear();
            AddinGlobal.oSetPoints.Clear();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled =false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTabulkaRezov_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AddinGlobal.oSetPoints.Clear();
            
            AddinGlobal.oSetWorkplanes.Clear();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow oRow = dataGridViewTabulkaRezov.Rows[e.RowIndex];
                Rez vybraneMeranie = (Rez)oRow.DataBoundItem;

                WorkPlane oWP1 = AddinGlobal.GetWorkplaneFromReferenceKey(vybraneMeranie.PlaneRefKey) as WorkPlane;

                if (oWP1 != null)
                    AddinGlobal.oSetWorkplanes.AddItem(oWP1);
                if (vybraneMeranie.LavyBodRefKey!=null && vybraneMeranie.LavyBodRefKey!="")
                AddinGlobal.HighlightPoint(vybraneMeranie.LavyBodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);
                if (vybraneMeranie.PravyBodRefKey != null && vybraneMeranie.LavyBodRefKey != "")
                    AddinGlobal.HighlightPoint(vybraneMeranie.PravyBodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);
            }
        }

        
        private void dataGridViewTabulkaRezov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (AddinGlobal.AktivnyPredpisKontroly.Stav == 0)
            {
                if (e.ColumnIndex == dataGridViewTabulkaRezov.Columns["btnLavyBod"].Index)
                {
                    //Do Something with your button.
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow oRow = dataGridViewTabulkaRezov.Rows[e.RowIndex];
                        Rez vybraneMeranie = (Rez)oRow.DataBoundItem;
                       
                        if (vybraneMeranie.LoadPoints(true))
                        {
                            FormatButtons();
                            //oRow.Cells["btnLavyBod"].Value = "Bod je vybratý";
                            AddinGlobal.HighlightPoint(vybraneMeranie.LavyBodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);
                        }
                        
                    }


                }
                if (e.ColumnIndex == dataGridViewTabulkaRezov.Columns["btnPravyBod"].Index)
                {
                    //Do Something with your button.
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow oRow = dataGridViewTabulkaRezov.Rows[e.RowIndex];
                        Rez vybraneMeranie = (Rez)oRow.DataBoundItem;
                        
                        if (vybraneMeranie.LoadPoints(false))
                        {
                            FormatButtons();
                            //oRow.Cells["btnPravyBod"].Value = "Bod je vybratý";
                            AddinGlobal.HighlightPoint(vybraneMeranie.PravyBodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);
                        }
                        
                    }
                }
            }
        }
    }
}
