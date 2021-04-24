using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

// ReSharper disable once CheckNamespace
namespace WebPDotNet.Tests
{

    public sealed partial class WebPTest
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
            
            CheckArgumentNullException(() => WebP.WebPDecodeARGB(null), nameof(WebP.WebPDecodeARGB), "data");

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
            
            CheckArgumentNullException(() => WebP.WebPDecodeRGB(null), nameof(WebP.WebPDecodeRGB), "data");

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
            
            CheckArgumentNullException(() => WebP.WebPDecodeBGRA(null), nameof(WebP.WebPDecodeBGRA), "data");

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
            
            CheckArgumentNullException(() => WebP.WebPDecodeBGR(null), nameof(WebP.WebPDecodeBGR), "data");

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

            CheckArgumentNullException(() => WebP.WebPDecodeRGBInto(null, output, stride), nameof(WebP.WebPDecodeRGBInto), "data");
            CheckArgumentNullException(() => WebP.WebPDecodeRGBInto(webp, null, stride), nameof(WebP.WebPDecodeRGBInto), "output");
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

            CheckArgumentNullException(() => WebP.WebPDecodeARGBInto(null, output, stride), nameof(WebP.WebPDecodeARGBInto), "data");
            CheckArgumentNullException(() => WebP.WebPDecodeARGBInto(webp, null, stride), nameof(WebP.WebPDecodeARGBInto), "output");
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

            CheckArgumentNullException(() => WebP.WebPDecodeRGBAInto(null, output, stride), nameof(WebP.WebPDecodeRGBAInto), "data");
            CheckArgumentNullException(() => WebP.WebPDecodeRGBAInto(webp, null, stride), nameof(WebP.WebPDecodeRGBAInto), "output");
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

            CheckArgumentNullException(() => WebP.WebPDecodeBGRInto(null, output, stride), nameof(WebP.WebPDecodeBGRInto), "data");
            CheckArgumentNullException(() => WebP.WebPDecodeBGRInto(webp, null, stride), nameof(WebP.WebPDecodeBGRInto), "output");
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

            CheckArgumentNullException(() => WebP.WebPDecodeBGRAInto(null, output, stride), nameof(WebP.WebPDecodeBGRAInto), "data");
            CheckArgumentNullException(() => WebP.WebPDecodeBGRAInto(webp, null, stride), nameof(WebP.WebPDecodeBGRAInto), "output");
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