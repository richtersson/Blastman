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
    public class ButtonActions
    {
        //
        public static void Button1_Execute()
        {
            //BasicInterface bi = null;
            //Tabulka_rezov tr = null;
            //if (((bi = (BasicInterface) AddinGlobal.IsFormAlreadyOpen(typeof(BasicInterface))) == null)&& ((tr = (Tabulka_rezov)AddinGlobal.IsFormAlreadyOpen(typeof(Tabulka_rezov))) == null))
            //{
            //    bi = new BasicInterface(AddinGlobal.AktivnyPredpisKontroly);
            //    bi.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    bi.Select();
            //}

           
           
        }
        //vytvorenie kusovníka
        public static void Button2_Execute()
        {
            //BasicInterface bi = null;
            //Tabulka_rezov tr = null;
            //if (((tr = (Tabulka_rezov)AddinGlobal.IsFormAlreadyOpen(typeof(Tabulka_rezov))) == null)&& ((bi = (BasicInterface)AddinGlobal.IsFormAlreadyOpen(typeof(BasicInterface))) == null))
            //{
            //    tr = new Tabulka_rezov(); 
            //    tr.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    tr.Select();
            //}
 
        }
        public static void Button3_Execute()
        {
            //TODO: add code below for the button click callback.

            //Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            //if (((oLogin = (Login)AddinGlobal.IsFormAlreadyOpen(typeof(Login))) == null)&& ((oView = (View)AddinGlobal.IsFormAlreadyOpen(typeof(View))) == null)&& ((oEdit = (Edit)AddinGlobal.IsFormAlreadyOpen(typeof(Edit))) == null)&& ((oNovyPK = (Novy_PK)AddinGlobal.IsFormAlreadyOpen(typeof(Novy_PK))) == null))
            //{
            //    oLogin = new Login();
            //    oLogin.ShowDialog(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    oLogin.Select();
            //}


        }
      
        public static void Button4_Execute()
        {
            //Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            //try
            //{
            //    AddinGlobal.UnMapDrive();
            //}
            //catch
            //{ }
            //if (((oLogin = (Login)AddinGlobal.IsFormAlreadyOpen(typeof(Login))) == null) && ((oView = (View)AddinGlobal.IsFormAlreadyOpen(typeof(View))) == null) && ((oEdit = (Edit)AddinGlobal.IsFormAlreadyOpen(typeof(Edit))) == null) && ((oNovyPK = (Novy_PK)AddinGlobal.IsFormAlreadyOpen(typeof(Novy_PK))) == null))
            //{
            //    foreach (InventorButton iBtn in AddinGlobal.ButtonList)
            //    {
            //        if (iBtn.ButtonDef.DisplayName != "Prihlásiť")
            //            iBtn.ButtonDef.Enabled = false;
            //        if (iBtn.ButtonDef.DisplayName == "Prihlásiť")
            //            iBtn.ButtonDef.Enabled = true;

            //    }
            //    AddinGlobal.LoggedIn = false;
            //    AddinGlobal.oSetFaces = null;
            //}
               
        }
        public static void Button5_Execute()
        {
            //TODO: add code below for the button click callback.
            //Novy_PK newPK = null;
            //Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;

            //if (((oLogin = (Login)AddinGlobal.IsFormAlreadyOpen(typeof(Login))) == null) && ((oView = (View)AddinGlobal.IsFormAlreadyOpen(typeof(View))) == null) && ((oEdit = (Edit)AddinGlobal.IsFormAlreadyOpen(typeof(Edit))) == null) && ((newPK = (Novy_PK)AddinGlobal.IsFormAlreadyOpen(typeof(Novy_PK))) == null))
            //{
            //    newPK = new Novy_PK();
            //    newPK.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    newPK.Select();
            //}
          
        }
        public static void Button6_Execute()
        {
            //Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            //if (((oLogin = (Login)AddinGlobal.IsFormAlreadyOpen(typeof(Login))) == null) && ((oView = (View)AddinGlobal.IsFormAlreadyOpen(typeof(View))) == null) && ((oEdit = (Edit)AddinGlobal.IsFormAlreadyOpen(typeof(Edit))) == null) && ((oNovyPK = (Novy_PK)AddinGlobal.IsFormAlreadyOpen(typeof(Novy_PK))) == null))
            //{
            //    oEdit = new Edit();
            //    oEdit.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    oEdit.Select();
            //}

            
        }
        public static void Button7_Execute()
        {
            //Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            //if (((oLogin = (Login)AddinGlobal.IsFormAlreadyOpen(typeof(Login))) == null) && ((oView = (View)AddinGlobal.IsFormAlreadyOpen(typeof(View))) == null) && ((oEdit = (Edit)AddinGlobal.IsFormAlreadyOpen(typeof(Edit))) == null) && ((oNovyPK = (Novy_PK)AddinGlobal.IsFormAlreadyOpen(typeof(Novy_PK))) == null))
            //{
            //    oView = new View();
            //    oView.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            //}
            //else
            //{
            //    oView.Select();
            //}

          
        }
        public static void Button8_Execute()
        {
            Create oCreate = new Create();
            oCreate.Show();
        }







    }
}
