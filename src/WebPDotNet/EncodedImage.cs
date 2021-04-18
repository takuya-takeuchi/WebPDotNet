using System;
using System.Runtime.InteropServices;

namespace WebPDotNet
{

    /// <summary>
    /// Defines the encoded image. This class cannot be inherited.
    /// </summary>
    public sealed class EncodedImage : WebPObject
    {

        #region Constructors

        internal EncodedImage(IntPtr ptr, int size)
        {
            this.NativePtr = ptr;
            this._Size = size;
        }

        #endregion

        #region Properties

        private readonly int _Size;

        /// <summary>
        /// Gets the size, in bytes, of this <see cref="EncodedImage"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>The size, in bytes, of this <see cref="EncodedImage"/>.</returns>
        public int Size
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Size;
            }            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the <see cref="EncodedImage"/> contents to a byte array.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>A new byte array.</returns>
        public byte[] ToArray()
        {
            this.ThrowIfDisposed();
            
            var image = new byte[this._Size];
            Marshal.Copy(this.NativePtr, image, 0, image.Length);
            return image;
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

            NativeMethods.webp_WebPFree(this.NativePtr);
        }

        #endregion

    }

}