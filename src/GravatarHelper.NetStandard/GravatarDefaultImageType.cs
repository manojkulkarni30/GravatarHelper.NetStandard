namespace GravatarHelper.NetStandard
{
    /// <summary>
    /// Gravatar Default Image Types
    /// </summary>
    public enum GravatarDefaultImageType
    {
        /// <summary>
        /// Do not load any image if none is associated with the email hash, instead return an HTTP 404 (File Not Found) response
        /// </summary>
        Image404,

        /// <summary>
        /// mm: (mystery-man) a simple, cartoon-style silhouetted outline of a person (does not vary by email hash)
        /// </summary>
        MM,

        /// <summary>
        /// A geometric pattern based on an email hash
        /// </summary>
        Identicon,

        /// <summary>
        /// A generated 'monster' with different colors, faces, etc
        /// </summary>
        MonsterId,

        /// <summary>
        /// Generated faces with differing features and backgrounds
        /// </summary>
        Wavatar,

        /// <summary>
        /// Awesome generated, 8-bit arcade-style pixelated faces
        /// </summary>
        Retro,

        /// <summary>
        /// A transparent PNG image
        /// </summary>
        Blank
    }
}
