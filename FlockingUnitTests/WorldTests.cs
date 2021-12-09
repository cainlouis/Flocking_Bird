using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System;

namespace FlockingUnitTests
{
    [TestClass]
    public class WorldTests
    {
        ///<summary>
        ///This test tests the world static constructor
        ///</summary>
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

        ///<summary>
        ///This test tests that the world creates the sparrows
        ///</summary>
        [TestMethod]
        public void WorldConstructorSparrowsCreated()
        {
            //arrage
            World w;
            //act
            w = new World();
            var numberOfSparrows = w.Sparrows.Count;
            //assert
            Assert.AreEqual(150,numberOfSparrows);
        }

        ///<summary>
        ///This test tests that the world creates the raven
        ///</summary>
        [TestMethod]
        public void WorldConstructorRavenCreated()
        {
            //arrage
            World w;
            //act
            w = new World();
            //assert
            Assert.IsNotNull(w.Raven);
        }

        ///<summary>
        ///This test tests that the sparrowsa are in random position
        ///</summary>
        [TestMethod]
        public void WorldTestSparrowRandomPosition()
        {
            //arrage
            World w;
            //act
            w = new World();
            float xPos = w.Sparrows[9].Position.Vx;
            float yPos = w.Sparrows[9].Position.Vy;
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

        ///<summary>
        ///This test tests that the raven is created at a random position
        ///</summary>
        [TestMethod]
        public void WorldTestRavenRandomPosition()
        {
            //arrage
            World w;
            //act
            w = new World();
            float xPos = w.Raven.Position.Vx;
            float yPos = w.Raven.Position.Vy;
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
