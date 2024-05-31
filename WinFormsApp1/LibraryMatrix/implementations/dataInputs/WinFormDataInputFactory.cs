using LibraryMatrix.interfaces.dataInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.implementations.dataInputs
{
    public class WinFormDataInputFactory : IDataInputFactory
    {
        public IDataInput CreateDataInput()
        {
            return new WinFormTextBox();
        }
    }
}
