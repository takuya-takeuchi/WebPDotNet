namespace WebPDotNet
{

    /// <summary>
    /// Specifies the algorithm for encoding the alpha plane.
    /// </summary>
    public enum AlphaCompression
    {

        /// <summary>
        /// Specifies that the alpha plane is not compressed.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the alpha plane is compressed with WebP lossless.
        /// </summary>
        CompressedWithWebP = 1

    }

}