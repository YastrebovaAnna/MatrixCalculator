using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces
{
    public interface IMatrixDeterminantOperation
    {
        double Execute(IMatrix matrix);
    }
}
