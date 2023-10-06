using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    /// <summary>
    /// This class is for drawing eclipse from seed file
    /// </summary>
    class Eclipse : Shape
    {
        private double width;
        private double height;

        public Eclipse(Point2D centre, double width, double height) : base(centre)
        {
            this.width = width;
            this.height = height;
        }

        public override bool ContainsPoint(Point2D point)
        {
            throw new NotImplementedException();
        }
    }
}
