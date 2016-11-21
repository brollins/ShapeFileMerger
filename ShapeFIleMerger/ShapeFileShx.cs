using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    class ShapeFileShx
    {
        int offset;
        int contentLength;


        public ShapeFileShx(BinaryReader reader)
        {
            offset = BinaryReaderHelper.ReadBigInt(reader);
            contentLength = BinaryReaderHelper.ReadBigInt(reader);
            Console.WriteLine(string.Format("ContentLength = {0}", contentLength));
        }

        public int Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        public int ContentLength
        {
            get
            {
                return contentLength;
            }

            set
            {
                contentLength = value;
            }
        }
    }
}
