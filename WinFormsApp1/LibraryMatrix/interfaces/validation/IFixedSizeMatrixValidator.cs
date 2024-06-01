using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces.validation
{
    public interface IFixedSizeMatrixValidator
    {
        void Validate(IMatrix matrix, int requiredRows, int requiredColumns);
    }
}
