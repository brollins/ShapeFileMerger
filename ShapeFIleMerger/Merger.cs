using System ;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileMerger
{
    public class Merger
    {
        private ShapeFileHeader shpHeader1;
        private ShapeFileHeader shpHeader2;
        private ShapeFileHeader shxHeader1;
        private ShapeFileHeader shxHeader2;
        private int recordHeaderSize = 8;

        public Merger(string sourceShapeFile1, string sourceShapeFile2, string targetShapeFile)
        {
            // read shapefile1 and shapefile2 header
            BinaryReader shpReader1 = new BinaryReader(File.OpenRead(sourceShapeFile1));
            BinaryReader shpReader2 = new BinaryReader(File.OpenRead(sourceShapeFile2));  
            shpHeader1 = new ShapeFileHeader(shpReader1);
            shpHeader2 = new ShapeFileHeader(shpReader2);
           

            if (shpHeader1.ShapeType != shpHeader2.ShapeType)
            {
                throw new Exception("The shape types are not equal.");
            }

            // write out combined header

            BinaryWriter shpWriter = new BinaryWriter(File.OpenWrite(targetShapeFile));

            BinaryWriterHelper.WriteBigInt(shpWriter, 9994);
            BinaryWriterHelper.WriteBigInt(shpWriter, 0);
            BinaryWriterHelper.WriteBigInt(shpWriter, 0);
            BinaryWriterHelper.WriteBigInt(shpWriter, 0);
            BinaryWriterHelper.WriteBigInt(shpWriter, 0);
            BinaryWriterHelper.WriteBigInt(shpWriter, 0);
            BinaryWriterHelper.WriteBigInt(shpWriter, shpHeader1.FileLength + shpHeader2.FileLength);
            shpWriter.Write((int)1000);
            shpWriter.Write((int)shpHeader1.ShapeType);
            shpWriter.Write(GetMin(shpHeader1.BoundingBoxXmin, shpHeader2.BoundingBoxXmin));
            shpWriter.Write(GetMin(shpHeader1.BoundingBoxYmin, shpHeader2.BoundingBoxYmin));
            shpWriter.Write(GetMax(shpHeader1.BoundingBoxXmax, shpHeader2.BoundingBoxXmax));
            shpWriter.Write(GetMax(shpHeader1.BoundingBoxYmax, shpHeader2.BoundingBoxYmax));
            shpWriter.Write(GetMin(shpHeader1.BoundingBoxZmin, shpHeader2.BoundingBoxZmin));
            shpWriter.Write(GetMax(shpHeader1.BoundingBoxZmax, shpHeader2.BoundingBoxZmax));
            shpWriter.Write(GetMin(shpHeader1.BoundingBoxMmin, shpHeader2.BoundingBoxMmin));
            shpWriter.Write(GetMax(shpHeader1.BoundingBoxMmax, shpHeader2.BoundingBoxMmax));


            BinaryReader shxReader1 = new BinaryReader(File.OpenRead(sourceShapeFile1.Replace(".shp", ".shx")));
            BinaryReader shxReader2 = new BinaryReader(File.OpenRead(sourceShapeFile2.Replace(".shp", ".shx")));
            shxHeader1 = new ShapeFileHeader(shxReader1);
            shxHeader2 = new ShapeFileHeader(shxReader2);


            BinaryWriter shxWriter = new BinaryWriter(File.OpenWrite(targetShapeFile.Replace(".shp", ".shx")));

            BinaryWriterHelper.WriteBigInt(shxWriter, 9994);
            BinaryWriterHelper.WriteBigInt(shxWriter, 0);
            BinaryWriterHelper.WriteBigInt(shxWriter, 0);
            BinaryWriterHelper.WriteBigInt(shxWriter, 0);
            BinaryWriterHelper.WriteBigInt(shxWriter, 0);
            BinaryWriterHelper.WriteBigInt(shxWriter, 0);
            BinaryWriterHelper.WriteBigInt(shxWriter, shpHeader1.FileLength + shpHeader2.FileLength);
            shxWriter.Write((int)1000);
            shxWriter.Write((int)shpHeader1.ShapeType);
            shxWriter.Write(GetMin(shpHeader1.BoundingBoxXmin, shpHeader2.BoundingBoxXmin));
            shxWriter.Write(GetMin(shpHeader1.BoundingBoxYmin, shpHeader2.BoundingBoxYmin));
            shxWriter.Write(GetMax(shpHeader1.BoundingBoxXmax, shpHeader2.BoundingBoxXmax));
            shxWriter.Write(GetMax(shpHeader1.BoundingBoxYmax, shpHeader2.BoundingBoxYmax));
            shxWriter.Write(GetMin(shpHeader1.BoundingBoxZmin, shpHeader2.BoundingBoxZmin));
            shxWriter.Write(GetMax(shpHeader1.BoundingBoxZmax, shpHeader2.BoundingBoxZmax));
            shxWriter.Write(GetMin(shpHeader1.BoundingBoxMmin, shpHeader2.BoundingBoxMmin));
            shxWriter.Write(GetMax(shpHeader1.BoundingBoxMmax, shpHeader2.BoundingBoxMmax));


            int counter = 0;

            while (shxReader1.BaseStream.Position != shxReader1.BaseStream.Length)
            {               
                int offsetInBytes = BinaryReaderHelper.ReadBigInt(shxReader1) * 2;
                int contentLengthInBytes = BinaryReaderHelper.ReadBigInt(shxReader1) * 2;
                int contentLengthIn16Bit = contentLengthInBytes / 2;

                BinaryWriterHelper.WriteBigInt(shxWriter, (int)shpWriter.BaseStream.Position / 2);
                BinaryWriterHelper.WriteBigInt(shxWriter, (int)contentLengthIn16Bit);

                shpReader1.BaseStream.Seek(offsetInBytes, SeekOrigin.Begin);
                byte[] bytes = shpReader1.ReadBytes(contentLengthInBytes + recordHeaderSize);
                
                shpWriter.Write(bytes);

                counter++;
            }

           while (shxReader2.BaseStream.Position != shxReader2.BaseStream.Length)
            {
                int offsetInBytes = BinaryReaderHelper.ReadBigInt(shxReader2) * 2;
                int contentLengthInBytes = BinaryReaderHelper.ReadBigInt(shxReader2) * 2;
                int contentLengthIn16Bit = contentLengthInBytes / 2;

                BinaryWriterHelper.WriteBigInt(shxWriter, (int)shpWriter.BaseStream.Position / 2);
                BinaryWriterHelper.WriteBigInt(shxWriter, (int)contentLengthIn16Bit);

                shpReader2.BaseStream.Seek(offsetInBytes, SeekOrigin.Begin);
                byte[] bytes = shpReader2.ReadBytes(contentLengthInBytes + recordHeaderSize);
                
                shpWriter.Write(bytes);
            }

            shpWriter.Close();
            shxWriter.Close();                        
        }

        public double GetMin(double value1, double value2)
        {
            if (value1 < value2)
            {
                return value1;
            }
            else
                return value2;
        }

        public double GetMax(double value1, double value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            else
                return value2;
        }
    }
}
