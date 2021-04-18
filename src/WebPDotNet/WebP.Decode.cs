using System;

namespace WebPDotNet
{

    public static partial class WebP
    {

        /// <summary>
        /// Return the encoder's version number.
        /// </summary>
        /// <returns>A <see cref="String"/> represents version number.</returns>
        public static string WebPGetDecoderVersion()
        {
            var version = NativeMethods.webp_WebPGetDecoderVersion();
            var revision = version & 0xFF;
            var minor = (version >> 8) & 0xFF;
            var major = (version >> 16) & 0xFF;
            return $"v{major}.{minor}.{revision}";
        }

        /// <summary>
        /// Decodes WebP image data to RGBA image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns>A new <see cref="DecodedImage"/>.</returns>
        public static DecodedImage WebPDecodeRGBA(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGBA((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.RGBA);
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data to ARGB image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns>A new <see cref="DecodedImage"/>.</returns>
        public static DecodedImage WebPDecodeARGB(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGBA((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.ARGB);
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data to BGRA image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns>A new <see cref="DecodedImage"/>.</returns>
        public static DecodedImage WebPDecodeBGRA(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGBA((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.BGRA);
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data to RGB image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns>A new <see cref="DecodedImage"/>.</returns>
        public static DecodedImage WebPDecodeRGB(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGB((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.RGB);
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data to BGR image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns>A new <see cref="DecodedImage"/>.</returns>
        public static DecodedImage WebPDecodeBGR(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeBGR((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.BGR);
                }
            }
        }

    }

}