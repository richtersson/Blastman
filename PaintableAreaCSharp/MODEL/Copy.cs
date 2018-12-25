using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blastman
{
    public partial class Copy : Form
    {
        private string _newmodelpath;
        private string _oldmodelpath;
        private string _oldnazov;
        private string _starecislo;
        private int _stav;
        public Copy(string StareCisloVykresu, string nazov, int stav, string oldmodelpath)
        {
            InitializeComponent();
            _starecislo = StareCisloVykresu;
            _oldmodelpath = oldmodelpath;
            _oldnazov = nazov;
            _stav = stav;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnVytvorit_Click(object sender, EventArgs e)
        {
            if (txtNazov.Text==null||cBoxCislaVykresov.SelectedValue == null)

            {
                MessageBox.Show("Zadefinujte všetky parametre.", "Nesprávna definícia", MessageBoxButtons.OK);
            }
            else
            {
                string Path = @"W:\" + cBoxCislaVykresov.SelectedValue + @"\" + txtNazov.Text;
                if (Directory.Exists(Path))
                {
                    
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(Path);
                }

                //AddinGlobal.InventorApp.Documents.Open(ModelPath);
                //Predpis_kontroly oPK = new Predpis_kontroly(oRow.Cells[0].Value.ToString(), oRow.Cells[2].Value.ToString(), ModelPath);
                //oPK.Rebuild();
                //AddinGlobal.AktivnyPredpisKontroly = oPK;
                //BasicInterface oBI = new BasicInterface(AddinGlobal.AktivnyPredpisKontroly);
                //this.Close();
                //oBI.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));


                string FileName = System.IO.Path.GetFileName(this._oldmodelpath);
                string NewModelPath = System.IO.Path.Combine(Path, FileName);
                //copy model
                File.Copy(_oldmodelpath, NewModelPath);

                //copy filecontext
                File.Copy(System.IO.Path.GetDirectoryName(_oldmodelpath) + @"\keydata.nai", System.IO.Path.GetDirectoryName(NewModelPath) + @"\keydata.nai");
                
                //Database.P_PREDPISKONTROLA_INS(cBoxCislaVykresov.SelectedValue.ToString(), txtNazov.Text, Path, FileName,_starecislo,_oldnazov,_stav);

                AddinGlobal.InventorApp.Documents.Open(NewModelPath);
                Predpis_kontroly oPK = new Predpis_kontroly(cBoxCislaVykresov.SelectedValue.ToString(),txtNazov.Text,0, NewModelPath);
                this.Close();
                oPK.RebuildCopy(_starecislo, _oldnazov,_stav);
                AddinGlobal.AktivnyPredpisKontroly = oPK;
                oPK.Save(false);
                BasicInterface bi = new BasicInterface(AddinGlobal.AktivnyPredpisKontroly);
                bi.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
            }
        }

        private void Novy_PK_Load(object sender, EventArgs e)
        {
            lblName.Text = "Kópia výkresu číslo " + _starecislo + " do výkresu:";
            //DataTable dt = Database.P_VYKRESYBEZPREDPISU();

            //cBoxCislaVykresov.DataSource = dt;
            cBoxCislaVykresov.DisplayMember ="VYK_CISLO_QMS";
            cBoxCislaVykresov.ValueMember = "VYK_CISLO_QMS";
            cBoxCislaVykresov.BindingContext = this.BindingContext;
        }
    }
}
