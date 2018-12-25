using Inventor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blastman
{
    public class Povrch
    {
        //properties
        public event PropertyChangedEventHandler PropertyChanged;
        private Typ_pohladu _typ_pohladu;
        private double _polomer1;
        private double _polomer2;
        private double _vyska1;
        private double _vyska2;
        private bool _priznaktextu;
        private bool _priznakdrazky;


        public string Face1RefKey = null;
        public Typ_pohladu Typ_pohladu
        {
            get { return this._typ_pohladu; }

            set
            {
                if (value != this._typ_pohladu)
                {
                    this._typ_pohladu = value;
                    NotifyPropertyChanged("Typ_pohladu");
                }
            }
        }
        public double Polomer1
        {
            get { return this._polomer1; }

            set
            {
                if (value != this._polomer1)
                {
                    this._polomer1 = value;
                    NotifyPropertyChanged("Polomer1");
                }
            }
        }
        public double Polomer2
        {
            get { return this._polomer2; }

            set
            {
                if (value != this._polomer2)
                {
                    this._polomer2 = value;
                    NotifyPropertyChanged("Polomer2");
                }
            }
        }
        public double Vyska1
        {
            get { return this._vyska1; }

            set
            {
                if (value != this._vyska1)
                {
                    this._vyska1 = value;
                    NotifyPropertyChanged("Vyska1");
                }
            }
        }
        public double Vyska2
        {
            get { return this._vyska2; }

            set
            {
                if (value != this._vyska2)
                {
                    this._vyska2 = value;
                    NotifyPropertyChanged("Vyska2");
                }
            }
        }
        public bool Text
        {
            get { return this._priznaktextu; }

            set
            {
                if (value != this._priznaktextu)
                {
                    this._priznaktextu = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }
        public bool Drazka
        {
            get { return this._priznakdrazky; }

            set
            {
                if (value != this._priznakdrazky)
                {
                    this._priznakdrazky = value;
                    NotifyPropertyChanged("Drazka");
                }
            }
        }

        //constructor
        public Povrch()
        {

        }
        public Povrch(Face oFace, Typ_pohladu oTyp, int KeyContext)
        {
           
                _typ_pohladu = oTyp;
                AddinGlobal.GetFaceReferenceKey(oFace, ref Face1RefKey, KeyContext);
                //EdgeCollection oCandidateCurves = AddinGlobal.InventorApp.TransientObjects.CreateEdgeCollection();
            List<Edge> oCandidateCurves = new List<Edge>();

            foreach (Edge oEdge in oFace.Edges)
                {
                    if (oEdge.GeometryType == CurveTypeEnum.kCircleCurve || oEdge.GeometryType == CurveTypeEnum.kCircularArcCurve)
                    {
                        double Z = Math.Round(oEdge.Geometry.Center.Z,2);
                        double Y = Math.Round(oEdge.Geometry.Center.Y,2);
                        if (Z== 0 && Y== 0)
                        {

                            oCandidateCurves.Add(oEdge);
                        }
                    }
                 }
            if (oCandidateCurves.Count > 2)
            {

               
                
                var groupedList = oCandidateCurves.GroupBy(c => Math.Round(c.Geometry.Radius,5) ).ToList();
                if (groupedList.Count > 2)
                {
                    throw new ArgumentException("Nebola zadaná korektná plocha. V prípade nejasností, kontaktuje");
                }
                else

                {
                    Edge oEdge = null;
                    int i = 0;
                    foreach (var group in groupedList)
                    {
                       
                        var oList = group.ToList();
                        oEdge = (Edge)oList[0];
                        i++;
                        if (i == 1)
                        {
                            _polomer1 = oEdge.Geometry.Radius * 10;
                            _vyska1 = oEdge.Geometry.Center.X * 10;
                        }
                        if (i == 2)
                        {
                            _polomer2 = oEdge.Geometry.Radius * 10;
                            _vyska2 = oEdge.Geometry.Center.X * 10;
                        }
                    }
                   
                }
            }

            else if (oCandidateCurves.Count==2)
                {
                    Edge oEdge = oCandidateCurves[0];
                    _polomer1 = oEdge.Geometry.Radius * 10;
                    _vyska1 = oEdge.Geometry.Center.X * 10;
                    Edge oEdge2 = oCandidateCurves[1];
                    _polomer2 = oEdge2.Geometry.Radius * 10;
                    _vyska2 = oEdge2.Geometry.Center.X * 10;
                }
                else
                {
                    throw new ArgumentException("Nebola zadaná korektná plocha.");
                }
                   
                
               
                    
                

        }


        //methods
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
    public enum Typ_pohladu : byte
    {
        [Description("Horný")]
        kTop = 1,
        [Description("Spodný")]
        kBottom = 2,
        [Description("Bočný")]
        kSide = 3
       


    }
    static class Typ_pohladuExtension

    {
        public static string ToString(this Typ_pohladu c, int dummy)

        {
            return AddinGlobal.GetDescription(c);
        }


    }
}
