using System.IO;

namespace ShapeFileMerger
{
    public class Geometry
    {
        private int shapeType;

        public Geometry()
        {
            
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

        public void Load(BinaryReader reader)
        {
            LoadCore(reader);
        }

        protected virtual void LoadCore(BinaryReader reader)
        {

        }
    }
}