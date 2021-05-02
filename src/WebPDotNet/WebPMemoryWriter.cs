using System;

namespace WebPDotNet
{

    public sealed class WebPMemoryWriter : WebPObject
    {

        #region Constructors

        public WebPMemoryWriter()
        {
            this.NativePtr = NativeMethods.webp_WebPMemoryWriter_new();
        }

        #endregion

        #region Properties

        public int Size
        {
            get
            {
                this.ThrowIfDisposed();
                return (int)NativeMethods.webp_WebPMemoryWriter_get_size(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPMemoryWriter_set_size(this.NativePtr, (int)value);
            }
        }

        #endregion

        #region Overrides 

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.webp_WebPMemoryWriter_delete(this.NativePtr);
        }

        #endregion

    }

}