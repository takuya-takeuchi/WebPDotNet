using System;
using System.Runtime.InteropServices;

namespace WebPDotNet
{

    /// <summary>
    /// Wraps input samples in either RGBA or YUVA format. This class cannot be inherited.
    /// </summary>
    public sealed class WebPPicture : WebPObject
    {

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int NativeWebPWriterFunction(IntPtr data, Int64 dataSize, IntPtr picture);

        #endregion

        #region Fields

        private DelegateHandler<NativeWebPWriterFunction> _NativeWebPWriterFunctionDelegate;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPPicture"/> class.
        /// </summary>
        public WebPPicture()
        {
            this.NativePtr = NativeMethods.webp_WebPPicture_new();
            this._NativeWebPWriterFunctionDelegate = new DelegateHandler<NativeWebPWriterFunction>(this.WebPWriterFunctionCallback);
        }

        internal WebPPicture(IntPtr ptr) :
            base(false)
        {
            this.NativePtr = ptr;
            this._NativeWebPWriterFunctionDelegate = new DelegateHandler<NativeWebPWriterFunction>(this.WebPWriterFunctionCallback);
        }

        #endregion

        #region Properties

        public WebPMemoryWriter CustomPtr
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.webp_WebPPicture_get_custom_ptr(this.NativePtr);
                return ret != IntPtr.Zero ? new WebPMemoryWriter(ret) : null;
            }
            set
            {
                this.ThrowIfDisposed();

                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();

                NativeMethods.webp_WebPPicture_set_custom_ptr(this.NativePtr, value.NativePtr);
            }
        }

        /// <summary>
        /// Sets or get the height, in pixels.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to <see cref="WebP.WebPMaxDimension"/>.</exception>
        /// <returns>The height, in pixels.</returns>
        public int Height
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPPicture_get_height(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= WebP.WebPMaxDimension))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to {nameof(WebP)}.{nameof(WebP.WebPMaxDimension)}.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPPicture_set_height(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether using ARGB or YUVA.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using ARGB; otherwise, <code>false</code>.</returns>
        public bool UseARGB
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPPicture_get_use_argb(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPPicture_set_use_argb(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the width, in pixels.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to <see cref="WebP.WebPMaxDimension"/>.</exception>
        /// <returns>The width, in pixels.</returns>
        public int Width
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPPicture_get_width(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= WebP.WebPMaxDimension))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to {nameof(WebP)}.{nameof(WebP.WebPMaxDimension)}.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPPicture_set_width(this.NativePtr, value);
            }
        }

        private WebPWriterFunction _Writer;

        public WebPWriterFunction Writer
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Writer;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPPicture_set_writer(this.NativePtr, value == null ? IntPtr.Zero : this._NativeWebPWriterFunctionDelegate.Handle);
                this._Writer = value;
            }
        }

        #endregion

        #region Methods

        #region Helpers

        public int WebPWriterFunctionCallback(IntPtr data, Int64 dataSize, IntPtr picture)
        {
            return this._Writer.Invoke(data, dataSize, new WebPPicture(picture));
        }

        #endregion

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

            NativeMethods.webp_WebPPicture_delete(this.NativePtr);
        }

        #endregion

    }

}