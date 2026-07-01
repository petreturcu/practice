using FluentAssertions;
using System.Runtime.ExceptionServices;

namespace Tests
{
    public class ExceptionCatching
    {
        [Test]
        public void SimpleThrow_ActuallyDoesShowTheLineOfTheOriginalExceptions()
        {
            // Arrange


            // Act
            try
            {
                SimpleThrowMethod();
            }
            catch (Exception e)
            {
                // Assert
                e.StackTrace.Should().Contain(":line 87");
                e.StackTrace.Should().Contain(":line 66");
            }
        }

        [Test]
        public void ExceptionDispatch_ShowsTheLineOfTheOriginalException()
        {
            // Arrange


            // Act
            try
            {
                DispatchThrowMethod();
            }
            catch (Exception e)
            {
                // Assert
                e.StackTrace.Should().Contain(":line 105");
                e.StackTrace.Should().Contain(":line 111");
            }
        }

        public void DispatchThrowMethod()
        {
            try
            {
                FirstMethod();
                SecondMethodWithDispatch();
                ThirdMethod();
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
                throw;
            }
        }

        public void SimpleThrowMethod()
        {
            try
            {
                FirstMethod();
                SecondMethod();
                ThirdMethod();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FirstMethod()
        {
            // some code
        }

        private void SecondMethod()
        {
            try
            {
                // hundreds of lines here

                // this line is NOT shown in the stack trace
                throw new NullReferenceException();

                // hundreds of lines here
            }
            catch (Exception)
            {
                // this line is shown in the stack trace
                throw;
            }
        }

        private void SecondMethodWithDispatch()
        {
            try
            {
                // hundreds of lines here

                // with ExceptionDispatchInfo this line is now shown in the stack trace
                throw new NullReferenceException();

                // hundreds of lines here
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
                throw;
            }
        }

        private void ThirdMethod()
        {
            // some other code
        }
    }
}
