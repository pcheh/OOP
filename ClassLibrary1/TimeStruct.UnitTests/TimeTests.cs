namespace TimeStruct.UnitTests
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        public void ConstructorTest()
        {
            var time = new Time(7, 44, 30);

            Assert.That(time.Hours, Is.EqualTo(7));
            Assert.That(time.Minutes, Is.EqualTo(44));
            Assert.That(time.Seconds, Is.EqualTo(30));
        }

        [TestCase(-2)]
        public void HoursSet_NegativeValue_ArgumentException(int val)
        {
            var time = new Time();

            Assert.That(() => time.Hours = val, Throws.ArgumentException);
        }

        [TestCase(-2)]
        [TestCase(80)]
        public void MinutesSet_NegativeOrBigValue_ArgumentException(int val)
        {
            var time = new Time();

            Assert.That(() => time.Minutes = val, Throws.ArgumentException);
        }

        [TestCase(-2)]
        [TestCase(80)]
        public void SecondsSet_NegativeOrBigValue_ArgumentException(int val)
        {
            var time = new Time();

            Assert.That(() => time.Seconds = val, Throws.ArgumentException);
        }

        [TestCase(2, 12, 32, 7952)]
        [TestCase(0, 0, 0, 0)]
        public void ValueInSecondsTest(
            int hours, int minutes, int seconds, int result)
        {
            var time = new Time(hours, minutes, seconds);

            Assert.That(time.DurationInSeconds, Is.EqualTo(result));
        }

        [TestCase(2, 12, 32, "2:12:32")]
        [TestCase(0, 0, 0, "0:0:0")]
        public void ToStringTest(int hours, int minutes, int seconds, string result)
        {
            var time = new Time(hours, minutes, seconds);

            Assert.That(time.ToString(), Is.EqualTo(result));
        }

        [TestCase(60, 60, true)]
        [TestCase(60, 61, false)]
        public void Equals_TwoTimes_ExpectedResult(
            int hours1, int hours2, bool result)
        {
            var time1 = new Time(hours1, 0, 0);
            var time2 = new Time(hours2, 0, 0);

            Assert.That(time1.Equals(time2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var time = new Time();
            var smth = new object();

            Assert.That(() => time.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Time(5, 6, 7);
            var y = new Time(5, 6, 7);
            var z = new Time(5, 5, 5);

            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [Test]
        public static void ComparisonTest()
        {
            var x = new Time(30, 10, 15);
            var y = new Time(30, 10, 15);
            var z = new Time(30, 55, 11);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);

            Assert.That(x >= y, Is.True);
            Assert.That(x >= z, Is.False);
            Assert.That(z >= x, Is.True);

            Assert.That(z > x, Is.True);
            Assert.That(x > z, Is.False);
            Assert.That(x > y, Is.False);

            Assert.That(x <= y, Is.True);
            Assert.That(x <= z, Is.True);
            Assert.That(z <= x, Is.False);

            Assert.That(x < z, Is.True);
            Assert.That(z < x, Is.False);
            Assert.That(x < y, Is.False);
        }

        [TestCase(30, 10, 15, 10, 55, 15, 41, 5, 30)]
        [TestCase(30, 10, 15, 0, 0, 0, 30, 10, 15)]
        public void AdditionTest(
            int hours1, int minutes1, int seconds1,
            int hours2, int minutes2, int seconds2,
            int resultHours, int resultMinutes, int resultSeconds)
        {
            var time1 = new Time(hours1, minutes1, seconds1);
            var time2 = new Time(hours2, minutes2, seconds2);
            var result = new Time(resultHours, resultMinutes, resultSeconds);

            Assert.That(time1 + time2, Is.EqualTo(result));
        }

        [TestCase(30, 10, 15, 10, 55, 15, 19, 15, 0)]
        [TestCase(30, 10, 15, 0, 0, 0, 30, 10, 15)]
        public void SubtractionTest(
            int hours1, int minutes1, int seconds1,
            int hours2, int minutes2, int seconds2,
            int resultHours, int resultMinutes, int resultSeconds)
        {
            var time1 = new Time(hours1, minutes1, seconds1);
            var time2 = new Time(hours2, minutes2, seconds2);
            var result = new Time(resultHours, resultMinutes, resultSeconds);

            Assert.That(time1 - time2, Is.EqualTo(result));
        }

        [TestCase(5, 7)]
        public void Subtraction_SubtrahendLargerThanMinuend_ArgumentException(int hours1, int hours2)
        {
            var time1 = new Time(hours1, 0, 0);
            var time2 = new Time(hours2, 0, 0);

            Assert.That(() => time1 - time2, Throws.ArgumentException);
        }

        [TestCase(5, 11, 33, 45, 57, 48, 45)]
        [TestCase(0.5, 11, 33, 45, 5, 46, 52)]
        public void MultiplicationTest(double k,
            int hours, int minutes, int seconds,
            int resultHours, int resultMinutes, int resultSeconds)
        {
            var time = new Time(hours, minutes, seconds);
            var result = new Time(resultHours, resultMinutes, resultSeconds);

            Assert.That(k * time, Is.EqualTo(result));
        }

        [TestCase(-5)]
        public void Multiplication_NegativeMultiplier_ArgumentException(double k)
        {
            var time = new Time(1, 1, 1);

            Assert.That(() => k * time, Throws.ArgumentException);
        }
    }
}