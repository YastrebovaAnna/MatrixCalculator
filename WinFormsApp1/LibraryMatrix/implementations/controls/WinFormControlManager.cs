using LibraryMatrix.interfaces.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.implementations.controls
{
    public class WinFormControlManager<T> : IControlManager<T> where T : IControl
    {
        private readonly Control _parentControl;

        public WinFormControlManager(Control parentControl)
        {
            _parentControl = parentControl;
        }

        public void AddControl(T control)
        {
            control.AddToParent(_parentControl);
        }

        public void RemoveControl(T control)
        {
            control.RemoveFromParent(_parentControl);
        }

        public void ClearControls(IEnumerable<T> controls)
        {
            foreach (var control in controls)
            {
                RemoveControl(control);
            }
        }

        public void RemoveReadOnlyControls()
        {
            foreach (Control control in _parentControl.Controls.OfType<Control>().ToList())
            {
                if (control is TextBox textBox && textBox.ReadOnly)
                {
                    if (control is IControl iControl)
                    {
                        RemoveControl((T)iControl);
                    }
                }
            }
        }

        public void ResetButtonPositions(bool isFirstMatrix, Control[] leftButtons, Control[] rightButtons)
        {
            if (isFirstMatrix)
            {
                ResetButtonPositions(leftButtons);
            }
            else
            {
                ResetButtonPositions(rightButtons);
            }
        }

        private void ResetButtonPositions(Control[] buttons)
        {
            int yOffset = 0;
            foreach (var button in buttons)
            {
                button.Location = new Point(button.Location.X, 245 + yOffset);
                yOffset += button.Height + 10;
            }
        }
    }
}
