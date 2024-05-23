using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.interfaces
{
    public interface IDataInput
    {
        string Text { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Point Location { get; set; }
        Color BackColor { get; set; }
    }
}
