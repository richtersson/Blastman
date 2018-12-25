using Inventor;
using System;

namespace Blastman
{
    public class MySelection
    {
        private InteractionEvents oInteractEvents;
        private SelectEvents oSelectEvents;

        private bool bStillSelecting;
        

        public Object PickOneEntity(SelectionFilterEnum filter)
        {
            Object ReturnObject;
            bStillSelecting = true;
            oInteractEvents = AddinGlobal.InventorApp.CommandManager.CreateInteractionEvents();
            oInteractEvents.InteractionDisabled = false;
            
            oSelectEvents = oInteractEvents.SelectEvents;
            
            
            //oSelectEvents.AddSelectionFilter(SelectionFilterEnum.kPartFaceFilter);
            oInteractEvents.Start();
            do
            {
                System.Windows.Forms.Application.DoEvents();
            } while (bStillSelecting);

            ObjectsEnumerator oSelectedEnts = oSelectEvents.SelectedEntities;
            if (oSelectedEnts.Count > 0)
            {
                ReturnObject= oSelectedEnts[0];
            }
            else
                ReturnObject= null;
            oInteractEvents.Stop();
            oSelectEvents = null;
            oInteractEvents = null;
            return ReturnObject;

        }
        private void oInteraction_OnTerminate()
        {
            bStillSelecting = false;
        }
        private void oSelect_OnSelect (ObjectsEnumerator JustSelectedEntities, SelectionDeviceEnum SelectionDevice, Point ModelPosition, Point2d ViewPositition, View View)
        {
            bStillSelecting = false;
        }
    }
}
