using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
namespace Blastman
{
    public class Rez
    {
        //properties
        private Guid _id = Guid.NewGuid();
        private string _nazovrezu;
        private string _nazovroviny;
        private double _perioda;
        private Typ_rezu _typrezu;
        private string _planeRefKey;
        private Point _origin;
        private UnitVector _x;
        private UnitVector _y;
        private UnitVector _z;
        private string _dxf;
        private PartComponentDefinition _oCompDef;
        private Point _lavybod;
        private Point _pravybod;
        private string _lavybodRefKey;
        private string _pravybodRefKey;


        public Guid ID_Rezu
        {
            get
            {
                return this._id;
            }
            set { _id = value; }
        }
        public Typ_rezu TypRezu
        {
            get { return this._typrezu; }

            set
            {
                if (value != this._typrezu)
                {
                    this._typrezu = value;
                    NotifyPropertyChanged("TypRezu");
                }
            }
        }
        public string NazovRezu
        {
            get { return this._nazovrezu; }

            set
            {
                if (value != this._nazovrezu)
                {
                    this._nazovrezu = value;
                    NotifyPropertyChanged("NazovRezu");
                }
            }
        }
        public string DXF
        {
            get { return this._dxf; }

            set
            {
                if (value != this._dxf)
                {
                    this._dxf = value;
                    NotifyPropertyChanged("DXF");
                }
            }
        }
        public Point Origin
        {
            get { return this._origin; }

            set
            {
                if (value != this._origin)
                {
                    this._origin = value;
                    NotifyPropertyChanged("Origin");
                }
            }
        }
        public UnitVector X
        {
            get { return this._x; }

            set
            {
                if (value != this._x)
                {
                    this._x = value;
                    NotifyPropertyChanged("X");
                }
            }
        }
        public UnitVector Y
        {
            get { return this._y; }

            set
            {
                if (value != this._y)
                {
                    this._y = value;
                    NotifyPropertyChanged("Y");
                }
            }
        }
        public UnitVector Z
        {
            get { return this._z; }

            set
            {
                if (value != this._z)
                {
                    this._z = value;
                    NotifyPropertyChanged("Z");
                }
            }
        }
        public Point PravyBod
        {
            get { return this._pravybod; }

            set
            {
                if (value != this._pravybod)
                {
                    this._pravybod = value;
                    NotifyPropertyChanged("PravyBod");
                }
            }
        }
        public Point LavyBod
        {
            get { return this._lavybod; }

            set
            {
                if (value != this._lavybod)
                {
                    this._lavybod = value;
                    NotifyPropertyChanged("LavyBod");
                }
            }
        }
        public string NazovRoviny
        {
            get { return this._nazovroviny; }

            set
            {
                if (value != this._nazovroviny)
                {
                    this._nazovroviny = value;
                    NotifyPropertyChanged("NazovRoviny");
                }
            }
        }
        public string PlaneRefKey
        {
            get { return this._planeRefKey; }

            set
            {
                if (value != this._planeRefKey)
                {
                    this._planeRefKey = value;
                    NotifyPropertyChanged("PlaneRefKey");
                }
            }
        }
        public string LavyBodRefKey
        {
            get { return this._lavybodRefKey; }

            set
            {
                if (value != this._lavybodRefKey)
                {
                    this._lavybodRefKey = value;
                    NotifyPropertyChanged("LavyBodRefKey");
                }
            }
        }
        public string PravyBodRefKey
        {
            get { return this._pravybodRefKey; }

            set
            {
                if (value != this._pravybodRefKey)
                {
                    this._pravybodRefKey = value;
                    NotifyPropertyChanged("PravyBodRefKey");
                }
            }
        }
        public double Perioda
        {
            get { return this._perioda; }

            set
            {
                if (value != this._perioda)
                {
                    this._perioda = value;
                    NotifyPropertyChanged("Perioda");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        //constructor
        public Rez()
        {

        }
        public Rez(Typ_rezu typ_rezu, PartComponentDefinition oCompDef)
        {
            _typrezu = typ_rezu;
            _oCompDef = oCompDef;
            WorkPlane oWP;
            if (typ_rezu == Typ_rezu.kPolohovaci)
            {
                //oWP = AddinGlobal.GetAndCreateWorkplaneFromFace(_oCompDef, out _nazovroviny);
                
                oWP = AddinGlobal.GetWorkplane(out _nazovroviny);
            }
            else
            {

                oWP = AddinGlobal.GetWorkplane(out _nazovroviny);
            }
            AddinGlobal.GetWorkplaneReferenceKey(oWP, ref _planeRefKey);
            _nazovrezu = _nazovroviny;


            oWP.GetPosition(out _origin, out _x, out _y);
            _z = oWP.Plane.Normal;
            TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
            _pravybod = oTrans.CreatePoint(0, 0, 0);
            _lavybod = oTrans.CreatePoint(0, 0, 0);
          

        }
        public Rez(Typ_rezu typ_rezu)
        {
            _typrezu = typ_rezu;

            WorkPlane oWP;

                oWP = AddinGlobal.GetWorkplane(out _nazovroviny);
           
            AddinGlobal.GetWorkplaneReferenceKey(oWP, ref _planeRefKey);
            _nazovrezu = _nazovroviny;


            oWP.GetPosition(out _origin, out _x, out _y);
            _z = oWP.Plane.Normal;
            TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
            _pravybod = oTrans.CreatePoint(0, 0, 0);
            _lavybod = oTrans.CreatePoint(0, 0, 0);
        }

        //methods
      public void UpdateRezFromModel()
        {
            WorkPlane oWP;

            oWP = AddinGlobal.GetWorkplaneFromReferenceKey(_planeRefKey);
            oWP.GetPosition(out _origin, out _x, out _y);
            _z = oWP.Plane.Normal;
           
            TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
            //_lavybod = oTrans.CreatePoint(0, 0, 0);
            //_pravybod = oTrans.CreatePoint(1, 1, 1);
        }
        public bool LoadPoints(bool lavybod)
        {
            string bodrefkey="";
            //Point oPoint = AddinGlobal.GetPointAndHisRefKey(SelectionFilterEnum.kAllPointEntities, ref bodrefkey, AddinGlobal.AktivnyPredpisKontroly.lContext);
            Selection2 oMySelect = new Selection2();
            Point FinalPoint=null;
            Object oObject = oMySelect.PickOneEntity("Vyberte bod",SelectionFilterEnum.kAllPointEntities);
            if (oObject != null)
            {
                WorkPoint oPoint = oObject as Inventor.WorkPoint;
                if (oPoint != null)
                {
                    Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
                    //Create a key context
                    // (required to obtain ref keys for BRep entities)


                    //Get a reference key for the face
                    byte[] RefKeyByte = new byte[] { };

                    oPoint.GetReferenceKey(ref RefKeyByte);
                    bodrefkey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                    oDoc = null;
                    FinalPoint= oPoint.Point;
                }

                SketchPoint oSketchPoint = oObject as Inventor.SketchPoint;
                if (oSketchPoint != null)
                {
                    Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
                    //Create a key context
                    // (required to obtain ref keys for BRep entities)


                    //Get a reference key for the face
                    byte[] RefKeyByte = new byte[] { };

                    oSketchPoint.GetReferenceKey(ref RefKeyByte);
                    bodrefkey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                    oDoc = null;
                    FinalPoint= oSketchPoint.Geometry3d;
                }
                SketchPoint3D oSketchPoint3D = oObject as Inventor.SketchPoint3D;
                if (oSketchPoint3D != null)
                {
                    Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
                    //Create a key context
                    // (required to obtain ref keys for BRep entities)


                    //Get a reference key for the face
                    byte[] RefKeyByte = new byte[] { };

                    oSketchPoint3D.GetReferenceKey(ref RefKeyByte);
                    bodrefkey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                    oDoc = null;
                    FinalPoint= oSketchPoint3D.Geometry;
                }
                Vertex oVertex = oObject as Inventor.Vertex;
                if (oVertex != null)
                {
                    Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
                    //Create a key context
                    // (required to obtain ref keys for BRep entities)

                    TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
                    //Get a reference key for the face
                    byte[] RefKeyByte = new byte[] { };

                    oVertex.GetReferenceKey(ref RefKeyByte, AddinGlobal.AktivnyPredpisKontroly.lContext);
                    bodrefkey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                    oDoc = null;
                    double[] coor = new double[] { };
                    oVertex.GetPoint(ref coor);
                    Point oPo = oTrans.CreatePoint(coor[0], coor[1], coor[2]);
                    FinalPoint= oPo;
                }
            }

            if (FinalPoint == null)
            {
                return false; 
            }
            if (lavybod)
            {
                _lavybod = FinalPoint;
                _lavybodRefKey = bodrefkey;
                return true;
            }
            else
            {
                _pravybod = FinalPoint;
                _pravybodRefKey = bodrefkey;
                return true;
            }

        }
        public void RefreshRezGeometryData()
        {
            WorkPlane oWP;
            TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
            oWP = AddinGlobal.GetWorkplaneFromReferenceKey(_planeRefKey);
            oWP.GetPosition(out _origin, out _x, out _y);
            _z = oWP.Plane.Normal;

            if (_lavybodRefKey != null && _lavybodRefKey != "")
            {
                Point oLeftPoint = AddinGlobal.GetPointFromReferenceKey(_lavybodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);

                if (oLeftPoint != null)
                    _lavybod = oLeftPoint;
                else
                    _lavybod = oTrans.CreatePoint(0, 0, 0);
            }
            if (_pravybodRefKey != null && _pravybodRefKey != "")
            {
                Point oRightPoint = AddinGlobal.GetPointFromReferenceKey(_pravybodRefKey, AddinGlobal.AktivnyPredpisKontroly.lContext);
                if (oRightPoint != null)
                    _pravybod = oRightPoint;
                else
                    _pravybod = oTrans.CreatePoint(0, 0, 0);
            }



        }

    }
    public enum Typ_rezu : byte
    {
        [Description("Charakteristický")]
        kCharakteristicky = 101,
        [Description("Polohovací")]
        kPolohovaci = 102,
        [Description("Pomocný")]
        kPomocny = 103

    }
    public class Rezy
    {
        private BindingList<Rez> _rezy;

        public BindingList<Rez> ZoznamRezov
        {
            get
            {
                return this._rezy;
            }
            set
            {
                this._rezy = value;
            }
        }
        public Rezy()
        {
            _rezy = new BindingList<Rez>();
        }
 
    }
}
