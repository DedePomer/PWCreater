using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.DataType
{
    public class RectangleZoneDataType
    {
        public DotDataType firstPoint;
        public DotDataType secondPoint;

        public RectangleZoneDataType(DotDataType firstPoint, DotDataType secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }
    }
}
