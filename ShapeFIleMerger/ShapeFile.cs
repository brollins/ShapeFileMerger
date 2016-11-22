using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private ShapeFileShx shx;

        public ShapeFile(string shapeFileName)
        {
            recordHeaders = new Collection<RecordHeader>();
            geometries = new Collection<Geometry>();
            BinaryReader reader = new BinaryReader(File.OpenRead(shapeFileName));
            Header = new ShapeFileHeader(reader);
            //shx = new ShapeFileShx(reader);

            int counter = 0;

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                RecordHeader recHead = new RecordHeader(reader);

                recordHeaders.Add(recHead);

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
                counter++;
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
