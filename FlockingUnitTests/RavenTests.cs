using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingUnitTests
{
    [TestClass]
    public class RavenTests
    {
        [TestMethod]
        public void TestInitialization()
        {
            Bird raven = new Raven(4, 5, 3, 4);
            Vector2 position = new Vector2(4, 5);
            Vector2 velocity = new Vector2(3, 4);
            Assert.AreEqual(position, raven.Position);
            Assert.AreEqual(velocity, raven.Velocity);
        }

        [TestMethod]
        public void TestChaseSparrow()
        {
            Raven raven = new Raven(30, 40, 1, 3);
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(25, 36, 4, 3));
            sparrows.Add(new Sparrow(70, 140, 2, 4));
            sparrows.Add(new Sparrow(60, 160, 2, 5));
            Vector2 result = raven.ChaseSparrow(sparrows);
            Assert.AreEqual(-5, result.Vx);
            Assert.AreEqual(-4, result.Vy);
        }

        [TestMethod]
        public void TestChaseSparrowZeroVector()
        {
            Raven raven = new Raven(30, 40, 1, 3);
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(25, 35, 4, 3));
            sparrows.Add(new Sparrow(70, 140, 2, 4));
            sparrows.Add(new Sparrow(60, 160, 2, 5));
            Vector2 result = raven.ChaseSparrow(sparrows);
            Assert.AreEqual(0, result.Vx);
            Assert.AreEqual(0, result.Vy);
        }
    }
}