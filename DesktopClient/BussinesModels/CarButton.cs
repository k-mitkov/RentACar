using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.BussinesModels
{
    class CarButton : VehicleTypeButton
    {
        public override void SelectButton(object _)
        {
            buttons[0].IsSelected = true;
            buttons[1].IsSelected = false;
            buttons[2].IsSelected = false;
        }
    }
}
