using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;
using System;

namespace FlockingUnitTests
{
    [TestClass]
    public class SparrowTests
    {
        [TestMethod]
        public void TestInitialization()
        {
            Bird sparrow = new Sparrow(4, 5, 3, 4);
            Vector2 position = new Vector2(4, 5);
            Vector2 velocity = new Vector2(3, 4);
            Assert.AreEqual(position, sparrow.Position);
            Assert.AreEqual(velocity, sparrow.Velocity);
        }

        [TestMethod]
        public void TestGetNeighbours()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            List<Sparrow> neighbours = s.GetNeighbours(GetList(s));
            Assert.AreEqual(1, neighbours.Count);
        }

        [TestMethod]
        public void TestGetNeighboursZeroVector()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            List<Sparrow> neighbours = s.GetNeighbours(GetListZeroVector());
            Assert.AreEqual(0, neighbours.Count);
        }

        [TestMethod]
        public void TestAlignment()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Vector2 result = s.Alignment(GetList(s));
            Assert.AreEqual(Math.Round((2.2) / Math.Sqrt(5.2), 4), Math.Round(result.Vx, 4), 0.01);
            Assert.AreEqual(Math.Round((-0.6) / Math.Sqrt(5.2), 4), Math.Round(result.Vy, 4), 0.01);
        }

        [TestMethod]
        public void TestAlignmentZeroVector()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Vector2 result = s.Alignment(GetListZeroVector());
            Assert.AreEqual(0, result.Vx, 0.01);
            Assert.AreEqual(0, result.Vy, 0.01);
        }

        [TestMethod]
        public void TestCohesion()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Vector2 result = s.Cohesion(GetList(s));
            Assert.AreEqual(Math.Round(-0.549009404, 4), Math.Round(result.Vx, 4), 0.01);
            Assert.AreEqual(Math.Round(-0.835816172, 4), Math.Round(result.Vy, 4), 0.01);
        }

        [TestMethod]
        public void TestCohesionZeroVector()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Vector2 result = s.Cohesion(GetListZeroVector());
            Assert.AreEqual(0, result.Vx, 0.01);
            Assert.AreEqual(0, result.Vy, 0.01);
        }

        [TestMethod]
        public void TestAvoidance()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(25, 35, 4, 3));
            sparrows.Add(new Sparrow(70, 140, 2, 4));
            sparrows.Add(new Sparrow(60, 160, 2, 5));
            Vector2 result = s.Avoidance(sparrows);
            Assert.AreEqual(Math.Round(0.995626235, 4), Math.Round(result.Vx, 4), 0.01);
            Assert.AreEqual(Math.Round(-0.093425903, 4), Math.Round(result.Vy, 4), 0.01);
        }

        [TestMethod]
        public void TestAvoidanceZeroVector()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Vector2 result = s.Avoidance(GetListZeroVector());
            Assert.AreEqual(0, result.Vx, 0.01);
            Assert.AreEqual(0, result.Vy, 0.01);
        }

        [TestMethod]
        public void TestFleeRaven()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Raven raven = new Raven(25, 35, 4, 3);
            Vector2 result = s.FleeRaven(raven);
            Assert.AreEqual(Math.Round(2.828427125, 4), Math.Round(result.Vx, 4), 0.01);
            Assert.AreEqual(Math.Round(2.828427125, 4), Math.Round(result.Vy, 4), 0.01);
        }

        [TestMethod]
        public void TestFleeRavenZeroVector()
        {
            Sparrow s = new Sparrow(30, 40, 1, 3);
            Raven raven = new Raven(60, 160, 2, 5);
            Vector2 result = s.FleeRaven(raven);
            Assert.AreEqual(0, result.Vx, 0.01);
            Assert.AreEqual(0, result.Vy, 0.01);
        }

        /// <summary>
        /// Create a list that contains one neighbour sparrow to the sparrow created before it is called
        /// </summary>
        /// <returns>A list of Sparrow</returns>
        private List<Sparrow> GetList(Sparrow s)
        {
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(15, 25, 4, 3));
            sparrows.Add(new Sparrow(70, 140, 2, 4));
            sparrows.Add(new Sparrow(60, 160, 2, 5));
            sparrows.Add(s);
            return sparrows;
        }

        /// <summary>
        /// Create a list that contains no neighbour sparrow to the sparrow created before it is called
        /// </summary>
        /// <returns>A list of Sparrow</returns>
        private List<Sparrow> GetListZeroVector()
        {
            List<Sparrow> sparrows = new List<Sparrow>();
            sparrows.Add(new Sparrow(75, 140, 2, 4));
            sparrows.Add(new Sparrow(70, 140, 2, 4));
            sparrows.Add(new Sparrow(60, 160, 2, 5));
            return sparrows;
        }

    }
}