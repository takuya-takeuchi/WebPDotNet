using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

// ReSharper disable once CheckNamespace
namespace WebPDotNet.Tests
{

    public sealed partial class WebPTest
    {

        [Fact]
        public void WebPConfig()
        {
            var config = new WebPConfig();
            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigPreset()
        {
            var config = new WebPConfig();

            foreach (var preset in Enum.GetValues(typeof(WebPPreset)).Cast<WebPPreset>())
            {
                Assert.True(WebP.WebPConfigPreset(config, preset, 0));
                Assert.True(WebP.WebPConfigPreset(config, preset, 100));
                CheckArgumentOutOfRangeException(() => WebP.WebPConfigPreset(config, preset, -1), nameof(WebP.WebPConfigPreset), "quality");
                CheckArgumentOutOfRangeException(() => WebP.WebPConfigPreset(config, preset, 101), nameof(WebP.WebPConfigPreset), "quality");
            }

            CheckArgumentNullException(() => WebP.WebPConfigPreset(null, WebPPreset.Default, 0), nameof(WebP.WebPConfigPreset), "config");

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigLosslessPreset()
        {
            var config = new WebPConfig();

            foreach (var level in Enumerable.Range(0, 10))
                Assert.True(WebP.WebPConfigLosslessPreset(config, level));

            CheckArgumentNullException(() => WebP.WebPConfigLosslessPreset(null, 6), nameof(WebP.WebPConfigLosslessPreset), "config");
            CheckArgumentOutOfRangeException(() => WebP.WebPConfigLosslessPreset(config, -1), nameof(WebP.WebPConfigLosslessPreset), "level");
            CheckArgumentOutOfRangeException(() => WebP.WebPConfigLosslessPreset(config, 10), nameof(WebP.WebPConfigLosslessPreset), "level");

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPValidateConfig()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            Assert.True(WebP.WebPConfigLosslessPreset(config, 6));
            Assert.True(WebP.WebPValidateConfig(config));

            CheckArgumentNullException(() => WebP.WebPValidateConfig(null), nameof(WebP.WebPValidateConfig), "config");

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigAlphaCompression()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var compression in Enum.GetValues(typeof(AlphaCompression)).Cast<AlphaCompression>())
            {
                config.AlphaCompression = compression;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigAlphaFiltering()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var filtering in Enum.GetValues(typeof(AlphaFiltering)).Cast<AlphaFiltering>())
            {
                config.AlphaFiltering = filtering;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigAlphaQuality()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.AlphaQuality = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.AlphaQuality = -1, nameof(WebPDotNet.WebPConfig.AlphaQuality), nameof(WebPDotNet.WebPConfig.AlphaQuality));
            CheckArgumentOutOfRangeException(() => config.AlphaQuality = 101, nameof(WebPDotNet.WebPConfig.AlphaQuality), nameof(WebPDotNet.WebPConfig.AlphaQuality));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigAutoFilter()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.AutoFilter = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigEmulateJpegSize()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.EmulateJpegSize = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigExact()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.Exact = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigFilterSharpness()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 7 })
            {
                config.FilterSharpness = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.FilterSharpness = -1, nameof(WebPDotNet.WebPConfig.FilterSharpness), nameof(WebPDotNet.WebPConfig.FilterSharpness));
            CheckArgumentOutOfRangeException(() => config.FilterSharpness = 8, nameof(WebPDotNet.WebPConfig.FilterSharpness), nameof(WebPDotNet.WebPConfig.FilterSharpness));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigFilterStrength()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.FilterStrength = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.FilterStrength = -1, nameof(WebPDotNet.WebPConfig.FilterStrength), nameof(WebPDotNet.WebPConfig.FilterStrength));
            CheckArgumentOutOfRangeException(() => config.FilterStrength = 101, nameof(WebPDotNet.WebPConfig.FilterStrength), nameof(WebPDotNet.WebPConfig.FilterStrength));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigFilterType()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var type in Enum.GetValues(typeof(FilterType)).Cast<FilterType>())
            {
                config.FilterType = type;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigImageHint()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var imageHint in Enum.GetValues(typeof(WebPImageHint)).Cast<WebPImageHint>().Except(new [] {WebPImageHint.Last}))
            {
                config.ImageHint = imageHint;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            config.ImageHint = WebPImageHint.Last;
            Assert.False(WebP.WebPValidateConfig(config));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigLossless()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.Lossless = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigLowMemory()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.LowMemory = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigMethod()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 6 })
            {
                config.Method = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.Method = -1, nameof(WebPDotNet.WebPConfig.Method), nameof(WebPDotNet.WebPConfig.Method));
            CheckArgumentOutOfRangeException(() => config.Method = 7, nameof(WebPDotNet.WebPConfig.Method), nameof(WebPDotNet.WebPConfig.Method));

            this.DisposeAndCheckDisposedState(config);
        }
        
        [Fact]
        public void WebPConfigNearLossless()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.NearLossless = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.NearLossless = -1, nameof(WebPDotNet.WebPConfig.NearLossless), nameof(WebPDotNet.WebPConfig.NearLossless));
            CheckArgumentOutOfRangeException(() => config.NearLossless = 101, nameof(WebPDotNet.WebPConfig.NearLossless), nameof(WebPDotNet.WebPConfig.NearLossless));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigPartitionLimit()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.PartitionLimit = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.PartitionLimit = -1, nameof(WebPDotNet.WebPConfig.PartitionLimit), nameof(WebPDotNet.WebPConfig.PartitionLimit));
            CheckArgumentOutOfRangeException(() => config.PartitionLimit = 101, nameof(WebPDotNet.WebPConfig.PartitionLimit), nameof(WebPDotNet.WebPConfig.PartitionLimit));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigPartitions()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 3 })
            {
                config.Partitions = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.Partitions = -1, nameof(WebPDotNet.WebPConfig.Partitions), nameof(WebPDotNet.WebPConfig.Partitions));
            CheckArgumentOutOfRangeException(() => config.Partitions = 4, nameof(WebPDotNet.WebPConfig.Partitions), nameof(WebPDotNet.WebPConfig.Partitions));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigPass()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 1, 10 })
            {
                config.Pass = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.Pass = 0, nameof(WebPDotNet.WebPConfig.Pass), nameof(WebPDotNet.WebPConfig.Pass));
            CheckArgumentOutOfRangeException(() => config.Pass = 11, nameof(WebPDotNet.WebPConfig.Pass), nameof(WebPDotNet.WebPConfig.Pass));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigPreprocessing()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var filter in Enum.GetValues(typeof(PreprocessingFilter)).Cast<PreprocessingFilter>())
            {
                config.Preprocessing = filter;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigQMax()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.QMax = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.QMax = -1, nameof(WebPDotNet.WebPConfig.QMax), nameof(WebPDotNet.WebPConfig.QMax));
            CheckArgumentOutOfRangeException(() => config.QMax = 101, nameof(WebPDotNet.WebPConfig.QMax), nameof(WebPDotNet.WebPConfig.QMax));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigQMin()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.QMin = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.QMax = -1, nameof(WebPDotNet.WebPConfig.QMin), nameof(WebPDotNet.WebPConfig.QMin));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigQuality()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.Quality = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.Quality = -1, nameof(WebPDotNet.WebPConfig.Quality), nameof(WebPDotNet.WebPConfig.Quality));
            CheckArgumentOutOfRangeException(() => config.Quality = 101, nameof(WebPDotNet.WebPConfig.Quality), nameof(WebPDotNet.WebPConfig.Quality));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigSegments()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 1, 4 })
            {
                config.Segments = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.Segments = 0, nameof(WebPDotNet.WebPConfig.Segments), nameof(WebPDotNet.WebPConfig.Segments));
            CheckArgumentOutOfRangeException(() => config.Segments = 5, nameof(WebPDotNet.WebPConfig.Segments), nameof(WebPDotNet.WebPConfig.Segments));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigShowCompressed()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.ShowCompressed = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigSpatialNoiseShapingStrength()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.SpatialNoiseShapingStrength = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.SpatialNoiseShapingStrength = -1, nameof(WebPDotNet.WebPConfig.SpatialNoiseShapingStrength), nameof(WebPDotNet.WebPConfig.SpatialNoiseShapingStrength));
            CheckArgumentOutOfRangeException(() => config.SpatialNoiseShapingStrength = 101, nameof(WebPDotNet.WebPConfig.SpatialNoiseShapingStrength), nameof(WebPDotNet.WebPConfig.SpatialNoiseShapingStrength));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigTargetPSNR()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.TargetPSNR = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.TargetPSNR = -1, nameof(WebPDotNet.WebPConfig.TargetPSNR), nameof(WebPDotNet.WebPConfig.TargetPSNR));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigTargetSize()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { 0, 100 })
            {
                config.TargetSize = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            CheckArgumentOutOfRangeException(() => config.TargetSize = -1, nameof(WebPDotNet.WebPConfig.TargetSize), nameof(WebPDotNet.WebPConfig.TargetSize));

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigThreadLevel()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.ThreadLevel = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigUseDeltaPalette()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.UseDeltaPalette = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

        [Fact]
        public void WebPConfigUseSharpYUV()
        {
            var config = new WebPConfig();

            Assert.True(WebP.WebPConfigPreset(config, WebPPreset.Default, 0));
            Assert.True(WebP.WebPValidateConfig(config));

            foreach (var value in new[] { false, true })
            {
                config.UseSharpYUV = value;
                Assert.True(WebP.WebPValidateConfig(config));
            }

            this.DisposeAndCheckDisposedState(config);
        }

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

            CheckArgumentNullException(() => WebP.WebPEncodeRGB(null, raw.Width, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeRGB), "rgb");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGB(raw.Data, 0, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeRGB), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGB(raw.Data, raw.Width, 0, raw.Stride, 100), nameof(WebP.WebPEncodeRGB), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGB(raw.Data, raw.Width, raw.Height, 0, 100), nameof(WebP.WebPEncodeRGB), "stride");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGB(raw.Data, raw.Width, 0, raw.Stride, -1), nameof(WebP.WebPEncodeRGB), "qualityFactor");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGB(raw.Data, raw.Width, 0, raw.Stride, 101), nameof(WebP.WebPEncodeRGB), "qualityFactor");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeRGB), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeRGBA()
        {
            var raw = this._RawImages[CspMode.RGBA];
            var encodedImage = WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeRGBA(null, raw.Width, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeRGBA), "rgba");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGBA(raw.Data, 0, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeRGBA), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGBA(raw.Data, raw.Width, 0, raw.Stride, 100), nameof(WebP.WebPEncodeRGBA), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGBA(raw.Data, raw.Width, raw.Height, 0, 100), nameof(WebP.WebPEncodeRGBA), "stride");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGBA(raw.Data, raw.Width, 0, raw.Stride, -1), nameof(WebP.WebPEncodeRGBA), "qualityFactor");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeRGBA(raw.Data, raw.Width, 0, raw.Stride, 101), nameof(WebP.WebPEncodeRGBA), "qualityFactor");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeRGBA), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeBGR()
        {
            var raw = this._RawImages[CspMode.BGR];
            var encodedImage = WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeBGR(null, raw.Width, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeBGR), "bgr");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGR(raw.Data, 0, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeBGR), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGR(raw.Data, raw.Width, 0, raw.Stride, 100), nameof(WebP.WebPEncodeBGR), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGR(raw.Data, raw.Width, raw.Height, 0, 100), nameof(WebP.WebPEncodeBGR), "stride");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGR(raw.Data, raw.Width, 0, raw.Stride, -1), nameof(WebP.WebPEncodeBGR), "qualityFactor");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGR(raw.Data, raw.Width, 0, raw.Stride, 101), nameof(WebP.WebPEncodeBGR), "qualityFactor");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeBGR), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeBGRA()
        {
            var raw = this._RawImages[CspMode.BGRA];
            var encodedImage = WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, raw.Stride, 100);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeBGRA(null, raw.Width, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeBGRA), "bgra");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGRA(raw.Data, 0, raw.Height, raw.Stride, 100), nameof(WebP.WebPEncodeBGRA), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGRA(raw.Data, raw.Width, 0, raw.Stride, 100), nameof(WebP.WebPEncodeBGRA), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGRA(raw.Data, raw.Width, raw.Height, 0, 100), nameof(WebP.WebPEncodeBGRA), "stride");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGRA(raw.Data, raw.Width, 0, raw.Stride, -1), nameof(WebP.WebPEncodeBGRA), "qualityFactor");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeBGRA(raw.Data, raw.Width, 0, raw.Stride, 101), nameof(WebP.WebPEncodeBGRA), "qualityFactor");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeBGRA), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessRGB()
        {
            var raw = this._RawImages[CspMode.RGB];
            var encodedImage = WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeLosslessRGB(null, raw.Width, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessRGB), "rgb");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGB(raw.Data, 0, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessRGB), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, 0, raw.Stride), nameof(WebP.WebPEncodeLosslessRGB), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGB(raw.Data, raw.Width, raw.Height, 0), nameof(WebP.WebPEncodeLosslessRGB), "stride");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeLosslessRGB), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessBGR()
        {
            var raw = this._RawImages[CspMode.BGR];
            var encodedImage = WebP.WebPEncodeLosslessBGR(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeLosslessBGR(null, raw.Width, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessBGR), "rgb");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGR(raw.Data, 0, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessBGR), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGR(raw.Data, raw.Width, 0, raw.Stride), nameof(WebP.WebPEncodeLosslessBGR), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGR(raw.Data, raw.Width, raw.Height, 0), nameof(WebP.WebPEncodeLosslessBGR), "stride");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeLosslessBGR), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessRGBA()
        {
            var raw = this._RawImages[CspMode.RGBA];
            var encodedImage = WebP.WebPEncodeLosslessRGBA(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeLosslessRGBA(null, raw.Width, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessRGBA), "rgb");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGBA(raw.Data, 0, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessRGBA), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGBA(raw.Data, raw.Width, 0, raw.Stride), nameof(WebP.WebPEncodeLosslessRGBA), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessRGBA(raw.Data, raw.Width, raw.Height, 0), nameof(WebP.WebPEncodeLosslessRGBA), "stride");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeLosslessRGBA), "result.webp");

            this.DisposeAndCheckDisposedState(encodedImage);
        }

        [Fact]
        public void WebPEncodeLosslessBGRA()
        {
            var raw = this._RawImages[CspMode.BGRA];
            var encodedImage = WebP.WebPEncodeLosslessBGRA(raw.Data, raw.Width, raw.Height, raw.Stride);
            Assert.True(encodedImage.Size > 0);

            CheckArgumentNullException(() => WebP.WebPEncodeLosslessBGRA(null, raw.Width, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessBGRA), "rgb");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGRA(raw.Data, 0, raw.Height, raw.Stride), nameof(WebP.WebPEncodeLosslessBGRA), "width");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGRA(raw.Data, raw.Width, 0, raw.Stride), nameof(WebP.WebPEncodeLosslessBGRA), "height");
            CheckArgumentOutOfRangeException(() => WebP.WebPEncodeLosslessBGRA(raw.Data, raw.Width, raw.Height, 0), nameof(WebP.WebPEncodeLosslessBGRA), "stride");

            WriteData(encodedImage.ToArray(), nameof(WebPEncodeLosslessBGRA), "result.webp");

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
