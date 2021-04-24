using System;
using System.Runtime.InteropServices;

namespace WebPDotNet
{

    /// <summary>
    /// Defines the decoded image. This class cannot be inherited.
    /// </summary>
    public sealed class DecodedImage : WebPObject
    {

        #region Constructors

        internal DecodedImage(IntPtr ptr, int width, int height, CspMode mode, int channel)
        {
            this.NativePtr = ptr;
            this._Width = width;
            this._Height = height;
            this._Colorspace = mode;
            this._Channel = channel;
        }

        #endregion

        #region Properties

        private readonly int _Channel;

        /// <summary>
        /// Gets the number of channel, of this <see cref="DecodedImage"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>The number of channel, of this <see cref="DecodedImage"/>.</returns>
        public int Channel
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Channel;
            }            
        }

        private readonly CspMode _Colorspace;

        /// <summary>
        /// Gets a colorspace of this <see cref="DecodedImage"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>A <see cref="CspMode"/> that represents the colorspace for this <see cref="DecodedImage"/>.</returns>
        public CspMode Colorspace
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Colorspace;
            }            
        }

        private readonly int _Height;

        /// <summary>
        /// Gets the height, in pixels, of this <see cref="DecodedImage"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>The height, in pixels, of this <see cref="DecodedImage"/>.</returns>
        public int Height
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Height;
            }            
        }

        private readonly int _Width;

        /// <summary>
        /// Gets the width, in pixels, of this <see cref="DecodedImage"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>The width, in pixels, of this <see cref="DecodedImage"/>.</returns>
        public int Width
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Width;
            }            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the <see cref="DecodedImage"/> contents to a byte array.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns>A new byte array.</returns>
        public byte[] ToArray()
        {
            this.ThrowIfDisposed();
            
            var image = new byte[this._Width * this._Height * this._Channel];
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