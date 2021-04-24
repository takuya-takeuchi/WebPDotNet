using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

// ReSharper disable once CheckNamespace
namespace WebPDotNet.Tests
{

    public sealed partial class WebPTest : TestBase
    {

        [Fact]
        public void WebPGetEncoderVersion()
        {
            var version = WebP.WebPGetEncoderVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
            var match = Regex.IsMatch(version, "v[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}");
            Assert.True(match);
        }

        [Fact]
        public void WebPEncodeRGB()
        {
            var raw = this._RawImages[CspMode.RGB];
            var encodedImage = WebP.WebPEncodeRGB(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            try
            {
                WebP.WebPEncodeRGB(null, raw.Width, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentNullException)} for rgb parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPEncodeRGB(raw.Data, 0, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentOutOfRangeException)} for width parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGB(raw.Data, raw.Width, 0, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentOutOfRangeException)} for height parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGB(raw.Data, raw.Width, raw.Height, 0, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentOutOfRangeException)} for stride parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGB(raw.Data, raw.Width, raw.Height, raw.Stride, -1);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGB(raw.Data, raw.Width, raw.Height, raw.Stride, 101);
                Assert.False(true, $"{nameof(WebPEncodeRGB)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeRGB), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeRGBA()
        {
            var raw = this._RawImages[CspMode.RGBA];
            var encodedImage = WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            try
            {
                WebP.WebPEncodeRGBA(null, raw.Width, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentNullException)} for rgba parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPEncodeRGBA(raw.Data, 0, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentOutOfRangeException)} for width parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGBA(raw.Data, raw.Width, 0, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentOutOfRangeException)} for height parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, 0, 100);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentOutOfRangeException)} for stride parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, raw.Stride, -1);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, raw.Stride, 101);
                Assert.False(true, $"{nameof(WebPEncodeRGBA)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeRGBA), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeBGR()
        {
            var raw = this._RawImages[CspMode.BGR];
            var encodedImage = WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            try
            {
                WebP.WebPEncodeBGR(null, raw.Width, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentNullException)} for bgr parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPEncodeBGR(raw.Data, 0, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentOutOfRangeException)} for width parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGR(raw.Data, raw.Width, 0, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentOutOfRangeException)} for height parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, 0, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentOutOfRangeException)} for stride parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, raw.Stride, -1);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, raw.Stride, 101);
                Assert.False(true, $"{nameof(WebPEncodeBGR)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeBGR), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeBGRA()
        {
            var raw = this._RawImages[CspMode.BGRA];
            var encodedImage = WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            try
            {
                WebP.WebPEncodeBGRA(null, raw.Width, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentNullException)} for bgra parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPEncodeBGRA(raw.Data, 0, raw.Height, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentOutOfRangeException)} for width parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGRA(raw.Data, raw.Width, 0, raw.Stride, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentOutOfRangeException)} for height parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, 0, 100);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentOutOfRangeException)} for stride parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, raw.Stride, -1);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, raw.Stride, 101);
                Assert.False(true, $"{nameof(WebPEncodeBGRA)} should throw {nameof(ArgumentOutOfRangeException)} for qualityFactor parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeBGRA), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessRGB()
        {
            var raw = this._RawImages[CspMode.RGB];
            var encodedImage = WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);

            try
            {
                WebP.WebPEncodeLosslessRGB(null, raw.Width, raw.Height, raw.Stride);
                Assert.False(true, $"{nameof(WebPEncodeLosslessRGB)} should throw {nameof(ArgumentNullException)} for rgb parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPEncodeLosslessRGB(raw.Data, 0, raw.Height, raw.Stride);
                Assert.False(true, $"{nameof(WebPEncodeLosslessRGB)} should throw {nameof(ArgumentOutOfRangeException)} for width parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, 0, raw.Stride);
                Assert.False(true, $"{nameof(WebPEncodeLosslessRGB)} should throw {nameof(ArgumentOutOfRangeException)} for height parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, raw.Height, 0);
                Assert.False(true, $"{nameof(WebPEncodeLosslessRGB)} should throw {nameof(ArgumentOutOfRangeException)} for stride parameter");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeLosslessRGB), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessRGBCheckLossless()
        {
            const int loop = 5;
            var raw = this._RawImages[CspMode.RGB];
            var encodedImage = WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);
            var webp = encodedImage.ToArray();
            this.DisposeAndCheckDisposedState(encodedImage);

            var decodedImage = WebP.WebPDecodeRGB(webp);
            var decodedWidth = decodedImage.Width;
            var decodedHeight = decodedImage.Height;
            var decodedChannel = decodedImage.Channel;
            var stride = decodedWidth * decodedChannel;
            var decodedRawImage = decodedImage.ToArray();
            this.DisposeAndCheckDisposedState(decodedImage);
            
            var oridinalDecodedRawImage = decodedRawImage;
            for (var l = 0; l < loop; l++)
            {
                using (var e = WebP.WebPEncodeLosslessRGB(decodedRawImage, decodedWidth, decodedHeight, stride))
                using (var d = WebP.WebPDecodeRGB(e.ToArray()))
                {
                    var tmp = d.ToArray();
                    Assert.Equal(tmp.Length, oridinalDecodedRawImage.Length);

                    for (var index = 0; index < oridinalDecodedRawImage.Length; index++)
                        Assert.Equal(tmp[index], oridinalDecodedRawImage[index]);

                    decodedRawImage = tmp;
                }
            }
        }

        [Fact]
        public void WebPEncodeLosslessBGRCheckLossless()
        {
            const int loop = 5;
            var raw = this._RawImages[CspMode.BGR];
            var encodedImage = WebP.WebPEncodeLosslessBGR(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);
            var webp = encodedImage.ToArray();
            this.DisposeAndCheckDisposedState(encodedImage);

            var decodedImage = WebP.WebPDecodeBGR(webp);
            var decodedWidth = decodedImage.Width;
            var decodedHeight = decodedImage.Height;
            var decodedChannel = decodedImage.Channel;
            var stride = decodedWidth * decodedChannel;
            var decodedRawImage = decodedImage.ToArray();
            this.DisposeAndCheckDisposedState(decodedImage);
            
            var oridinalDecodedRawImage = decodedRawImage;
            for (var l = 0; l < loop; l++)
            {
                using (var e = WebP.WebPEncodeLosslessBGR(decodedRawImage, decodedWidth, decodedHeight, stride))
                using (var d = WebP.WebPDecodeBGR(e.ToArray()))
                {
                    var tmp = d.ToArray();
                    Assert.Equal(tmp.Length, oridinalDecodedRawImage.Length);

                    for (var index = 0; index < oridinalDecodedRawImage.Length; index++)
                        Assert.Equal(tmp[index], oridinalDecodedRawImage[index]);

                    decodedRawImage = tmp;
                }
            }
        }

        [Fact]
        public void WebPEncodeLosslessRGBACheckLossless()
        {
            const int loop = 5;
            var raw = this._RawImages[CspMode.RGBA];
            var encodedImage = WebP.WebPEncodeLosslessRGBA(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);
            var webp = encodedImage.ToArray();
            this.DisposeAndCheckDisposedState(encodedImage);

            var decodedImage = WebP.WebPDecodeRGBA(webp);
            var decodedWidth = decodedImage.Width;
            var decodedHeight = decodedImage.Height;
            var decodedChannel = decodedImage.Channel;
            var stride = decodedWidth * decodedChannel;
            var decodedRawImage = decodedImage.ToArray();
            this.DisposeAndCheckDisposedState(decodedImage);
            
            var oridinalDecodedRawImage = decodedRawImage;
            for (var l = 0; l < loop; l++)
            {
                using (var e = WebP.WebPEncodeLosslessRGBA(decodedRawImage, decodedWidth, decodedHeight, stride))
                using (var d = WebP.WebPDecodeRGBA(e.ToArray()))
                {
                    var tmp = d.ToArray();
                    Assert.Equal(tmp.Length, oridinalDecodedRawImage.Length);

                    for (var index = 0; index < oridinalDecodedRawImage.Length; index++)
                        Assert.Equal(tmp[index], oridinalDecodedRawImage[index]);

                    decodedRawImage = tmp;
                }
            }
        }

        [Fact]
        public void WebPEncodeLosslessBGRACheckLossless()
        {
            const int loop = 5;
            var raw = this._RawImages[CspMode.BGRA];
            var encodedImage = WebP.WebPEncodeLosslessBGRA(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);
            var webp = encodedImage.ToArray();
            this.DisposeAndCheckDisposedState(encodedImage);

            var decodedImage = WebP.WebPDecodeBGRA(webp);
            var decodedWidth = decodedImage.Width;
            var decodedHeight = decodedImage.Height;
            var decodedChannel = decodedImage.Channel;
            var stride = decodedWidth * decodedChannel;
            var decodedRawImage = decodedImage.ToArray();
            this.DisposeAndCheckDisposedState(decodedImage);
            
            var oridinalDecodedRawImage = decodedRawImage;
            for (var l = 0; l < loop; l++)
            {
                using (var e = WebP.WebPEncodeLosslessBGRA(decodedRawImage, decodedWidth, decodedHeight, stride))
                using (var d = WebP.WebPDecodeBGRA(e.ToArray()))
                {
                    var tmp = d.ToArray();
                    Assert.Equal(tmp.Length, oridinalDecodedRawImage.Length);

                    for (var index = 0; index < oridinalDecodedRawImage.Length; index++)
                        Assert.Equal(tmp[index], oridinalDecodedRawImage[index]);

                    decodedRawImage = tmp;
                }
            }
        }

    }

}
