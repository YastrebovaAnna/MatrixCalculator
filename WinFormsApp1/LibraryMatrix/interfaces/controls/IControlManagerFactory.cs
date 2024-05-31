using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces.controls
{
    public interface IControlManagerFactory<T> where T : IControl
    {
        IControlManager<T> CreateControlManager(Control parentControl);
    }
}
