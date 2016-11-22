using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class BinaryWriterHelper
    {
        public static void WriteBigInt(BinaryWriter writer,  int smallInt)
        {
            byte[] bytes = BitConverter.GetBytes(smallInt); 
            Array.Reverse(bytes);
            writer.Write(bytes);
        }
    }
}
