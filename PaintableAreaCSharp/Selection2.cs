using Inventor;
using System;

namespace Blastman
{
    class Selection2
    {
        private InteractionEvents objInteraction;
        private SelectEvents sle;
        private UserInputEvents uiecc;
        private bool curSelection = false;
        private bool bStillSelecting;
        public Object PickOneEntity(string Message, SelectionFilterEnum filter, SelectionFilterEnum filter2, SelectionFilterEnum filter3)
        {
            
            Object ReturnObject;
            bStillSelecting = true;
            sle = null;
            objInteraction = null;
            objInteraction = AddinGlobal.InventorApp.CommandManager.CreateInteractionEvents();
            sle = objInteraction.SelectEvents;
            sle.ResetSelections();
            sle.ClearSelectionFilter();
            sle.SingleSelectEnabled = true;
            sle.AddSelectionFilter(filter);
            sle.AddSelectionFilter(filter2);
            sle.AddSelectionFilter(filter3);
            objInteraction.StatusBarText = Message;
            //objInteraction.SetCursor(CursorTypeEnum.kCursorBuiltInSelectArrow);
            curSelection = true;

            
            sle.OnSelect += new SelectEventsSink_OnSelectEventHandler(sle_OnSelect);
            sle.OnUnSelect += new SelectEventsSink_OnUnSelectEventHandler(sle_OnUnSelect);
            objInteraction.OnTerminate += new InteractionEventsSink_OnTerminateEventHandler(objInteraction_OnTerminate);
            objInteraction.Start();

           
            do
            {
                System.Windows.Forms.Application.DoEvents();
            } while (bStillSelecting);

            ObjectsEnumerator oSelectedEnts = sle.SelectedEntities;
            if (oSelectedEnts.Count > 0)
            {
               ReturnObject = oSelectedEnts[1];
            }
            else
                ReturnObject = null;
            objInteraction.Stop();
            sle = null;
            objInteraction = null;
            return ReturnObject;
        }
        public Object PickOneEntity(string Message, SelectionFilterEnum filter, SelectionFilterEnum filter2)
        {

            Object ReturnObject;
            bStillSelecting = true;
            sle = null;
            objInteraction = null;
            objInteraction = AddinGlobal.InventorApp.CommandManager.CreateInteractionEvents();
            sle = objInteraction.SelectEvents;
            sle.ResetSelections();
            sle.ClearSelectionFilter();
            sle.SingleSelectEnabled = true;
            sle.AddSelectionFilter(filter);
            sle.AddSelectionFilter(filter2);
            objInteraction.StatusBarText = Message;
            //objInteraction.SetCursor(CursorTypeEnum.kCursorBuiltInSelectArrow);
            curSelection = true;


            sle.OnSelect += new SelectEventsSink_OnSelectEventHandler(sle_OnSelect);
            sle.OnUnSelect += new SelectEventsSink_OnUnSelectEventHandler(sle_OnUnSelect);
            objInteraction.OnTerminate += new InteractionEventsSink_OnTerminateEventHandler(objInteraction_OnTerminate);
            objInteraction.Start();


            do
            {
                System.Windows.Forms.Application.DoEvents();
            } while (bStillSelecting);

            ObjectsEnumerator oSelectedEnts = sle.SelectedEntities;
            if (oSelectedEnts.Count > 0)
            {
                ReturnObject = oSelectedEnts[1];
            }
            else
                ReturnObject = null;
            objInteraction.Stop();
            sle = null;
            objInteraction = null;
            return ReturnObject;
        }
        public Object PickOneEntity(string Message, SelectionFilterEnum filter)
        {

            Object ReturnObject;
            bStillSelecting = true;
            sle = null;
            objInteraction = null;
            objInteraction = AddinGlobal.InventorApp.CommandManager.CreateInteractionEvents();
            sle = objInteraction.SelectEvents;
            sle.ResetSelections();
            sle.ClearSelectionFilter();
            sle.SingleSelectEnabled = true;
            sle.AddSelectionFilter(filter);
            objInteraction.StatusBarText = Message;
            //objInteraction.SetCursor(CursorTypeEnum.kCursorBuiltInSelectArrow);
            curSelection = true;


            sle.OnSelect += new SelectEventsSink_OnSelectEventHandler(sle_OnSelect);
            sle.OnUnSelect += new SelectEventsSink_OnUnSelectEventHandler(sle_OnUnSelect);
            objInteraction.OnTerminate += new InteractionEventsSink_OnTerminateEventHandler(objInteraction_OnTerminate);
            objInteraction.Start();


            do
            {
                System.Windows.Forms.Application.DoEvents();
            } while (bStillSelecting);

            ObjectsEnumerator oSelectedEnts = sle.SelectedEntities;
            if (oSelectedEnts.Count > 0)
            {
                ReturnObject = oSelectedEnts[1];
            }
            else
                ReturnObject = null;
            objInteraction.Stop();
            sle = null;
            objInteraction = null;
            return ReturnObject;
        }

        private void sle_OnUnSelect(ObjectsEnumerator UnSelectedEntities, SelectionDeviceEnum SelectionDevice,
    Inventor.Point ModelPosition, Point2d ViewPosition, Inventor.View View)
        {
            if (curSelection)
            {
                //Can remove selected entities from an ObjectCollection or list
            }
        }

        private void sle_OnSelect(ObjectsEnumerator JustSelectedEntities, SelectionDeviceEnum SelectionDevice,
            Inventor.Point ModelPosition, Point2d ViewPosition, Inventor.View View)
        {
            if (curSelection)
            {
                bStillSelecting = false;
                //Can add selected entities to an ObjectCollection or list
            }
        }
        private void objInteraction_OnTerminate()
        {
            bStillSelecting = false;
        }
    }
}
