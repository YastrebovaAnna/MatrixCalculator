using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class LogOperation : IElementOperation
    {
        public double Execute(double value)
        {
            return Math.Log(value);
        }
    }
}
