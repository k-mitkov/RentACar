﻿using System.Windows.Data;

namespace DesktopClient.Util
{
    public class LocalizationExtension : Binding
    {
        public LocalizationExtension(string name) : base("[" + name + "]")
        {
            Mode = BindingMode.Default;
            Source = TranslationSource.Instance;
        }
    }
}
