using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;
using System.Data;


using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace Blastman
{
    public static class AddinGlobal
    {
        public static Inventor.Application InventorApp;

        public static string RibbonPanelId;
        public static RibbonPanel RibbonPanel;
        public static List<InventorButton> ButtonList = new List<InventorButton>();
       
        private static string mClassId;
        public static bool IsActiveMeranie=false;
        public static Meranie AktivneMeranie;
        public static Rezy rezy;
        public static Predpis_kontroly AktivnyPredpisKontroly;
        public static Rez LastRez1;
        public static Rez LastRez2;
        public static HighlightSet oSetFaces;
        public static HighlightSet oSetWorkplanes;
        public static HighlightSet oSetPoints;

        public static byte[] byContextHelper;
        public static int lContextHelper=0;
        public static System.Data.DataTable KodyVad;
        public static bool LoggedIn = false;
        //  public static InventorButton button4;
        //public static InventorButton button3;

        public static string Blastman_version = "0.1";
        public static string DriveLetter;
        public static string ServerIPAdress;
        public static string ServerLoginName;
        public static string ServerLoginPassword;

        public static string ClassId
        {
            get 
            {
                if (!string.IsNullOrEmpty(mClassId))
                    return AddinGlobal.mClassId;
                else
                    throw new System.Exception("The addin server class id hasn't been gotten yet!");
            }
            set { AddinGlobal.mClassId = value; }
        }

        public static void GetAddinClassId(Type t)
        {
            GuidAttribute guidAtt = (GuidAttribute)GuidAttribute.GetCustomAttribute(t, typeof(GuidAttribute));
            mClassId = "{" + guidAtt.Value + "}";
        }


        public static string GetDescription<T>(this T enumerationValue)
                where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();

        }
        /// <summary>
        /// method to get Workplane object from UI
        /// </summary>
        /// <returns></returns>
        public static WorkPlane GetWorkplane()
        {
            WorkPlane wp=default(WorkPlane);
            Object oObject = InventorApp.CommandManager.Pick(SelectionFilterEnum.kWorkPlaneFilter, "Vyberte pracovnú rovinu súčiastky.");
            wp = (WorkPlane)oObject;
            return wp;
        }
        public static WorkPlane GetWorkplane(out string WorkPlaneName)
        {
            WorkPlane wp = default(WorkPlane);
            Object oObject = InventorApp.CommandManager.Pick(SelectionFilterEnum.kWorkPlaneFilter, "Vyberte pracovnú rovinu súčiastky.");
            wp = (WorkPlane)oObject;
            if (wp == null)
            {
                throw new Exception();
                
            }
            else
            {
                WorkPlaneName = wp.Name;
                return wp;
            }
        }
        public static WorkPlane GetAndCreateWorkplaneFromFace (PartComponentDefinition oCompDef, out string WorkPlaneName)
        {
            WorkPlane oWP= default(WorkPlane); 
            Object oObject = InventorApp.CommandManager.Pick(SelectionFilterEnum.kPartFacePlanarFilter, "Vyberte rovinnú plochu súčiastky.");
            oWP = oCompDef.WorkPlanes.AddByPlaneAndOffset(oObject, "0 mm");
            oWP.Visible = false;
            WorkPlaneName = oWP.Name;

            return oWP;

        }


        public static Face GetPlanarFace()
        {
            Face oFace = default(Face);
            Object oObject = InventorApp.CommandManager.Pick(SelectionFilterEnum.kPartFacePlanarFilter, "Vyberte plochu.");
            
            oFace = (Face)oObject;
            
            return oFace;
        }

        /// <summary>
        /// Method to export DXF of section of selected objects. In case there is a empty collection, method exports whole section.
        /// </summary>
        
        public static PlanarSketch GetSketchOfSection(Rez oRez, PartComponentDefinition oCompDef)
        {
            PlanarSketch oSketch;
            oSketch = oCompDef.Sketches.Add(AddinGlobal.GetWorkplaneFromReferenceKey(oRez.PlaneRefKey));
            // Call the Project Cut Edges command.
            oSketch.Edit();

            oSketch.ProjectedCuts.Add();
            //InventorApp.CommandManager.ControlDefinitions["SketchProjectCutEdgesCmd"].Execute();
            

            oSketch.ExitEdit();
            oSketch.Visible = false;
            //oSketch.Delete();
            InventorApp.ActiveView.Update();
            return oSketch;
        }
       
        //public static string GetRefKeyForFace(Face oFace)
        //{
        //    Document oDoc = InventorApp.ActiveDocument;
        //    byte[] byKey = new byte[] { };
        //    int KeyContext = oDoc.ReferenceKeyManager.CreateKeyContext();
        //    oFace.GetReferenceKey(ref byKey,KeyContext);
        //    string strkey = oDoc.ReferenceKeyManager.KeyToString(ref byKey);
        //    return strkey;
          

        //}
        public static void GetFaceReferenceKey(Face oFace, ref byte[] oRefKey, int KeyContext)
        {
           
            oFace.GetReferenceKey(ref oRefKey,KeyContext);
        }
        public static void GetFaceReferenceKey(Face oFace, ref string oRefKey, int KeyContext)
        {
            Document oDoc = AddinGlobal.InventorApp.ActiveDocument;
            byte[] RefKeyByte = new byte[] { };

            //Get a reference key for the face
            oFace.GetReferenceKey(ref RefKeyByte, KeyContext);
         
            oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
            oDoc = null;
        }
        
        public static void GetWorkplaneReferenceKey(WorkPlane oWP, ref byte[] oRefKey)
        {

            //Get a reference key for the face
            oWP.GetReferenceKey(ref oRefKey);


        }
        public static void GetWorkplaneReferenceKey(WorkPlane oWP, ref string oRefKey)
        {
            Document oDoc = InventorApp.ActiveDocument;
            //Create a key context
            // (required to obtain ref keys for BRep entities)


            //Get a reference key for the face
            byte[] RefKeyByte = new byte[] { };

            oWP.GetReferenceKey(ref RefKeyByte);
            oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
            oDoc = null;
            

        }
        public static Face GetFace(SelectionFilterEnum oSelFilter)
        {
            Face oFace = default(Face);
            Object oObject = AddinGlobal.InventorApp.CommandManager.Pick(oSelFilter, "Vyberte plochu.");
            oFace = (Face)oObject;
            if (oObject != null)
            {
                return oFace;
            }
            else 
            {
                return null;
            }
        }
        public static Inventor.Point GetPointAndHisRefKey(SelectionFilterEnum oSelFilter, ref string oRefKey, int KeyContext)
        {
            //Inventor.Point oPoint = default(Inventor.Point);
            Object oObject = AddinGlobal.InventorApp.CommandManager.Pick(oSelFilter, "Vyberte bod.");
            WorkPoint oPoint = oObject as Inventor.WorkPoint;
            if (oPoint != null)
            {
                Document oDoc = InventorApp.ActiveDocument;
                //Create a key context
                // (required to obtain ref keys for BRep entities)


                //Get a reference key for the face
                byte[] RefKeyByte = new byte[] { };

                oPoint.GetReferenceKey(ref RefKeyByte);
                oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                oDoc = null;
                return oPoint.Point;
            }

            SketchPoint oSketchPoint = oObject as Inventor.SketchPoint;
            if (oSketchPoint != null)
            {
                Document oDoc = InventorApp.ActiveDocument;
                //Create a key context
                // (required to obtain ref keys for BRep entities)


                //Get a reference key for the face
                byte[] RefKeyByte = new byte[] { };

                oSketchPoint.GetReferenceKey(ref RefKeyByte);
                oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                oDoc = null;
                return oSketchPoint.Geometry3d;
            }
            SketchPoint3D oSketchPoint3D = oObject as Inventor.SketchPoint3D;
            if (oSketchPoint3D != null)
            {
                Document oDoc = InventorApp.ActiveDocument;
                //Create a key context
                // (required to obtain ref keys for BRep entities)


                //Get a reference key for the face
                byte[] RefKeyByte = new byte[] { };

                oSketchPoint3D.GetReferenceKey(ref RefKeyByte);
                oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                oDoc = null;
                return oSketchPoint3D.Geometry;
            }
            Vertex oVertex = oObject as Inventor.Vertex;
            if (oVertex != null)
            {
                Document oDoc = InventorApp.ActiveDocument;
                //Create a key context
                // (required to obtain ref keys for BRep entities)

                TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
                //Get a reference key for the face
                byte[] RefKeyByte = new byte[] { };

                oVertex.GetReferenceKey(ref RefKeyByte,KeyContext);
                oRefKey = oDoc.ReferenceKeyManager.KeyToString(RefKeyByte);
                oDoc = null;
                double[] coor = new double[] { };
                oVertex.GetPoint(ref coor);
                Point oPo = oTrans.CreatePoint(coor[0],coor[1],coor[2]);
                return oPo;
            }

            return null;

        }
        public static void HighlightPoint(string oRefKey, int KeyContext)
        {
            //Inventor.Point oPoint = default(Inventor.Point);
            try
            {
                Document oDoc = InventorApp.ActiveDocument;
                byte[] RefKeyByte = new byte[] { };

                oDoc.ReferenceKeyManager.StringToKey(oRefKey, ref RefKeyByte);

            

                //Bind reference key to the Face object
                object oObject;
                object context;
                oDoc.ReferenceKeyManager.CanBindKeyToObject(RefKeyByte, KeyContext, out oObject, out context);
                oDoc.ReferenceKeyManager.BindKeyToObject(ref RefKeyByte, KeyContext, out oObject);


                WorkPoint oPoint = oObject as Inventor.WorkPoint;
                if (oPoint != null)
                {
                    oSetPoints.AddItem(oObject);
                    oDoc = null;
                    return;
                }

                SketchPoint oSketchPoint = oObject as Inventor.SketchPoint;
                if (oSketchPoint != null)
                {
                    oSetPoints.AddItem(oObject);
                    oDoc = null;
                    return;
                }
                SketchPoint3D oSketchPoint3D = oObject as Inventor.SketchPoint3D;
                if (oSketchPoint3D != null)
                {
                    oSetPoints.AddItem(oObject);
                    oDoc = null;
                    return;
                }
                Vertex oVertex = oObject as Inventor.Vertex;
                if (oVertex != null)
                {
                    oSetPoints.AddItem(oObject);
                    oDoc = null;
                    return;
                }
               
                oDoc = null;

               
            }
            catch
            {
               
            }
            

            

        }
        public static Point GetPointFromReferenceKey(string oRefKey, int KeyContext)
        {
            try
            {
                Document oDoc = InventorApp.ActiveDocument;
                byte[] RefKeyByte = new byte[] { };

                oDoc.ReferenceKeyManager.StringToKey(oRefKey, ref RefKeyByte);



                //Bind reference key to the Face object
                object oObject;
                object context;
                oDoc.ReferenceKeyManager.CanBindKeyToObject(RefKeyByte, KeyContext, out oObject, out context);
                oDoc.ReferenceKeyManager.BindKeyToObject(ref RefKeyByte, KeyContext, out oObject);


                WorkPoint oPoint = oObject as Inventor.WorkPoint;
                if (oPoint != null)
                {
                    
                    oDoc = null;
                    return oPoint.Point;
                }

                SketchPoint oSketchPoint = oObject as Inventor.SketchPoint;
                if (oSketchPoint != null)
                {
                    
                    oDoc = null;
                    return oSketchPoint.Geometry3d;
                }
                SketchPoint3D oSketchPoint3D = oObject as Inventor.SketchPoint3D;
                if (oSketchPoint3D != null)
                {
                   
                    oDoc = null;
                    return oSketchPoint3D.Geometry;
                }
                Vertex oVertex = oObject as Inventor.Vertex;
                if (oVertex != null)
                {

                    oDoc = null;
                    return oVertex.Point;
                }
                else 
                    {
                    
                    oDoc = null;
                    return null;
                }


            }
            catch
            {
                throw new Exception("Nenačítaný bod.");
            }
        }
        public static List<Face> GetFaceMultiple(SelectionFilterEnum oSelFilter)
        {
            Face oFace = default(Face);
            List<Face> oFaces = new List<Face>();
            while (true)
            {
                Object oObject = AddinGlobal.InventorApp.CommandManager.Pick(oSelFilter, "Vyberte plochu.");
                oFace = (Face)oObject;
                oFaces.Add(oFace);
                if (oObject!=null)
                {
                    oSetFaces.AddItem(oFace);
                }
                if (oObject==null)
                {
                    break;
                }
            }

            
            return oFaces;
        }
        public static void SetCameraToView(ViewOrientationTypeEnum oViewType)
        {
            Camera oCam = AddinGlobal.InventorApp.ActiveView.Camera;
            oCam.ViewOrientationType = oViewType;
            oCam.Apply();
        }
        public static void MapDrive()
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo("net.exe", string.Format(@"net use {0}: {1}", driveLetter,UNCPath));
            //processStartInfo.UseShellExecute = false;
            //Process process = Process.Start(processStartInfo);

            IWshNetwork_Class network = new IWshNetwork_Class();
            network.MapNetworkDrive(DriveLetter, @ServerIPAdress,Type.Missing,ServerLoginName,ServerLoginPassword);


        }
        public static void UnMapDrive()
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo("net.exe", string.Format(@"net use {0}: /delete", driveLetter));
            //processStartInfo.UseShellExecute = false;
            //Process process = Process.Start(processStartInfo);
            IWshNetwork_Class network = new IWshNetwork_Class();
            network.RemoveNetworkDrive(DriveLetter);
        }
        public static Face GetFaceFromReferenceKey(
                                ref byte[] oRefKey,
                            int KeyContext)
        {
            try
            {
                Document oDoc = InventorApp.ActiveDocument;
                
               

                //Bind reference key to the Face object
                object MatchType;
                Face oFace = oDoc.ReferenceKeyManager.BindKeyToObject(ref oRefKey, KeyContext, out MatchType) as Face;
                oDoc = null;
                //Return result
                return oFace;
            }
            catch
            {
                return null;
            }
        }
        public static Face GetFaceFromReferenceKey(
                               string oRefKey,
                           int KeyContext)
        {
            try
            {
                Document oDoc = InventorApp.ActiveDocument;
                
                //Bind reference key to the Face object
                object MatchType;
          
                byte[] RefKeyByte = new byte[] { };

                oDoc.ReferenceKeyManager.StringToKey(oRefKey, ref RefKeyByte);
                Face oFace = oDoc.ReferenceKeyManager.BindKeyToObject(ref RefKeyByte, KeyContext, out MatchType) as Face;
                oDoc = null;
                //Return result
                return oFace;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static WorkPlane GetWorkplaneFromReferenceKey(
                                ref byte[] oRefKey)
        {
            try
            {
                Document oDoc = InventorApp.ActiveDocument;

                //Bind reference key to the Face object
                object MatchType;
                WorkPlane oWP = oDoc.ReferenceKeyManager.BindKeyToObject(ref oRefKey,0,out MatchType) as WorkPlane;
                oDoc = null;
                //Return result
                return oWP;
            }
            catch
            {
                return null;
            }
        }
        public static WorkPlane GetWorkplaneFromReferenceKey(
                                string oRefKey)
        {
            try
            {
                Document oDoc = InventorApp.ActiveDocument;
                byte[] RefKeyByte = new byte[] { };

                oDoc.ReferenceKeyManager.StringToKey(oRefKey, ref RefKeyByte);
                


                //Bind reference key to the Face object
                object MatchType;
                WorkPlane oWP = oDoc.ReferenceKeyManager.BindKeyToObject(ref RefKeyByte, 0, out MatchType) as WorkPlane;

                //Return result
                oDoc = null;
                return oWP;
            }
            catch
            {
                return null;
            }
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }


    }
    internal class InventorMainFrame : System.Windows.Forms.IWin32Window
    {
        public InventorMainFrame(long hWnd) { m_hWnd = hWnd; }
        public System.IntPtr Handle
        {
            get { return (System.IntPtr)m_hWnd; }
        }
        private long m_hWnd;
    }
}