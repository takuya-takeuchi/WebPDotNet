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
                throw new ArgumentOutOfRangeException(nameof(qualityFactor), $"{nameof(qualityFactor)} must be from 0 to 100.");

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
                throw new ArgumentOutOfRangeException(nameof(qualityFactor), $"{nameof(qualityFactor)} must be from 0 to 100.");

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
                throw new ArgumentOutOfRangeException(nameof(qualityFactor), $"{nameof(qualityFactor)} must be from 0 to 100.");

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
                throw new ArgumentOutOfRangeException(nameof(qualityFactor), $"{nameof(qualityFactor)} must be from 0 to 100.");

            unsafe
            {
                fixed (byte* p = &bgra[0])
                {
                    var size = NativeMethods.webp_WebPEncodeBGRA((IntPtr)p, width, height, stride, qualityFactor, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes RGB image data to lossless WebP image.
        /// </summary>
        /// <param name="rgb">The RGB image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw RGB image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw RGB image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw RGB image to encode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rgb"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeLosslessRGB(byte[] rgb,
                                                         int width,
                                                         int height,
                                                         int stride)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");

            unsafe
            {
                fixed (byte* p = &rgb[0])
                {
                    var size = NativeMethods.webp_WebPEncodeLosslessRGB((IntPtr)p, width, height, stride, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes BGR image data to lossless WebP image.
        /// </summary>
        /// <param name="bgr">The BGR image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw BGR image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw BGR image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw BGR image to encode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bgr"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeLosslessBGR(byte[] bgr,
                                                         int width,
                                                         int height,
                                                         int stride)
        {
            if (bgr == null)
                throw new ArgumentNullException(nameof(bgr));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");

            unsafe
            {
                fixed (byte* p = &bgr[0])
                {
                    var size = NativeMethods.webp_WebPEncodeLosslessBGR((IntPtr)p, width, height, stride, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes RGBA image data to lossless WebP image.
        /// </summary>
        /// <param name="rgba">The RGBA image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw RGBA image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw RGBA image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw RGBA image to encode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rgba"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeLosslessRGBA(byte[] rgba,
                                                          int width,
                                                          int height,
                                                          int stride)
        {
            if (rgba == null)
                throw new ArgumentNullException(nameof(rgba));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");

            unsafe
            {
                fixed (byte* p = &rgba[0])
                {
                    var size = NativeMethods.webp_WebPEncodeLosslessRGBA((IntPtr)p, width, height, stride, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Encodes BGRA image data to lossless WebP image.
        /// </summary>
        /// <param name="bgra">The BGRA image data to encode.</param>
        /// <param name="width">The width, in pixels, of the raw BGRA image to encode.</param>
        /// <param name="height">The height, in pixels, of the raw BGRA image to encode.</param>
        /// <param name="stride">The stride, in bytes, of the raw BGRA image to encode.</param>
        /// <exception cref="ArgumentNullException"><paramref name="bgra"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>, <paramref name="height"/> and <paramref name="stride"/> must be more than 0.</exception>
        /// <returns>A new <see cref="EncodedImage"/>.</returns>
        public static EncodedImage WebPEncodeLosslessBGRA(byte[] bgra,
                                                          int width,
                                                          int height,
                                                          int stride)
        {
            if (bgra == null)
                throw new ArgumentNullException(nameof(bgra));
            if (!(width > 0))
                throw new ArgumentOutOfRangeException(nameof(width), $"{nameof(width)} must be more than 0.");
            if (!(height > 0))
                throw new ArgumentOutOfRangeException(nameof(height), $"{nameof(height)} must be more than 0.");
            if (!(stride > 0))
                throw new ArgumentOutOfRangeException(nameof(stride), $"{nameof(stride)} must be more than 0.");

            unsafe
            {
                fixed (byte* p = &bgra[0])
                {
                    var size = NativeMethods.webp_WebPEncodeLosslessBGRA((IntPtr)p, width, height, stride, out var output);
                    return new EncodedImage(output, (int)size);
                }
            }
        }

        /// <summary>
        /// Initialize the configuration according to a predefined set of parameters and a given quality factor.
        /// </summary>
        /// <param name="config">The compression parameters to initialize.</param>
        /// <param name="preset">The predefined settings for <see cref="WebPConfig"/>.</param>
        /// <param name="quality">The value to control the loss and quality during compression. It ranges from 0 to 100.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="quality"/> must be from 0 to 100.</exception>
        /// <returns><code>true</code> if <paramref name="config"/> has no error; otherwise, <code>false</code>.</returns>
        public static bool WebPConfigPreset(WebPConfig config, WebPPreset preset, float quality)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (!(0 <= quality && quality <= 100))
                throw new ArgumentOutOfRangeException(nameof(quality), $"{nameof(quality)} must be from 0 to 100.");

            return NativeMethods.webp_WebPConfigPreset(config.NativePtr, preset, quality);
        }

        /// <summary>
        /// Activate the lossless compression mode with the desired efficiency level.
        /// </summary>
        /// <param name="config">The compression parameters to activate.</param>
        /// <param name="level">The desired efficiency level. It ranges from 0 to 9. 0 is fastest and 9 is slower. A good default level is 6.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="level"/> must be from 0 to 9.</exception>
        /// <returns><code>true</code> if <paramref name="config"/> has no error; otherwise, <code>false</code>.</returns>
        public static bool WebPConfigLosslessPreset(WebPConfig config, int level)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (!(0 <= level && level <= 9))
                throw new ArgumentOutOfRangeException(nameof(level), $"{nameof(level)} must be from 0 to 9.");

            return NativeMethods.webp_WebPConfigLosslessPreset(config.NativePtr, level);
        }

        /// <summary>
        /// Validates whether specified configuration has no error or not.
        /// </summary>
        /// <param name="config">The compression parameters to validate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is null.</exception>
        /// <returns><code>true</code> if <paramref name="config"/> has no error; otherwise, <code>false</code>.</returns>
        public static bool WebPValidateConfig(WebPConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return NativeMethods.webp_WebPValidateConfig(config.NativePtr);
        }

        /// <summary>
        /// Initialize the <see cref="WebPPicture"/>.
        /// </summary>
        /// <param name="picture">The picture to initialize.</param>
        /// <exception cref="ArgumentNullException"><paramref name="picture"/> is null.</exception>
        /// <returns><code>true</code> if initialize succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPPictureInit(WebPPicture picture)
        {
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            return NativeMethods.webp_WebPPictureInit(picture.NativePtr);
        }

        /// <summary>
        /// Allocate or deallocate memory based on <see cref="WebPPicture.Width"/> and <see cref="WebPPicture.Height"/>.
        /// </summary>
        /// <param name="picture">The picture to allocate/deallocate memory.</param>
        /// <exception cref="ArgumentNullException"><paramref name="picture"/> is null.</exception>
        /// <returns><code>true</code> if allocation/deallocation succeeds; otherwise, <code>false</code>.</returns>
        public static bool WebPPictureAlloc(WebPPicture picture)
        {
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            return NativeMethods.webp_WebPPictureAlloc(picture.NativePtr);
        }

        /// <summary>
        /// Release the memory allocated by <see cref="WebPPictureAlloc"/> or WebPPictureImport methods.
        /// </summary>
        /// <param name="picture">The picture to release memory.</param>
        /// <exception cref="ArgumentNullException"><paramref name="picture"/> is null.</exception>
        public static void WebPPictureFree(WebPPicture picture)
        {
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            NativeMethods.webp_WebPPictureFree(picture.NativePtr);
        }

        public static void WebPMemoryWriterInit(WebPMemoryWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            NativeMethods.webp_WebPMemoryWriterInit(writer.NativePtr);
        }

        public static void WebPMemoryWriterClear(WebPMemoryWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            NativeMethods.webp_WebPMemoryWriterClear(writer.NativePtr);
        }

        public static int WebPMemoryWrite(byte[] data, WebPPicture picture)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (picture == null)
                throw new ArgumentNullException(nameof(picture));

            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    return NativeMethods.webp_WebPMemoryWrite((IntPtr)p, data.Length, picture.NativePtr);
                }
            }
        }

    }

}