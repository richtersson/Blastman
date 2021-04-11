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

            Login oLogin = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            // ((oLogin = (Login)AddinGlobal.IsWindowOpen<Window>("Login"))==null)
            if (AddinGlobal.IsWindowOpenReal<Window>("Login"))
            {
                oLogin = new Login();
                // Could be a good idea to set the owner for this window
                // especially if used as modeless
                var helper = new System.Windows.Interop.WindowInteropHelper(oLogin);
                helper.Owner = new IntPtr(AddinGlobal.InventorApp.MainFrameHWND);

                oLogin.Show();
            }
            else
            {
                oLogin.Activate();

            }


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

            foreach (InventorButton iBtn in AddinGlobal.ButtonList)
            {
                if (iBtn.ButtonDef.DisplayName != "Prihlásiť")
                    iBtn.ButtonDef.Enabled = false;
                if (iBtn.ButtonDef.DisplayName == "Prihlásiť")
                    iBtn.ButtonDef.Enabled = true;

            }
            AddinGlobal.LoggedIn = false;



        }
        public static void Button5_Execute()
        {
            NewProgram oProgram = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            // ((oLogin = (Login)AddinGlobal.IsWindowOpen<Window>("Login"))==null)
            if (AddinGlobal.IsWindowOpenReal<Window>("NewProgram"))
            {
                oProgram = new NewProgram();
                // Could be a good idea to set the owner for this window
                // especially if used as modeless
                var helper = new System.Windows.Interop.WindowInteropHelper(oProgram);
                helper.Owner = new IntPtr(AddinGlobal.InventorApp.MainFrameHWND);

                oProgram.Show();
            }
            else
            {
                oProgram.Activate();

            }
        }
        public static void Button6_Execute()
        {
            EditWPF oEdit = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            // ((oLogin = (Login)AddinGlobal.IsWindowOpen<Window>("Login"))==null)
            if (AddinGlobal.IsWindowOpenReal<Window>("NewProgram"))
            {
                oEdit = new EditWPF();
                // Could be a good idea to set the owner for this window
                // especially if used as modeless
                var helper = new System.Windows.Interop.WindowInteropHelper(oEdit);
                helper.Owner = new IntPtr(AddinGlobal.InventorApp.MainFrameHWND);

                oEdit.Show();
            }
            else
            {
                oEdit.Activate();

            }


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
            //Blastman_program oProgram = new Blastman_program(AddinGlobal.InventorApp);

            //string ModelPath = AddinGlobal.BlastmanModelFolder + @"\" + oProgram.ProgramName + @"\" + oProgram.ProgramName + ".iam";
            //if (ModelPath != null)
            //{
            //    AddinGlobal.InventorApp.Documents.Open(ModelPath);
            //    oProgram.MapParameters();
            //    this.Close();
            //    DataTable dtPositions = cldDB.P_POSITION_SEL(oProgram.ProgramName);
            //    foreach (DataRow row in dtPositions.Rows)
            //    {


            //        oProgram.PositionList.Add(new PositionConfiguration(AddinGlobal.InventorApp, (int)row["positionNumber"], (double)row["P1_X"], (double)row["P2_Y"], (double)row["P3_C"], (double)row["P4_Z"], (double)row["P5_A1"], (double)row["P6_A2"], (double)row["P7_A3"], (double)row["P8_A4"], (string)row["time_or_axle"], (string)row["joint_speed"], (string)row["blasting_state"], (string)row["swing_axle"], (string)row["swing_angle"], (string)row["swing_speed"]));


            //    }


            //    Create oCreate = new Create(oProgram);
            //    oCreate.Show();

            //}
            Create oCreate = null;
            if (AddinGlobal.IsWindowOpenReal<Window>("Create"))

            {
                oCreate = new Create(AddinGlobal.AktivnyBlastmanProgram);
                oCreate.Show();
            }
            else
            {
                oCreate.Activate();
            }
        }
        public static void Button9_Execute()
        {
            LoadProgram oProgram = null;
            //View oView = null;
            //Edit oEdit = null;
            //Novy_PK oNovyPK = null;
            // ((oLogin = (Login)AddinGlobal.IsWindowOpen<Window>("Login"))==null)
            if (AddinGlobal.IsWindowOpenReal<Window>("LoadProgram"))
            {
                oProgram = new LoadProgram();
                // Could be a good idea to set the owner for this window
                // especially if used as modeless
                var helper = new System.Windows.Interop.WindowInteropHelper(oProgram);
                helper.Owner = new IntPtr(AddinGlobal.InventorApp.MainFrameHWND);

                oProgram.Show();
            }
            else
            {
                oProgram.Activate();

            }
        }







    }
}
