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
            Flock flock = new Flock();

            List<Sparrow> sparrows = new List<Sparrow>();

            Sparrow s1 = new Sparrow( 6, 6, -3,4 );
            flock.Subscribe(s1.CalculateBehaviour,s1.Move,s1.CalculateRavenAvoidance);
            Sparrow s2 = new Sparrow( 2, 4, -2,1 );
            flock.Subscribe(s2.CalculateBehaviour,s2.Move,s2.CalculateRavenAvoidance);

            sparrows.Add(s1);
            sparrows.Add(s2);
       
            Raven raven = new Raven();

            float expX = -2.31f;
            float expY = 1.722f;
            
            // Act
            flock.RaiseMoveEvents(sparrows,raven);
            
            //Assert
            Assert.AreEqual(expX, s1.Velocity.Vx, 0.01);
            Assert.AreEqual(expY, s1.Velocity.Vy, 0.01);
        }
    }
}
