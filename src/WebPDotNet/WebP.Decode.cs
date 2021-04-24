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
                    return new DecodedImage(ret, width, height, CspMode.RGBA, 4);
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
                    return new DecodedImage(ret, width, height, CspMode.ARGB, 4);
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
                    var ret = NativeMethods.webp_WebPDecodeBGRA((IntPtr)p, data.Length, out var width, out var height);
                    return new DecodedImage(ret, width, height, CspMode.BGRA, 4);
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
                    return new DecodedImage(ret, width, height, CspMode.RGB, 3);
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
                    return new DecodedImage(ret, width, height, CspMode.BGR, 3);
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data into 8-bit unsigned integer array as RGB image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="output">The array to copy to.</param>
        /// <param name="stride">The stride, in bytes, of the decoded image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="output"/> is null.</exception>
        /// <returns><code>true</code> if decode succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPDecodeRGBInto(byte[] data, byte[] output, int stride)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            unsafe
            {
                fixed (byte* p = &data[0])
                fixed (byte* o = &output[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGBInto((IntPtr)p, data.Length, (IntPtr)o, output.Length, stride);
                    return ret != IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data into 8-bit unsigned integer array as RGBA image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="output">The array to copy to.</param>
        /// <param name="stride">The stride, in bytes, of the decoded image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="output"/> is null.</exception>
        /// <returns><code>true</code> if decode succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPDecodeRGBAInto(byte[] data, byte[] output, int stride)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            unsafe
            {
                fixed (byte* p = &data[0])
                fixed (byte* o = &output[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeRGBAInto((IntPtr)p, data.Length, (IntPtr)o, output.Length, stride);
                    return ret != IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data into 8-bit unsigned integer array as ARGB image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="output">The array to copy to.</param>
        /// <param name="stride">The stride, in bytes, of the decoded image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="output"/> is null.</exception>
        /// <returns><code>true</code> if decode succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPDecodeARGBInto(byte[] data, byte[] output, int stride)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            unsafe
            {
                fixed (byte* p = &data[0])
                fixed (byte* o = &output[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeARGBInto((IntPtr)p, data.Length, (IntPtr)o, output.Length, stride);
                    return ret != IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data into 8-bit unsigned integer array as BGR image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="output">The array to copy to.</param>
        /// <param name="stride">The stride, in bytes, of the decoded image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="output"/> is null.</exception>
        /// <returns><code>true</code> if decode succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPDecodeBGRInto(byte[] data, byte[] output, int stride)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            unsafe
            {
                fixed (byte* p = &data[0])
                fixed (byte* o = &output[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeBGRInto((IntPtr)p, data.Length, (IntPtr)o, output.Length, stride);
                    return ret != IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Decodes WebP image data into 8-bit unsigned integer array as BGRA image.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="output">The array to copy to.</param>
        /// <param name="stride">The stride, in bytes, of the decoded image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="output"/> is null.</exception>
        /// <returns><code>true</code> if decode succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPDecodeBGRAInto(byte[] data, byte[] output, int stride)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            unsafe
            {
                fixed (byte* p = &data[0])
                fixed (byte* o = &output[0])
                {
                    var ret = NativeMethods.webp_WebPDecodeBGRAInto((IntPtr)p, data.Length, (IntPtr)o, output.Length, stride);
                    return ret != IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Validate the WebP image data and retrieve the image width and height.
        /// </summary>
        /// <param name="data">The WebP image data to decode.</param>
        /// <param name="width">When this method returns, contains the width, in pixels, of WebP image, if <paramref name="data"/> is WebP image; otherwise, <code>0</code>. This parameter is passed uninitialized.</param>
        /// <param name="height">When this method returns, contains the height, in pixels, of WebP image, if <paramref name="data"/> is WebP image; otherwise, <code>0</code>. This parameter is passed uninitialized.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <returns><code>true</code> if <paramref name="data"/> is WebP image; otherwise, <code>false</code>.</returns>
        public static bool WebPGetInfo(byte[] data, out int width, out int height)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    return NativeMethods.webp_WebPGetInfo((IntPtr)p, data.Length, out width, out height);
                }
            }
        }

    }

}