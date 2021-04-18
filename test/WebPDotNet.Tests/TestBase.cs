using System;
using System.Collections.Generic;
using Xunit;

namespace WebPDotNet.Tests
{

    public abstract class TestBase
    {

        #region Methods

        public void DisposeAndCheckDisposedState(WebPObject obj)
        {
            if (obj == null)
                return;

            obj.Dispose();
            Assert.True(obj.IsDisposed);
            Assert.True(obj.NativePtr == IntPtr.Zero);
        }

        public void DisposeAndCheckDisposedStates(IEnumerable<WebPObject> objs)
        {
            foreach (var obj in objs)
                this.DisposeAndCheckDisposedState(obj);
        }

        #endregion

    }

}
