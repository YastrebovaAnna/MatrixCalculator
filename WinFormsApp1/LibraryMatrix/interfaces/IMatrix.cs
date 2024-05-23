using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces
{
    public interface IMatrix
    {
        int Rows { get; }
        int Columns { get; }
    }
}
