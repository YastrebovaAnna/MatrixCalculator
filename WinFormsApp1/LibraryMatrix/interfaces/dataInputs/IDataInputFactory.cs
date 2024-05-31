using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces.dataInputs
{
    public interface IDataInputFactory
    {
        IDataInput CreateDataInput();
    }
}
