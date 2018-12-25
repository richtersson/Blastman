using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using System.Windows.Forms;
using System.IO;

namespace Blastman
{
    public class Predpis_kontroly
    {
        /// <summary>
        /// Basic class for one model with measurements
        /// </summary>
        
        //properties
        public event PropertyChangedEventHandler PropertyChanged;
        string _modelPath;
        string _modelFileName;
        string _cislovykresu;
        string _nazov;
        BindingList<Meranie> _merania;
        BindingList<Povrch> _povrchy;
        double _skupVzdPlus, _skupVzdMinus, _skupUholPlus, _skupUholMinus, _skupRadiusPlus, _skupRadiusMinus, _skupPovrchChyby;
        int _stav;
        private Rez _charakteristickyrez;
        private Rez _polohovacirez;
        public PlanarSketch CharacteristicSketch;
        public PartComponentDefinition oCompDef;
        public string CharakteristickeDXFPath;

        public int lContext;
        public byte[] byContext = new byte[] { };

        public string ModelPath
        {
            get
            {
                return this._modelPath;
            }
            set
            {
                if (value != this._modelPath)
                {
                    this._modelPath = value;
                    NotifyPropertyChanged("ModelPath");
                }
            }
        }
        public string ModelFileName
        {
            get
            {
                return this._modelFileName;
            }
            set
            {
                if (value != this._modelFileName)
                {
                    this._modelFileName = value;
                    NotifyPropertyChanged("ModelFileName");
                }
            }
        }
        public int Stav
        {
            get
            {
                return this._stav;
            }
            set
            {
                if (value != this._stav)
                {
                    this._stav = value;
                    NotifyPropertyChanged("UplnostStavu");
                }
            }
        }
        
        public BindingList<Meranie> Merania
        {
            get
            {
                return this._merania;
            }
            set
            {
                this._merania = value;
            }
        }
        public BindingList<Povrch> Povrchy
        {
            get
            {
                return this._povrchy;
            }
            set
            {
                this._povrchy = value;
            }
        }
        public Rez CharakteristickyRez
        {
            get { return this._charakteristickyrez; }

            set
            {
                if (value != this._charakteristickyrez)
                {
                    this._charakteristickyrez = value;
                    NotifyPropertyChanged("CharakteristickyRez");
                }
            }
        }
        public Rez PolohovaciRez
        {
            get { return this._polohovacirez; }

            set
            {
                if (value != this._polohovacirez)
                {
                    this._polohovacirez = value;
                    NotifyPropertyChanged("PolohovaciRez");
                }
            }
        }
        public string CisloVykresu
        {
            get { return this._cislovykresu; }

            set
            {
                if (value != this._cislovykresu)
                {
                    this._cislovykresu = value;
                    NotifyPropertyChanged("CisloVykresu");
                }
            }
        }
        public string Nazov
        {
            get { return this._nazov; }

            set
            {
                if (value != this._nazov)
                {
                    this._nazov = value;
                    NotifyPropertyChanged("Nazov");
                }
            }
        }
        public string SkupVzdPlus
        {
            get { return this._skupVzdPlus.ToString(); }

            set
            {
                if (value != this._skupVzdPlus.ToString())
                {
                    this._skupVzdPlus = Double.Parse(value);
                    NotifyPropertyChanged("SkupVzdPlus");
                }
            }
        }
        public string SkupVzdMinus
        {
            get { return this._skupVzdMinus.ToString(); }

            set
            {
                if (value != this._skupVzdMinus.ToString())
                {
                    this._skupVzdMinus = Double.Parse(value);
                    NotifyPropertyChanged("SkupVzdMinus");
                }
            }
        }
        public string SkupUholPlus
        {
            get { return this._skupUholPlus.ToString(); }

            set
            {
                if (value != this._skupUholPlus.ToString())
                {
                    this._skupUholPlus = Double.Parse(value);
                    NotifyPropertyChanged("SkupUholPlus");
                }
            }
        }
        public string SkupUholMinus
        {
            get { return this._skupUholMinus.ToString(); }

            set
            {
                if (value != this._skupUholMinus.ToString())
                {
                    this._skupUholMinus = Double.Parse(value);
                    NotifyPropertyChanged("SkupUholMinus");
                }
            }
        }
        public string SkupRadiusPlus
        {
            get { return this._skupRadiusPlus.ToString(); }

            set
            {
                if (value != this._skupRadiusPlus.ToString())
                {
                    this._skupRadiusPlus = Double.Parse(value);
                    NotifyPropertyChanged("SkupRadiusPlus");
                }
            }
        }
        public string SkupRadiusMinus
        {
            get { return this._skupRadiusMinus.ToString(); }

            set
            {
                if (value != this._skupRadiusMinus.ToString())
                {
                    this._skupRadiusMinus = Double.Parse(value);
                    NotifyPropertyChanged("SkupRadiusMinus");
                }
            }
        }
        public string SkupPovrchChyby
        {
            get { return this._skupPovrchChyby.ToString(); }

            set
            {
                if (value != this._skupPovrchChyby.ToString())
                {
                    this._skupPovrchChyby = Double.Parse(value);
                    NotifyPropertyChanged("SkupPovrchChyby");
                }
            }
        }
        
        
        
        
        
        
        //constructors
        public Predpis_kontroly()
        {
           ConstructorSupport();
        }
        public Predpis_kontroly(string cislovykresu, string nazovpredpisu, int stav, string modelpath)
        {
           
            _cislovykresu = cislovykresu;
            _nazov = nazovpredpisu;
            _modelPath = modelpath;
            _stav = stav;
            _modelFileName = System.IO.Path.GetFileName(modelpath);
            ConstructorSupport();

        }

