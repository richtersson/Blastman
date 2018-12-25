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
    public partial class Novy_PK : Form
    {
        private string ModelPath;
        public Novy_PK()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg1 = new OpenFileDialog();
            dlg1.DefaultExt = "*.ipt";
            dlg1.Multiselect = false;
            dlg1.Filter = "Inventor súčasti|*.ipt";

            if (dlg1.ShowDialog() != DialogResult.OK)
                return;
            ModelPath =  dlg1.FileName;
            lblPath.Text = Path.GetFileName(ModelPath);
        }

        private void btnVytvorit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModelPath == null || txtNazov.Text == null || cBoxCislaVykresov.SelectedValue == null)

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
                        try
                        {
                            DirectoryInfo di = Directory.CreateDirectory(Path);
                        }
                        catch
                        {
                            throw new Exception("Nie je možné vytvoriť zložku pre predpis kontroly. Skontrolujte pripojený disk.");
                        }
                    }




                    string FileName = System.IO.Path.GetFileName(ModelPath);
                    string NewModelPath = System.IO.Path.Combine(Path, FileName);

                    File.Copy(ModelPath, NewModelPath);
                    //Database.P_PREDPISKONTROLA_INS(cBoxCislaVykresov.SelectedValue.ToString(), txtNazov.Text, Path, FileName);

                    AddinGlobal.InventorApp.Documents.Open(NewModelPath);
                    Predpis_kontroly oPK = new Predpis_kontroly(cBoxCislaVykresov.SelectedValue.ToString(), txtNazov.Text, 0, NewModelPath);
                    this.Close();
                    AddinGlobal.AktivnyPredpisKontroly = oPK;
                    oPK.Save(false);
                    BasicInterface bi = new BasicInterface(AddinGlobal.AktivnyPredpisKontroly);
                    bi.Show(new InventorMainFrame(AddinGlobal.InventorApp.MainFrameHWND));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Novy_PK_Load(object sender, EventArgs e)
        {
            //DataTable dt = Database.P_VYKRESYBEZPREDPISU();

            //cBoxCislaVykresov.DataSource = dt;
            //cBoxCislaVykresov.DisplayMember ="VYK_CISLO_QMS";
            //cBoxCislaVykresov.ValueMember = "VYK_CISLO_QMS";
            //cBoxCislaVykresov.BindingContext = this.BindingContext;
        }
    }
}
