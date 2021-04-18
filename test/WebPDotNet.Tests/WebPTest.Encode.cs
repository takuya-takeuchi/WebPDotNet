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

    }

}
