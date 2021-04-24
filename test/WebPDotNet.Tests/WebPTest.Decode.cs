using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

// ReSharper disable once CheckNamespace
namespace WebPDotNet.Tests
{

    public sealed partial class WebPTest : TestBase
    {

        [Fact]
        public void WebPGetDecoderVersion()
        {
            var version = WebP.WebPGetDecoderVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
            var match = Regex.IsMatch(version, "v[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}");
            Assert.True(match);
        }

        [Fact]
        public void WebPDecodeARGB()
        {
            const int width = 400;
            const int height = 301;
            const CspMode colorspace = CspMode.ARGB;
            var webp = ReadData("1_webp_ll.webp");

            var decodedImage = WebP.WebPDecodeARGB(webp);
            Assert.Equal(width, decodedImage.Width);
            Assert.Equal(height, decodedImage.Height);
            Assert.Equal(colorspace, decodedImage.Colorspace);

            try
            {
                WebP.WebPDecodeARGB(null);
                Assert.False(true, $"{nameof(WebPDecodeARGB)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            this.DisposeAndCheckDisposedState(decodedImage);
        }

        [Fact]
        public void WebPDecodeRGB()
        {
            const int width = 400;
            const int height = 301;
            const CspMode colorspace = CspMode.RGB;
            var webp = ReadData("1_webp_ll.webp");

            var decodedImage = WebP.WebPDecodeRGB(webp);
            Assert.Equal(width, decodedImage.Width);
            Assert.Equal(height, decodedImage.Height);
            Assert.Equal(colorspace, decodedImage.Colorspace);

            try
            {
                WebP.WebPDecodeRGB(null);
                Assert.False(true, $"{nameof(WebPDecodeRGB)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }
            
            this.DisposeAndCheckDisposedState(decodedImage);
        }

        [Fact]
        public void WebPDecodeBGRA()
        {
            const int width = 400;
            const int height = 301;
            const CspMode colorspace = CspMode.BGRA;
            var webp = ReadData("1_webp_ll.webp");

            var decodedImage = WebP.WebPDecodeBGRA(webp);
            Assert.Equal(width, decodedImage.Width);
            Assert.Equal(height, decodedImage.Height);
            Assert.Equal(colorspace, decodedImage.Colorspace);

            try
            {
                WebP.WebPDecodeBGRA(null);
                Assert.False(true, $"{nameof(WebPDecodeBGRA)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            this.DisposeAndCheckDisposedState(decodedImage);
        }

        [Fact]
        public void WebPDecodeBGR()
        {
            const int width = 400;
            const int height = 301;
            const CspMode colorspace = CspMode.BGR;
            var webp = ReadData("1_webp_ll.webp");

            var decodedImage = WebP.WebPDecodeBGR(webp);
            Assert.Equal(width, decodedImage.Width);
            Assert.Equal(height, decodedImage.Height);
            Assert.Equal(colorspace, decodedImage.Colorspace);

            try
            {
                WebP.WebPDecodeBGR(null);
                Assert.False(true, $"{nameof(WebPDecodeBGR)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }
            
            this.DisposeAndCheckDisposedState(decodedImage);
        }

        [Fact]
        public void WebPDecodeRGBInto()
        {
            const int channel = 3;
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            const int stride = width * channel;
            var output = new byte[stride * height];
            var ret = WebP.WebPDecodeRGBInto(webp, output, stride);
            Assert.True(ret);

            const int stride2 = (width + 1) * channel;
            var output2 = new byte[stride2 * height];
            var ret2 = WebP.WebPDecodeRGBInto(webp, output2, stride2);
            Assert.True(ret2);

            const int stride3 = (width - 1) * channel;
            var output3 = new byte[stride3 * height];
            var ret3 = WebP.WebPDecodeRGBInto(webp, output3, stride3);
            Assert.False(ret3);

            try
            {
                WebP.WebPDecodeRGBInto(null, output, stride);
                Assert.False(true, $"{nameof(WebPDecodeRGBInto)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPDecodeRGBInto(webp, null, stride);
                Assert.False(true, $"{nameof(WebPDecodeRGBInto)} should throw {nameof(ArgumentNullException)} for output parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void WebPDecodeARGBInto()
        {
            const int channel = 4;
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            const int stride = width * channel;
            var output = new byte[stride * height];
            var ret = WebP.WebPDecodeARGBInto(webp, output, stride);
            Assert.True(ret);

            const int stride2 = (width + 1) * channel;
            var output2 = new byte[stride2 * height];
            var ret2 = WebP.WebPDecodeARGBInto(webp, output2, stride2);
            Assert.True(ret2);

            const int stride3 = (width - 1) * channel;
            var output3 = new byte[stride3 * height];
            var ret3 = WebP.WebPDecodeARGBInto(webp, output3, stride3);
            Assert.False(ret3);

            try
            {
                WebP.WebPDecodeARGBInto(null, output, stride);
                Assert.False(true, $"{nameof(WebPDecodeARGBInto)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPDecodeARGBInto(webp, null, stride);
                Assert.False(true, $"{nameof(WebPDecodeARGBInto)} should throw {nameof(ArgumentNullException)} for output parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void WebPDecodeRGBAInto()
        {
            const int channel = 4;
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            const int stride = width * channel;
            var output = new byte[stride * height];
            var ret = WebP.WebPDecodeRGBAInto(webp, output, stride);
            Assert.True(ret);

            const int stride2 = (width + 1) * channel;
            var output2 = new byte[stride2 * height];
            var ret2 = WebP.WebPDecodeRGBAInto(webp, output2, stride2);
            Assert.True(ret2);

            const int stride3 = (width - 1) * channel;
            var output3 = new byte[stride3 * height];
            var ret3 = WebP.WebPDecodeRGBAInto(webp, output3, stride3);
            Assert.False(ret3);

            try
            {
                WebP.WebPDecodeRGBAInto(null, output, stride);
                Assert.False(true, $"{nameof(WebPDecodeRGBAInto)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPDecodeRGBAInto(webp, null, stride);
                Assert.False(true, $"{nameof(WebPDecodeRGBAInto)} should throw {nameof(ArgumentNullException)} for output parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void WebPDecodeBGRInto()
        {
            const int channel = 3;
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            const int stride = width * channel;
            var output = new byte[stride * height];
            var ret = WebP.WebPDecodeBGRInto(webp, output, stride);
            Assert.True(ret);

            const int stride2 = (width + 1) * channel;
            var output2 = new byte[stride2 * height];
            var ret2 = WebP.WebPDecodeBGRInto(webp, output2, stride2);
            Assert.True(ret2);

            const int stride3 = (width - 1) * channel;
            var output3 = new byte[stride3 * height];
            var ret3 = WebP.WebPDecodeBGRInto(webp, output3, stride3);
            Assert.False(ret3);

            try
            {
                WebP.WebPDecodeBGRInto(null, output, stride);
                Assert.False(true, $"{nameof(WebPDecodeBGRInto)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPDecodeBGRInto(webp, null, stride);
                Assert.False(true, $"{nameof(WebPDecodeBGRInto)} should throw {nameof(ArgumentNullException)} for output parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void WebPDecodeBGRAInto()
        {
            const int channel = 4;
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            const int stride = width * channel;
            var output = new byte[stride * height];
            var ret = WebP.WebPDecodeBGRAInto(webp, output, stride);
            Assert.True(ret);

            const int stride2 = (width + 1) * channel;
            var output2 = new byte[stride2 * height];
            var ret2 = WebP.WebPDecodeBGRAInto(webp, output2, stride2);
            Assert.True(ret2);

            const int stride3 = (width - 1) * channel;
            var output3 = new byte[stride3 * height];
            var ret3 = WebP.WebPDecodeBGRAInto(webp, output3, stride3);
            Assert.False(ret3);

            try
            {
                WebP.WebPDecodeBGRAInto(null, output, stride);
                Assert.False(true, $"{nameof(WebPDecodeBGRAInto)} should throw {nameof(ArgumentNullException)} for data parameter");
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                WebP.WebPDecodeBGRAInto(webp, null, stride);
                Assert.False(true, $"{nameof(WebPDecodeBGRAInto)} should throw {nameof(ArgumentNullException)} for output parameter");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void WebPGetInfoValid()
        {
            const int width = 400;
            const int height = 301;
            var webp = ReadData("1_webp_ll.webp");

            var ret = WebP.WebPGetInfo(webp, out var w, out var h);
            Assert.Equal(width, w);
            Assert.Equal(height, h);
            Assert.True(ret);
        }

        [Fact]
        public void WebPGetInfoInalid()
        {
            const int width = 0;
            const int height = 0;
            var webp = ReadData("1_webp_ll.png");

            var ret = WebP.WebPGetInfo(webp, out var w, out var h);
            Assert.Equal(width, w);
            Assert.Equal(height, h);
            Assert.False(ret);
        }

    }

}