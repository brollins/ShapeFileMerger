using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class MultiPoint : Geometry
    {
        double boundingBoxXmin;
        double boundingBoxYmin;
        double boundingBoxXmax;
        double boundingBoxYmax;
        int numPoints;

        public MultiPoint(BinaryReader reader)
        {
            this.LoadCore(reader);
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
            numPoints = reader.ReadInt32();

            Collection<PolyPoint> points = new Collection<PolyPoint>();
            for (int point = 0; point < numPoints; point++)
            {
                PolyPoint pointRec = new PolyPoint(reader);
                points.Add(pointRec);
                Console.WriteLine(string.Format("Point: {0}, {1}", pointRec.X, pointRec.Y));
            }
        }
    }
}
