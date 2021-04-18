#ifndef _CPP_WEBP_DECODE_H_
#define _CPP_WEBP_DECODE_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT const int32_t webp_WebPGetDecoderVersion()
{
    return ::WebPGetDecoderVersion();
}

DLLEXPORT const uint8_t* webp_WebPDecodeRGBA(const uint8_t* data,
                                             const size_t data_size,
                                             int32_t* width,
                                             int32_t* height)
{
    return ::WebPDecodeRGBA(data, data_size, width, height);
}

DLLEXPORT const uint8_t* webp_WebPDecodeARGB(const uint8_t* data,
                                             const size_t data_size,
                                             int32_t* width,
                                             int32_t* height)
{
    return ::WebPDecodeARGB(data, data_size, width, height);
}

DLLEXPORT const uint8_t* webp_WebPDecodeBGRA(const uint8_t* data,
                                             const size_t data_size,
                                             int32_t* width,
                                             int32_t* height)
{
    return ::WebPDecodeBGRA(data, data_size, width, height);
}

DLLEXPORT const uint8_t* webp_WebPDecodeRGB(const uint8_t* data,
                                            const size_t data_size,
                                            int32_t* width,
                                            int32_t* height)
{
    return ::WebPDecodeRGB(data, data_size, width, height);
}

DLLEXPORT const uint8_t* webp_WebPDecodeBGR(const uint8_t* data,
                                            const size_t data_size,
                                            int32_t* width,
                                            int32_t* height)
{
    return ::WebPDecodeBGR(data, data_size, width, height);
}

#endif // _CPP_WEBP_DECODE_H_