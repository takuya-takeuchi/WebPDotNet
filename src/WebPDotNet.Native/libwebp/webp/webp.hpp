#ifndef _CPP_WEBP_H_
#define _CPP_WEBP_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT void webp_WebPFree(void* ptr)
{
    return ::WebPFree(ptr);
}

#endif // _CPP_WEBP_H_