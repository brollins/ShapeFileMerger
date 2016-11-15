using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class RecordHeader
    {
        int recordNumber;
        int contentLength;

        public RecordHeader(BinaryReader reader)
        {
            RecordNumber = BinaryReaderHelper.ReadBigInt(reader);
            ContentLength = BinaryReaderHelper.ReadBigInt(reader);
        }

        public int RecordNumber
        {
            get
            {
                return recordNumber;
            }

            set
            {
                recordNumber = value;
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
