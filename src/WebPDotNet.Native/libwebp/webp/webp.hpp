#ifndef _CPP_WEBP_H_
#define _CPP_WEBP_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT int32_t webp_WEBP_MAX_DIMENSION()
{
    return WEBP_MAX_DIMENSION;
}

DLLEXPORT void webp_WebPFree(void* ptr)
{
    return ::WebPFree(ptr);
}

#endif // _CPP_WEBP_H_