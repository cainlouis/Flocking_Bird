using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlockingBackend;

namespace FlockingUnitTests
{
    [TestClass]
    public class FlockTests
    {
        ///<summary>
        ///This test tests if the sparrows are succesfully subscribed to the events
        ///</summary>
        [TestMethod]
        public void TestSubscribeSparrow()
        {
            //arange
            Flock flock = new Flock(); //create the flock
            List<Sparrow> sparrows = new List<Sparrow>(); //create the list of sparrows

            //create the sparrows
            Sparrow sparrow1 = new Sparrow(10, 6, 3, 3);
            Sparrow sparrow2 = new Sparrow(1, 2, 1, 2);
            Sparrow sparrow3 = new Sparrow(4, 5, 5, -2);

            //subscribe the events to the sparrows
            flock.Subscribe(sparrow1.CalculateBehaviour, sparrow1.Move, sparrow1.CalculateRavenAvoidance);
            flock.Subscribe(sparrow2.CalculateBehaviour, sparrow2.Move, sparrow2.CalculateRavenAvoidance);
            flock.Subscribe(sparrow3.CalculateBehaviour, sparrow3.Move, sparrow3.CalculateRavenAvoidance);

            //add the sparrows to the sparrow list
            sparrows.Add(sparrow1);
            sparrows.Add(sparrow2);
            sparrows.Add(sparrow3);

            //creating the raven
            Raven raven = new Raven();

            //expected results
            float velocityXresult = (float)2.8716412;
            float velocityYresult = (float)0.60421896;

            // Act 
            flock.RaiseMoveEvents(sparrows, raven); //invoke the events

            //Assert
            Assert.AreEqual(velocityXresult, sparrow1.Velocity.Vx, 0.01);
            Assert.AreEqual(velocityYresult, sparrow1.Velocity.Vy, 0.01);
        }

        ///<summary>
        ///This test tests if the sparrows don't change of velocity when no neighbors are around
        ///</summary>
        [TestMethod]
        public void TestSubscribeSparrowNoNeighbor()
        {
            //arange
            Flock flock = new Flock(); //Create a new flock
            List<Sparrow> sparrows = new List<Sparrow>(); //Create new list of sparrows

            //creating the sparrows
            Sparrow sparrow1 = new Sparrow(200, 200, 3, 3);
            Sparrow sparrow2 = new Sparrow(1, 2, 1, 2);
            Sparrow sparrow3 = new Sparrow(4, 5, 5, -2);

            //subscribing the sparrows
            flock.Subscribe(sparrow1.CalculateBehaviour, sparrow1.Move, sparrow1.CalculateRavenAvoidance);
            flock.Subscribe(sparrow2.CalculateBehaviour, sparrow2.Move, sparrow2.CalculateRavenAvoidance);
            flock.Subscribe(sparrow3.CalculateBehaviour, sparrow3.Move, sparrow3.CalculateRavenAvoidance);

            //add sparrows to the list
            sparrows.Add(sparrow1);
            sparrows.Add(sparrow2);
            sparrows.Add(sparrow3);

            //create the raven
            Raven raven = new Raven();

            //expected values
            float velocityXresult = (float)3;
            float velocityYresult = (float)3;

            // Act 
            flock.RaiseMoveEvents(sparrows, raven);

            //Assert
            Assert.AreEqual(velocityXresult, sparrow1.Velocity.Vx, 0.01);
            Assert.AreEqual(velocityYresult, sparrow1.Velocity.Vy, 0.01);
        }
    }
}
