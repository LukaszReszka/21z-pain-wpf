using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN21Z_WPF2.MVVM
{
    public interface IViewModel
    {
        Action Close { get; set; }
    }
}