        //constructor support
        private void ConstructorSupport()
        {
            if (AddinGlobal.oSetFaces == null)
            {
                Inventor.Color oRed = AddinGlobal.InventorApp.TransientObjects.CreateColor(255, 0, 0, 0.4);
                AddinGlobal.oSetFaces = AddinGlobal.InventorApp.ActiveDocument.CreateHighlightSet();
                AddinGlobal.oSetFaces.Color = oRed;
            }
            if (AddinGlobal.oSetPoints == null)
            {
                Inventor.Color oGreen = AddinGlobal.InventorApp.TransientObjects.CreateColor(255, 0, 0, 1);
                AddinGlobal.oSetPoints = AddinGlobal.InventorApp.ActiveDocument.CreateHighlightSet();
                AddinGlobal.oSetPoints.Color = oGreen;
            }
            if (AddinGlobal.oSetWorkplanes == null)
            {
                Inventor.Color oBlue = AddinGlobal.InventorApp.TransientObjects.CreateColor(0, 255, 0, 0.25);
                AddinGlobal.oSetWorkplanes = AddinGlobal.InventorApp.ActiveDocument.CreateHighlightSet();
                AddinGlobal.oSetWorkplanes.Color = oBlue;
            }

            if (AddinGlobal.rezy == null)
            {
                AddinGlobal.rezy = new Rezy();
            }
            if (AddinGlobal.KodyVad == null)
            {
                //AddinGlobal.KodyVad = Database.p_chybovnik_sel();

            }
            oCompDef = ((PartDocument)AddinGlobal.InventorApp.ActiveDocument).ComponentDefinition;

            if (AddinGlobal.lContextHelper==0)
            {

                lContext = AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.CreateKeyContext();
                AddinGlobal.lContextHelper = lContext;
            }
            else
            {
                lContext = AddinGlobal.lContextHelper;
            }
           
            _merania = new BindingList<Meranie>();
            _povrchy = new BindingList<Povrch>();
        }


        //methods
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
      
