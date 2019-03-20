using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using _3Dconnexion;
using System.Windows.Interop;
using System.IO;
using Blastman.Properties;
using System.Windows.Forms;

namespace Blastman
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window, INotifyPropertyChanged
    {
        private Blastman_program _oBlastmanProgram;
  
        private ObservableCollection<PositionConfiguration> _positionList;
        private string time_or_axle;
        private string joint_speed;
        private string blasting_state;
        private string swing_axle;
        private string swing_angle;
        private string swing_speed;
        private double p1_X;
        private double p2_Y;
        private double p3_C;
        private double p4_Z;
        private double p5_A1;
        private double p6_A2;
        private double p7_A3;
        private double p8_A4;
        private int totalprogramtime;
        private string programname;



        #region Properties
        public Blastman_program oBlastmanProgram { get => _oBlastmanProgram; set => _oBlastmanProgram = value; }




        public ObservableCollection<PositionConfiguration> oPositionList
        {
            get => _positionList; set
            {
                if (value != _positionList)
                {
                    _positionList = value;
                    OnPropertyChanged("oPositionList");


                }
            }
        }

        public double P1_X
        {
            get => p1_X;
            set
            {
                if (value != p1_X)
                {
                    p1_X = value;
                    OnPropertyChanged("P1_X");

                    try
                    {
                        oBlastmanProgram.MoveToSliders(p1_X, p2_Y, p3_C, p4_Z, p5_A1, p6_A2, p7_A3, p8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P2_Y
        {
            get => p2_Y; set
            {
                if (value != p2_Y)
                {
                    p2_Y = value;
                    OnPropertyChanged("P2_Y");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }

        public double P3_C
        {
            get => p3_C; set
            {
                if (value != p3_C)
                {
                    p3_C = value;
                    OnPropertyChanged("P3_C");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P4_Z
        {
            get => p4_Z; set
            {
                if (value != p4_Z)
                {
                    p4_Z = value;
                    OnPropertyChanged("P4_Z");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P5_A1
        {
            get => p5_A1; set
            {
                if (value != p5_A1)
                {
                    p5_A1 = value;
                    OnPropertyChanged("P5_A1");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P6_A2
        {
            get => p6_A2; set
            {
                if (value != p6_A2)
                {
                    p6_A2 = value;
                    OnPropertyChanged("P6_A2");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P7_A3
        {
            get => p7_A3; set
            {
                if (value != p7_A3)
                {
                    p7_A3 = value;
                    OnPropertyChanged("P7_A3");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public double P8_A4
        {
            get => p8_A4; set
            {
                if (value != p8_A4)
                {
                    p8_A4 = value;
                    OnPropertyChanged("P8_A4");
                    try
                    {
                        oBlastmanProgram.MoveToSliders(P1_X, P2_Y, P3_C, P4_Z, P5_A1, P6_A2, P7_A3, P8_A4);
                    }
                    catch
                    { }
                }
            }
        }
        public string Time_or_axle
        {
            get => time_or_axle; set
            {
                if (value != time_or_axle)
                {
                    time_or_axle = value;
                    OnPropertyChanged("Time_or_axle");

                }
            }
        }
        public string Joint_speed
        {
            get => joint_speed; set
            {
                if (value != joint_speed)
                {
                    joint_speed = value;
                    OnPropertyChanged("Joint_speed");

                }
            }
        }
        public string Blasting_state
        {
            get => blasting_state; set
            {
                if (value != blasting_state)
                {
                    blasting_state = value;
                    OnPropertyChanged("Blasting_state");

                }
            }
        }
        public string Swing_axle
        {
            get => swing_axle; set
            {
                if (value != swing_axle)
                {
                    swing_axle = value;
                    OnPropertyChanged("Swing_axle");

                }
            }
        }
        public string Swing_angle
        {
            get => swing_angle; set
            {
                if (value != swing_angle)
                {
                    swing_angle = value;
                    OnPropertyChanged("Swing_angle");

                }
            }
        }
        public string Swing_speed
        {
            get => swing_speed; set
            {
                if (value != swing_speed)
                {
                    swing_speed = value;
                    OnPropertyChanged("Swing_speed");

                }
            }
        }

        public int TotalProgramTime
        {
            get => totalprogramtime; set
            {
                if (value != totalprogramtime)
                {
                    totalprogramtime = value;
                    OnPropertyChanged("TotalProgramTime");

                }
            }
        }

        public string ProgramName
        {
            get => programname; set
            {
                if (value != programname)
                {
                    programname = value;
                    OnPropertyChanged("ProgramName");

                }
            }
        } 
        #endregion

        public Create(Blastman_program blastmanprogram)
        {
            InitializeComponent();
            _oBlastmanProgram = blastmanprogram;
            programname = _oBlastmanProgram.ProgramName;
            _positionList = _oBlastmanProgram.PositionList;
            time_or_axle = "1";
            joint_speed = "0";
            blasting_state = "0";
            swing_axle = "0";
            swing_angle = "3000";
            swing_speed = "1000";


            this.DataContext = this;
            
        }

        private void btnSavePosition_Click(object sender, RoutedEventArgs e)
        {

            _oBlastmanProgram.PositionList.Add(new PositionConfiguration(AddinGlobal.InventorApp, oBlastmanProgram.PositionList.Count+1,p1_X,p2_Y,p3_C,p4_Z,p5_A1,p6_A2,p7_A3,p8_A4,time_or_axle,joint_speed,blasting_state,swing_axle,swing_angle,swing_speed));
            TotalProgramTime = _positionList.Sum(item => Convert.ToInt32(item.Time_or_axle));
        }

        

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            PositionConfiguration oPosition = row.Item as PositionConfiguration;
            int i = _positionList.Count;
            P1_X = oPosition.oDof.P1_X;
            P2_Y = oPosition.oDof.P2_Y;
            P3_C = oPosition.oDof.P3_C;
            P4_Z = oPosition.oDof.P4_Z;
            P5_A1 = oPosition.oDof.P5_A1;
            P6_A2 = oPosition.oDof.P6_A2;
            P7_A3 = oPosition.oDof.P7_A3;
            P8_A4 = oPosition.oDof.P8_A4;
           
            Time_or_axle = oPosition.Time_or_axle;
            Joint_speed = oPosition.Joint_speed;
            Blasting_state = oPosition.Blasting_state;
            Swing_axle = oPosition.Swing_axle;
            Swing_angle = oPosition.Swing_angle;
            Swing_speed = oPosition.Swing_speed;
            this.DataContext = this;

        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void btnXMLGenerate_Click(object sender, RoutedEventArgs e)
        {
            _oBlastmanProgram.XMLExport();
        }

        private void BtnDeletePosition_Click(object sender, RoutedEventArgs e)
        {
            if (datagridPolohy.SelectedItem!=null)
            {
                PositionConfiguration oPosition = datagridPolohy.SelectedItem as PositionConfiguration;
                _positionList.Remove(oPosition);
                RecalculateOrder();
                
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            if (datagridPolohy.SelectedItem != null)
            {
                PositionConfiguration oPosition = datagridPolohy.SelectedItem as PositionConfiguration;

                try
                {
                    _positionList.Move(_positionList.IndexOf(oPosition), _positionList.IndexOf(oPosition) - 1);
                    RecalculateOrder();
                }
                catch
                { }

            }
        }
        private void RecalculateOrder ()
        {
            
            foreach (PositionConfiguration oPosition2 in _positionList)
            {
                oPosition2.PositionNumber = _positionList.IndexOf(oPosition2) + 1;
            }
            OnPropertyChanged("oPositionList");
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            if (datagridPolohy.SelectedItem != null)
            {
                PositionConfiguration oPosition = datagridPolohy.SelectedItem as PositionConfiguration;

                try
                {
                    _positionList.Move(_positionList.IndexOf(oPosition), _positionList.IndexOf(oPosition) + 1);
                    RecalculateOrder();
                }
                catch { }

            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            _oBlastmanProgram.PlayProgram();
        }

        private const string appName = "Test Siapp";
        private const string logFileName = "log.txt";
        private const string templateTR = "TX: {1,-7}{0}TY: {2,-7}{0}TZ: {3,-7}{0}RX: {4,-7}{0}RY: {5,-7}{0}RZ: {6,-7}{0}P: {7}";

        private IntPtr hWnd = IntPtr.Zero;
        private IntPtr devHdl = IntPtr.Zero;
        private SiApp.SpwRetVal res;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            hWnd = new WindowInteropHelper(this).Handle; ;

            // Prepare log file
            File.Create(logFileName).Close();

            // Initialize the driver
            if (InitializeSiApp())
            {
                // Export the application commands to the driver
                ExportApplicationCommands();

                // Set the buttonbank / action set to use on the 3Dconnexion devices
                SiApp.SiAppCmdActivateActionSet(devHdl, @"ACTION_SET_ID");
            }
        }
        private bool InitializeSiApp()
        {
            res = SiApp.SiInitialize();
            if (res != SiApp.SpwRetVal.SPW_NO_ERROR)
            {
                System.Windows.MessageBox.Show("Initialize function failed");
                return false;
            }

            Log("SiInitialize", res.ToString());

            SiApp.SiOpenData openData = new SiApp.SiOpenData();
            SiApp.SiOpenWinInit(openData, hWnd);
            if (openData.hWnd == IntPtr.Zero)
                System.Windows.MessageBox.Show("Handle is empty");
            Log("SiOpenWinInit", openData.hWnd + "(window handle)");

            devHdl = SiApp.SiOpen(appName, SiApp.SI_ANY_DEVICE, IntPtr.Zero, SiApp.SI_EVENT, openData);
            if (devHdl == IntPtr.Zero)
                System.Windows.MessageBox.Show("Open returns empty device handle");
            Log("SiOpen", devHdl + "(device handle)");

            return (devHdl != IntPtr.Zero);
        }
        /// <summary>
        /// Method to export the application commands to 3dxware so that they can be assigned to
        /// 3Dconnexion device buttons.
        /// </summary>
        private void ExportApplicationCommands()
        {
            string imagesPath = string.Empty;
            string resDllPath = string.Empty;
            string dllName = "3DxService.dll";

            string homePath = Get3DxWareHomeDirectory();

            if (!string.IsNullOrEmpty(homePath))
            {
                imagesPath = System.IO.Path.Combine(homePath, @"Cfg\Images\3DxService\{0}");
                resDllPath = System.IO.Path.Combine(homePath, @"en-US\" + dllName);
            }

            using (ActionCache cache = new ActionCache())
            {
                // An actionset can also be considered to be a buttonbank, a menubar, or a set of toolbars
                ActionNode buttonBank = cache.Add(new ActionSet("ACTION_SET_ID", "Custom action set"));

                // Add a couple of categiores / menus / tabs to the buttonbank/menubar/toolbar
                ActionNode fileNode = buttonBank.Add(new Category("CAT_ID_FILE", "File"));
                ActionNode editNode = buttonBank.Add(new Category("CAT_ID_EDIT", "Edit"));

                // Add menu items to the menus. When the button on the 3D mouse is pressed the id will be sent to the application
                // in the SI_APP_EVENT event structure in the SiAppCmdID.appCmdID field

                // Add menu items / actions which use bitmaps loaded in memory of this application
                //fileNode.Add(new _3Dconnexion.Action("ID_OPEN", "Open", "Open file", ImageItem.FromImage(Resources.Open)));
                //fileNode.Add(new _3Dconnexion.Action("ID_CLOSE", "Close", "Close file", ImageItem.FromImage(Resources.Сlose)));
                //fileNode.Add(new _3Dconnexion.Action("ID_EXIT", "Exit", "Exit program", ImageItem.FromImage(Resources.Exit)));

                // Export a menu item / action using a bitmap from an external dll resource
                fileNode.Add(new _3Dconnexion.Action("ID_ABOUT", "About", "Info about the program", ImageItem.FromResource(resDllPath, "#172", "#2")));

                // Add menu items / actions using bitmaps located on the harddrive
                editNode.Add(new _3Dconnexion.Action("ID_CUT", "Cut", "Shortcut is Ctrl + X", ImageItem.FromFile(string.Format(imagesPath, "Macro_Cut.png"))));
                editNode.Add(new _3Dconnexion.Action("ID_COPY", "Copy", "Shortcut is Ctrl + C", ImageItem.FromFile(string.Format(imagesPath, "Macro_Copy.png"))));
                editNode.Add(new _3Dconnexion.Action("ID_PASTE", "Paste", "Shortcut is Ctrl + V", ImageItem.FromFile(string.Format(imagesPath, "Macro_Paste.png"))));

                // Add a menu item without an image associated with it
                editNode.Add(new _3Dconnexion.Action("ID_UNDO", "Undo", "Shortcut is Ctrl + Z"));

                // Now add an image and associate it with the menu item ID_UNDO by using the same id as the menu item / action
                cache.Add(ImageItem.FromFile(string.Format(imagesPath, "Macro_Undo.png"), 0, @"ID_UNDO"));
                try
                {
                    // Write the complete cache to the driver
                    cache.SaveTo3Dxware(devHdl);
                }
                catch (Exception e)
                {
                    Log("cache.SaveTo3Dxware", e.Message);
                }
            }
        }
        private string Get3DxWareHomeDirectory()
        {
            string softwareKeyName = string.Empty;
            string homeDirectory = string.Empty;

            if (IntPtr.Size == 8)
            {
                softwareKeyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\3Dconnexion\3DxWare";
            }
            else
            {
                softwareKeyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\3Dconnexion\3DxWare";
            }

            object regValue = Microsoft.Win32.Registry.GetValue(softwareKeyName, "Home Directory", null);
            if (regValue != null)
            {
                homeDirectory = regValue.ToString();
            }

            return homeDirectory;
        }
        private void Log(string functionName, string result)
        {
            string msg = string.Format("{0}: Function {1} returns {2}{3}", DateTime.Now, functionName, result, Environment.NewLine);
            try
            {
                File.AppendAllText(logFileName, msg);
            }
            catch { };
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHomePosition_Click(object sender, RoutedEventArgs e)
        {
            oBlastmanProgram.MoveToSliders(0, 0, 0, 0, 0, 0, 0, 0);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            oBlastmanProgram.Save(true);
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (oBlastmanProgram.State==0)
            {
               
                MessageBoxResult result = System.Windows.MessageBox.Show("Chcete uložiť zmeny?", "Upozornenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Do this
                
                    this.Close();
                    AddinGlobal.InventorApp.SilentOperation = true;
                    oBlastmanProgram.Save(false);
                    
                    
                    AddinGlobal.InventorApp.ActiveDocument.Save2();
                    AddinGlobal.InventorApp.ActiveDocument.Close();
                    AddinGlobal.InventorApp.SilentOperation = false;

                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                    AddinGlobal.InventorApp.ActiveDocument.Close();
                }
                else if (result == MessageBoxResult.Cancel)
                {

                }
            }
            else
            {
                this.Close();

                AddinGlobal.InventorApp.ActiveDocument.Close();
            }
        }

        //private void SliderP1_X_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    oBlastmanProgram.MoveDirectly(-e.NewValue/10);
            
        //}
    }
}
