using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using System.Windows.Forms;

namespace Blastman
{
    class DataKybernetika
    {
        public void ShowInfos()
        {
            SketchEntity oSketchEnt= AddinGlobal.InventorApp.ActiveDocument.SelectSet[1];
            TransientGeometry oTrans = AddinGlobal.InventorApp.TransientGeometry;
            Face oFace = oSketchEnt.ReferencedEntity;
            MessageBox.Show("Referenced entity: " + oFace.Appearance.DisplayName);

        }
    }
}
