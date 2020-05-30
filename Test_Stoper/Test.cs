using Stoper;
using System;
using Xunit;

namespace Test_Stoper
{
    public class Test
    {
        [Fact]
        public void Test_ShouldThrowArgumentExceptionWhenNotStarted()
        {
            var stoper = new MyStoper();

            Assert.Throws<ArgumentException>(() => stoper.Time);
        }

        [Fact]
        public void Test_ShouldThrowArgumentExceptionWhenRunning()
        {
            var stoper = new MyStoper();

            stoper.Start();

            Assert.Throws<ArgumentException>(() => stoper.Time);
        }

        [Fact]
        public void Test_ShouldThrowInvalidOperationExceptionWhenStartingAgain()
        {
            var stoper = new MyStoper();

            stoper.Start();
            
            Assert.Throws<InvalidOperationException>(() => stoper.Start());
        }

        [Fact]
        public void Test_ShouldThrowInvalidOperationExceptionWhenStoppingAgain()
        {
            var stoper = new MyStoper();

            stoper.Start();
            stoper.Stop();

            Assert.Throws<InvalidOperationException>(() => stoper.Stop());
        }

        [Fact]
        public void Test_ShouldThrowInvalidOperationExceptionAfterRestarting()
        {
            var stoper = new MyStoper();

            stoper.Start();
            stoper.Stop();
            stoper.Restart();

            Assert.Throws<ArgumentException>(() => stoper.Time);
        }

        [Fact]
        public void Test_ShouldReturnNotNullTime()
        {
            var stoper = new MyStoper();

            stoper.Start();
            stoper.Stop();
            stoper.Start();
            stoper.Stop();

            double? time = stoper.Time;

            Assert.True(time is not null);
        }
    }
}
