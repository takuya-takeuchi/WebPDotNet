namespace WebPDotNet
{
    
    /// <summary>
    /// Specifies the Colorspaces.
    /// </summary>
    public enum CspMode
    {

        /// <summary>
        /// Specifies that the format is 24 bits per pixel; 8 bits each are used for the red, green, and blue components.
        /// </summary>
        RGB = 0,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the red, green, blue, and alpha components.
        /// </summary>
        RGBA = 1,

        /// <summary>
        /// Specifies that the format is 24 bits per pixel; 8 bits each are used for the blue, green, and red components.
        /// </summary>
        BGR = 2,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the blue, green, red, and alpha components.
        /// </summary>
        BGRA = 3,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the alpha, red, green, and blue components.
        /// </summary>
        ARGB = 4,

        /// <summary>
        /// Specifies that the format is 16 bits per pixel; 4 bits each are used for the red, green, blue, and alpha components.
        /// </summary>
        RGBA4444 = 5,

        /// <summary>
        /// Specifies that the format is 16 bits per pixel; 5 bits are used for the red component, 6 bits are used for the green component, and 5 bits are used for the blue component.
        /// </summary>
        RGB565 = 6,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the red, green, blue, and alpha components. The red, green, and blue components are premultiplied, according to the alpha component.
        /// </summary>
        PRGBA = 7,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the blue, green, red, and alpha components. The blue, green, and red components are premultiplied, according to the alpha component.
        /// </summary>
        PBGRA = 8,

        /// <summary>
        /// Specifies that the format is 32 bits per pixel; 8 bits each are used for the alpha, red, green, and blue components. The red, green, and blue components are premultiplied, according to the alpha component.
        /// </summary>
        PARGB = 9,

        /// <summary>
        /// Specifies that the format is 16 bits per pixel; 4 bits each are used for the red, green, blue, and alpha components. The red, green, and blue components are premultiplied, according to the alpha component.
        /// </summary>
        PRGBA4444 = 10,

        /// <summary>
        /// Specifies that the format is YUV, without transparency.
        /// </summary>
        YUV = 11,

        /// <summary>
        /// Specifies that the format is YUVA, without transparency.
        /// </summary>
        YUVA = 12,

        /// <summary>
        /// Specifies that the format is not specified.
        /// </summary>
        Last = 13

    }

}