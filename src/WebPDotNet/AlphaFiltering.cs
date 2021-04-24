namespace WebPDotNet
{

    /// <summary>
    /// Specifies the predictive filtering method for alpha plane.
    /// </summary>
    public enum AlphaFiltering
    {

        /// <summary>
        /// Specifies that the predictive filtering method is not used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the fast method is used.
        /// </summary>
        Fast = 1,

        /// <summary>
        /// Specifies that the best method is used.
        /// </summary>
        Best = 2

    }

}