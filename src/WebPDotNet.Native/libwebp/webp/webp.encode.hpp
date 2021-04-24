#ifndef _CPP_WEBP_ENCODE_H_
#define _CPP_WEBP_ENCODE_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT const int32_t webp_WebPGetEncoderVersion()
{
    return ::WebPGetEncoderVersion();
}

DLLEXPORT const size_t webp_WebPEncodeRGB(const uint8_t* rgb,
                                          const int32_t width,
                                          const int32_t height,
                                          const int32_t stride,
                                          const float quality_factor,
                                          uint8_t** output)
{
    return ::WebPEncodeRGB(rgb, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeBGR(const uint8_t* bgr,
                                          const int32_t width,
                                          const int32_t height,
                                          const int32_t stride,
                                          const float quality_factor,
                                          uint8_t** output)
{
    return ::WebPEncodeBGR(bgr, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeRGBA(const uint8_t* rgba,
                                           const int32_t width,
                                           const int32_t height,
                                           const int32_t stride,
                                           const float quality_factor,
                                           uint8_t** output)
{
    return ::WebPEncodeRGBA(rgba, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeBGRA(const uint8_t* bgra,
                                           const int32_t width,
                                           const int32_t height,
                                           const int32_t stride,
                                           const float quality_factor,
                                           uint8_t** output)
{
    return ::WebPEncodeBGRA(bgra, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessRGB(const uint8_t* rgb,
                                                  const int32_t width,
                                                  const int32_t height,
                                                  const int32_t stride,
                                                  uint8_t** output)
{
    return ::WebPEncodeLosslessRGB(rgb, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessBGR(const uint8_t* bgr,
                                                  const int32_t width,
                                                  const int32_t height,
                                                  const int32_t stride,
                                                  uint8_t** output)
{
    return ::WebPEncodeLosslessBGR(bgr, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessRGBA(const uint8_t* rgba,
                                                   const int32_t width,
                                                   const int32_t height,
                                                   const int32_t stride,
                                                   uint8_t** output)
{
    return ::WebPEncodeLosslessRGBA(rgba, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessBGRA(const uint8_t* bgra,
                                                   const int32_t width,
                                                   const int32_t height,
                                                   const int32_t stride,
                                                   uint8_t** output)
{
    return ::WebPEncodeLosslessBGRA(bgra, width, height, stride, output);
}

#endif // _CPP_WEBP_ENCODE_H_