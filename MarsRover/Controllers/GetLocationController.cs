using MarsRover.Process;
using MarsRover.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarsRover.Controllers
{
    public class GetLocationController : ApiController
    {

        public ReturnRemoteControlActionRequestViewModel Post([FromBody] RemoteControlActionRequestViewModel list)
        {
            if (list==null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            } 
            if (!ModelState.IsValid) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }            
            var area = new Coordinate(list.AreaX, list.AreaY);
            var returnList = new ReturnRemoteControlActionRequestViewModel();
            var locator = new Locator();
            foreach (var rover in list.ListOfRovers)
            {
                var position = rover.StartingLocation.ToCharArray();
                var x = Int32.Parse(position[0].ToString());
                var y = Int32.Parse(position[1].ToString());
                var startingCoordinate = new Coordinate(x, y);
                var startingHeading = CompassConvertor(position[2].ToString().ToUpper());
                var directions = rover.Directions.ToUpper();
                var finalLocation = locator.GetLocation(startingCoordinate, area, startingHeading, directions);
                var roverReturn = new MarsRoverReturnViewModel();
                roverReturn.Id = rover.Id;
                roverReturn.EndLocation = finalLocation;
                returnList.ListOfRovers.Add(roverReturn);
            }
            return returnList;
        }

        private CompassEnum CompassConvertor(string heading)
        {
            CompassEnum compHeading = CompassEnum.North;
            switch (heading)
            {
                case "N":
                    compHeading = CompassEnum.North;
                    break;
                case "E":
                    compHeading = CompassEnum.East;
                    break;
                case "S":
                    compHeading = CompassEnum.South;
                    break;
                case "W":
                    compHeading = CompassEnum.West;
                    break;
            }
            return compHeading;
        }
    }
}
