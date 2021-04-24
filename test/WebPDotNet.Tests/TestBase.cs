using System;
using System.Collections.Generic;
using Xunit;

namespace WebPDotNet.Tests
{

    public abstract class TestBase
    {

        #region Methods

        protected void DisposeAndCheckDisposedState(WebPObject obj)
        {
            if (obj == null)
                return;

            obj.Dispose();
            Assert.True(obj.IsDisposed);
            Assert.True(obj.NativePtr == IntPtr.Zero);
        }

        protected void DisposeAndCheckDisposedStates(IEnumerable<WebPObject> objs)
        {
            foreach (var obj in objs)
                this.DisposeAndCheckDisposedState(obj);
        }

        protected static void CheckArgumentNullException(Action action, string methodName, string parameterName)
        {
            try
            {
                action.Invoke();
                Assert.False(true, $"{methodName} should throw {nameof(ArgumentNullException)} for {parameterName} parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        protected static void CheckArgumentOutOfRangeException(Action action, string methodName, string parameterName)
        {
            try
            {
                action.Invoke();
                Assert.False(true, $"{methodName} should throw {nameof(ArgumentOutOfRangeException)} for {parameterName} parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        #endregion

    }

}
