using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class PolyLine: Geometry
    {
        double boundingBoxXmin;
        double boundingBoxYmin;
        double boundingBoxXmax;
        double boundingBoxYmax;
        int numParts;
        int numPoints;

        public PolyLine(BinaryReader reader)
        {
            this.LoadCore(reader);
        }

      
        public int NumParts
        {
            get
            {
                return numParts;
            }

            set
            {
                numParts = value;
            }
        }

        public int NumPoints
        {
            get
            {
                return numPoints;
            }

            set
            {
                numPoints = value;
            }
        }

        public double BoundingBoxXmin
        {
            get
            {
                return boundingBoxXmin;
            }

            set
            {
                boundingBoxXmin = value;
            }
        }

        public double BoundingBoxYmin
        {
            get
            {
                return boundingBoxYmin;
            }

            set
            {
                boundingBoxYmin = value;
            }
        }

        public double BoundingBoxXmax
        {
            get
            {
                return boundingBoxXmax;
            }

            set
            {
                boundingBoxXmax = value;
            }
        }

        public double BoundingBoxYmax
        {
            get
            {
                return boundingBoxYmax;
            }

            set
            {
                boundingBoxYmax = value;
            }
        }
        protected override void LoadCore(BinaryReader reader)
        {
            ShapeType = reader.ReadInt32();
            BoundingBoxXmin = reader.ReadDouble();
            BoundingBoxYmin = reader.ReadDouble();
            BoundingBoxXmax = reader.ReadDouble();
            BoundingBoxYmax = reader.ReadDouble();
            numParts = reader.ReadInt32();
            numPoints = reader.ReadInt32();

            Collection<int> parts = new Collection<int>();
            for (int part = 0; part < numParts; part++)
            {
                parts.Add(reader.ReadInt32());
            }
            Console.WriteLine(string.Format("Parts:  {0}", parts.Count));

            Collection<Point> points = new Collection<Point>();
            for (int point = 0; point < numPoints; point++)
            {
                Point pointRec = new Point(reader);
                points.Add(pointRec);
                Console.WriteLine(string.Format("Point: {0}, {1}", pointRec.X, pointRec.Y));
            }
        }
    }
}
