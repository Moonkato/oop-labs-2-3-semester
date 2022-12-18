using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6_OOP
{
    public class CMyFolder : Folder
    {
        public CMyFolder(int folder_sizee) : base(folder_sizee)
        {
        }

        public override CShape createShape(string code)
        {
            CShape smt = null;

            switch (code)
            {
                case "C":
                    smt = new CCircle(0, 0, picturebox1);
                    break;
                case "T":
                    smt = new Triangle(0, 0, picturebox1);
                    break;
                case "S":
                    smt = new Square(0, 0, picturebox1);
                    break;
                case "F":
                    smt = new CMyFolder(0);
                    break;
            }
            return smt;
        }
    }

}
