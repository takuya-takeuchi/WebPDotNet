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

        #endregion

    }

}