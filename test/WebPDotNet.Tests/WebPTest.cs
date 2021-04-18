using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

// ReSharper disable once CheckNamespace
namespace WebPDotNet.Tests
{

    public sealed partial class WebPTest : TestBase
    {

        #region Fields

        private const string ResultDirectory = "Result";

        private const string TestImageDirectory = "TestImages";

        private readonly IDictionary<CspMode, RawImage> _RawImages = new Dictionary<CspMode, RawImage>();

        #endregion

        #region Constructors

        public WebPTest()
        {
            // create test image on memory buffer
            var path = GetPath("1_webp_ll.png");
            using (var png = (Bitmap)Image.FromFile(path))
            {
                unsafe
                {
                    // png is Format32bppArgb
                    // In .NET Argb is BGRA
                    var width = png.Width;
                    var height = png.Height;
                    var format = png.PixelFormat;
                    var bitmapData = png.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
                    var stride = bitmapData.Stride;
                    var channel = 4;
                    var scanLine = bitmapData.Stride / channel;
                    var scan0 = (byte*)bitmapData.Scan0;
                    
                    this._RawImages.Add(CspMode.BGR, ToRawImage(scan0, width, height, stride, scanLine, channel, true, 3, false, false));
                    this._RawImages.Add(CspMode.BGRA, ToRawImage(scan0, width, height, stride, scanLine, channel, true, 4, false, true));
                    this._RawImages.Add(CspMode.RGB, ToRawImage(scan0, width, height, stride, scanLine, channel, true, 3, true, false));
                    this._RawImages.Add(CspMode.RGBA, ToRawImage(scan0, width, height, stride, scanLine, channel, true, 4, true, true));

                    png.UnlockBits(bitmapData);
                }
            }
        }

        #endregion

        [Fact]
        public void GetNativeVersion()
        {
            var version = WebP.GetNativeVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

        #region Helpers

        private static unsafe RawImage ToRawImage(byte* scan0,
                                                  int width,
                                                  int height,
                                                  int stride,
                                                  int scanLine,
                                                  int channel,
                                                  bool hasAlpha,
                                                  int destChannel,
                                                  bool swapRgb,
                                                  bool includeAlpha)
        {
            var rawImage = new RawImage { Data = new byte[scanLine * destChannel * height], Width = width, Height = height, Stride = scanLine * destChannel, Channel = destChannel };
            fixed (byte* p = &rawImage.Data[0])
            {
                var source = scan0;
                var target = p;
                for (var y = 0; y < rawImage.Height; y++)
                {
                    for (var x = 0; x < rawImage.Width; x++)
                    {
                        if (includeAlpha)
                            target[3] = source[3];

                        if (hasAlpha && !includeAlpha)
                        {
                            var alpha = source[3] / 255d;
                            if (swapRgb)
                            {
                                target[0] = (byte)(source[2] * alpha);
                                target[1] = (byte)(source[1] * alpha);
                                target[2] = (byte)(source[0] * alpha);
                            }
                            else
                            {
                                target[0] = (byte)(source[0] * alpha);
                                target[1] = (byte)(source[1] * alpha);
                                target[2] = (byte)(source[2] * alpha);
                            }
                        }
                        else
                        {
                            if (swapRgb)
                            {
                                target[0] = source[2];
                                target[1] = source[1];
                                target[2] = source[0];
                            }
                            else
                            {
                                target[0] = source[0];
                                target[1] = source[1];
                                target[2] = source[2];
                            }
                        }

                        source += channel;
                        target += rawImage.Channel;
                    }

                    source += (stride - width * channel);
                    target += (rawImage.Stride - rawImage.Width * rawImage.Channel);
                }
            }

            return rawImage;
        }

        private static string GetPath(string fileName)
        {
            return Path.Combine(TestImageDirectory, fileName);
        }

        private static byte[] ReadData(string fileName)
        {
            return File.ReadAllBytes(GetPath(fileName));
        }

        private static void WriteData(byte[] data, string directoryName, string fileName)
        {
            var directory = Path.Combine(ResultDirectory, directoryName);
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, fileName);
            File.WriteAllBytes(path, data);
        }

        #endregion

        private sealed class RawImage
        {

            public byte[] Data
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Stride
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }

            public int Channel
            {
                get;
                set;
            }

        }

    }

}
