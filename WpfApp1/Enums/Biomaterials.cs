using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp1.Enums
{
    public enum Biomaterials
    {
        None,
        [Description("Кровь")]
        Blood,
        [Description("Слюна")]
        Saliva,
        [Description("МОЧА")]
        URINE
    }
}
