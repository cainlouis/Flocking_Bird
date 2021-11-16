using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System;

namespace FlockingUnitTests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void WorldStaticConstructor()
        {
            //arrage
            World w;
            //act
            w = new World();
            //assert
            Assert.AreEqual(150,World.InitialCount);
            Assert.AreEqual(1000,World.Width);
            Assert.AreEqual(500,World.Height);
            Assert.AreEqual(4,World.MaxSpeed);
            Assert.AreEqual(100,World.NeighbourRadius);
            Assert.AreEqual(50,World.AvoidanceRadius);
        }

        [TestMethod]
        public void WorldConstructorSparrowsCreated()
        {
            //arrage
            World w;
            //act
            w = new World();
            var numberOfSparrows = w.sparrows.Count;
            //assert
            Assert.AreEqual(150,numberOfSparrows);
        }

        [TestMethod]
        public void WorldConstructorRavenCreated()
        {
            //arrage
            World w;
            //act
            w = new World();
            //assert
            Assert.IsNotNull(w.raven);
        }

        [TestMethod]
        public void WorldTestSparrowRandomPosition()
        {
            //arrage
            World w;
            //act
            w = new World();
            float xPos = w.sparrows[9].Position.Vx;
            float yPos = w.sparrows[9].Position.Vy;
            bool xPosResult = false;
            bool yPosResult = false;
            if(xPos >= 0 && xPos <= 1000){
                xPosResult = true;
            }

            if(yPos >= 0 && yPos <= 500){
                yPosResult = true;
            }
            //assert
            Assert.IsTrue(xPosResult);
            Assert.IsTrue(yPosResult);
            
        }

        [TestMethod]
        public void WorldTestRavenRandomPosition()
        {
            //arrage
            World w;
            //act
            w = new World();
            float xPos = w.raven.Position.Vx;
            float yPos = w.raven.Position.Vy;
            bool xPosResult = false;
            bool yPosResult = false;
            if(xPos >= 0 && xPos <= 1000){
                xPosResult = true;
            }

            if(yPos >= 0 && yPos <= 500){
                yPosResult = true;
            }
            //assert
            Assert.IsTrue(xPosResult);
            Assert.IsTrue(yPosResult);
        }
    }
}
