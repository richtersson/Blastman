using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blastman
{
    public class AdnTabIndexManager
    {
        private Form _form;

        private SortedDictionary<int, Control> _ctrlDic;

        private SortedDictionary<int, Control>.Enumerator _ctrlDicEnum;

        // Constructor, simply pass in the form
        // the TabIndexManager will take care of
        // initializing the form controls tab indices
        public AdnTabIndexManager(Form form)
        {
            _form = form;

            // Required in order to be able to catch form events
            _form.KeyPreview = true;

            _ctrlDic = new SortedDictionary<int, Control>();

            if (LoadControlsTabIndices(form.Controls))
            {
                _form.KeyPress += new KeyPressEventHandler(OnKeyPress);

                _ctrlDicEnum = _ctrlDic.GetEnumerator();
            }
        }

        // Loads tab indices recursively if form contains
        // container controls
        private bool LoadControlsTabIndices(
            System.Windows.Forms.Control.ControlCollection ctrls)
        {
            try
            {
                foreach (Control ctrl in ctrls)
                {
                    // We don't set focus to containers,
                    // groupboxes or panels because
                    // it is usually useless
                    if (!(ctrl is ContainerControl) &&
                        !(ctrl is GroupBox) &&
                        !(ctrl is Panel))
                    {
                        int index = ctrl.TabIndex;

                        //prevents duplicates tabIndex
                        //can happen in case of nested controls
                        while (_ctrlDic.ContainsKey(index))
                            ++index;

                        _ctrlDic.Add(index, ctrl);
                    }

                    LoadControlsTabIndices(ctrl.Controls);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Finds the nested control with focus
        // In case of container controls
        // we need to iterate to find the control
        // that really has focus, such as a TextBox
        // inside a GroupBox
        private Control GetActiveControl()
        {
            if (_form.ActiveControl != null)
            {
                Control trueActiveCtrl = _form.ActiveControl;

                while (trueActiveCtrl is ContainerControl)
                {
                    ContainerControl cctrl = trueActiveCtrl as
                        ContainerControl;

                    trueActiveCtrl = cctrl.ActiveControl;
                }

                return trueActiveCtrl;
            }

            return null;
        }

        // Initializes the control enumerator to the
        // activeControl
        private void InitializeCtrlEnum(Control activeCtrl)
        {
            if (activeCtrl != null)
            {
                _ctrlDicEnum = _ctrlDic.GetEnumerator();
                _ctrlDicEnum.MoveNext();

                while (_ctrlDicEnum.Current.Value != null)
                {
                    if (_ctrlDicEnum.Current.Value == activeCtrl)
                        return;

                    _ctrlDicEnum.MoveNext();
                }
            }
        }

        // Returns the next control based on TabIndices
        // initialized in the member dictionary
        private Control NextControl
        {
            get
            {
                Control trueActiveCtrl = GetActiveControl();

                if (_ctrlDicEnum.Current.Value != trueActiveCtrl)
                    InitializeCtrlEnum(trueActiveCtrl);

                _ctrlDicEnum.MoveNext();

                if (_ctrlDicEnum.Current.Value == null)
                {
                    _ctrlDicEnum = _ctrlDic.GetEnumerator();
                    _ctrlDicEnum.MoveNext();
                }

                return _ctrlDicEnum.Current.Value;
            }
        }

        // Tab key pressed event handler
        private void OnKeyPress(
            System.Object sender,
            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\t')
            {
                //gives focus to next control
                this.NextControl.Focus();
            }
        }
    }
}
