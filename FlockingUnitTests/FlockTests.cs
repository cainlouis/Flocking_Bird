using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlockingBackend;

namespace FlockingUnitTests
{
    [TestClass]
    public class FlockTests
    {
        [TestMethod]
        public void TestSubscribeSparrow()
        {
            //arange
            Flock flock = new Flock();
            List<Sparrow> sparrows = new List<Sparrow>();

            Sparrow sparrow1 = new Sparrow( 10, 6, 3,3 );
            Sparrow sparrow2 = new Sparrow( 1, 2, 1,2 );
            Sparrow sparrow3 = new Sparrow( 4, 5, 5,-2 );

            flock.Subscribe(sparrow1.CalculateBehaviour,sparrow1.Move,sparrow1.CalculateRavenAvoidance);
            flock.Subscribe(sparrow2.CalculateBehaviour,sparrow2.Move,sparrow2.CalculateRavenAvoidance);
            flock.Subscribe(sparrow3.CalculateBehaviour,sparrow3.Move,sparrow3.CalculateRavenAvoidance);

            sparrows.Add(sparrow1);
            sparrows.Add(sparrow2);
            sparrows.Add(sparrow3);
       
            Raven raven = new Raven();

            float velocityXresult = (float)2.8716412;
            float velocityYresult = (float)0.60421896;
            
            // Act
            flock.RaiseMoveEvents(sparrows,raven);
            
            //Assert
            Assert.AreEqual(velocityXresult, sparrow1.Velocity.Vx);
            Assert.AreEqual(velocityYresult, sparrow1.Velocity.Vy);
        }

        [TestMethod]
        public void TestSubscribeSparrowNoNeighbor()
        {
            //arange
            Flock flock = new Flock();
            List<Sparrow> sparrows = new List<Sparrow>();

            Sparrow sparrow1 = new Sparrow( 200, 200, 3,3 );
            Sparrow sparrow2 = new Sparrow( 1, 2, 1,2 );
            Sparrow sparrow3 = new Sparrow( 4, 5, 5,-2 );

            flock.Subscribe(sparrow1.CalculateBehaviour,sparrow1.Move,sparrow1.CalculateRavenAvoidance);
            flock.Subscribe(sparrow2.CalculateBehaviour,sparrow2.Move,sparrow2.CalculateRavenAvoidance);
            flock.Subscribe(sparrow3.CalculateBehaviour,sparrow3.Move,sparrow3.CalculateRavenAvoidance);

            sparrows.Add(sparrow1);
            sparrows.Add(sparrow2);
            sparrows.Add(sparrow3);
       
            Raven raven = new Raven();

            float velocityXresult = (float)3;
            float velocityYresult = (float)3;
            
            // Act 
            flock.RaiseMoveEvents(sparrows,raven);
            
            //Assert
            Assert.AreEqual(velocityXresult, sparrow1.Velocity.Vx);
            Assert.AreEqual(velocityYresult, sparrow1.Velocity.Vy);
        }
    }
}
