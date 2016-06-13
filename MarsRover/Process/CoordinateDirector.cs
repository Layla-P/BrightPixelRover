using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.Process
{
    public static class CoordinateDirector
    {
        public static Coordinate NewLocation(CompassEnum heading, Coordinate xy, Coordinate area)
        {
            Coordinate xyNew = xy;
            switch (heading)
            {
                case CompassEnum.North:
                    {
                        xyNew = new Coordinate(xy.X, xy.Y + 1);
                    }
                    break;
                case CompassEnum.East:
                    {
                        xyNew = new Coordinate(xy.X + 1, xy.Y);
                    }
                    break;
                case CompassEnum.South:
                    {
                        xyNew = new Coordinate(xy.X, xy.Y - 1);
                    }
                    break;
                case CompassEnum.West:
                    {
                        xyNew = new Coordinate(xy.X - 1, xy.Y);
                    }
                    break;
            }
            if (area.X < xy.X)
            {
                return xy;
            }
            if (area.Y < xy.Y)
            {
                return xy;
            }
            return xyNew;
        }

    }
}