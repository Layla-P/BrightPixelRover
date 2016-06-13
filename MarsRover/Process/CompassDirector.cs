using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.Process
{
    public static class CompassDirector
    {
        public static CompassEnum NextPosition(CompassEnum heading, string instruction)
        {
            CompassEnum newHeading;
            if (instruction == "L")
            {
                newHeading = TurnLeft(heading);
            }
            else if (instruction == "R")
            {
                newHeading = TurnRight(heading);
            }
            else
            {
                newHeading = heading;
            }

            return newHeading;
        }

        private static CompassEnum TurnLeft(CompassEnum heading)
        {
            CompassEnum newHeading = heading;
            switch (heading)
            {
                case CompassEnum.North:
                    { newHeading = CompassEnum.West; }
                    break;
                case CompassEnum.East:
                    { newHeading = CompassEnum.North; }
                    break;
                case CompassEnum.South:
                    { newHeading = CompassEnum.East; }
                    break;
                case CompassEnum.West:
                    { newHeading = CompassEnum.South; }
                    break;
            }
            return newHeading;
        }
        private static CompassEnum TurnRight(CompassEnum heading)
        {
            CompassEnum newHeading = heading;
            switch (heading)
            {
                case CompassEnum.North:
                    { newHeading = CompassEnum.East; }
                    break;
                case CompassEnum.East:
                    { newHeading = CompassEnum.South; }
                    break;
                case CompassEnum.South:
                    { newHeading = CompassEnum.West; }
                    break;
                case CompassEnum.West:
                    { newHeading = CompassEnum.North; }
                    break;
            }
            return newHeading;
        }

    }
}