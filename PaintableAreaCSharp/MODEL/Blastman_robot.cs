using Inventor;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Blastman
{
    

    
    public class Blastman_program 

    {
        private ObservableCollection<PositionConfiguration> positionlist;
        
        AssemblyDocument oAssembly;
        AssemblyComponentDefinition oAssemblyDef;
        Parameter oP1_X;
        Parameter oP2_Y;
        Parameter oP3_C;
        Parameter oP4_Z;
        Parameter oP5_A1;
        Parameter oP6_A2;
        Parameter oP7_A3;
        Parameter oP8_A4;
        Parameter oSwing_axle;

        public ObservableCollection<PositionConfiguration> PositionList { get => positionlist; set
            {
                if (value != positionlist)
                {
                    positionlist = value;
                   
                }
            }
        }

        

        public Blastman_program (Inventor.Application inventorApp) 
        {
            oAssembly = (AssemblyDocument)inventorApp.ActiveDocument;
            oAssemblyDef = oAssembly.ComponentDefinition;
            
            positionlist = new ObservableCollection<PositionConfiguration>();
             oP1_X = oAssemblyDef.Parameters["P1_X"];
             oP2_Y = oAssemblyDef.Parameters["P2_Y"];
             oP3_C = oAssemblyDef.Parameters["P3_C"];
             oP4_Z = oAssemblyDef.Parameters["P4_Z"];
             oP5_A1 = oAssemblyDef.Parameters["P5_A1"];
             oP6_A2 = oAssemblyDef.Parameters["P6_A2"];
             oP7_A3 = oAssemblyDef.Parameters["P7_A3"];
             oP8_A4 = oAssemblyDef.Parameters["P8_A4"];
             oSwing_axle = oAssemblyDef.Parameters["swing_axle"];
        }

        public void MoveToSliders(double p1_X, double p2_Y, double p3_C, double p4_Z, double p5_A1, double p6_A2, double p7_A3, double p8_A4)
        {
            
            oP1_X.Value = -p1_X/10;
            oP2_Y.Value = -p2_Y/10;
            oP3_C.Value = p3_C / 180* Math.PI;
            oP4_Z.Value = p4_Z/10;
            oP5_A1.Value = p5_A1 / 180 * Math.PI;
            oP6_A2.Value = p6_A2 / 180 * Math.PI;
            oP7_A3.Value = p7_A3 / 180 * Math.PI;
            oP8_A4.Value = p8_A4 / 180 * Math.PI;
            

            oAssembly.Update();
        }

        public bool XMLExport()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML súbor|*.xml";
            saveFileDialog1.Title = "Uložiť XML výstup";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, GetXMLText());
            }
            Process.Start("notepad.exe", saveFileDialog1.FileName);


            return true;
        }
        private string GetXMLText()
        {
            string header;
            string footer;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(System.IO.Path.Combine(XMLReader.AssemblyDirectory, "XMLheader.xml")))
                {
                    // Read the stream to a string, and write the string to the console.
                    header = sr.ReadToEnd() + System.Environment.NewLine;


                }
                using (StreamReader sr = new StreamReader(System.IO.Path.Combine(XMLReader.AssemblyDirectory, "XMLfooter_home.xml")))
                {
                    // Read the stream to a string, and write the string to the console.
                    footer = sr.ReadToEnd() + System.Environment.NewLine;


                }
            }
            catch (Exception e)
            {
                throw new Exception("Program nemôže načítať hlavičku. Preinštalujte nadstavbu Blastman NC Control.");
            }


            
            int i = 1;
            string finalText=header;
            foreach (PositionConfiguration oPosition in this.positionlist)
            {
                string point;
                point = "<!--Point: " + i +"-->" + System.Environment.NewLine;
                i++;
                point += "<point" + System.Environment.NewLine;
                point += @"type=""1""" + System.Environment.NewLine;
                point += @"j1=""" + Math.Round(-oPosition.oDof.P1_X * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j2=""" + Math.Round(-oPosition.oDof.P2_Y* 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j3=""" + Math.Round(oPosition.oDof.P3_C * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j4=""" + Math.Round(oPosition.oDof.P4_Z * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j5=""" + Math.Round(oPosition.oDof.P5_A1 * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j6=""" + Math.Round(-oPosition.oDof.P6_A2 * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j7=""" + Math.Round(-oPosition.oDof.P7_A3 * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"j8=""" + Math.Round(-oPosition.oDof.P8_A4 * 100).ToString() + @"""" + System.Environment.NewLine;
                point += @"time_or_axle=""" + oPosition.Time_or_axle + @"""" + System.Environment.NewLine;
                point += @"joint_speed=""" + oPosition.Joint_speed + @"""" + System.Environment.NewLine;
                point += @"blasting_state=""" + oPosition.Blasting_state + @"""" + System.Environment.NewLine;
                point += @"swing_axle=""" + oPosition.Swing_axle + @"""" + System.Environment.NewLine;
                point += @"swing_angle=""" + oPosition.Swing_angle + @"""" + System.Environment.NewLine;
                point += @"swing_speed=""" + oPosition.Swing_speed + @""" />" + System.Environment.NewLine;
                finalText += point;
            }
            finalText += footer;
            finalText += "</info>";

            return finalText;
        }
        public void PlayProgram()
        {
            for (int i = 0; i < positionlist.Count-1 ; i++)
            {
                 RunBetweenPositions(positionlist[i], positionlist[i + 1]);
                

            }
        }
        private void RunBetweenPositions(PositionConfiguration firstposition, PositionConfiguration secondposition)
        {
            double oStartPositionP1= firstposition.oDof.P1_X/10;
            double oStartPositionP2 = firstposition.oDof.P2_Y / 10;
            double oStartPositionP3 = firstposition.oDof.P3_C / 180 * Math.PI;
            double oStartPositionP4 = firstposition.oDof.P4_Z / 10;
            double oStartPositionP5 = firstposition.oDof.P5_A1 / 180 * Math.PI;
            double oStartPositionP6 = firstposition.oDof.P6_A2 / 180 * Math.PI;
            double oStartPositionP7 = firstposition.oDof.P7_A3 / 180 * Math.PI;
            double oStartPositionP8 = firstposition.oDof.P8_A4 / 180 * Math.PI;


            oP1_X.Value = -oStartPositionP1;
            oP2_Y.Value = -oStartPositionP2;
            oP3_C.Value = oStartPositionP3;
            oP4_Z.Value = oStartPositionP4;
            oP5_A1.Value = oStartPositionP5;
            oP6_A2.Value = oStartPositionP6;
            oP7_A3.Value = oStartPositionP7;
            oP8_A4.Value = oStartPositionP8;

            double oLimitPositionP1 = secondposition.oDof.P1_X/10;
            double oLimitPositionP2 = secondposition.oDof.P2_Y / 10;
            double oLimitPositionP3 = secondposition.oDof.P3_C / 180 * Math.PI; 
            double oLimitPositionP4 = secondposition.oDof.P4_Z / 10;
            double oLimitPositionP5 = secondposition.oDof.P5_A1 / 180 * Math.PI; 
            double oLimitPositionP6 = secondposition.oDof.P6_A2 / 180 * Math.PI; 
            double oLimitPositionP7 = secondposition.oDof.P7_A3 / 180 * Math.PI; 
            double oLimitPositionP8 = secondposition.oDof.P8_A4 / 180 * Math.PI; 


            double oStep;
            int oDelay = Convert.ToInt16(firstposition.Time_or_axle) *1000/100;

            double distanceP1 = Math.Abs(oStartPositionP1-oLimitPositionP1);
            double distanceP2 = Math.Abs(oStartPositionP2 - oLimitPositionP2);
            double distanceP3 = Math.Abs(oStartPositionP3 - oLimitPositionP3);
            double distanceP4 = Math.Abs(oStartPositionP4 - oLimitPositionP4);
            double distanceP5 = Math.Abs(oStartPositionP5 - oLimitPositionP5);
            double distanceP6 = Math.Abs(oStartPositionP6 - oLimitPositionP6);
            double distanceP7 = Math.Abs(oStartPositionP7 - oLimitPositionP7);
            double distanceP8 = Math.Abs(oStartPositionP8 - oLimitPositionP8);

            if (oStartPositionP1 > oLimitPositionP1)
                distanceP1 = distanceP1 * -1;
            if (oStartPositionP2 > oLimitPositionP2)
                distanceP2 = distanceP2 * -1;
            if (oStartPositionP3 > oLimitPositionP3)
                distanceP3 = distanceP3 * -1;
            if (oStartPositionP4 > oLimitPositionP4)
                distanceP4 = distanceP4 * -1;
            if (oStartPositionP5 > oLimitPositionP5)
                distanceP5 = distanceP5 * -1;
            if (oStartPositionP6 > oLimitPositionP6)
                distanceP6 = distanceP6 * -1;
            if (oStartPositionP7 > oLimitPositionP7)
                distanceP7 = distanceP7 * -1;
            if (oStartPositionP8 > oLimitPositionP8)
                distanceP8 = distanceP8 * -1;
            int speed = 20;
            for (int i = 0; i < speed; i++)
            {
                System.Threading.Thread.Sleep(oDelay);
                oP1_X.Value -= distanceP1 / speed;
                oP2_Y.Value -= distanceP2 / speed;
                oP3_C.Value += (distanceP3 / 180 * Math.PI)/speed;
                oP4_Z.Value += distanceP4 / speed;
                oP5_A1.Value += (distanceP5 / 180 * Math.PI) / speed;
                oP6_A2.Value += (distanceP6 / 180 * Math.PI) / speed;
                oP7_A3.Value += (distanceP7 / 180 * Math.PI) / speed;
                oP8_A4.Value += (distanceP8 / 180 * Math.PI) / speed;
                //if (reverse)
                //    movingparameter.Value -= distance / 100;
                //else
                //    movingparameter.Value += distance / 100;
                oAssembly.Update();
                AddinGlobal.InventorApp.ActiveView.Update();
            }
            
            

            
           
        }
        



    }
    public class PositionConfiguration:INotifyPropertyChanged
    {
        private int positionNumber;
        private DegreesOfFreedom odof;
        private string time_or_axle;
        private string joint_speed;
        private string blasting_state;
        private string swing_axle;
        private string swing_angle;
        private string swing_speed;

        public int PositionNumber { get => positionNumber; set
            {
                if (value != positionNumber)
                {
                    positionNumber = value;
                    OnPropertyChanged("PositionNumber");
                }
            }
        }

        public DegreesOfFreedom oDof { get => odof; set => odof = value; }
        public string Time_or_axle { get => time_or_axle; set => time_or_axle = value; }
        public string Joint_speed { get => joint_speed; set => joint_speed = value; }
        public string Blasting_state { get => blasting_state; set => blasting_state = value; }
        public string Swing_axle { get => swing_axle; set => swing_axle = value; }
        public string Swing_angle { get => swing_angle; set => swing_angle = value; }
        public string Swing_speed { get => swing_speed; set => swing_speed = value; }

        public PositionConfiguration(Inventor.Application inventorApp, int positionnumber, double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8, string _timeoraxle, string _jointspeed, string _blastingstate, string _swingaxle, string _swingangle, string _swingspeed) 
        {
            odof = new DegreesOfFreedom(p1,p2, p3,p4, p5, p6,p7,p8);
            positionNumber = positionnumber;
            time_or_axle = _timeoraxle;
            joint_speed = _jointspeed;
            blasting_state = _blastingstate;
            swing_axle = _swingaxle;
            swing_angle = _swingangle;
            Swing_speed = _swingspeed;
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

    }
    public struct DegreesOfFreedom : INotifyPropertyChanged
    {





        private double _P1_X;
        private double _p2_Y;
        private double _p3_C;
        private double _p4_Z;
        private double _p5_A1;
        private double _p6_A2;
        private double _p7_A3;
        private double _p8_A4;

        public double P1_X
        {
            get { return _P1_X; }
            set
            {
                _P1_X = value;
                OnPropertyChanged("P1_X");
            }
        }
        public double P2_Y { get => _p2_Y; set
            {
                _p2_Y = value;
                OnPropertyChanged("P2_Y");
            }
        }
        public double P3_C { get => _p3_C; set
            {
                _p3_C = value;
                OnPropertyChanged("P3_C");
            }
        }
        public double P4_Z { get => _p4_Z; set
            {
                _p4_Z = value;
                OnPropertyChanged("P4_Z");
            }
        }
        public double P5_A1 { get => _p5_A1; set
            {
                _p5_A1 = value;
                OnPropertyChanged("P5_A1");
            }
        }
        public double P6_A2 { get => _p6_A2; set
            {
                _p6_A2 = value;
                OnPropertyChanged("P6_A2");
            }
        }
        public double P7_A3 { get => _p7_A3; set
            {
                _p7_A3 = value;
                OnPropertyChanged("P7_A3");
            }
        }
        public double P8_A4 { get => _p8_A4; set
            {
                _p8_A4 = value;
                OnPropertyChanged("P8_A4");
            }
        }

        public DegreesOfFreedom(double p1_X, double p2_Y, double p3_C, double p4_Z, double p5_A1, double p6_A2, double p7_A3, double p8_A4) : this()
        {
            P1_X = p1_X;
            P2_Y = p2_Y;
            P3_C = p3_C;
            P4_Z = p4_Z;
            P5_A1 = p5_A1;
            P6_A2 = p6_A2;
            P7_A3 = p7_A3;
            P8_A4 = p8_A4;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
