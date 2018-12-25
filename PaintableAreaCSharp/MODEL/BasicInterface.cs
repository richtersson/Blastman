using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;

namespace Blastman
{
    public partial class BasicInterface : Form
    {
        AdnTabIndexManager _TabIndexManager;
        public BasicInterface(Predpis_kontroly oPredpis)
        {
            InitializeComponent();
            _TabIndexManager = new AdnTabIndexManager(this);
            pk = oPredpis;
        }

        private void BasicInterface_Load(object sender, EventArgs e)
        {
            //controls turning off to viewing regime
            if (pk.Stav != 0)
            {
                btnCharakteristickyRez.Enabled = false;
                btnExport.Enabled = false;
                btnPolohovaciRez.Enabled = false;
                btnPridatMeranie.Enabled = false;
                btnSavePredpisKontroly.Enabled = false;
                btnUpravMeranie.Enabled = false;
                btnVymazMeranie.Enabled = false;
                chBoxSkupTolPovrch.Enabled = false;
                chBoxSkupTolRadius.Enabled = false;
                chBoxSkupTolUhol.Enabled = false;
                chBoxSkupTolVzd.Enabled = false;
                txtSkupPovrchChyby.ReadOnly = true;
                txtSkupRadiusMinus.ReadOnly = true;
                txtSkupRadiusPlus.ReadOnly = true;
                txtSkupUholMinus.ReadOnly = true;
                txtSkupUholPlus.ReadOnly = true;
                txtSkupVzdMinus.ReadOnly = true;
                txtSkupVzdPlus.ReadOnly = true;
            }
            

            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;


            if (AddinGlobal.oSetFaces == null)
            {
                Inventor.Color oRed = AddinGlobal.InventorApp.TransientObjects.CreateColor(255, 0, 0, 0.4);
                AddinGlobal.oSetFaces = AddinGlobal.InventorApp.ActiveDocument.CreateHighlightSet();
                AddinGlobal.oSetFaces.Color = oRed;
            }
                
            if (AddinGlobal.rezy == null)
            {
                AddinGlobal.rezy = new Rezy();
            }

        
            //controls binding



            txtBoxCisloVykresu.DataBindings.Add("Text", this.pk, "CisloVykresu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBoxNazovPredpisuKontroly.DataBindings.Add("Text", this.pk, "Nazov", false, DataSourceUpdateMode.OnPropertyChanged);

            
            txtSkupVzdPlus.DataBindings.Add("Text", this.pk, "SkupVzdPlus", false, DataSourceUpdateMode.OnValidation);
            
            txtSkupVzdMinus.DataBindings.Add("Text", this.pk, "SkupVzdMinus", false, DataSourceUpdateMode.OnValidation);
            txtSkupUholPlus.DataBindings.Add("Text", this.pk, "SkupUholPlus", false, DataSourceUpdateMode.OnValidation);
            txtSkupUholMinus.DataBindings.Add("Text", this.pk, "SkupUholMinus", false, DataSourceUpdateMode.OnValidation);
            txtSkupRadiusPlus.DataBindings.Add("Text", this.pk, "SkupRadiusPlus", false, DataSourceUpdateMode.OnValidation);
            txtSkupRadiusMinus.DataBindings.Add("Text", this.pk, "SkupRadiusMinus", false, DataSourceUpdateMode.OnValidation);
            txtSkupPovrchChyby.DataBindings.Add("Text", this.pk, "SkupPovrchChyby", false, DataSourceUpdateMode.OnValidation);

       
            lblModelPath.DataBindings.Add("Text", this.pk, "ModelFileName",false, DataSourceUpdateMode.OnPropertyChanged);


            cBoxTypMerania.DataSource = Enum.GetValues(typeof(Typ_merania));
            cBoxTypMerania.FormattingEnabled = true;
            
            
            
            //datagridview settings
            dataGridViewMerania.DataSource = pk.Merania;
            dataGridViewMerania.Columns["Typ_tolerancie"].Visible = false;
            dataGridViewMerania.Columns["NominalValue"].Visible = false;
            dataGridViewMerania.Columns["Saved"].Visible = false;
            dataGridViewMerania.Columns["ID_Merania"].Visible = false;
            dataGridViewMerania.Columns["Typ_skupinovej_tolerancie"].Visible = false;
            dataGridViewMerania.Columns["KodChyby"].Visible = false;
            dataGridViewMerania.Columns["Navestie1"].Visible = false;
            dataGridViewMerania.Columns["Navestie2"].Visible = false;
            dataGridViewMerania.Columns["Navestie3"].Visible = false;
            dataGridViewMerania.Columns["DXF1"].Visible = false;
            dataGridViewMerania.Columns["DXF2"].Visible = false;
            dataGridViewMerania.Columns["Rez1"].Visible = false;
            dataGridViewMerania.Columns["Rez2"].Visible = false;
            dataGridViewMerania.Columns["PouzitaSkupinovaTolerancia"].Visible = false;

            dataGridViewMerania.Columns["Typ_merania"].HeaderText = "Typ merania";
            dataGridViewMerania.Columns["NazovMerania"].HeaderText = "Názov merania";
            dataGridViewMerania.Columns["NazovMerania"].DisplayIndex = 1;


            Typ_merania typ;
            Enum.TryParse<Typ_merania>(cBoxTypMerania.SelectedValue.ToString(),out typ);
           

            //povolne skupinových tolerancií
            if(txtSkupVzdPlus.Text!="0"||txtSkupVzdMinus.Text!="0")
            {
                chBoxSkupTolVzd.Checked = true;
            }
            if (txtSkupUholPlus.Text != "0" || txtSkupUholMinus.Text != "0")
            {
                chBoxSkupTolUhol.Checked = true;
            }
            if (txtSkupRadiusPlus.Text != "0" || txtSkupRadiusMinus.Text != "0")
            {
                chBoxSkupTolRadius.Checked = true;
            }
            if (txtSkupPovrchChyby.Text != "0")
            {
                chBoxSkupTolPovrch.Checked = true;
            }


           


        }

        private void cBoxTypMerania_Format(object sender, ListControlConvertEventArgs e)
        {

            e.Value = AddinGlobal.GetDescription<Typ_merania>((Typ_merania)e.Value);
        }

        private void btnCharakteristickaRovina_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            if (AddinGlobal.rezy == null)
            {
                AddinGlobal.rezy = new Rezy();
            }
            try {
                pk.CharakteristickyRez = new Rez(Typ_rezu.kCharakteristicky, pk.oCompDef);
                pk.CharakteristickyRez.NazovRezu = "Charakteristický rez";

                //duplicite Rez
                Rez oRez = AddinGlobal.rezy.ZoznamRezov.SingleOrDefault(p => p.TypRezu == pk.CharakteristickyRez.TypRezu);
                if (oRez == null)
                {

                    AddinGlobal.rezy.ZoznamRezov.Add(pk.CharakteristickyRez);
                }
                else
                {
                    int i = AddinGlobal.rezy.ZoznamRezov.IndexOf(oRez);
                    AddinGlobal.rezy.ZoznamRezov[i] = pk.CharakteristickyRez;
                }


            }
            catch { }
            
            this.Show();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Validate();
            //kontrola vyplnených tolerancií
            if (chBoxSkupTolVzd.Checked)
            {
                if (txtSkupVzdPlus.Text=="0" && txtSkupVzdMinus.Text =="0")
                {
                    MessageBox.Show("Aktivované skupinové tolerancie s nulovou hodnotou. Vypnite používanie skupinových tolerancií, alebo zadajte hodnoty.");
                    return;
                }
            }
            if (chBoxSkupTolUhol.Checked)
            {
                if (txtSkupUholPlus.Text == "0" && txtSkupUholMinus.Text == "0")
                {
                    MessageBox.Show("Aktivované skupinové tolerancie s nulovou hodnotou. Vypnite používanie skupinových tolerancií, alebo zadajte hodnoty.");
                    return;
                }
            }
            if (chBoxSkupTolRadius.Checked)
            {
                if (txtSkupRadiusPlus.Text == "0" && txtSkupRadiusMinus.Text == "0")
                {
                    MessageBox.Show("Aktivované skupinové tolerancie s nulovou hodnotou. Vypnite používanie skupinových tolerancií, alebo zadajte hodnoty.");
                    return;
                }
            }

            pk.Export();
           


        }

