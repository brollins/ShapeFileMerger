using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ShapeFileMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            //string source1 = @"..\..\data\ISD_Boundary.shp";
            //string source1 = @"..\..\data\Streets.shp";
            //string source1 = @"..\..\data\Medical_Facilities.shp";
            string source1 = @"..\..\data\Multipass.shp";

            ShapeFile file = new ShapeFile(source1);
            Console.ReadKey();

            //int numberOfRecords = (header.FileLength - 50) / 14;

            //for (int i = 0; i < numberOfRecords; i++)
            //{
            //    RecordHeader recordHeader = new RecordHeader(reader);
            //    PointRecord pointRecord = new PointRecord(reader);
            //    Console.WriteLine(recordHeader.RecordNumber + " " + pointRecord.ShapeType + " " + recordHeader.ContentLength);
            //}

            //Console.ReadKey();

        }
    }
}




