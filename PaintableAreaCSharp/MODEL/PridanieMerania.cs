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
    public partial class PridanieMerania : Form
    {
        private Meranie AktivneMeranie;
        public bool MeranieSaved = false;
        private int KeyContext;
        AdnTabIndexManager _TabIndexManager;
        private int Stav;
        private SelectionFilterEnum oSelFilter = SelectionFilterEnum.kPartFaceFilter;
        public PridanieMerania(Meranie meranie, int StavPredpisu)
        {
            InitializeComponent();
            AktivneMeranie = meranie;
            Stav = StavPredpisu;

        }



        private void PridanieMerania_Load(object sender, EventArgs e)
        {
            _TabIndexManager = new AdnTabIndexManager(this);
            txtNominalValue.Text = AktivneMeranie.NominalValue.ToString();

            //viewing mode
            if (Stav!=0)
            {
                btnEntityOne.Enabled = false;
                btnEntityTwo.Enabled = false;
                btnSaveMeranie.Enabled = false;
                btnUlozMeranie.Enabled = false;
                txtNavestieOne.ReadOnly = true;
                txtNavestieTwo.ReadOnly = true;
                txtNavestieThree.ReadOnly = true;
                txtNazovMerania.ReadOnly = true;
                chBoxSkupinoveTolerancie.Enabled = false;
                cBoxPrvyRez.Enabled = false;
                cBoxDruhyRez.Enabled = false;
                cBoxKodChyby.Enabled = false;
                
            }



            //binding textboxes
            //txtNominalValue.DataBindings.Add("Text", this.AktivneMeranie, "NominalValue", false, DataSourceUpdateMode.OnPropertyChanged);
            txtNavestieOne.DataBindings.Add("Text", this.AktivneMeranie, "Navestie1", false, DataSourceUpdateMode.OnValidation);
            txtNavestieTwo.DataBindings.Add("Text", this.AktivneMeranie, "Navestie2", false, DataSourceUpdateMode.OnValidation);
            txtNavestieThree.DataBindings.Add("Text", this.AktivneMeranie, "Navestie3", false, DataSourceUpdateMode.OnValidation);
            txtNazovMerania.DataBindings.Add("Text", this.AktivneMeranie, "NazovMerania", false, DataSourceUpdateMode.OnPropertyChanged);

            //binding comboboxes



            cBoxPrvyRez.DataSource = new BindingSource(AddinGlobal.rezy.ZoznamRezov, null);
            cBoxDruhyRez.DataSource = new BindingSource(AddinGlobal.rezy.ZoznamRezov, null);
            cBoxPrvyRez.DisplayMember = "NazovRezu";
            cBoxDruhyRez.DisplayMember = "NazovRezu";
            if (AktivneMeranie.Rez1 != null)
            {
                cBoxPrvyRez.SelectedIndex = cBoxPrvyRez.FindString(AktivneMeranie.Rez1.NazovRezu);
            }
            else
            {
                if (AddinGlobal.LastRez1 != null)
                    cBoxPrvyRez.SelectedIndex = cBoxPrvyRez.FindString(AddinGlobal.LastRez1.NazovRezu);
            }
            if (AktivneMeranie.Rez2 != null)
            {
                cBoxDruhyRez.SelectedIndex = cBoxDruhyRez.FindString(AktivneMeranie.Rez2.NazovRezu);

            }
            else
            {
                if (AddinGlobal.LastRez2 != null)
                    cBoxDruhyRez.SelectedValue = cBoxDruhyRez.FindString(AddinGlobal.LastRez2.NazovRezu);
            }

            cBoxKodChyby.DataSource = AddinGlobal.KodyVad.DefaultView;
            cBoxKodChyby.DisplayMember = "chy_nazov";
            cBoxKodChyby.ValueMember = "chy_kod";
            cBoxKodChyby.BindingContext = this.BindingContext;

            if (AktivneMeranie.KodChyby != 0)
                cBoxKodChyby.SelectedValue = AktivneMeranie.KodChyby;
            

            //binding labels
            var binding = new Binding("Text", AktivneMeranie, "Typ_merania");
            binding.Format += delegate (object sentFrom, ConvertEventArgs convertEventArgs)
                              {
                                  convertEventArgs.Value = AddinGlobal.GetDescription<Typ_merania>((Typ_merania)convertEventArgs.Value);
                              };
            lblTyp_merania.DataBindings.Add(binding);

            var binding2 = new Binding("Text", AktivneMeranie, "Typ_tolerancie");
            binding2.Format += delegate (object sentFrom, ConvertEventArgs convertEventArgs)
            {
                convertEventArgs.Value = AddinGlobal.GetDescription<Typ_tolerancie>((Typ_tolerancie)convertEventArgs.Value);
            };
            lblTyp_tolerancie.DataBindings.Add(binding2);

            var binding3 = new Binding("Text", AktivneMeranie, "Typ_skupinovej_tolerancie");
            binding3.Format += delegate (object sentFrom, ConvertEventArgs convertEventArgs)
            {
                convertEventArgs.Value = AddinGlobal.GetDescription<Typ_skupinovej_tolerancie>((Typ_skupinovej_tolerancie)convertEventArgs.Value);
            };
            lblTypSkupinovejTolerancie.DataBindings.Add(binding3);


            //binding checkboxes
            chBoxSkupinoveTolerancie.DataBindings.Add("Checked", this.AktivneMeranie, "PouzitaSkupinovaTolerancia", false, DataSourceUpdateMode.OnPropertyChanged);

            //zobrazenie ploch v pripade ze su uz vybrane
            if (AktivneMeranie.Face1RefKey != null && AktivneMeranie.Face1RefKey != "")
            {
                Face oFace = AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face1RefKey, AddinGlobal.lContextHelper);
                if (oFace != null)
                    AddinGlobal.oSetFaces.AddItem(oFace);
            }
            if (AktivneMeranie.Face2RefKey != null && AktivneMeranie.Face2RefKey != "")
            {
                Face oFace = AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face2RefKey, AddinGlobal.lContextHelper);
                if (oFace != null)
                    AddinGlobal.oSetFaces.AddItem(oFace);
            }


            //zobrazenie tolerancí
            switch (AktivneMeranie.Typ_tolerancie)
            {
                case Typ_tolerancie.kSymmetry:
                    //tolerancie
                    txtNavestieOne.Visible = false;
                    txtNavestieTwo.Visible = true;
                    txtNavestieThree.Visible = true;
                    lblNavestie1.Visible = false;
                    lblNavestie1.Text = "Mínusová odchýlka";
                    lblNavestie2.Text = "Plusová odchýlka";
                    lblNavestie3.Text = "Mínusová odchýlka";
                    break;
                case Typ_tolerancie.kAbsoluteValue:
                    //tolerancie
                    txtNavestieOne.Visible = true;
                    txtNavestieTwo.Visible = false;
                    txtNavestieThree.Visible = false;
                    lblNavestie1.Visible = true;
                    lblNavestie2.Visible = false;
                    lblNavestie3.Visible = false;
                    lblNavestie1.Text = "Absolútna hodnota";
                    lblNavestie2.Text = "Plusová odchýlka";
                    lblNavestie3.Text = "Mínusová odchýlka";
                    break;
                case Typ_tolerancie.kStopa:
                    //tolerancie
                    txtNavestieOne.Visible = true;
                    txtNavestieTwo.Visible = true;
                    txtNavestieThree.Visible = true;
                    lblNavestie1.Visible = true;
                    lblNavestie2.Visible = true;
                    lblNavestie3.Visible = true;
                    lblNavestie1.Text = "Priemer";
                    lblNavestie2.Text = "Max šírka";
                    lblNavestie3.Text = "Max výška";
                    break;
                case Typ_tolerancie.kVyronok:
                    //tolerancie
                    txtNavestieOne.Visible = true;
                    txtNavestieTwo.Visible = true;
                    txtNavestieThree.Visible = false;
                    lblNavestie1.Visible = true;
                    lblNavestie2.Visible = true;
                    lblNavestie3.Visible = false;
                    lblNavestie1.Text = "Max výška";
                    lblNavestie2.Text = "Max šírka";
                    lblNavestie3.Text = "Max výška";
                    break;
                case Typ_tolerancie.kText:
                    //tolerancie
                    txtNavestieOne.Visible = true;
                    txtNavestieTwo.Visible = false;
                    txtNavestieThree.Visible = false;
                    lblNavestie1.Visible = true;
                    lblNavestie2.Visible = false;
                    lblNavestie3.Visible = false;
                    lblNavestie1.Text = "Max výška";
                    lblNavestie2.Text = "Max šírka";
                    lblNavestie3.Text = "Max výška";
                    break;
                default:
                    break;
            }

            //form design based on typ merania value
            switch (AktivneMeranie.Typ_merania)
            {
                case Typ_merania.kVzdialenostDvochPlochvJednejRovine:

                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;





                    break;
                case Typ_merania.kVzdialenostDvochPlochvDvochRovinach:

                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = true;
                    cBoxDruhyRez.Visible = true;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;



                    break;
                case Typ_merania.kPriemerValcovejPlochy:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;


                    //selection filter
                    oSelFilter = SelectionFilterEnum.kPartFaceCylindricalFilter;

                    break;
                case Typ_merania.kPriemerHranyKuzelovejPlochy:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;




                    break;
                case Typ_merania.kUholDvochPloch:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kUholDvochPlochV2Rovinach:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = true;
                    cBoxDruhyRez.Visible = true;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kRadiusZaoblenia:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    //selection filter
                    oSelFilter = SelectionFilterEnum.kPartFaceToroidalFilter;
                    break;
                case Typ_merania.kRadiusvPriesecniku:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kObvodovaHadzavost:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = true;
                    cBoxDruhyRez.Visible = true;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kStopaPoNastroji:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kVyronok:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kMeranieOblastiZnačenia:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kKruhovitostVonkajsiehoPriemeru:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kKuzelovitostVonkajsiehoPriemeru:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kRovnobeznostCiel:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kKolmostCela:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kVypuklostCela:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kPovrchoveDefekty:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kDrazkaOdOsi:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kDrazkaOdOsiBlizsieDNo:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kDrazkaOdOsiVzdialenejsieDNo:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kPlochaKBlizsejHrane:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kPlochaKVzdialenejsejHrane:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = true;
                    btnEntityTwo.Visible = true;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                case Typ_merania.kSirkaDrazkyVReze:
                    //plochy
                    lblEntityOne.Visible = true;
                    btnEntityOne.Visible = true;
                    lblEntityTwo.Visible = false;
                    btnEntityTwo.Visible = false;

                    //rezy
                    lblPrvyRez.Visible = true;
                    cBoxPrvyRez.Visible = true;
                    lblDruhyRez.Visible = false;
                    cBoxDruhyRez.Visible = false;
                    cBoxDruhyRez.Enabled = cBoxDruhyRez.Visible;
                    break;
                default:
                    break;
            }


        }

        private void cBoxTypTolerancie_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = AddinGlobal.GetDescription<Typ_tolerancie>((Typ_tolerancie)e.Value);
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void cBoxSkupinováTolerancia_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = AddinGlobal.GetDescription<Typ_skupinovej_tolerancie>((Typ_skupinovej_tolerancie)e.Value);
        }

        private void btnEntityOne_Click(object sender, EventArgs e)
        {
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            this.Hide();
            Selection2 oMySelect = new Selection2();
                switch (AktivneMeranie.Typ_merania)
                {
                    case Typ_merania.kPriemerValcovejPlochy:
                        Object oObject = oMySelect.PickOneEntity("Vyberte valcovú alebo kuželovú plochu", SelectionFilterEnum.kPartFaceCylindricalFilter,SelectionFilterEnum.kPartFaceConicalFilter);
                        Face oFace2 = oObject as Inventor.Face;
                        AddinGlobal.oSetFaces.AddItem(oFace2);
                        AddinGlobal.GetFaceReferenceKey(oFace2, ref AktivneMeranie.Face1RefKey, AddinGlobal.lContextHelper);
                        try
                        {
                            Cylinder oCylinder = oFace2.Geometry;
                            txtNominalValue.Text = (Math.Round(oCylinder.Radius * 2 * 10, 2)).ToString();
                        }
                        catch
                    {
                        txtNominalValue.Text = "0";
                    }
                        break;
                    case Typ_merania.kRadiusZaoblenia:
                        Face oFace = AktivneMeranie.GetFace(oSelFilter);
                        SurfaceTypeEnum test = oFace.SurfaceType;
                         AddinGlobal.oSetFaces.AddItem(oFace);
                         AddinGlobal.GetFaceReferenceKey(oFace, ref AktivneMeranie.Face1RefKey, AddinGlobal.lContextHelper);
                         Torus oTorus = oFace.Geometry;
                        double NominalValue;
                        NominalValue = Math.Round(oTorus.MinorRadius, 3) * 10;
                        if (NominalValue < 0)
                        {
                            NominalValue = Math.Abs(NominalValue);
                        }
                        txtNominalValue.Text = NominalValue.ToString();
                        break;


                    default:
                        Face oFace3 = AktivneMeranie.GetFace(oSelFilter);
                        AddinGlobal.oSetFaces.AddItem(oFace3);
                        AddinGlobal.GetFaceReferenceKey(oFace3, ref AktivneMeranie.Face1RefKey, AddinGlobal.lContextHelper);
                    break;
                
            }
            this.Show();

        }
        private void btnEntityTwo_Click(object sender, EventArgs e)
        {
            //AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = false;
            this.Hide();
            Face oFace = AktivneMeranie.GetFace(oSelFilter);
            if (oFace != null)
            {
                AddinGlobal.oSetFaces.AddItem(oFace);
                AddinGlobal.GetFaceReferenceKey(oFace, ref AktivneMeranie.Face2RefKey, AddinGlobal.lContextHelper);

                // AddinGlobal.InventorApp.UserInterfaceManager.UserInteractionDisabled = true;
                switch (AktivneMeranie.Typ_merania)
                {
                    case Typ_merania.kVzdialenostDvochPlochvJednejRovine:
                        MeasureTools oMeasureTools = AddinGlobal.InventorApp.MeasureTools;
                        double distance = oMeasureTools.GetMinimumDistance(AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face1RefKey, AddinGlobal.lContextHelper), AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face2RefKey, AddinGlobal.lContextHelper));
                        txtNominalValue.Text = (Math.Round(distance * 10, 3)).ToString();

                        break;
                    case Typ_merania.kVzdialenostDvochPlochvDvochRovinach:

                        break;
                    case Typ_merania.kPriemerValcovejPlochy:


                        break;
                    case Typ_merania.kUholDvochPloch:
                        //MeasureTools oMeasureTools2 = AddinGlobal.InventorApp.MeasureTools;
                        //double angle = oMeasureTools2.GetAngle(AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face1RefKey, AktivneMeranie.oContextData), AddinGlobal.GetFaceFromReferenceKey(AktivneMeranie.Face2RefKey, AktivneMeranie.oContextData));
                        //txtNominalValue.Text = angle.ToString();
                        break;
                    default:
                        break;
                }
            }
            this.Show();
        }

        private void btnSaveMeranie_Click(object sender, EventArgs e)
        {
            //kontrola merania
            switch (AktivneMeranie.Typ_merania)
            {
                case Typ_merania.kVzdialenostDvochPlochvJednejRovine:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kVzdialenostDvochPlochvDvochRovinach:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kPriemerValcovejPlochy:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kPriemerHranyKuzelovejPlochy:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kUholDvochPloch:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kUholDvochPlochV2Rovinach:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kRadiusZaoblenia:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kRadiusvPriesecniku:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kObvodovaHadzavost:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kStopaPoNastroji:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kVyronok:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kMeranieOblastiZnačenia:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kKruhovitostVonkajsiehoPriemeru:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kKuzelovitostVonkajsiehoPriemeru:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kRovnobeznostCiel:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kKolmostCela:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kVypuklostCela:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kPovrchoveDefekty:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kDrazkaOdOsi:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kDrazkaOdOsiBlizsieDNo:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kDrazkaOdOsiVzdialenejsieDNo:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kPlochaKBlizsejHrane:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kPlochaKVzdialenejsejHrane:
                    if (AktivneMeranie.Face1RefKey == null || AktivneMeranie.Face2RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                case Typ_merania.kSirkaDrazkyVReze:
                    if (AktivneMeranie.Face1RefKey == null)
                    {
                        MessageBox.Show("Nie sú zadané všetky požadované plochy merania.");
                        return;
                    }
                    break;
                default:
                    break;
            }

            //kontrola tolerancií
            if (AktivneMeranie.PouzitaSkupinovaTolerancia == false)
            {
                switch (AktivneMeranie.Typ_tolerancie)
            {
                
                case Typ_tolerancie.kSymmetry:
                        if (AktivneMeranie.Navestie2=="0" && AktivneMeranie.Navestie3=="0")
                        {
                            MessageBox.Show("Nie sú zadané hodnoty tolerancie. Zadajte tolerančné pásmo, alebo vyberte skupinovú toleranciu.");
                            return;
                        }
                    break;
                case Typ_tolerancie.kAbsoluteValue:
                        if (AktivneMeranie.Navestie1 == "0")
                        {
                            MessageBox.Show("Nie sú zadané hodnoty tolerancie. Zadajte tolerančné pásmo, alebo vyberte skupinovú toleranciu.");
                            return;
                        }
                        break;
                case Typ_tolerancie.kStopa:
                        if (AktivneMeranie.Navestie1 == "0" && AktivneMeranie.Navestie2 == "0" && AktivneMeranie.Navestie3 == "0")
                        {
                            MessageBox.Show("Nie sú zadané hodnoty tolerancie. Zadajte tolerančné pásmo, alebo vyberte skupinovú toleranciu.");
                            return;
                        }
                        break;
                        
                case Typ_tolerancie.kVyronok:
                        if (AktivneMeranie.Navestie1 == "0" && AktivneMeranie.Navestie2 == "0" )
                        {
                            MessageBox.Show("Nie sú zadané hodnoty tolerancie. Zadajte tolerančné pásmo, alebo vyberte skupinovú toleranciu.");
                            return;
                        }
                        
                        break;
                case Typ_tolerancie.kText:
                        if (AktivneMeranie.Navestie1 == "0")
                        {
                            MessageBox.Show("Nie sú zadané hodnoty tolerancie. Zadajte tolerančné pásmo, alebo vyberte skupinovú toleranciu.");
                            return;
                        }
                        break;
                default:
                    break;
            }
        }
            if (AktivneMeranie.PouzitaSkupinovaTolerancia == true)
            {
                if (AktivneMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kLength)
                {
                    if (AddinGlobal.AktivnyPredpisKontroly.SkupVzdMinus == "0" && AddinGlobal.AktivnyPredpisKontroly.SkupVzdPlus == "0")
                    {
                        MessageBox.Show("Použitá skupinová tolerancia vzdialenosti nie je nadefinovaná.");
                        return;
                    }
                }
                if (AktivneMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kAngle)
                {
                    if (AddinGlobal.AktivnyPredpisKontroly.SkupUholMinus == "0" && AddinGlobal.AktivnyPredpisKontroly.SkupUholPlus == "0")
                    {
                        MessageBox.Show("Použitá skupinová tolerancia uhlu nie je nadefinovaná.");
                        return;
                    }
                }
                if (AktivneMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kDiameter)
                {
                    if (AddinGlobal.AktivnyPredpisKontroly.SkupRadiusMinus == "0" && AddinGlobal.AktivnyPredpisKontroly.SkupRadiusPlus == "0")
                    {
                        MessageBox.Show("Použitá skupinová tolerancia rádiusu nie je nadefinovaná.");
                        return;
                    }
                }
                if (AktivneMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kPovrch)
                {
                    if (AddinGlobal.AktivnyPredpisKontroly.SkupPovrchChyby == "0")
                    {
                        MessageBox.Show("Použitá skupinová tolerancia povrchových chýb nie je nadefinovaná.");
                        return;
                    }
                }
            }


                AktivneMeranie.Saved = true;
            if (cBoxPrvyRez.Enabled)
            {
                AktivneMeranie.Rez1 = (Rez)cBoxPrvyRez.SelectedValue;
                AddinGlobal.LastRez1= (Rez)cBoxPrvyRez.SelectedValue;
            }
            else
                AktivneMeranie.Rez1 = null;
            if (cBoxDruhyRez.Enabled)
            {
                AktivneMeranie.Rez2 = (Rez)cBoxDruhyRez.SelectedValue;
                AddinGlobal.LastRez2= (Rez)cBoxDruhyRez.SelectedValue; 
            }
            else
                AktivneMeranie.Rez2 = null;
            AktivneMeranie.KodChyby = int.Parse(cBoxKodChyby.SelectedValue.ToString());
            this.Close();
        }

       

       

      

        private void chBoxSkupinoveTolerancie_CheckedChanged(object sender, EventArgs e)
        {
            txtNavestieOne.Enabled = !chBoxSkupinoveTolerancie.Checked;
            txtNavestieTwo.Enabled = !chBoxSkupinoveTolerancie.Checked;
            txtNavestieThree.Enabled= !chBoxSkupinoveTolerancie.Checked;
        }

       

        private void cBoxPrvyRez_SelectedValueChanged(object sender, EventArgs e)
        {
            AddinGlobal.oSetWorkplanes.Clear();
            Rez rez = (Rez)cBoxPrvyRez.SelectedValue;
            if (rez != null)
                AddinGlobal.oSetWorkplanes.AddItem(AddinGlobal.GetWorkplaneFromReferenceKey(rez.PlaneRefKey));
        }

        private void cBoxDruhyRez_SelectedValueChanged(object sender, EventArgs e)
        {
            AddinGlobal.oSetWorkplanes.Clear();
            Rez rez = (Rez)cBoxDruhyRez.SelectedValue;
            if (rez != null)
                AddinGlobal.oSetWorkplanes.AddItem(AddinGlobal.GetWorkplaneFromReferenceKey(rez.PlaneRefKey));
        }

        private void PridanieMerania_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddinGlobal.oSetFaces.Clear();
            AddinGlobal.oSetWorkplanes.Clear();
        }

    }
}
