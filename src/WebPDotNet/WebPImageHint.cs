namespace WebPDotNet
{
    
    /// <summary>
    /// Specifies the image characteristics hint for the underlying encoder.
    /// </summary>
    public enum WebPImageHint
    {

        /// <summary>
        /// Specifies that the default preset.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Specifies that the preset for digital picture, like portrait, inner shot.
        /// </summary>
        Picture,

        /// <summary>
        /// Specifies that the preset for outdoor photograph, with natural lighting.
        /// </summary>
        Photo,

        /// <summary>
        /// Specifies that the preset for discrete tone image (graph, map-tile etc).
        /// </summary>
        Graph,

        /// <summary>
        /// Specifies that the preset is not specified.
        /// </summary>
        Last

    }

}