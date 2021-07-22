using System;
using System.Runtime.InteropServices;
using WebPDotNet.Interop;

namespace WebPDotNet
{

    public sealed class WebPMemoryWriter : WebPObject
    {

        #region Constructors

        public WebPMemoryWriter()
        {
            this.NativePtr = NativeMethods.webp_WebPMemoryWriter_new();
        }

        internal WebPMemoryWriter(IntPtr ptr) :
            base(false)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public int MaxSize
        {
            get
            {
                this.ThrowIfDisposed();
                return (int)NativeMethods.webp_WebPMemoryWriter_get_max_size(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPMemoryWriter_set_max_size(this.NativePtr, value);
            }
        }

        public IntPtr Mem
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPMemoryWriter_get_mem(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPMemoryWriter_set_mem(this.NativePtr, value);
            }
        }

        public uint[] Pad
        {
            get
            {
                this.ThrowIfDisposed();
                // ToDo: set proper message for exception
                var error = NativeMethods.webp_WebPMemoryWriter_get_pad(this.NativePtr, out var ret, out var retLen);
                switch (error)
                {
                    case NativeMethods.ErrorType.GeneralOutOfRange:
                        throw new ArgumentOutOfRangeException();
                    case NativeMethods.ErrorType.GeneralMemAlloc:
                        throw new OutOfMemoryException();
                }

                var pad = new uint[retLen];
                InteropHelper.Copy(ret, pad, retLen);
                NativeMethods.stdlib_free(ret);
                return pad;
            }
            set
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.webp_WebPMemoryWriter_set_pad(this.NativePtr, value, value.Length);
            }
        }

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