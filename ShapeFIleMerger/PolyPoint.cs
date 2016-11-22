using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class PolyPoint : Geometry
    {
        double x;
        double y;

        public PolyPoint(BinaryReader reader)
        {
            this.LoadCore(reader);
        }


        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        protected override void LoadCore(BinaryReader reader)
        {
            x = reader.ReadDouble();
            y = reader.ReadDouble();
            Console.WriteLine(string.Format("Point: {0}, {1}", x, y));
        }

    }
}
