using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_TDD;

namespace Lab1_TDD.Tests
{
    [TestClass]
    public class NumberRangeTests
    {
        // Тест 1: Перевірка генерації винятку, коли ліва межа більша за праву
        [TestMethod]
        public void Constructor_LeftGreaterThanRight_ThrowsArgumentException()
        {
            // Arrange
            double left = 10.0;
            double right = 5.0;
            bool exceptionThrown = false;

            // Act
            try
            {
                NumberRange range = new NumberRange(left, right);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        // Тест 2: Обчислення довжини стандартного додатного діапазону
        [TestMethod]
        public void GetLength_PositiveBounds_ReturnsCorrectLength()
        {
            NumberRange range = new NumberRange(2.0, 7.5);
            double expected = 5.5;
            double actual = range.GetLength();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        // Тест 3: Обчислення довжини діапазону з від'ємними межами
        [TestMethod]
        public void GetLength_NegativeBounds_ReturnsCorrectLength()
        {
            NumberRange range = new NumberRange(-10.0, -3.0);
            double expected = 7.0;
            double actual = range.GetLength();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        // Тест 4: Обчислення довжини виродженого діапазону (точки), де межі рівні
        [TestMethod]
        public void GetLength_EqualBounds_ReturnsZero()
        {
            NumberRange range = new NumberRange(4.0, 4.0);
            double expected = 0.0;
            double actual = range.GetLength();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        // Тест 5: Перевірка потрапляння числа, що лежить строго всередині діапазону
        [TestMethod]
        public void Contains_ValueInsideRange_ReturnsTrue()
        {
            NumberRange range = new NumberRange(1.0, 5.0);
            double val = 3.0;
            bool result = range.Contains(val);
            Assert.IsTrue(result);
        }

        // Тест 6: Перевірка потрапляння числа, що лежить рівно на лівій межі діапазону
        [TestMethod]
        public void Contains_ValueOnLeftBoundary_ReturnsTrue()
        {
            NumberRange range = new NumberRange(1.0, 5.0);
            double val = 1.0;
            bool result = range.Contains(val);
            Assert.IsTrue(result);
        }

        // Тест 7: Перевірка числа, яке знаходиться за межами діапазону
        [TestMethod]
        public void Contains_ValueOutsideRange_ReturnsFalse()
        {
            NumberRange range = new NumberRange(1.0, 5.0);
            double val = 8.0;
            bool result = range.Contains(val);
            Assert.IsFalse(result);
        }

        // Тест 8: Перевірка перетину двох діапазонів, що частково перекриваються
        [TestMethod]
        public void Intersects_OverlappingRanges_ReturnsTrue()
        {
            NumberRange range1 = new NumberRange(1.0, 5.0);
            NumberRange range2 = new NumberRange(3.0, 7.0);
            bool result = range1.Intersects(range2);
            Assert.IsTrue(result);
        }

        // Тест 9: Перевірка перетину діапазонів, що дотикаються в одній граничній точці
        [TestMethod]
        public void Intersects_TouchingRangesAtBoundary_ReturnsTrue()
        {
            NumberRange range1 = new NumberRange(1.0, 3.0);
            NumberRange range2 = new NumberRange(3.0, 6.0);
            bool result = range1.Intersects(range2);
            Assert.IsTrue(result);
        }

        // Тест 10: Перевірка двох діапазонів, які не перетинаються
        [TestMethod]
        public void Intersects_DisjointRanges_ReturnsFalse()
        {
            NumberRange range1 = new NumberRange(1.0, 2.0);
            NumberRange range2 = new NumberRange(4.0, 6.0);
            bool result = range1.Intersects(range2);
            Assert.IsFalse(result);
        }

        // Тест 11: Перевірка генерації винятку при передачі null у метод Intersects
        [TestMethod]
        public void Intersects_NullArgument_ThrowsArgumentNullException()
        {
            NumberRange range1 = new NumberRange(1.0, 5.0);
            bool exceptionThrown = false;

            try
            {
                range1.Intersects(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        // Тест 12: Порівняння на рівність двох діапазонів з однаковими межами
        [TestMethod]
        public void Equals_IdenticalRanges_ReturnsTrue()
        {
            NumberRange range1 = new NumberRange(2.0, 6.0);
            NumberRange range2 = new NumberRange(2.0, 6.0);
            bool result = range1.Equals(range2);
            Assert.IsTrue(result);
        }
    }
}