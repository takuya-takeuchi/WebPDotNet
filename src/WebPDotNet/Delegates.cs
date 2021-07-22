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

namespace WebPDotNet
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int WebPWriterFunction(IntPtr data, size_t dataSize, WebPPicture picture);

}
