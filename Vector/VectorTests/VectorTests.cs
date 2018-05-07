using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VectorTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void Indexer_SetsCorrectCoefficient()
        {
            var sut = new Vector.Vector(0, 2, 8);
            sut[0] = 5;

            Assert.AreEqual(5, sut[0]);
        }

        [TestMethod]
        public void AddUpVectors_ReturnsCorrectVector()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(3, 1, 4);

            Assert.IsTrue(new Vector.Vector(5, 4, 8) == a + b);
        }

        [TestMethod]
        public void SubtractVectors_ReturnsCorrectVector()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(3, 1, 4);

            Assert.IsTrue(new Vector.Vector(-1, 2, 0) == a - b);
        }

        [TestMethod]
        public void MultiplyTwoVectors_ReturnsCrossProduct()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(3, 1, 4);

            Assert.IsTrue(new Vector.Vector(8, 4, -1) == a * b);
        }

        [TestMethod]
        public void MultiplyVectorWithScalarValue_MultipliesEachCoefficient()
        {
            var a = new Vector.Vector(2, 3, 4);

            Assert.IsTrue(new Vector.Vector(6, 9, 12) == a * 3);
        }

        [TestMethod]
        public void EqualOperator_Succeeds_ForEqualCtorParameters()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(2, 3, 4);

            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void EqualOperator_Fails_ForUnequalCtorParameters()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(2, 3, 4);

            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void Equals_Succeeds_ForEqualCtorParameters()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(2, 3, 4);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Equals_Fails_ForUnequalCtorParameters()
        {
            var a = new Vector.Vector(2, 3, 4);
            var b = new Vector.Vector(2, 3, 4);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void ExplicitCasting_ToDouble_ReturnsMagnitudeOfVector()
        {
            var sut = new Vector.Vector(1, 2, 3);
            var magnitude = (double) sut;

            Assert.AreEqual(3.74165, magnitude, 0.00001);
        }

        [TestMethod]
        public void ImplicitCasting_SetsFirstCoefficientOfVector()
        {
            Vector.Vector sut = 4;

            Assert.AreEqual(new Vector.Vector(4,0,0), sut);
        }

        [TestMethod]
        public void ToString_PlotsAllCoefficients()
        {
            var sut = new Vector.Vector(1, 2, 3);

            Assert.AreEqual("x: 1\r\ny: 2\r\nz: 3\r\n", sut.ToString());
        }
    }
}
