using System;

namespace WebPDotNet
{

    /// <summary>
    /// Defines the compression parameters. This class cannot be inherited.
    /// </summary>
    public sealed class WebPConfig : WebPObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPConfig"/> class.
        /// </summary>
        public WebPConfig()
        {
            this.NativePtr = NativeMethods.webp_WebPConfig_new();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets or get the algorithm for encoding the alpha plane.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><see cref="AlphaCompression"/>.</returns>
        public AlphaCompression AlphaCompression
        {
            get
            {
                this.ThrowIfDisposed();
                return (AlphaCompression)NativeMethods.webp_WebPConfig_get_alpha_compression(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_alpha_compression(this.NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Sets or get the predictive filtering method for alpha plane.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><see cref="AlphaFiltering"/>.</returns>
        public AlphaFiltering AlphaFiltering
        {
            get
            {
                this.ThrowIfDisposed();
                return (AlphaFiltering)NativeMethods.webp_WebPConfig_get_alpha_filtering(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_alpha_filtering(this.NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Sets or get the value for alpha compression between 0 and 100.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value for alpha compression between 0 and 100.</returns>
        public int AlphaQuality
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_alpha_quality(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_alpha_quality(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether using auto adjust filter's strength.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using auto adjust filter's strength; otherwise, <code>false</code>.</returns>
        public bool AutoFilter
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_autofilter(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_autofilter(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether compression parameters will be remapped to better match the expected output size from JPEG compression.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if compression parameters will be remapped to better match the expected output size from JPEG compression; otherwise, <code>false</code>.</returns>
        public bool EmulateJpegSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_emulate_jpeg_size(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_emulate_jpeg_size(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether preserve the exact RGB values under transparent area.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if preserve the exact RGB values under transparent area, <code>false</code>.</returns>
        public bool Exact
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_exact(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_exact(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value for sharpness filter between 0 and 7.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 7.</exception>
        /// <returns>The value for sharpness filter.</returns>
        public int FilterSharpness
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_filter_sharpness(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 7))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 7.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_filter_sharpness(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value for strength of filter between 0 and 100.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The strength of filter.</returns>
        public int FilterStrength
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_filter_strength(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_filter_strength(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value for filter type.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><see cref="FilterType"/>.</returns>
        public FilterType FilterType
        {
            get
            {
                this.ThrowIfDisposed();
                return (FilterType)NativeMethods.webp_WebPConfig_get_filter_type(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_filter_type(this.NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Sets or get the value of hint for image type.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><see cref="WebPImageHint"/>.</returns>
        public WebPImageHint ImageHint
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_image_hint(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_image_hint(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether using lossless encoding.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using lossless encoding, <code>false</code>.</returns>
        public bool Lossless
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_lossless(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_lossless(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether reduce memory usage (but increase CPU use).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if reduce memory usage, <code>false</code>.</returns>
        public bool LowMemory
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_low_memory(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_low_memory(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value for quality/speed trade-off between 0 and 6. 0 is fast and 6 is slower-better.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 6.</exception>
        /// <returns>The value for quality/speed trade-off.</returns>
        public int Method
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_method(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 6))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 6.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_method(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value of near lossless encoding between 0 (max-loss) and 100 (off).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value of near lossless encoding between 0 (max-loss) and 100 (off).</returns>
        public int NearLossless
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_near_lossless(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_near_lossless(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value of quality degradation allowed to fit the 512k limit on prediction modes coding (0: no degradation, 100: maximum possible degradation).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value of quality degradation allowed to fit the 512k limit on prediction modes coding.</returns>
        public int PartitionLimit
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_partition_limit(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_partition_limit(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the log2 (number of token partitions) in from 0 to 3.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 3.</exception>
        /// <returns>The log2 (number of token partitions) in from 0 to 3. Default is set to 0 for easier progressive decoding.</returns>
        public int Partitions
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_partitions(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 3))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 3.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_partitions(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of entropy-analysis passes between 1 to 10.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 1 to 10.</exception>
        /// <returns>The number of entropy-analysis passes between 1 to 10.</returns>
        public int Pass
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_pass(this.NativePtr);
            }
            set
            {
                if (!(1 <= value && value <= 10))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 1 to 10.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_pass(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value of preprocessing filter.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><see cref="PreprocessingFilter"/>.</returns>
        public PreprocessingFilter Preprocessing
        {
            get
            {
                this.ThrowIfDisposed();
                return (PreprocessingFilter)NativeMethods.webp_WebPConfig_get_preprocessing(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_preprocessing(this.NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Sets or get the value of maximum permissible quality factor.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value of maximum permissible quality factor.</returns>
        public int QMax
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_qmax(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_qmax(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value of minimum permissible quality factor.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be greater than or equal to zero.</exception>
        /// <returns>The value of minimum permissible quality factor.</returns>
        public int QMin
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_qmin(this.NativePtr);
            }
            set
            {
                if (!(value >= 0))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be greater than or equal to zero.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_qmin(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value of quality.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value of quality. For lossy, 0 gives the smallest size and 100 the largest. For lossless, this parameter is the amount of effort put into the compression: 0 is the fastest but gives larger files compared to the slowest, but best, 100.</returns>
        public float Quality
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_quality(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_quality(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the maximum number of segments to use, from 1 to 4.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 1 to 4.</exception>
        /// <returns>The maximum number of segments to use, from 1 to 4.</returns>
        public int Segments
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_segments(this.NativePtr);
            }
            set
            {
                if (!(1 <= value && value <= 4))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 1 to 4.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_segments(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether exports compressed picture back.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if exports compressed picture back, <code>false</code>.</returns>
        public bool ShowCompressed
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_show_compressed(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_show_compressed(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value of Spatial Noise Shaping between 0 and 100.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be from 0 to 100.</exception>
        /// <returns>The value of Spatial Noise Shaping.</returns>
        public int SpatialNoiseShapingStrength
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_sns_strength(this.NativePtr);
            }
            set
            {
                if (!(0 <= value && value <= 100))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be from 0 to 100.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_sns_strength(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value to try to achieve minimal distortion.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be greater than or equal to zero.</exception>
        /// <returns>The value to try to achieve minimal distortion.</returns>
        public float TargetPSNR
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_target_PSNR(this.NativePtr);
            }
            set
            {
                if (!(value >= 0))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be greater than or equal to zero.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_target_PSNR(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the target size, in bytes, to try and reach for the compressed output.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> must be greater than or equal to zero.</exception>
        /// <returns>The target size, in bytes, to try and reach for the compressed output.</returns>
        public int TargetSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_target_size(this.NativePtr);
            }
            set
            {
                if (!(value >= 0))
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} must be greater than or equal to zero.");

                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_target_size(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether use multi-threaded encoding.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using multi-threaded encoding; otherwise, <code>false</code>.</returns>
        public bool ThreadLevel
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_thread_level(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_thread_level(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value for reserved for future lossless feature.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using reserved for future lossless feature; otherwise, <code>false</code>.</returns>
        public bool UseDeltaPalette
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_use_delta_palette(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_use_delta_palette(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the value indicating whether using sharp (and slow) RGB->YUV conversion.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <returns><code>true</code> if using sharp (and slow) RGB->YUV conversion; otherwise, <code>false</code>.</returns>
        public bool UseSharpYUV
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.webp_WebPConfig_get_use_sharp_yuv(this.NativePtr) != 0;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.webp_WebPConfig_set_use_sharp_yuv(this.NativePtr, value ? 1 : 0);
            }
        }

        #endregion

        #region Overrides 

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.webp_WebPConfig_delete(this.NativePtr);
        }

        #endregion

    }

}