        public void Export()
        {
            AddinGlobal.InventorApp.SilentOperation = true;
            string folderpath = System.IO.Path.GetDirectoryName(ModelPath);

            ////////TODO////////////////////
            //Checking all needed values////
            ////////////////////////////////
           
            //prítomnost charakteristického rezu
            bool charrez = false;
            foreach (Rez oRez in AddinGlobal.rezy.ZoznamRezov)
            {
                if (oRez.TypRezu == Typ_rezu.kCharakteristicky)
                    charrez = true;

            }
            if (charrez==true)
            {

            }
            else
            {
                MessageBox.Show("Nie je zadefinovaný charakteristický rez.");
                return;
            }


            

            //kontrola prítomnosti platného predpisu
            //if(Database.p_existujeplatny(_cislovykresu)==1)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Pre výkres " + _cislovykresu + " už existuje platný predpis. Chcete pokračovať v exporte?", "Upozornenie", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        //do something
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        return;
            //    }
               
            //}
            //else
            //{

            //}

            //kontrola či existuje skupinová tolerancia premerania ktoré používajú skupinové tolerancie
            foreach (Meranie oMeranie in _merania)
            {
                if (oMeranie.PouzitaSkupinovaTolerancia==true)
                {
                    if (oMeranie.Typ_skupinovej_tolerancie==Typ_skupinovej_tolerancie.kLength)
                    {
                        if (_skupVzdMinus==0 && _skupVzdPlus==0)
                        {
                            MessageBox.Show("Skupinová tolerancia vzdialenosti použitá v meraní " + oMeranie.NazovMerania +" nie je nadefinovaná.");
                            return;
                        }
                    }
                    if (oMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kAngle)
                    {
                        if (_skupUholMinus == 0 && _skupUholPlus == 0)
                        {
                            MessageBox.Show("Skupinová tolerancia uhlu použitá v meraní " + oMeranie.NazovMerania + " nie je nadefinovaná.");
                            return;
                        }
                    }
                    if (oMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kDiameter)
                    {
                        if (_skupRadiusMinus == 0 && _skupRadiusPlus == 0)
                        {
                            MessageBox.Show("Skupinová tolerancia rádiusu použitá v meraní " + oMeranie.NazovMerania + " nie je nadefinovaná.");
                            return;
                        }
                    }
                    if (oMeranie.Typ_skupinovej_tolerancie == Typ_skupinovej_tolerancie.kPovrch)
                    {
                        if (_skupPovrchChyby == 0)
                        {
                            MessageBox.Show("Skupinová tolerancia povrchových chýb použitá v meraní " + oMeranie.NazovMerania + " nie je nadefinovaná.");
                            return;
                        }
                    }
                }
            }

            //kontrola či existujú všetky plochy, ktoré sú v databáze
            foreach (Meranie oMeranie in _merania)
            {
                if (!(oMeranie.Face1RefKey==null || oMeranie.Face1RefKey == ""))
                {
                    if(AddinGlobal.GetFaceFromReferenceKey(oMeranie.Face1RefKey, this.lContext)== null)
                    {
                        MessageBox.Show("V meraní " + oMeranie.NazovMerania + "je zadefinovaná neplatná prvá plocha. Predefinujte plochu, alebo zmeňte meranie.");
                        return;
                    }
                }
                if (!(oMeranie.Face2RefKey == null || oMeranie.Face2RefKey == ""))
                {
                    if (AddinGlobal.GetFaceFromReferenceKey(oMeranie.Face2RefKey, this.lContext) == null)
                    {
                        MessageBox.Show("V meraní " + oMeranie.NazovMerania + "je zadefinovaná neplatná druhá plocha. Predefinujte plochu, alebo zmeňte meranie.");
                        return;
                    }
                }
            }


            ////////////////////////////////
            //Controls passed///////////////
            ////////////////////////////////


            //get and export all rez sketches
            try
            {
                
                string nazovdxf = "";
                int pocetpomocnychrezov=1;
                foreach (Rez oRez in AddinGlobal.rezy.ZoznamRezov)
                {

                    if (oRez.TypRezu == Typ_rezu.kCharakteristicky)
                        nazovdxf = @"\char.dxf";
                    if (oRez.TypRezu == Typ_rezu.kPolohovaci)
                        nazovdxf = @"\pol.dxf";
                    if (oRez.TypRezu == Typ_rezu.kPomocny)
                    {
                        nazovdxf = @"\R" + pocetpomocnychrezov.ToString("00") +  ".dxf";
                        pocetpomocnychrezov++;
                    }


                    CharacteristicSketch = AddinGlobal.GetSketchOfSection(oRez, oCompDef);
                    string rezdxf = folderpath  + nazovdxf;
                    oRez.DXF = nazovdxf;
                    ExportDXF(CharacteristicSketch, rezdxf);
                    CharacteristicSketch.Delete();

                }

            }
            catch
            {
                MessageBox.Show("Problém s exportovaním geometrie rezov. Skontrolujte tabuľku rezov.");
                //return;
            }

            //create and export DXFs for merania
            try
            {
               
                foreach (Meranie oMeranie in Merania)
                {

                    string nazovdxf = "";
                  
                 
                    if (oMeranie.Face2RefKey==null || oMeranie.Face2RefKey=="")
                    {
                        nazovdxf = oMeranie.NazovMerania + "a.dxf";
                        PlanarSketch oSketch1 = GetSketchOfSectionFiltered(oMeranie.Rez1, oCompDef, oMeranie.Face1RefKey, lContext);
                        if (oSketch1 != null)
                        {
                            ExportDXF(oSketch1, folderpath + @"\" + nazovdxf);
                            oMeranie.DXF1 = nazovdxf;
                            oSketch1.Delete();
                        }
                        else
                        {
                            MessageBox.Show("Problém s meraním " + oMeranie.NazovMerania + ". Export nie je úspešný, skontrolujte meranie. Najpravdepodobnejšie rovina rezu nepretína korektne plochu merania.");
                            return;
                        }
                    }
                    else
                    {
                        if (oMeranie.Rez2==null || oMeranie.Rez2==oMeranie.Rez1)
                        {
                            //dxf1
                            nazovdxf = oMeranie.NazovMerania + "a.dxf";

                            PlanarSketch oSketch1 = GetSketchOfSectionFiltered(oMeranie.Rez1, oCompDef, oMeranie.Face1RefKey, lContext);

                            if (oSketch1 != null)
                            {
                                ExportDXF(oSketch1, folderpath + @"\" + nazovdxf);
                                oMeranie.DXF1 = nazovdxf;
                                oSketch1.Delete();
                            }
                            else
                            {
                                MessageBox.Show("Problém s meraním " + oMeranie.NazovMerania + ". Export nie je úspešný, skontrolujte meranie. Najpravdepodobnejšie rovina rezu nepretína korektne plochu merania.");
                                return;
                            }

                            //dxf2
                            nazovdxf = oMeranie.NazovMerania + "b.dxf";
                            PlanarSketch oSketch2 = GetSketchOfSectionFiltered(oMeranie.Rez1, oCompDef, oMeranie.Face2RefKey, lContext);

                            if (oSketch2 != null)
                            {
                                ExportDXF(oSketch2, folderpath + @"\" + nazovdxf);
                            oMeranie.DXF2 = nazovdxf;
                            oSketch2.Delete();
                            }
                            else
                            {
                                MessageBox.Show("Problém s meraním " + oMeranie.NazovMerania + ". Export nie je úspešný, skontrolujte meranie. Najpravdepodobnejšie rovina rezu nepretína korektne plochu merania.");
                                return;
                            }
                        }
                        else
                        {
                            //dxf1
                            nazovdxf = oMeranie.NazovMerania + "a.dxf";
                            PlanarSketch oSketch1 = GetSketchOfSectionFiltered(oMeranie.Rez1, oCompDef, oMeranie.Face1RefKey, lContext);
                            if (oSketch1 != null)
                            {
                                ExportDXF(oSketch1, folderpath + @"\" + nazovdxf);
                                oMeranie.DXF1 = nazovdxf;
                                oSketch1.Delete();
                            }
                            else
                            {
                                MessageBox.Show("Problém s meraním " + oMeranie.NazovMerania + ". Export nie je úspešný, skontrolujte meranie. Najpravdepodobnejšie rovina rezu nepretína korektne plochu merania.");
                                return;
                            }

                            //dxf2
                            nazovdxf = oMeranie.NazovMerania + "b.dxf";
                            PlanarSketch oSketch2 = GetSketchOfSectionFiltered(oMeranie.Rez2, oCompDef, oMeranie.Face2RefKey, lContext);
                            if (oSketch2 != null)
                            {
                                ExportDXF(oSketch2, folderpath + @"\" + nazovdxf);
                                oMeranie.DXF2 = nazovdxf;
                                oSketch2.Delete();
                            }
                            else
                            {
                                MessageBox.Show("Problém s meraním " + oMeranie.NazovMerania + ". Export nie je úspešný, skontrolujte meranie. Najpravdepodobnejšie rovina rezu nepretína korektne plochu merania.");
                                return;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            AddinGlobal.InventorApp.SilentOperation = false;


            //save all data to database
            Save(false);
           

            MassProperties oMassProps = oCompDef.MassProperties;
            //save file
            AddinGlobal.InventorApp.ActiveDocument.Save();
            //send message to database, that export was completed
            try
            {
                //Database.P_EXPORT_PREDPIS(_cislovykresu, oMassProps.CenterOfMass.X * 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export nie je úspešný." + System.Environment.NewLine + ex.Message);
                return;
            }
            
            MessageBox.Show("Predpis bol úspešne exportovaný.");

            BasicInterface bi = null;
            bi = (BasicInterface)AddinGlobal.IsFormAlreadyOpen(typeof(BasicInterface));
            bi.Close();
            AddinGlobal.InventorApp.ActiveDocument.Close();
        }
        public void Copy()
        {
            
        }
        
        
        //method to add faces to highlight set
        public void HighlightFaces(Face oFace1, Face oFace2)
        {
           if (oFace1!=null)
               AddinGlobal.oSetFaces.AddItem(oFace1);
           if (oFace2 != null)
           AddinGlobal.oSetFaces.AddItem(oFace2);
          



        }
        public void HighlightWorkplanes(WorkPlane oWP1, WorkPlane oWP2)
        {
          
            if (oWP1 != null)
                AddinGlobal.oSetWorkplanes.AddItem(oWP1);
            if (oWP2 != null)
                AddinGlobal.oSetWorkplanes.AddItem(oWP2);



        }
        //export of plain planar sketch to dxf
        public void ExportDXF(PlanarSketch oSketch, string ExportPath)
        {
            DataIO oDataIO;
            oDataIO = oSketch.DataIO;
            oDataIO.WriteDataToFile("DXF", ExportPath);
        }
        //exporting position of workplane to txt
        public void ExportRezPosition(Rez oRez, string ExportPath)
        {
            Point origin;
            UnitVector X;
            UnitVector Y;
            AddinGlobal.GetWorkplaneFromReferenceKey(oRez.PlaneRefKey).GetPosition(out origin, out X, out Y);
            string lines = origin.X + "," + origin.Y + "," + origin.Z + System.Environment.NewLine + X.X + "," + X.Y + "," + X.Z + System.Environment.NewLine + Y.X + "," + Y.Y + "," + Y.Z ;
            System.IO.File.WriteAllText(ExportPath, lines);
        }

        
        //getting sketch filter by 
        public PlanarSketch GetSketchOfSectionFiltered(Rez oRez, PartComponentDefinition oCompDef, string KeyFace, int KeyContext)
        {
            ObjectCollection entitiesToDelete = AddinGlobal.InventorApp.TransientObjects.CreateObjectCollection();
            ObjectCollection oFaceCol = AddinGlobal.InventorApp.TransientObjects.CreateObjectCollection();
            PlanarSketch oSketch;
            oSketch = oCompDef.Sketches.Add(AddinGlobal.GetWorkplaneFromReferenceKey(oRez.PlaneRefKey));
            oSketch.Edit();
            oSketch.ProjectedCuts.Add();
            int FaceCount = 0;
            
            Face oReferenceFace = AddinGlobal.GetFaceFromReferenceKey(KeyFace, KeyContext);
           
            foreach (SurfaceBody oBody in oCompDef.SurfaceBodies)
            {
                foreach (Face oFace in oBody.Faces)
                {
                    if ((oFace.InternalName==oReferenceFace.InternalName)&& !(System.Object.ReferenceEquals(oFace, oReferenceFace)))
                    {
                        oFaceCol.Add(oFace);
                        FaceCount++;
                    }
                }
            }

           
            foreach (SketchEntity oSketchEnt in oSketch.SketchEntities)
            {
                    byte[] oRefKey = new Byte[] { };
                
                    Face oFace = oSketchEnt.ReferencedEntity as Face;
                 if (oFace != null)
                    {
                        bool Vymazat = true;

                    if ((System.Object.ReferenceEquals(oFace, oReferenceFace)))
                    {
                        
                    }
                    else
                    {
                        foreach (Face oSimilarFace in oFaceCol)
                        {
                            if (System.Object.ReferenceEquals(oFace, oSimilarFace))
                            {
                                Vymazat = false;
                            }

                        }
                        if (Vymazat == true)
                            entitiesToDelete.Add(oSketchEnt);
                    }
                }
                    else
                        entitiesToDelete.Add(oSketchEnt);
            }
            

            
            
            foreach (ProjectedCut pc in oSketch.ProjectedCuts)
            {
                
                pc.BreakLink();
            }
            oSketch.Solve();

            SelectSet oSelectSet = AddinGlobal.InventorApp.ActiveDocument.SelectSet;
            oSelectSet.Clear();
            foreach (SketchEntity oSketchEntity in entitiesToDelete)
            {
                oSelectSet.Select(oSketchEntity);
            }
            AddinGlobal.InventorApp.CommandManager.ControlDefinitions["AppDeleteCmd"].Execute();

            if (oSketch.SketchEntities.Count == 0)
            {

                oSketch.ExitEdit();

                oSketch.Visible = false;
                AddinGlobal.InventorApp.ActiveView.Update();
                oSketch.Delete();
                return null;
            }
            else
            {
                oSketch.ExitEdit();

                oSketch.Visible = false;
                AddinGlobal.InventorApp.ActiveView.Update();
                return oSketch;
            }
        }
        public void Save(bool ShowResultMessageBox)
        {
            try
            {



                // now save the long context as byte array
                // Context should be saved after creating all the keys
                AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.SaveContextToArray(lContext, ref byContext);
                    
                
                //vymazanie všetkých dat
                //Database.P_VYMAZANIEDATPREDPISU(_cislovykresu);

                //uloženie skupinových tolerancií

                //Database.P_SKTOLERANCIA_INS(_cislovykresu, 201, _skupUholMinus, _skupUholPlus);
                //Database.P_SKTOLERANCIA_INS(_cislovykresu, 202, _skupVzdMinus, _skupVzdPlus);
                //Database.P_SKTOLERANCIA_INS(_cislovykresu, 203, _skupRadiusMinus, _skupRadiusPlus);
                //Database.P_SKTOLERANCIA_INS(_cislovykresu, 204, _skupPovrchChyby, 0);




                //uloženie rezov

                foreach (Rez oRez in AddinGlobal.rezy.ZoznamRezov)
                {
                    try
                    {
                        oRez.RefreshRezGeometryData();
                        //MessageBox.Show(oRez.NazovRezu + System.Environment.NewLine + oRez.Origin.X * 10 + "|" + oRez.Origin.Y * 10 + "|" + oRez.Origin.Z * 10+ System.Environment.NewLine+ oRez.LavyBod.X * 10+"|"+ oRez.LavyBod.Y * 10 + "|" + oRez.LavyBod.Z * 10+ System.Environment.NewLine + oRez.PravyBod.X * 10 + "|" + oRez.PravyBod.Y * 10 + "|" + oRez.PravyBod.Z * 10);
                        //Database.P_REZ_INS(_cislovykresu, (int)oRez.TypRezu, oRez.ID_Rezu, oRez.Origin.X * 10, oRez.Origin.Y * 10, oRez.Origin.Z * 10, oRez.X.X, oRez.X.Y, oRez.X.Z, oRez.Y.X, oRez.Y.Y, oRez.Y.Z, oRez.Perioda, oRez.DXF, oRez.NazovRezu, oRez.PlaneRefKey, oRez.NazovRoviny, oRez.Z.X, oRez.Z.Y, oRez.Z.Z, oRez.LavyBod.X * 10, oRez.LavyBod.Y * 10, oRez.LavyBod.Z * 10, oRez.PravyBod.X * 10, oRez.PravyBod.Y * 10, oRez.PravyBod.Z * 10, oRez.LavyBodRefKey, oRez.PravyBodRefKey);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + System.Environment.NewLine+System.Environment.NewLine + "Uloženie neúspešné.");
                        return;
                    }
                }

                //uloženie meraní
                foreach (Meranie oMeranie in Merania)
                {

                    //Database.P_MERANIE_INS(_cislovykresu, oMeranie.NazovMerania, (int)oMeranie.Typ_merania, (int)oMeranie.Typ_tolerancie, oMeranie.KodChyby, oMeranie.Rez1, oMeranie.Rez2, oMeranie.Face1RefKey, oMeranie.Face2RefKey, Double.Parse(oMeranie.Navestie1), Double.Parse(oMeranie.Navestie2), Double.Parse(oMeranie.Navestie3),oMeranie.DXF1, oMeranie.DXF2, AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.KeyToString(ref byContext));
                    int TypVyslednejTolerancie;
                    if (oMeranie.PouzitaSkupinovaTolerancia)
                    {
                        TypVyslednejTolerancie = (int)oMeranie.Typ_skupinovej_tolerancie;
                    }
                    else TypVyslednejTolerancie = (int)oMeranie.Typ_tolerancie;
                    try
                    {
                        //Database.P_MERANIE_INS(_cislovykresu, oMeranie.NazovMerania, (int)oMeranie.Typ_merania, TypVyslednejTolerancie, oMeranie.KodChyby, oMeranie.Rez1, oMeranie.Rez2, oMeranie.Face1RefKey, oMeranie.Face2RefKey, Double.Parse(oMeranie.Navestie1), Double.Parse(oMeranie.Navestie2), Double.Parse(oMeranie.Navestie3), oMeranie.DXF1, oMeranie.DXF2, "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Uloženie neúspešné.");
                        return;
                    }
                }

                //uloženie povrchov
                foreach(Povrch oPovrch in Povrchy)
                {
                    try
                    {
                        //Database.P_POVRCH_INS(_cislovykresu, (int)oPovrch.Typ_pohladu, Math.Round(oPovrch.Polomer1, 4), Math.Round(oPovrch.Polomer2, 4), Math.Round(oPovrch.Vyska1, 4), Math.Round(oPovrch.Vyska2, 4), oPovrch.Face1RefKey, Convert.ToInt16(oPovrch.Text), Convert.ToInt16(oPovrch.Drazka));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Uloženie neúspešné.");
                        return;
                    }

        }

                //uloženie filecontextu do súboru
                SaveContextToBinaryFile(byContext);

                if (ShowResultMessageBox)
                    MessageBox.Show("Predpis kontroly bol úspešne uložený do databázy.");
            }
            catch
            {
                MessageBox.Show("Problém s uložením predpisu.");
            }
        }
        public void Rebuild()
        {
            //nacitanie skupinových tolerancií
            //Database.P_SKTOLERANCIA_SEL(_cislovykresu, _stav, _nazov, out _skupVzdMinus , out _skupVzdPlus, out _skupUholMinus, out _skupUholPlus, out _skupRadiusMinus, out _skupRadiusPlus, out _skupPovrchChyby);

            //nacitanie tabuľky  rezov
            BindingList<Rez> oRezy;
            //Database.P_REZ_SEL(_cislovykresu, _stav, _nazov, out oRezy);
            //AddinGlobal.rezy.ZoznamRezov = oRezy;

            //nacitanie meraní
            //Database.P_MERANIE_SEL(_cislovykresu, _stav, _nazov, out _merania);
            

            //nacitanie povrchov
            //Database.P_POVRCH_SEL(_cislovykresu, _stav, _nazov,out _povrchy);

            //nacitanie key contextu
            try
            {
                byContext = LoadContextFromBinaryFile(System.IO.Path.GetDirectoryName(_modelPath) + @"\keydata.nai");
                lContext = AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.LoadContextFromArray(ref byContext);
                AddinGlobal.lContextHelper = lContext;
            }
            catch
            {
                MessageBox.Show("Nepodarilo sa načítať podkladné dáta z umiestnenia modelu na serveri. Kontaktujte svojho administrátora.");
            }

        }
        public void RebuildCopy(string _oldcislovykresy, string _oldnazov, int _stav)
        {
            //nacitanie skupinových tolerancií
            //Database.P_SKTOLERANCIA_SEL(_oldcislovykresy, _stav, _oldnazov, out _skupVzdMinus, out _skupVzdPlus, out _skupUholMinus, out _skupUholPlus, out _skupRadiusMinus, out _skupRadiusPlus, out _skupPovrchChyby);

            //nacitanie tabuľky  rezov
            //BindingList<Rez> oRezy;
            //Database.P_REZ_SEL(_oldcislovykresy, _stav, _oldnazov, out oRezy);
            //AddinGlobal.rezy.ZoznamRezov = oRezy;

            //nacitanie meraní
            //Database.P_MERANIE_SEL(_oldcislovykresy, _stav, _oldnazov, out _merania);

            //nacitanie povrchov
            //Database.P_POVRCH_SEL(_oldcislovykresy, _stav, _oldnazov, out _povrchy);

            //nacitanie key contextu
            lContext = AddinGlobal.lContextHelper;

            //nacitanie key contextu
            try
            {
                byContext = LoadContextFromBinaryFile(System.IO.Path.GetDirectoryName(_modelPath) + @"\keydata.nai");
                lContext = AddinGlobal.InventorApp.ActiveDocument.ReferenceKeyManager.LoadContextFromArray(ref byContext);
                AddinGlobal.lContextHelper = lContext;
            }
            catch
            {
                MessageBox.Show("Nepodarilo sa načítať podkladné dáta z umiestnenia modelu na serveri. Kontaktujte svojho administrátora.");
            }

        }
        public void SaveContextToBinaryFile(byte [] byContext)
        {
            string directory = System.IO.Path.GetDirectoryName(_modelPath);
            BinaryWriter binWriter = new BinaryWriter(System.IO.File.Open(directory + @"\keydata.nai", FileMode.Create));
            binWriter.Write(byContext.Length);
            binWriter.Write(byContext);
            binWriter.Close();
        }
        public byte [] LoadContextFromBinaryFile(string filename)
        {
            // Open the File to read the Face keys
            BinaryReader binReader = new BinaryReader(
                  System.IO.File.Open(filename, FileMode.Open));
            // Reset the position in the stream to zero.
            binReader.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] byKey = new byte[] { };
            try
            {
                // Read the size of context array
                int nSize = binReader.ReadInt32();
                // Read the context array
                byKey = binReader.ReadBytes(nSize);
                return byKey;
            }
            finally
            {
                binReader.Close();
            }
        }


    }
}
