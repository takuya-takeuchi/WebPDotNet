using System;

namespace WebPDotNet
{

    /// <summary>
    /// Provides the methods of libwebp.
    /// </summary>
    public static partial class WebP
    {

        #region Fields

        /// <summary>
        /// A read-only field that represents a value of maximum width/height allowed (inclusive), in pixels for WebP format.
        /// </summary>
        public static int WebPMaxDimension;

        #endregion

        #region Constructors

        static WebP()
        {
            WebPMaxDimension = NativeMethods.webp_WEBP_MAX_DIMENSION();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the string representation of the version of wrapper library of libwebp.
        /// </summary>
        /// <returns>A <see cref="String"/> represents version number of wrapper library of libwebp.</returns>
        public static string GetNativeVersion()
        {
            return StringHelper.FromStdString(NativeMethods.get_version(), true);
        }

        #endregion

    }

}