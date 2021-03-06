using System;

namespace WebPDotNet
{

    public static partial class WebP
    {

        /// <summary>
        /// Return the encoder's version number.
        /// </summary>
        /// <returns>A <see cref="String"/> represents version number.</returns>
        public static string WebPGetEncoderVersion()
        {
            var version = NativeMethods.webp_WebPGetEncoderVersion();
            var revision = version & 0xFF;
            var minor = (version >> 8) & 0xFF;
            var major = (version >> 16) & 0xFF;
            return $"v{major}.{minor}.{revision}";
        }

        /// <summary>
        /// Encodes RGB image data to WebP image.
        /// </summary>
        /// <param name="rgb">The RGB image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw RGB image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw RGB image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw RGB image to encode.</param>
        /// <param name="qualityFactor">The value to control the loss and quality during compression. It ranges from 0 to 100.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rgb"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0. Or <paramref name="qualityFactor"/> must be from 0 to 100.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeRGB(byte[] rgb,
                                                 int width,
                                                 int height,
                                                 int stride,
                                                 float qualityFactor)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");
            if (!(0 <= qualityFactor && qualityFactor <= 100))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(qualityFactor)} must be from 0 to 100.");

            unsafe
            {
                fixed (byte* p = &rgb[0])
                {
                    var size = NativeMethods.webp_WebPEncodeRGB((IntPtr)p, width, height, stride, qualityFactor, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes BGR image data to WebP image.
        /// </summary>
        /// <param name="bgr">The BGR image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw BGR image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw BGR image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw BGR image to encode.</param>
        /// <param name="qualityFactor">The value to control the loss and quality during compression. It ranges from 0 to 100.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bgr"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0. Or <paramref name="qualityFactor"/> must be from 0 to 100.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeBGR(byte[] bgr,
                                                 int width,
                                                 int height,
                                                 int stride,
                                                 float qualityFactor)
        {
            if (bgr == null)
                throw new ArgumentNullException(nameof(bgr));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");
            if (!(0 <= qualityFactor && qualityFactor <= 100))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(qualityFactor)} must be from 0 to 100.");

            unsafe
            {
                fixed (byte* p = &bgr[0])
                {
                    var size = NativeMethods.webp_WebPEncodeBGR((IntPtr)p, width, height, stride, qualityFactor, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes RGBA image data to WebP image.
        /// </summary>
        /// <param name="rgba">The RGBA image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw RGBA image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw RGBA image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw RGBA image to encode.</param>
        /// <param name="qualityFactor">The value to control the loss and quality during compression. It ranges from 0 to 100.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rgba"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0. Or <paramref name="qualityFactor"/> must be from 0 to 100.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeRGBA(byte[] rgba,
                                                  int width,
                                                  int height,
                                                  int stride,
                                                  float qualityFactor)
        {
            if (rgba == null)
                throw new ArgumentNullException(nameof(rgba));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");
            if (!(0 <= qualityFactor && qualityFactor <= 100))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(qualityFactor)} must be from 0 to 100.");

            unsafe
            {
                fixed (byte* p = &rgba[0])
                {
                    var size = NativeMethods.webp_WebPEncodeRGBA((IntPtr)p, width, height, stride, qualityFactor, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes BGRA image data to WebP image.
        /// </summary>
        /// <param name="bgra">The BGRA image data to encode.</param>
        /// <param name="width">The width, in pixels, of the BGRA image to encode.</param>
        /// <param name="height">The height, in pixels, of the BGRA image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the BGRA image to encode.</param>
        /// <param name="qualityFactor">The value to control the loss and quality during compression. It ranges from 0 to 100.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bgra"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0. Or <paramref name="qualityFactor"/> must be from 0 to 100.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeBGRA(byte[] bgra,
                                                  int width,
                                                  int height,
                                                  int stride,
                                                  float qualityFactor)
        {
            if (bgra == null)
                throw new ArgumentNullException(nameof(bgra));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");
            if (!(0 <= qualityFactor && qualityFactor <= 100))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(qualityFactor)} must be from 0 to 100.");

            unsafe
            {
                fixed (byte* p = &bgra[0])
                {
                    var size = NativeMethods.webp_WebPEncodeBGRA((IntPtr)p, width, height, stride, qualityFactor, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

    }

}