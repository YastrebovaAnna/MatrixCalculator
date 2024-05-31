using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMatrix.interfaces.labels;

namespace LibraryMatrix.interfaces
{
    public interface IUIFactory
    {
        ILabel CreateLabel();
        ILabelService CreateLabelService();
    }
}
