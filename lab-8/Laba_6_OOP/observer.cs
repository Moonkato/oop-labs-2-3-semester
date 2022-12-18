using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_6_OOP
{ 
    public interface observer
    {
        void move(int dx, int dy);

        void resize(int new_size);
    }

}
