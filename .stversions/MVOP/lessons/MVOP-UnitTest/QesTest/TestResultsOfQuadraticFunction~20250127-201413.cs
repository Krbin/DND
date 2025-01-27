using System;
using Qes;

namespace QesTest
{
    [TestClass]
    public class TestResultsOfQuadraticFunction
    {
        [TestMethod]
        public void Discriminator_is_bigger_than_0()
        {
            double a = 4;
            double b = 12;
            double c = 5;

            double res = qes.Discriminator(a, b, c);

            Assert.AreEqual(res, 64);
        }

        [TestMethod]

        public void Discrimitor_is_lower_than_0()
        {
            double a = 4;
            double b = 4;
            double c = 4;


            Assert.ThrowsException<DiscriminatorLowerThanZero>(() => qes.Discriminator(a, b, c));
        }

        [TestMethod]

        public void Discriminator_is_0()
        {
            double a = 1;
            double b = 4;
            double c = 4;

            double res = qes.Discriminator(a,b,c);

            Assert.AreEqual(res, 0);

        }
    }
}