        private void cBoxTypTolerancie_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = AddinGlobal.GetDescription<Typ_tolerancie>((Typ_tolerancie)e.Value);
        }

        private void cBoxTypMerania_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void btnPridatMeranie_Click(object sender, EventArgs e)
        {
            if (AddinGlobal.rezy.ZoznamRezov.Count > 0)
            {
                AddinGlobal.oSetFaces.Clear();
                
                
                //pridelenie naźvu merania
                string nazov="";
                for (int i = 0; i < 200; i++)
                {
                    int iteracia = i + 1;
                    nazov = "M" + iteracia.ToString("00");
                    bool obsadene = false;
                    foreach (Meranie oMeranie in pk.Merania)
                    {
                        if (oMeranie.NazovMerania == nazov)
                        {
                            obsadene = true;
                        }
                        
                    }
                    if (obsadene)
                    {

                    }
                    else
                    {
                        break;
                    }

                }


                AddinGlobal.AktivneMeranie = new Meranie((Typ_merania)cBoxTypMerania.SelectedValue, nazov);
                PridanieMerania pm = new PridanieMerania(AddinGlobal.AktivneMeranie,pk.Stav);

                pm.FormClosed += new FormClosedEventHandler(pm_FormClosed);

                this.Hide();
                pm.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            }
            else
                MessageBox.Show("Nie sú definované žiadne rezy.");
            
            
            
            
            
        }
        private void pm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //if Meranie is saved
            if (AddinGlobal.AktivneMeranie.Saved == true)
            {
               
                    //update of existing Meranie
                Meranie oMeranie = pk.Merania.SingleOrDefault(p => p.ID_Merania == AddinGlobal.AktivneMeranie.ID_Merania);
                if (oMeranie==null)
                    {

                        pk.Merania.Add(AddinGlobal.AktivneMeranie);
                    }
                else
                {
                    int i = pk.Merania.IndexOf(oMeranie);
                    pk.Merania[i] = AddinGlobal.AktivneMeranie;
                }
                    
                
               

                this.Refresh();
            }
            this.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            
        }
        private void tr_FormClosed(object sender, FormClosedEventArgs e)
        {

            //if Meranie is saved
           
            this.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));

        }
        private void oPovrchy_FormClosed(object sender, FormClosedEventArgs e)
        {

            //if Meranie is saved

            this.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));

        }





        private void button1_Click(object sender, EventArgs e)
        {
            pk.Merania.Add(AddinGlobal.AktivneMeranie);
        }

        private void dataGridViewMerania_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (e.Value == null)
                return;
           if (dataGridViewMerania.Columns[e.ColumnIndex].Name=="Typ_merania")
            { 
               Typ_merania enumValue = (Typ_merania)e.Value ;
               string enumstring = enumValue.ToString(0);
               e.Value = enumstring ;
             }
           if (dataGridViewMerania.Columns[e.ColumnIndex].Name == "Rez1")
           {
               Rez enumValue = (Rez)e.Value;
               string enumstring = enumValue.NazovRezu;
               e.Value = enumstring;
           }
           if (dataGridViewMerania.Columns[e.ColumnIndex].Name == "Rez2")
           {
               Rez enumValue = (Rez)e.Value;
               string enumstring = enumValue.NazovRezu;
               e.Value = enumstring;
           }
        }

        private void dataGridViewMerania_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddinGlobal.oSetFaces.Clear();
            AddinGlobal.oSetWorkplanes.Clear();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow oRow = dataGridViewMerania.Rows[e.RowIndex];
                Meranie vybraneMeranie = (Meranie)oRow.DataBoundItem;

                Face oFace1 = AddinGlobal.GetFaceFromReferenceKey(vybraneMeranie.Face1RefKey, pk.lContext) as Face;
                Face oFace2 = AddinGlobal.GetFaceFromReferenceKey(vybraneMeranie.Face2RefKey, pk.lContext) as Face;
                WorkPlane oWP1=null;
                WorkPlane oWP2=null;
                if (vybraneMeranie.Rez1!= null) oWP1 = AddinGlobal.GetWorkplaneFromReferenceKey(vybraneMeranie.Rez1.PlaneRefKey) as WorkPlane;
                if (vybraneMeranie.Rez2!= null) oWP2 = AddinGlobal.GetWorkplaneFromReferenceKey(vybraneMeranie.Rez2.PlaneRefKey) as WorkPlane;
                pk.HighlightFaces(oFace1, oFace2);
                pk.HighlightWorkplanes(oWP1, oWP2);
            }
        }

        private void BasicInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            AddinGlobal.oSetFaces.Clear();
            AddinGlobal.oSetWorkplanes.Clear();
            

        }

        private void btnVymazMeranie_Click(object sender, EventArgs e)
        {
            if (dataGridViewMerania.SelectedCells!=null)
            {
                foreach (DataGridViewCell oCell in dataGridViewMerania.SelectedCells)
                {
                    DataGridViewRow oRow = oCell.OwningRow;
                    
                    Meranie vybraneMeranie = (Meranie)oRow.DataBoundItem;
                    pk.Merania.Remove(vybraneMeranie);
                }
                dataGridViewMerania.Refresh();
            }
        }

        private void btnUpravMeranie_Click(object sender, EventArgs e)
        {
            AddinGlobal.oSetFaces.Clear();
            Meranie vybraneMeranie;
            if (dataGridViewMerania.SelectedCells != null)
            {
                DataGridViewRow oRow = dataGridViewMerania.SelectedCells[0].OwningRow;

                vybraneMeranie = (Meranie)oRow.DataBoundItem;
            
                AddinGlobal.AktivneMeranie = vybraneMeranie;
                PridanieMerania pm = new PridanieMerania(AddinGlobal.AktivneMeranie,pk.Stav);

                pm.FormClosed += new FormClosedEventHandler(pm_FormClosed);

                this.Hide();
                pm.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            }
        }

        private void btnPolohovaciRez_Click(object sender, EventArgs e)
        {
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            this.Hide();
            if (AddinGlobal.rezy == null)
            {
                AddinGlobal.rezy = new Rezy();
            }
            try
            {
                pk.PolohovaciRez = new Rez(Typ_rezu.kPolohovaci, pk.oCompDef);
                pk.PolohovaciRez.NazovRezu = "Polohovací rez";
                //duplicite Rez
                Rez oRez = AddinGlobal.rezy.ZoznamRezov.SingleOrDefault(p => p.TypRezu == pk.PolohovaciRez.TypRezu);
                if (oRez == null)
                {

                    AddinGlobal.rezy.ZoznamRezov.Add(pk.PolohovaciRez);
                }
                else
                {
                    int i = AddinGlobal.rezy.ZoznamRezov.IndexOf(oRez);
                    AddinGlobal.rezy.ZoznamRezov[i] = pk.PolohovaciRez;
                }
            }
            catch
            { }
           
            this.Show();
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;
        }

        private void btnTabulkaRezov_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tabulka_rezov tr = new Tabulka_rezov();
            tr.FormClosed += new FormClosedEventHandler(tr_FormClosed);

            this.Hide();
            tr.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));

        }

        private void btnSavePredpisKontroly_Click(object sender, EventArgs e)
        {
            
            AddinGlobal.InventorApp.ActiveDocument.Save();
            pk.Save(true);
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Validate();
            if (pk.Stav == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Chcete uložiť zmeny?", "Upozornenie", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    pk.Save(false);
                    AddinGlobal.InventorApp.ActiveDocument.Save();
                    AddinGlobal.InventorApp.ActiveDocument.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                    AddinGlobal.InventorApp.ActiveDocument.Close();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    
                }
            }
            else
            {
                this.Close();
               
                AddinGlobal.InventorApp.ActiveDocument.Close();
            }
        }


            
        

        private void chBoxSkupTolVzd_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSkupTolVzd.Checked == false)
            {
                this.ActiveControl = txtSkupVzdMinus;
                txtSkupVzdMinus.Text = "0";
                this.ActiveControl = txtSkupVzdPlus;
                txtSkupVzdPlus.Text = "0";
            }
            txtSkupVzdMinus.Enabled = chBoxSkupTolVzd.Checked;
            txtSkupVzdPlus.Enabled = chBoxSkupTolVzd.Checked;
            
        }

        private void chBoxSkupTolUhol_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSkupTolUhol.Checked == false)
            {
                this.ActiveControl = txtSkupUholMinus;
                txtSkupUholMinus.Text = "0";
                this.ActiveControl = txtSkupUholPlus;
                txtSkupUholPlus.Text = "0";
            }
            txtSkupUholMinus.Enabled = chBoxSkupTolUhol.Checked;
            txtSkupUholPlus.Enabled = chBoxSkupTolUhol.Checked;
           
        }

        private void chBoxSkupTolRadius_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSkupTolRadius.Checked == false)
            {
                this.ActiveControl = txtSkupRadiusPlus;
                txtSkupRadiusPlus.Text = "0";
                this.ActiveControl = txtSkupRadiusMinus;
                txtSkupRadiusMinus.Text = "0";
            }
            txtSkupRadiusPlus.Enabled = chBoxSkupTolRadius.Checked;
            txtSkupRadiusMinus.Enabled = chBoxSkupTolRadius.Checked;
           
        }

        private void chBoxSkupTolPovrch_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSkupTolPovrch.Checked == false)
            {
                this.ActiveControl = txtSkupPovrchChyby;
                txtSkupPovrchChyby.Text = "0";

            }
            txtSkupPovrchChyby.Enabled = chBoxSkupTolPovrch.Checked;
           

        }

        private void btnKontrolaKvalityPovrchov_Click(object sender, EventArgs e)
        {

            this.Hide();
            Povrchy oPovrchy = new Povrchy(this.pk);
            oPovrchy.FormClosed += new FormClosedEventHandler(tr_FormClosed);

            this.Hide();
            oPovrchy.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            AddinGlobal.oSetFaces.Clear();
        }

        private void dataGridViewMerania_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            AddinGlobal.oSetFaces.Clear();
            AddinGlobal.oSetWorkplanes.Clear();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow oRow = dataGridViewMerania.Rows[e.RowIndex];
                Meranie vybraneMeranie = (Meranie)oRow.DataBoundItem;

                Face oFace1 = AddinGlobal.GetFaceFromReferenceKey(vybraneMeranie.Face1RefKey, pk.lContext) as Face;
                Face oFace2 = AddinGlobal.GetFaceFromReferenceKey(vybraneMeranie.Face2RefKey, pk.lContext) as Face;
                WorkPlane oWP1 = null;
                WorkPlane oWP2 = null;
                if (vybraneMeranie.Rez1 != null) oWP1 = AddinGlobal.GetWorkplaneFromReferenceKey(vybraneMeranie.Rez1.PlaneRefKey) as WorkPlane;
                if (vybraneMeranie.Rez2 != null) oWP2 = AddinGlobal.GetWorkplaneFromReferenceKey(vybraneMeranie.Rez2.PlaneRefKey) as WorkPlane;
                pk.HighlightFaces(oFace1, oFace2);
                pk.HighlightWorkplanes(oWP1, oWP2);
            }
        }

        private void BasicInterface_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                bool charrez = false;
                bool polrez = false;
                foreach (Rez oRez in AddinGlobal.rezy.ZoznamRezov)
                {
                    if (oRez.TypRezu == Typ_rezu.kCharakteristicky)
                    {
                        charrez = true;
                    }
                    if (oRez.TypRezu == Typ_rezu.kPolohovaci)
                    {
                        polrez = true;
                    }

                }
                if (charrez)
                    lblCharRez.Text = "Charakteristický rez je určený.";
                else
                    lblCharRez.Text = "";
                if (polrez)
                    lblPolohovaciRez.Text = "Polohovací rez je určený.";
                else
                    lblPolohovaciRez.Text = "";
            }
            catch
            { }
        }

        private void dataGridViewMerania_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (pk.Stav ==0)
            btnUpravMeranie_Click(this, EventArgs.Empty);
        }
       
    }
}
