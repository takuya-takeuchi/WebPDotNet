using System;
using System.Text;

namespace WebPDotNet
{

    /// <summary>
    /// Provides the methods of libwebp.
    /// </summary>
    public static partial class WebP
    {

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