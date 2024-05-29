using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class SinOperation : IElementOperation
    {
        public double Execute(double value)
        {
            return Math.Sin(value);
        }
    }
}
