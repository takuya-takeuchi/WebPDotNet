namespace WebPDotNet
{

    /// <summary>
    /// Specifies the preprocessing filter.
    /// </summary>
    public enum PreprocessingFilter
    {

        /// <summary>
        /// Specifies that the preprocessing filter is not used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the segment-smooth is used.
        /// </summary>
        SegmentSmooth = 1,

        /// <summary>
        /// Specifies that the pseudo-random dithering is used.
        /// </summary>
        PseudoRandomDithering = 2

    }

}