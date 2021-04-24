using System;

namespace WebPDotNet
{

    /// <summary>
    /// Wraps input samples in either RGBA or YUVA format. This class cannot be inherited.
    /// </summary>
    public sealed class WebPPicture : WebPObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPPicture"/> class.
        /// </summary>
        public WebPPicture()
        {
            this.NativePtr = NativeMethods.webp_WebPPicture_new();
        }

        #endregion

        #region Properties

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