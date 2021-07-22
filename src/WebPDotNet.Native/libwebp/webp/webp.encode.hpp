#ifndef _CPP_WEBP_ENCODE_H_
#define _CPP_WEBP_ENCODE_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT const int32_t webp_WebPGetEncoderVersion()
{
    return WebPGetEncoderVersion();
}

DLLEXPORT const size_t webp_WebPEncodeRGB(const uint8_t* rgb,
                                          const int32_t width,
                                          const int32_t height,
                                          const int32_t stride,
                                          const float quality_factor,
                                          uint8_t** output)
{
    return WebPEncodeRGB(rgb, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeBGR(const uint8_t* bgr,
                                          const int32_t width,
                                          const int32_t height,
                                          const int32_t stride,
                                          const float quality_factor,
                                          uint8_t** output)
{
    return WebPEncodeBGR(bgr, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeRGBA(const uint8_t* rgba,
                                           const int32_t width,
                                           const int32_t height,
                                           const int32_t stride,
                                           const float quality_factor,
                                           uint8_t** output)
{
    return WebPEncodeRGBA(rgba, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeBGRA(const uint8_t* bgra,
                                           const int32_t width,
                                           const int32_t height,
                                           const int32_t stride,
                                           const float quality_factor,
                                           uint8_t** output)
{
    return WebPEncodeBGRA(bgra, width, height, stride, quality_factor, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessRGB(const uint8_t* rgb,
                                                  const int32_t width,
                                                  const int32_t height,
                                                  const int32_t stride,
                                                  uint8_t** output)
{
    return WebPEncodeLosslessRGB(rgb, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessBGR(const uint8_t* bgr,
                                                  const int32_t width,
                                                  const int32_t height,
                                                  const int32_t stride,
                                                  uint8_t** output)
{
    return WebPEncodeLosslessBGR(bgr, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessRGBA(const uint8_t* rgba,
                                                   const int32_t width,
                                                   const int32_t height,
                                                   const int32_t stride,
                                                   uint8_t** output)
{
    return WebPEncodeLosslessRGBA(rgba, width, height, stride, output);
}

DLLEXPORT const size_t webp_WebPEncodeLosslessBGRA(const uint8_t* bgra,
                                                   const int32_t width,
                                                   const int32_t height,
                                                   const int32_t stride,
                                                   uint8_t** output)
{
    return WebPEncodeLosslessBGRA(bgra, width, height, stride, output);
}

DLLEXPORT const bool webp_WebPConfigPreset(WebPConfig* config,
                                           const WebPPreset preset,
                                           const float quality)
{
    return WebPConfigPreset(config, preset, quality) != 0;
}

DLLEXPORT const bool webp_WebPConfigLosslessPreset(WebPConfig* config,
                                                   const int level)
{
    return WebPConfigLosslessPreset(config, level) != 0;
}

DLLEXPORT const bool webp_WebPValidateConfig(WebPConfig* config)
{
    return WebPValidateConfig(config);
}

DLLEXPORT const bool webp_WebPPictureInit(WebPPicture* picture)
{
    return WebPPictureInit(picture) != 0;
}

DLLEXPORT const bool webp_WebPPictureAlloc(WebPPicture* picture)
{
    return WebPPictureAlloc(picture) != 0;
}

DLLEXPORT void webp_WebPPictureFree(WebPPicture* picture)
{
    WebPPictureFree(picture);
}

DLLEXPORT void webp_WebPMemoryWriterInit(WebPMemoryWriter* writer)
{
    WebPMemoryWriterInit(writer);
}

DLLEXPORT void webp_WebPMemoryWriterClear(WebPMemoryWriter* writer)
{
    WebPMemoryWriterClear(writer);
}

DLLEXPORT int32_t webp_WebPMemoryWrite(const uint8_t* data,
                                       size_t data_size,
                                       const WebPPicture* picture)
{
    return WebPMemoryWrite(data, data_size, picture);
}

#pragma region WebPConfig functions

DLLEXPORT const int32_t webp_WebPConfig_get_lossless(WebPConfig* config)
{
    return config->lossless;
}

DLLEXPORT void webp_WebPConfig_set_lossless(WebPConfig* config, const int32_t value)
{
    config->lossless = value;
}

DLLEXPORT const float webp_WebPConfig_get_quality(WebPConfig* config)
{
    return config->quality;
}

DLLEXPORT void webp_WebPConfig_set_quality(WebPConfig* config, const float value)
{
    config->quality = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_method(WebPConfig* config)
{
    return config->method;
}

DLLEXPORT void webp_WebPConfig_set_method(WebPConfig* config, const int32_t value)
{
    config->method = value;
}

DLLEXPORT const WebPImageHint webp_WebPConfig_get_image_hint(WebPConfig* config)
{
    return config->image_hint;
}

DLLEXPORT void webp_WebPConfig_set_image_hint(WebPConfig* config, const WebPImageHint value)
{
    config->image_hint = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_target_size(WebPConfig* config)
{
    return config->target_size;
}

DLLEXPORT void webp_WebPConfig_set_target_size(WebPConfig* config, const int32_t value)
{
    config->target_size = value;
}

DLLEXPORT const float webp_WebPConfig_get_target_PSNR(WebPConfig* config)
{
    return config->target_PSNR;
}

DLLEXPORT void webp_WebPConfig_set_target_PSNR(WebPConfig* config, const float value)
{
    config->target_PSNR = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_segments(WebPConfig* config)
{
    return config->segments;
}

DLLEXPORT void webp_WebPConfig_set_segments(WebPConfig* config, const int32_t value)
{
    config->segments = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_sns_strength(WebPConfig* config)
{
    return config->sns_strength;
}

DLLEXPORT void webp_WebPConfig_set_sns_strength(WebPConfig* config, const int32_t value)
{
    config->sns_strength = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_filter_strength(WebPConfig* config)
{
    return config->filter_strength;
}

DLLEXPORT void webp_WebPConfig_set_filter_strength(WebPConfig* config, const int32_t value)
{
    config->filter_strength = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_filter_sharpness(WebPConfig* config)
{
    return config->filter_sharpness;
}

DLLEXPORT void webp_WebPConfig_set_filter_sharpness(WebPConfig* config, const int32_t value)
{
    config->filter_sharpness = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_filter_type(WebPConfig* config)
{
    return config->filter_type;
}

DLLEXPORT void webp_WebPConfig_set_filter_type(WebPConfig* config, const int32_t value)
{
    config->filter_type = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_autofilter(WebPConfig* config)
{
    return config->autofilter;
}

DLLEXPORT void webp_WebPConfig_set_autofilter(WebPConfig* config, const int32_t value)
{
    config->autofilter = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_alpha_compression(WebPConfig* config)
{
    return config->alpha_compression;
}

DLLEXPORT void webp_WebPConfig_set_alpha_compression(WebPConfig* config, const int32_t value)
{
    config->alpha_compression = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_alpha_filtering(WebPConfig* config)
{
    return config->alpha_filtering;
}

DLLEXPORT void webp_WebPConfig_set_alpha_filtering(WebPConfig* config, const int32_t value)
{
    config->alpha_filtering = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_alpha_quality(WebPConfig* config)
{
    return config->alpha_quality;
}

DLLEXPORT void webp_WebPConfig_set_alpha_quality(WebPConfig* config, const int32_t value)
{
    config->alpha_quality = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_pass(WebPConfig* config)
{
    return config->pass;
}

DLLEXPORT void webp_WebPConfig_set_pass(WebPConfig* config, const int32_t value)
{
    config->pass = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_show_compressed(WebPConfig* config)
{
    return config->show_compressed;
}

DLLEXPORT void webp_WebPConfig_set_show_compressed(WebPConfig* config, const int32_t value)
{
    config->show_compressed = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_preprocessing(WebPConfig* config)
{
    return config->preprocessing;
}

DLLEXPORT void webp_WebPConfig_set_preprocessing(WebPConfig* config, const int32_t value)
{
    config->preprocessing = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_partitions(WebPConfig* config)
{
    return config->partitions;
}

DLLEXPORT void webp_WebPConfig_set_partitions(WebPConfig* config, const int32_t value)
{
    config->partitions = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_partition_limit(WebPConfig* config)
{
    return config->partition_limit;
}

DLLEXPORT void webp_WebPConfig_set_partition_limit(WebPConfig* config, const int32_t value)
{
    config->partition_limit = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_emulate_jpeg_size(WebPConfig* config)
{
    return config->emulate_jpeg_size;
}

DLLEXPORT void webp_WebPConfig_set_emulate_jpeg_size(WebPConfig* config, const int32_t value)
{
    config->emulate_jpeg_size = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_thread_level(WebPConfig* config)
{
    return config->thread_level;
}

DLLEXPORT void webp_WebPConfig_set_thread_level(WebPConfig* config, const int32_t value)
{
    config->thread_level = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_low_memory(WebPConfig* config)
{
    return config->low_memory;
}

DLLEXPORT void webp_WebPConfig_set_low_memory(WebPConfig* config, const int32_t value)
{
    config->low_memory = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_near_lossless(WebPConfig* config)
{
    return config->near_lossless;
}

DLLEXPORT void webp_WebPConfig_set_near_lossless(WebPConfig* config, const int32_t value)
{
    config->near_lossless = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_exact(WebPConfig* config)
{
    return config->exact;
}

DLLEXPORT void webp_WebPConfig_set_exact(WebPConfig* config, const int32_t value)
{
    config->exact = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_use_delta_palette(WebPConfig* config)
{
    return config->use_delta_palette;
}

DLLEXPORT void webp_WebPConfig_set_use_delta_palette(WebPConfig* config, const int32_t value)
{
    config->use_delta_palette = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_use_sharp_yuv(WebPConfig* config)
{
    return config->use_sharp_yuv;
}

DLLEXPORT void webp_WebPConfig_set_use_sharp_yuv(WebPConfig* config, const int32_t value)
{
    config->use_sharp_yuv = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_qmin(WebPConfig* config)
{
    return config->qmin;
}

DLLEXPORT void webp_WebPConfig_set_qmin(WebPConfig* config, const int32_t value)
{
    config->qmin = value;
}

DLLEXPORT const int32_t webp_WebPConfig_get_qmax(WebPConfig* config)
{
    return config->qmax;
}

DLLEXPORT void webp_WebPConfig_set_qmax(WebPConfig* config, const int32_t value)
{
    config->qmax = value;
}

#pragma endregion WebPConfig functions

#pragma region WebPPicture functions

DLLEXPORT const int32_t webp_WebPPicture_get_use_argb(WebPPicture* picture)
{
    return picture->use_argb;
}

DLLEXPORT void webp_WebPPicture_set_use_argb(WebPPicture* picture, const int32_t value)
{
    picture->use_argb = value;
}

DLLEXPORT const int32_t webp_WebPPicture_get_width(WebPPicture* picture)
{
    return picture->width;
}

DLLEXPORT void webp_WebPPicture_set_width(WebPPicture* picture, const int32_t value)
{
    picture->width = value;
}

DLLEXPORT const int32_t webp_WebPPicture_get_height(WebPPicture* picture)
{
    return picture->height;
}

DLLEXPORT void webp_WebPPicture_set_height(WebPPicture* picture, const int32_t value)
{
    picture->height = value;
}

DLLEXPORT const void* webp_WebPPicture_get_custom_ptr(WebPPicture* picture)
{
    return picture->custom_ptr;
}

DLLEXPORT void webp_WebPPicture_set_custom_ptr(WebPPicture* picture, void* const value)
{
    picture->custom_ptr = value;
}

DLLEXPORT const WebPWriterFunction webp_WebPPicture_get_writer(WebPPicture* picture)
{
    return picture->writer;
}

DLLEXPORT void webp_WebPPicture_set_writer(WebPPicture* picture, const WebPWriterFunction value)
{
    picture->writer = value;
}

#pragma endregion WebPPicture functions

#pragma region WebPMemoryWriter functions

DLLEXPORT const uint8_t* webp_WebPMemoryWriter_get_mem(WebPMemoryWriter* writer)
{
    return writer->mem;
}

DLLEXPORT void webp_WebPMemoryWriter_set_mem(WebPMemoryWriter* writer, uint8_t* const value)
{
    writer->mem = value;
}

DLLEXPORT const size_t webp_WebPMemoryWriter_get_size(WebPMemoryWriter* writer)
{
    return writer->size;
}

DLLEXPORT void webp_WebPMemoryWriter_set_size(WebPMemoryWriter* writer, const size_t value)
{
    writer->size = value;
}

DLLEXPORT const size_t webp_WebPMemoryWriter_get_max_size(WebPMemoryWriter* writer)
{
    return writer->max_size;
}

DLLEXPORT void webp_WebPMemoryWriter_set_max_size(WebPMemoryWriter* writer, const size_t value)
{
    writer->max_size = value;
}

DLLEXPORT const int32_t webp_WebPMemoryWriter_get_pad(WebPMemoryWriter* writer,
                                                      uint32_t** ret,
                                                      uint32_t* ret_len)
{
    const size_t len = array_length(writer->pad);
    uint32_t* mem = (uint32_t*)malloc(sizeof(uint32_t) * len);
    if (!mem) return ERR_GENERAL_MEMALLOC;
    memcpy(mem, &(writer->pad[0]), sizeof(uint32_t) * len);
    *ret = mem;
    return ERR_OK;
}

DLLEXPORT int32_t webp_WebPMemoryWriter_set_pad(WebPMemoryWriter* writer,
                                               const uint32_t* value,
                                               const int32_t value_len)
{
    const size_t len = array_length(writer->pad);
    if (!(0 <= len && len < value_len)) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(&(writer->pad[0]), value, sizeof(uint32_t) * value_len);
    return ERR_OK;
}

#pragma endregion WebPMemoryWriter functions

#pragma region non-libwebp functions

DLLEXPORT const WebPConfig* webp_WebPConfig_new()
{
    return new WebPConfig();
}

DLLEXPORT void webp_WebPConfig_delete(WebPConfig* config)
{
    delete config;
}

DLLEXPORT const WebPPicture* webp_WebPPicture_new()
{
    return new WebPPicture();
}

DLLEXPORT void webp_WebPPicture_delete(WebPPicture* picture)
{
    delete picture;
}

DLLEXPORT const WebPMemoryWriter* webp_WebPMemoryWriter_new()
{
    return new WebPMemoryWriter();
}

DLLEXPORT void webp_WebPMemoryWriter_delete(WebPMemoryWriter* config)
{
    delete config;
}

#pragma endregion non-libwebp functions

#endif // _CPP_WEBP_ENCODE_H_