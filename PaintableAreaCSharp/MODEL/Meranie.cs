using System;
using System.ComponentModel;
using Inventor;

namespace Blastman
{
    public class Meranie : INotifyPropertyChanged
    {
        //properties
        Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
        private Guid _id = Guid.NewGuid();
        private string _nazovmerania;
        private Typ_merania _typ_merania;
        private Typ_tolerancie _typ_tolerancie;
        private Typ_skupinovej_tolerancie _typ_skupinovej_tolerancie;
        private Rez _rez1;
        private Rez _rez2;
        private string _rez1ID;
        private string _rez2ID;
        private int _kodchyby;
        private string _dxf1;
        private string _dxf2;


        //not used, using byte[]
        //private string _workplaneOneID = String.Empty;
        //private string _workplaneTwoID = String.Empty;

        
        //reference keys for selected faces
        public string Face1RefKey=null;
        public string Face2RefKey=null;

     

        
        
        private bool _saved = false;
        
        private double _nominalValue;
        private double _navestie1;
        private double _navestie2;
        private double _navestie3;
        private bool _pouzitaskupinovatolerancia;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        
        //constructor
        public Meranie()
        {
            
           
        }
        public Meranie(Typ_merania typ_merania, string NazovMerania)
        {
            _typ_merania = typ_merania;
            _nazovmerania = NazovMerania;
            
            switch (_typ_merania)
            {
                case Typ_merania.kVzdialenostDvochPlochvJednejRovine:
                    _typ_tolerancie = (Typ_tolerancie) 101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kVzdialenostDvochPlochvDvochRovinach:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kPriemerValcovejPlochy:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kPriemerHranyKuzelovejPlochy:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kUholDvochPloch:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)201;
                    break;
                case Typ_merania.kUholDvochPlochV2Rovinach:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)201;
                    break;
                case Typ_merania.kRadiusZaoblenia:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)203;
                    break;
                case Typ_merania.kRadiusvPriesecniku:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)203;
                    break;
                case Typ_merania.kObvodovaHadzavost:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kStopaPoNastroji:
                    _typ_tolerancie = (Typ_tolerancie)103;
                    break;
                case Typ_merania.kVyronok:
                    _typ_tolerancie = (Typ_tolerancie)104;
                    break;
                case Typ_merania.kMeranieOblastiZnačenia:
                    _typ_tolerancie = (Typ_tolerancie)105;
                    break;
                case Typ_merania.kKruhovitostVonkajsiehoPriemeru:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kKuzelovitostVonkajsiehoPriemeru:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kRovnobeznostCiel:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kKolmostCela:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kVypuklostCela:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    break;
                case Typ_merania.kPovrchoveDefekty:
                    _typ_tolerancie = (Typ_tolerancie)102;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)204;
                    break;
                case Typ_merania.kDrazkaOdOsi:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kDrazkaOdOsiBlizsieDNo:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kDrazkaOdOsiVzdialenejsieDNo:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kPlochaKBlizsejHrane:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kPlochaKVzdialenejsejHrane:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                case Typ_merania.kSirkaDrazkyVReze:
                    _typ_tolerancie = (Typ_tolerancie)101;
                    _typ_skupinovej_tolerancie = (Typ_skupinovej_tolerancie)202;
                    break;
                default:
                    break;
            }

        }

        public Guid ID_Merania
        {
            get
            {
                return this._id;
            }
            set { }
        }
        public Rez Rez1
        {
            get { return this._rez1; }

            set
            {
                if (value != this._rez1)
                {
                    this._rez1 = value;
                    NotifyPropertyChanged("Rez1");
                }
            }
        }
        public Rez Rez2
        {
            get { return this._rez2; }

            set
            {
                if (value != this._rez2)
                {
                    this._rez2 = value;
                    NotifyPropertyChanged("Rez2");
                }
            }
        }
        public Typ_merania Typ_merania
        {
            get { return this._typ_merania; }

            set
            {
                if (value != this._typ_merania)
                {
                    this._typ_merania = value;
                    NotifyPropertyChanged("Typ_merania");
                }
            }
        }
        public Typ_skupinovej_tolerancie Typ_skupinovej_tolerancie
        {
            get { return this._typ_skupinovej_tolerancie; }

            set
            {
                if (value != this._typ_skupinovej_tolerancie)
                {
                    this._typ_skupinovej_tolerancie = value;
                    NotifyPropertyChanged("Typ_skupinovej_tolerancie");
                }
            }
        }
        public Typ_tolerancie Typ_tolerancie
        {
            get { return this._typ_tolerancie; }

            set
            {
                if (value != this._typ_tolerancie)
                {
                    this._typ_tolerancie = value;
                    NotifyPropertyChanged("Typ_tolerancie");
                }
            }
        }
        public double NominalValue
        {
            get { return this._nominalValue; }

            set
            {
                if (value != this._nominalValue)
                {
                    this._nominalValue = value;
                    NotifyPropertyChanged("NominalValue");
                }
            }
        }
        public int KodChyby
        {
            get { return this._kodchyby; }

            set
            {
                if (value != this._kodchyby)
                {
                    this._kodchyby = value;
                    NotifyPropertyChanged("KodChyby");
                }
            }
        }
        public bool Saved
        {
            get { return this._saved; }

            set
            {
                _saved = value;
            }
        }
        public string Navestie1
        {
            get { return this._navestie1.ToString(); }

            set
            {
                if (value != this._navestie1.ToString())
                {
                    this._navestie1 = Double.Parse(value);
                    NotifyPropertyChanged("Navestie1");
                }
            }
        }
        public string Navestie2
        {
            get { return this._navestie2.ToString(); }

            set
            {
                if (value != this._navestie2.ToString())
                {
                    this._navestie2 = Double.Parse(value);
                    NotifyPropertyChanged("Navestie2");
                }
            }
        }
        public string Navestie3
        {
            get { return this._navestie3.ToString(); }

            set
            {
                if (value != this._navestie3.ToString())
                {
                    this._navestie3 = Double.Parse(value);
                    NotifyPropertyChanged("Navestie3");
                }
            }
        }
        public string NazovMerania
        {
            get { return this._nazovmerania; }

            set
            {
                if (value != this._nazovmerania)
                {
                    this._nazovmerania = value;
                    NotifyPropertyChanged("NazovMerania");
                }
            }
        }
        public string DXF1
        {
            get { return this._dxf1; }

            set
            {
                if (value != this._dxf1)
                {
                    this._dxf1 = value;
                    NotifyPropertyChanged("DXF1");
                }
            }
        }
        public string DXF2
        {
            get { return this._dxf2; }

            set
            {
                if (value != this._dxf2)
                {
                    this._dxf2 = value;
                    NotifyPropertyChanged("DXF2");
                }
            }
        }
        public bool PouzitaSkupinovaTolerancia
        {
            get { return this._pouzitaskupinovatolerancia; }

            set
            {
                if (value != this._pouzitaskupinovatolerancia)
                {
                    this._pouzitaskupinovatolerancia = value;
                    NotifyPropertyChanged("PouzitaSkupinovaTolerancia");
                }
            }
        }
        

        //methods
        
        
        //generic method for getting the face from model
        public Face GetFace(SelectionFilterEnum oSelFilter)
        {
            Face oFace = default(Face);
            Object oObject =AddinGlobal.InventorApp.CommandManager.Pick(oSelFilter, "Vyberte plochu.");
            oFace = (Face)oObject;
            return oFace;
        }
        //public Face GetFace(SelectionFilterEnum oSelFilter1, SelectionFilterEnum oSelFilter2)
        //{
        //    Face oFace = default(Face);
        //    Object oObject = AddinGlobal.InventorApp.CommandManager.Pick(oSelFilter1,oSelFilter2, "Vyberte plochu.");
        //    oFace = (Face)oObject;
        //    return oFace;
        //}





    }

    public enum Typ_merania:byte
    {
        [Description("Vzdialenosť dvoch plôch v jednej rovine")] 
        kVzdialenostDvochPlochvJednejRovine = 1,
        [Description("Vzdialenosť dvoch plôch v dvoch rovinách")] 
        kVzdialenostDvochPlochvDvochRovinach = 2,
        [Description("Priemer valcovej a kužeľovej plochy")] 
        kPriemerValcovejPlochy = 3,
        [Description("Priemer hrany v mieste priesečníku dvoch plôch")]
        kPriemerHranyKuzelovejPlochy = 4,
        [Description("Uhol dvoch plôch v jednej rovine")]
        kUholDvochPloch = 5,
        [Description("Uhol dvoch plôch v dvoch rovinách")]
        kUholDvochPlochV2Rovinach = 6,
        [Description("Rádius plochy")]
        kRadiusZaoblenia = 7,
        [Description("Rádius v priesečníku")]
        kRadiusvPriesecniku = 8,
        [Description("Obvodová hádzavosť")]
        kObvodovaHadzavost = 9,
        [Description("Stopa po nástroji")]
        kStopaPoNastroji = 10,
        [Description("Výronok")]
        kVyronok = 11,
        [Description("Meranie oblasti značenia")]
        kMeranieOblastiZnačenia = 12,
        [Description("Kruhovitosť vonkajšieho priemeru")]
        kKruhovitostVonkajsiehoPriemeru = 13,
        [Description("Kužeľovitosť vonkajšieho priemeru")]
        kKuzelovitostVonkajsiehoPriemeru = 14,
        [Description("Rovnobežnosť čiel")]
        kRovnobeznostCiel = 15,
        [Description("Kolmosť čela")]
        kKolmostCela = 16,
        [Description("Vypuklosť/vydutosť čela")]
        kVypuklostCela = 17,
        [Description("Povrchové defekty")]
        kPovrchoveDefekty = 18,
        [Description("Vzdialenosť osi drážky od rovnobežnej referenčnej roviny vedenej cez os súčiastky na reze kolmom na os drážky")]
        kDrazkaOdOsi = 19,
        [Description("Vzdialenosť bližšieho konca drážky ku stredu súčiastky od kolmej referenčnej roviny vedenej cez os súčiastky na reze v osi drážky")]
        kDrazkaOdOsiBlizsieDNo = 20,
        [Description("Vzdialenosť vzdialenejšieho konca drážky ku stredu súčiastky od kolmej referenčnej roviny vedenej cez os súčiastky na reze v osi drážky.")]
        kDrazkaOdOsiVzdialenejsieDNo = 21,
        [Description("Vzdialenosť plochy od hrany začiatku inej plochy.")]
        kPlochaKBlizsejHrane = 22,
        [Description("Vzdialenosť plochy od hrany konca inej plochy")]
        kPlochaKVzdialenejsejHrane = 23,
        [Description("Šírka drážky")]
        kSirkaDrazkyVReze = 24





    }
    public enum Typ_tolerancie : byte
    {
        [Description("Asymetrická")] kSymmetry = 101,
        [Description("Absolútna hodnota")] kAbsoluteValue = 102,
        [Description("Stopa")] kStopa = 103,
        [Description("Výronok")] kVyronok = 104,
        [Description("Text")] kText = 105


    }
  
    public enum Typ_skupinovej_tolerancie : byte
    {
        [Description("Uhlová")]
        kAngle = 201,
        [Description("Vzdialenosť plôch")]
        kLength = 202,
        [Description("Rádius")]
        kDiameter = 203,
        [Description("Povrchové defekty")]
        kPovrch = 204


    }


    /// <summary>
    /// method to show description of enums with method ToString
    /// </summary>
    
    static class Typ_meraniaEnumExtension

    {
        public static string ToString(this Typ_merania c,int dummy)

        {
            return AddinGlobal.GetDescription(c);
        }

            
    }
     

}
