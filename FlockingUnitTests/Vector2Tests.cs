using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;

namespace FlockingUnitTests
{
    [TestClass]
    public class Vector2Test2
    {
        [TestMethod]
        public void TestOperatorAdd()
        {
            Vector2 a = new Vector2(1, 2);
            Vector2 b = new Vector2(2, 3);
            Vector2 result = a + b;

            Assert.AreEqual(3, result.Vx);
            Assert.AreEqual(5, result.Vy);
        }

        [TestMethod]
        public void TestOperatorSubstract()
        {
            Vector2 a = new Vector2(2, 3);
            Vector2 b = new Vector2(3, 2);
            Vector2 result = a - b;

            Assert.AreEqual(-1, result.Vx);
            Assert.AreEqual(1, result.Vy);
        }

        [TestMethod]
        public void TestOperatorDivide()
        {
            Vector2 a = new Vector2(30, 20);
            float b = 2;
            Vector2 result = a / b;

            Assert.AreEqual(15, result.Vx);
            Assert.AreEqual(10, result.Vy);
        }

        [TestMethod]
        public void TestOperatorMultiply()
        {
            Vector2 a = new Vector2(15, 10);
            float b = 2;
            Vector2 result = a * b;

            Assert.AreEqual(30, result.Vx);
            Assert.AreEqual(20, result.Vy);
        }

        [TestMethod]
        public void TestDistanceSquared()
        {
            Vector2 a = new Vector2(5, 6);
            Vector2 b = new Vector2(1, 3);
            float result = Vector2.DistanceSquared(a, b);

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void TestNormalize()
        {
            Vector2 a = new Vector2(4, 3);
            Vector2 result = Vector2.Normalize(a);
            float vx = (float)4 / 5;
            float vy = (float)3 / 5;

            Assert.AreEqual(vx, result.Vx);
            Assert.AreEqual(vy, result.Vy);
        }

    }
}
