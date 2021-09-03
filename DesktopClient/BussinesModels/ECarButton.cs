using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.BussinesModels
{
    class ECarButton : VehicleTypeButton
    {
        public override void SelectButton(object _)
        {
            buttons[0].IsSelected = false;
            buttons[1].IsSelected = true;
            buttons[2].IsSelected = false;
        }
    }
}
