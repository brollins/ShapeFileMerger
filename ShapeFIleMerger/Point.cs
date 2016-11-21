using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeFileMerger
{
    public class Point: Geometry
    {
        double x;
        double y;

        public Point(BinaryReader reader)
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
            ShapeType = reader.ReadInt32();
            x = reader.ReadDouble();
            y = reader.ReadDouble();
            Console.WriteLine(string.Format("Point: {0}, {1}", x, y));
        }
    }
}
