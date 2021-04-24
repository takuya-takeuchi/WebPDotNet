namespace WebPDotNet
{

    /// <summary>
    /// Specifies the predefined settings for <see cref="WebPConfig"/>, depending on the type of source picture.
    /// </summary>
    public enum WebPPreset
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
        /// Specifies that the preset for hand or line drawing, with high-contrast details.
        /// </summary>
        Drawing,

        /// <summary>
        /// Specifies that the preset for small-sized colorful images.
        /// </summary>
        Icon,

        /// <summary>
        /// Specifies that the preset for text-like.
        /// </summary>
        Text

    }

}