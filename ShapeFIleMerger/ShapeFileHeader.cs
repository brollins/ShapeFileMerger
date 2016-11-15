using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ShapeFileMerger
{
    class ShapeFileHeader
    {
        int fileCode;
        int fileLength;
        int version;
        int shapeType;
        double boundingBoxXmin;
        double boundingBoxYmin;
        double boundingBoxXmax;
        double boundingBoxYmax;
        double boundingBoxZmin;
        double boundingBoxZmax;
        double boundingBoxMmin;
        double boundingBoxMmax;
        
        public ShapeFileHeader(BinaryReader reader)
        {
            fileCode = BinaryReaderHelper.ReadBigInt(reader);
            reader.BaseStream.Seek(24, SeekOrigin.Begin);
            fileLength = BinaryReaderHelper.ReadBigInt(reader);
            version = reader.ReadInt32();
            shapeType = reader.ReadInt32();
            boundingBoxXmin = reader.ReadDouble();
            boundingBoxYmin = reader.ReadDouble();
            boundingBoxXmax = reader.ReadDouble();
            boundingBoxYmax = reader.ReadDouble();
            boundingBoxZmin = reader.ReadDouble();
            boundingBoxZmax = reader.ReadDouble();
            boundingBoxMmin = reader.ReadDouble();
            boundingBoxMmax = reader.ReadDouble();
            Console.WriteLine(string.Format("ShapeType = {0}", shapeType));
        }
        
        public int FileCode
        {
            get
            {
                return fileCode;
            }

            set
            {
                fileCode = value;
            }
        }

        public int FileLength
        {
            get
            {
                return fileLength;
            }

            set
            {
                fileLength = value;
            }
        }

        public int Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public int ShapeType
        {
            get
            {
                return shapeType;
            }

            set
            {
                shapeType = value;
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

        public double BoundingBoxZmin
        {
            get
            {
                return boundingBoxZmin;
            }

            set
            {
                boundingBoxZmin = value;
            }
        }

        public double BoundingBoxZmax
        {
            get
            {
                return boundingBoxZmax;
            }

            set
            {
                boundingBoxZmax = value;
            }
        }

        public double BoundingBoxMmin
        {
            get
            {
                return boundingBoxMmin;
            }

            set
            {
                boundingBoxMmin = value;
            }
        }

        public double BoundingBoxMmax
        {
            get
            {
                return boundingBoxMmax;
            }

            set
            {
                boundingBoxMmax = value;
            }
        }
    }
}
