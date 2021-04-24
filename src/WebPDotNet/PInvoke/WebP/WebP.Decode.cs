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
        public static extern int32_t webp_WebPGetDecoderVersion();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeRGBA(IntPtr data,
                                                        size_t data_size,
                                                        out int32_t width,
                                                        out int32_t height);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeARGB(IntPtr data,
                                                        size_t data_size,
                                                        out int32_t width,
                                                        out int32_t height);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeBGRA(IntPtr data,
                                                        size_t data_size,
                                                        out int32_t width,
                                                        out int32_t height);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeRGB(IntPtr data,
                                                       size_t data_size,
                                                       out int32_t width,
                                                       out int32_t height);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeBGR(IntPtr data,
                                                       size_t data_size,
                                                       out int32_t width,
                                                       out int32_t height);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeRGBInto(IntPtr data,
                                                           size_t data_size,
                                                           IntPtr output,
                                                           int64_t size,
                                                           int32_t stride);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeARGBInto(IntPtr data,
                                                            size_t data_size,
                                                            IntPtr output,
                                                            int64_t size,
                                                            int32_t stride);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeRGBAInto(IntPtr data,
                                                            size_t data_size,
                                                            IntPtr output,
                                                            int64_t size,
                                                            int32_t stride);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeBGRInto(IntPtr data,
                                                           size_t data_size,
                                                           IntPtr output,
                                                           int64_t size,
                                                           int32_t stride);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr webp_WebPDecodeBGRAInto(IntPtr data,
                                                            size_t data_size,
                                                            IntPtr output,
                                                            int64_t width,
                                                            int32_t stride);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool webp_WebPGetInfo(IntPtr data,
                                                   size_t data_size,
                                                   out int32_t width,
                                                   out int32_t height);

        #endregion

    }

}