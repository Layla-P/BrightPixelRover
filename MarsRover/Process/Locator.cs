using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.Process
{
    public class Locator
    {
        public string GetLocation(Coordinate xy, Coordinate area, CompassEnum compass, string directions)
        {
            var directionSplit = directions.ToCharArray();
            var currentLocation =xy;
            var currentHeading = compass;
            CompassEnum newHeading;
            for (var i = 0; i < directionSplit.Length; i++)
            {
                var instruction = directionSplit[i].ToString();                
                newHeading = CompassDirector.NextPosition(currentHeading, instruction);
                if (newHeading == currentHeading)
                {
                    currentLocation = CoordinateDirector.NewLocation(newHeading, currentLocation, area);
                }
                currentHeading = newHeading;
            }


            var finalLocation = currentLocation.X.ToString() + currentLocation.Y.ToString() + CompassConvertor(currentHeading);

            return finalLocation;
        }

        private string CompassConvertor(CompassEnum heading)
        {
            string stringHeading = string.Empty;
            switch (heading)
            {
                case CompassEnum.North:
                    stringHeading = "N";
                    break;
                case CompassEnum.East:
                    stringHeading = "E";
                        break;
                case CompassEnum.South:
                        stringHeading = "S";
                        break;
                case CompassEnum.West:
                        stringHeading = "W";
                        break;
            }
            return stringHeading;
        }

    }
}