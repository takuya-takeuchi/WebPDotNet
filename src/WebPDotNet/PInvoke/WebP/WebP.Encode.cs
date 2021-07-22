using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int64_t = System.Int64;
using size_t = System.Int64;

// ReSharper disable once CheckNamespace
namespace WebPDotNet
{

    internal sealed partial class NativeMethods
    {

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPGetEncoderVersion();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeRGB(IntPtr rgb,
                                                       int32_t width,
                                                       int32_t height,
                                                       int32_t stride,
                                                       float quality_factor,
                                                       out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeBGR(IntPtr bgr,
                                                       int32_t width,
                                                       int32_t height,
                                                       int32_t stride,
                                                       float quality_factor,
                                                       out IntPtr output);


        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeRGBA(IntPtr rgba,
                                                        int32_t width,
                                                        int32_t height,
                                                        int32_t stride,
                                                        float quality_factor,
                                                        out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeBGRA(IntPtr bgra,
                                                        int32_t width,
                                                        int32_t height,
                                                        int32_t stride,
                                                        float quality_factor,
                                                        out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeLosslessRGB(IntPtr rgb,
                                                               int32_t width,
                                                               int32_t height,
                                                               int32_t stride,
                                                               out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeLosslessBGR(IntPtr bgr,
                                                               int32_t width,
                                                               int32_t height,
                                                               int32_t stride,
                                                               out IntPtr output);


        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeLosslessRGBA(IntPtr rgba,
                                                                int32_t width,
                                                                int32_t height,
                                                                int32_t stride,
                                                                out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPEncodeLosslessBGRA(IntPtr bgra,
                                                                int32_t width,
                                                                int32_t height,
                                                                int32_t stride,
                                                                out IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPConfigPreset(IntPtr config,
                                                        WebPPreset preset,
                                                        float quality);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPConfigLosslessPreset(IntPtr config, int32_t level);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPValidateConfig(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPPictureInit(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPPictureAlloc(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPictureFree(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriterInit(IntPtr writer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriterClear(IntPtr writer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPMemoryWrite(IntPtr data,
                                                          size_t data_size,
                                                          IntPtr picture);

        #region WebPConfig

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPConfig_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_delete(IntPtr config);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_lossless(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_lossless(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float webp_WebPConfig_get_quality(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_quality(IntPtr config, float value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_method(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_method(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern WebPImageHint webp_WebPConfig_get_image_hint(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_image_hint(IntPtr config, WebPImageHint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_target_size(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_target_size(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float webp_WebPConfig_get_target_PSNR(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_target_PSNR(IntPtr config, float value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_segments(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_segments(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_sns_strength(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_sns_strength(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_filter_strength(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_filter_strength(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_filter_sharpness(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_filter_sharpness(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_filter_type(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_filter_type(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_autofilter(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_autofilter(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_alpha_compression(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_alpha_compression(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_alpha_filtering(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_alpha_filtering(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_alpha_quality(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_alpha_quality(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_pass(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_pass(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_show_compressed(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_show_compressed(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_preprocessing(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_preprocessing(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_partitions(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_partitions(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_partition_limit(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_partition_limit(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_emulate_jpeg_size(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_emulate_jpeg_size(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_thread_level(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_thread_level(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_low_memory(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_low_memory(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_near_lossless(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_near_lossless(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_exact(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_exact(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_use_delta_palette(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_use_delta_palette(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_use_sharp_yuv(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_use_sharp_yuv(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_qmin(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_qmin(IntPtr config, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPConfig_get_qmax(IntPtr config);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPConfig_set_qmax(IntPtr config, int32_t value);

        #endregion 

        #region WebPPicture

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPPicture_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_delete(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPPicture_get_use_argb(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_set_use_argb(IntPtr picture, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPPicture_get_width(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_set_width(IntPtr picture, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int32_t webp_WebPPicture_get_height(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_set_height(IntPtr picture, int32_t value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPPicture_get_custom_ptr(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_set_custom_ptr(IntPtr picture, IntPtr value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPPicture_get_writer(IntPtr picture);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPPicture_set_writer(IntPtr picture, IntPtr value);

        #endregion

        #region WebPMemoryWriter

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPMemoryWriter_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriter_delete(IntPtr writer);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPMemoryWriter_get_mem(IntPtr writer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriter_set_mem(IntPtr writer, IntPtr value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPMemoryWriter_get_size(IntPtr writer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriter_set_size(IntPtr writer, size_t value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern size_t webp_WebPMemoryWriter_get_max_size(IntPtr writer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void webp_WebPMemoryWriter_set_max_size(IntPtr writer, size_t value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType webp_WebPMemoryWriter_get_pad(IntPtr writer,
                                                                     out IntPtr ret,
                                                                     out uint32_t ret_len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType webp_WebPMemoryWriter_set_pad(IntPtr writer,
                                                                     uint32_t[] value,
                                                                     int32_t value_len);

        #endregion

        #endregion

    }

}