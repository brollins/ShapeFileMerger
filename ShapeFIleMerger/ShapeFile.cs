using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    class ShapeFile
    {
        private ShapeFileHeader header;
        private Collection<Geometry> geometries;
        private Collection<RecordHeader> recordHeaders;

        public ShapeFile(string shapeFileName)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(shapeFileName));
            Header = new ShapeFileHeader(reader);

           

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                recordHeaders.Add(new RecordHeader(reader));

                if (header.ShapeType == 1)
                {
                    geometries.Add(new Point(reader));
                }
                if (header.ShapeType == 3)
                {
                    geometries.Add(new PolyLine(reader));
                }
                if (header.ShapeType == 5)
                {
                    geometries.Add(new Polygon(reader));
                }
                if (header.ShapeType == 8)
                {
                    geometries.Add(new MultiPoint(reader));
                }
            }
        }
         

       
        internal Collection<Geometry> Geometries
        {
            get
            {
                return geometries;
            }

            set
            {
                geometries = value;
            }
        }

        internal ShapeFileHeader Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public Collection<RecordHeader> RecordHeaders
        {
            get
            {
                return recordHeaders;
            }

            set
            {
                recordHeaders = value;
            }
        }
    }
}
