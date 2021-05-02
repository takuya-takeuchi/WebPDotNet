#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#include <webp/encode.h>
#include <webp/decode.h>

#include <cstdint>
#include <string>
#include <string.h>
#include <vector>

#define ERR_OK                                                            0x00000000

// General
#define ERR_GENERAL_ERROR                                                 0x76000000
#define ERR_GENERAL_FILE_IO                         -(ERR_GENERAL_ERROR | 0x00000001)
#define ERR_GENERAL_OUT_OF_RANGE                    -(ERR_GENERAL_ERROR | 0x00000002)
#define ERR_GENERAL_MEMALLOC                        -(ERR_GENERAL_ERROR | 0x00000003)

// Image
#define ERR_IMAGE_ERROR                                                   0x77000000
#define ERR_IMAGE_FILE_INVALID                        -(ERR_IMAGE_ERROR | 0x00000001)
#define ERR_IMAGE_FILE_WRONG_EXTENSION                -(ERR_IMAGE_ERROR | 0x00000002)

#pragma region templates

template<typename TYPE, std::size_t SIZE>
std::size_t array_length(const TYPE (&)[SIZE])
{   
    return SIZE;
}

#pragma endregion templates

#endif