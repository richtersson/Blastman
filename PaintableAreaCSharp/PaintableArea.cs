#region Namespaces

using System;
using System.Text;
using System.Linq;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

using Inventor;

#endregion

namespace Blastman
{
    [GuidAttribute("4D109CD0-9BA6-46CC-B6CD-3BE569887CD5")]
    public class Blastman_Addin : Inventor.ApplicationAddInServer
    {
        private Inventor.ApplicationEvents m_appEvents;
      
        public Blastman_Addin()
        {
        }

        #region Implementations of the Interface Members 

        /// <summary>
        /// Do initializations in it such as caching the application object, registering event handlers, and adding ribbon buttons.
        /// </summary>
        /// <param name="siteObj">The entry object for the addin.</param>
        /// <param name="loaded1stTime">Indicating whether the addin is loaded for the 1st time.</param>
        public void Activate(Inventor.ApplicationAddInSite siteObj, bool loaded1stTime)
        {
            AddinGlobal.InventorApp = siteObj.Application;

			try
			{
                AddinGlobal.GetAddinClassId(this.GetType());

               

                //Icon icon1 = new Icon("Resources/pa.ico");
                Icon Create = new Icon(this.GetType(), "Create.ico"); //Change it if necessary but make sure it's embedded.
                Icon Create_small = new Icon(this.GetType(), "Create_small.ico");
                Icon View = new Icon(this.GetType(), "View.ico");
                Icon View_small = new Icon(this.GetType(), "View_small.ico");
                Icon Edit = new Icon(this.GetType(), "Edit.ico");
                Icon Edit_small = new Icon(this.GetType(), "Edit_small.ico");
                Icon login = new Icon(this.GetType(), "login.ico");
                Icon login_small = new Icon(this.GetType(), "login_small.ico");
                Icon logout = new Icon(this.GetType(), "logout.ico");
                Icon logout_small = new Icon(this.GetType(), "logout_small.ico");
                Icon Table = new Icon(this.GetType(), "Table.ico");
                Icon Table_small = new Icon(this.GetType(), "Table_small.ico");


                InventorButton button1 = new InventorButton(
                    "Upraviť", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    Edit_small, Edit,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button1.SetBehavior(true, true, true);
                button1.Execute = ButtonActions.Button8_Execute;
                AddinGlobal.ButtonList.Add(button1);



                InventorButton TabulkaRezovButton = new InventorButton(
                    "Tabuľka rezov", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    Table_small, Table,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                TabulkaRezovButton.SetBehavior(false, true, true);
                TabulkaRezovButton.ButtonDef.Enabled = false;
                TabulkaRezovButton.Execute = ButtonActions.Button2_Execute;
                AddinGlobal.ButtonList.Add(TabulkaRezovButton);

                Icon icon3 = new Icon(this.GetType(), "partlist.ico"); //Change it if necessary but make sure it's embedded.

                InventorButton LoginButton = new InventorButton(
                    "Prihlásiť", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    logout_small, logout,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                LoginButton.SetBehavior(false, true, true);
                LoginButton.Execute = ButtonActions.Button3_Execute;
                AddinGlobal.ButtonList.Add(LoginButton);

                InventorButton LogoutButton = new InventorButton(
                    "Odhlásiť", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    login_small, login,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                LogoutButton.SetBehavior(false, true, true);
                LogoutButton.ButtonDef.Enabled = false;
                LogoutButton.Execute = ButtonActions.Button4_Execute;
                AddinGlobal.ButtonList.Add(LogoutButton);

                InventorButton NewButton = new InventorButton(
                    "Vytvoriť", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    Create_small, Create,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                NewButton.SetBehavior(true, true, true);
                NewButton.ButtonDef.Enabled = false;
                NewButton.Execute = ButtonActions.Button5_Execute;
                AddinGlobal.ButtonList.Add(NewButton);

                InventorButton EditButton = new InventorButton(
                    "Editovať", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    Edit_small, Edit,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                EditButton.SetBehavior(false, true, true);
                EditButton.ButtonDef.Enabled = false;
                EditButton.Execute = ButtonActions.Button6_Execute;
                AddinGlobal.ButtonList.Add(EditButton);

                InventorButton ViewButton = new InventorButton(
                    "Prezerať", "PaintableArea.Button_" + Guid.NewGuid().ToString(), "Meranie", "",
                    View_small, View,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                ViewButton.SetBehavior(false, true, true);
                ViewButton.ButtonDef.Enabled = false;
                ViewButton.Execute = ButtonActions.Button7_Execute;
                AddinGlobal.ButtonList.Add(ViewButton);
                

                if (loaded1stTime == true)
                {
                    //if (null == System.Windows.Application.Current)
                    //{
                    //    new System.Windows.Application();
                    //}
                    UserInterfaceManager uiMan = AddinGlobal.InventorApp.UserInterfaceManager;
                    if (uiMan.InterfaceStyle == InterfaceStyleEnum.kRibbonInterface) //kClassicInterface support can be added if necessary.
                    {
                        //ribbon in part
                        Inventor.Ribbon ribbon = uiMan.Ribbons["Assembly"];
                        RibbonTab tab = ribbon.RibbonTabs["id_TabAssemble"]; //Change it if necessary.


                       

                        AddinGlobal.RibbonPanelId = "{69E065D2-6B82-4D60-8CDB-8C791A9DA246}";
                        AddinGlobal.RibbonPanel = tab.RibbonPanels.Add(
                            "Blastman NC v" + AddinGlobal.Blastman_version,
                            "PaintableArea.RibbonPanel_" + Guid.NewGuid().ToString(),
                            AddinGlobal.RibbonPanelId, String.Empty, true);

                        CommandControls cmdCtrls = AddinGlobal.RibbonPanel.CommandControls;
                        cmdCtrls.AddButton(button1.ButtonDef, button1.DisplayBigIcon, button1.DisplayText, "", button1.InsertBeforeTarget);
                        cmdCtrls.AddButton(TabulkaRezovButton.ButtonDef, TabulkaRezovButton.DisplayBigIcon, TabulkaRezovButton.DisplayText, "", TabulkaRezovButton.InsertBeforeTarget);


                        //ribbon in zerodoc
                        Inventor.Ribbon ribbon2 = uiMan.Ribbons["ZeroDoc"];
                        RibbonTab tab2 = ribbon2.RibbonTabs["id_GetStarted"]; //Change it if necessary.

                        AddinGlobal.RibbonPanelId = "{69E065D2-6B82-4D60-8CDB-8C791A9DA246}";
                        AddinGlobal.RibbonPanel = tab2.RibbonPanels.Add(
                           "Blastman NC v" + AddinGlobal.Blastman_version,
                           "PaintableArea.RibbonPanel_" + Guid.NewGuid().ToString(),
                           AddinGlobal.RibbonPanelId, String.Empty, true);

                        CommandControls cmdCtrls2 = AddinGlobal.RibbonPanel.CommandControls;
                        cmdCtrls2.AddButton(LoginButton.ButtonDef, LoginButton.DisplayBigIcon, LoginButton.DisplayText, "", LoginButton.InsertBeforeTarget);
                        cmdCtrls2.AddButton(LogoutButton.ButtonDef, LogoutButton.DisplayBigIcon, LogoutButton.DisplayText, "", LogoutButton.InsertBeforeTarget);
                        cmdCtrls2.AddButton(NewButton.ButtonDef, NewButton.DisplayBigIcon, NewButton.DisplayText, "", NewButton.InsertBeforeTarget);
                        
                        cmdCtrls2.AddButton(EditButton.ButtonDef, EditButton.DisplayBigIcon, EditButton.DisplayText, "", EditButton.InsertBeforeTarget);
                        cmdCtrls2.AddButton(ViewButton.ButtonDef, ViewButton.DisplayBigIcon, ViewButton.DisplayText, "", ViewButton.InsertBeforeTarget);
                        
                        
                        
                        
                        //ribbon in part
                        Inventor.Ribbon ribbon3 = uiMan.Ribbons["Part"];
                        RibbonTab tab3 = ribbon3.RibbonTabs["id_GetStarted"]; //Change it if necessary.

                        AddinGlobal.RibbonPanelId = "{3BDF4F6F-178E-424E-88B1-2F1ACA066CDD}";
                        AddinGlobal.RibbonPanel = tab3.RibbonPanels.Add(
                           "Blastman NC v" + AddinGlobal.Blastman_version,
                           "PaintableArea.RibbonPanel_" + Guid.NewGuid().ToString(),
                           AddinGlobal.RibbonPanelId, String.Empty, true);

                        CommandControls cmdCtrls3 = AddinGlobal.RibbonPanel.CommandControls;
                        cmdCtrls3.AddButton(LoginButton.ButtonDef, LoginButton.DisplayBigIcon, LoginButton.DisplayText, "", LoginButton.InsertBeforeTarget);
                        cmdCtrls3.AddButton(LogoutButton.ButtonDef, LogoutButton.DisplayBigIcon, LogoutButton.DisplayText, "", LogoutButton.InsertBeforeTarget);
                        cmdCtrls3.AddButton(NewButton.ButtonDef, NewButton.DisplayBigIcon, NewButton.DisplayText, "", NewButton.InsertBeforeTarget);
                        
                        cmdCtrls3.AddButton(EditButton.ButtonDef, EditButton.DisplayBigIcon, EditButton.DisplayText, "", EditButton.InsertBeforeTarget);
                        cmdCtrls3.AddButton(ViewButton.ButtonDef, ViewButton.DisplayBigIcon, ViewButton.DisplayText, "", ViewButton.InsertBeforeTarget);
                        cmdCtrls3.AddButton(TabulkaRezovButton.ButtonDef, TabulkaRezovButton.DisplayBigIcon, TabulkaRezovButton.DisplayText, "", TabulkaRezovButton.InsertBeforeTarget);


                        //loading settings
                        XMLReader.ReadSetting(System.IO.Path.Combine(XMLReader.AssemblyDirectory, "settings.xml"));

                    }
                    long version = AddinGlobal.InventorApp.SoftwareVersion.Major;
                    
                    
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }

            // TODO: Add more initialization code below.
            m_appEvents = AddinGlobal.InventorApp.ApplicationEvents;
            m_appEvents.OnCloseDocument += new ApplicationEventsSink_OnCloseDocumentEventHandler(ApplicationEvents_OnCloseDocument);
            m_appEvents.OnQuit += new ApplicationEventsSink_OnQuitEventHandler(ApplicationEvents_OnQuit);
            

        }

        /// <summary>
        /// Do cleanups in it such as releasing COM objects or forcing the GC to Collect when necessary.
        /// </summary>
        public void Deactivate()
        {
            foreach (InventorButton button in AddinGlobal.ButtonList)
            {
                if (button.ButtonDef != null) button.ButtonDef = null;

            }
            AddinGlobal.InventorApp = null;
            AddinGlobal.RibbonPanel = null;
            AddinGlobal.ButtonList = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            m_appEvents.OnCloseDocument -= new ApplicationEventsSink_OnCloseDocumentEventHandler(ApplicationEvents_OnCloseDocument);
            m_appEvents.OnQuit -= new ApplicationEventsSink_OnQuitEventHandler(ApplicationEvents_OnQuit);
        }

        /// <summary>
        /// Deprecated. Use the ControlDefinition instead to execute commands.
        /// </summary>
        /// <param name="commandID"></param>
        public void ExecuteCommand(int commandID)
        {
        }

        /// <summary>
        /// Implement it if wanting to expose your own automation interface. 
        /// </summary>
		public object Automation
        {
            get { return null; }
		}
        private void ApplicationEvents_OnCloseDocument(_Document DocumentObject,string FullDocumentName, EventTimingEnum BeforeOrAfter, NameValueMap Context, out HandlingCodeEnum HandlingCode)
{
                HandlingCode =   Inventor.HandlingCodeEnum.kEventNotHandled;
 
                if (BeforeOrAfter !=
                    Inventor.EventTimingEnum.kAfter)
                {
                    return;
                }
                HandlingCode = Inventor.HandlingCodeEnum.kEventHandled;

                if (AddinGlobal.rezy != null) AddinGlobal.rezy = null;
            if (AddinGlobal.LastRez1 != null) AddinGlobal.LastRez1 = null;
            if (AddinGlobal.LastRez2 != null) AddinGlobal.LastRez2 = null;
            if (AddinGlobal.oSetFaces != null) AddinGlobal.oSetFaces = null;
            if (AddinGlobal.KodyVad != null) AddinGlobal.KodyVad = null;
            if (AddinGlobal.oSetWorkplanes != null) AddinGlobal.oSetWorkplanes = null;
            if (AddinGlobal.oSetPoints != null) AddinGlobal.oSetPoints = null;
            if (AddinGlobal.AktivneMeranie != null) AddinGlobal.AktivneMeranie = null;
                if (AddinGlobal.AktivnyPredpisKontroly != null) AddinGlobal.AktivnyPredpisKontroly = null;
                if (AddinGlobal.lContextHelper != 0) AddinGlobal.lContextHelper = 0;
                if (AddinGlobal.byContextHelper != null) AddinGlobal.byContextHelper = null;
            //    if (AddinGlobal.rezy != null) Marshal.FinalReleaseComObject(AddinGlobal.rezy);
            //    if (AddinGlobal.oSetFaces != null) Marshal.FinalReleaseComObject(AddinGlobal.oSetFaces);
            //if (AddinGlobal.oSetWorkplanes != null) Marshal.FinalReleaseComObject(AddinGlobal.oSetWorkplanes);
            //if (AddinGlobal.AktivneMeranie != null) Marshal.FinalReleaseComObject(AddinGlobal.AktivneMeranie);
            //    if (AddinGlobal.AktivnyPredpisKontroly != null) Marshal.FinalReleaseComObject(AddinGlobal.AktivnyPredpisKontroly);
}
        private void ApplicationEvents_OnQuit(EventTimingEnum BeforeOrAfter, NameValueMap Context, out HandlingCodeEnum HandlingCode)
        {
            BeforeOrAfter = EventTimingEnum.kBefore;
            HandlingCode = Inventor.HandlingCodeEnum.kEventHandled;
            try
            {
                AddinGlobal.UnMapDrive();
            }
            catch
            { }
        }


        #endregion


    }
}
