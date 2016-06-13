using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Process;

namespace MarsRover.Tests.Tests
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        public void FindNewPositionReturnsExpectedTestOne()
        {
            // arrange
            var area = new Coordinate(5, 5);
            var xyOne = new Coordinate(1, 2);
            var directionOne = CompassEnum.North;
            var inputOne = "LMLMLMLMM";
            var expectedOne = "13N";

            //act
            var locatorOne = new Locator();
            var actualOne = locatorOne.GetLocation(xyOne, area, directionOne, inputOne);

            // assert
            Assert.AreEqual(expectedOne, actualOne);
        }

        [TestMethod]
        public void FindNewPositionReturnsExpectedTestTwo()
        {
            // arrange
            var area = new Coordinate(5, 5);
            var xyTwo = new Coordinate(3,3);
            var directionTwo = CompassEnum.East;
            var inputTwo = "MMRMMRMRRM";
            var expectedTwo = "51E";

            //act
            var locatorTwo = new Locator();
            var actualTwo= locatorTwo.GetLocation(xyTwo,area, directionTwo, inputTwo);

            // assert
            Assert.AreEqual(expectedTwo, actualTwo);

        }

        }
    }

