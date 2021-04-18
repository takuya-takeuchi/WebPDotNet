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
            
            this.DisposeAndCheckDisposedState(decodedImage);
        }

    }

}
