namespace IC.Client.View.Components.Structs
{
    /// <summary>
    /// Presents Blend Function struct
    /// 
    /// 2017/06/10 - created VTyagunov
    /// </summary>
    public struct BlendFunction
    {
        /// <summary>Blend Op</summary>
        public byte BlendOp;
        /// <summary>Blend flags</summary>
        public byte BlendFlags;
        /// <summary>Source Constant Alpha</summary>
        public byte SourceConstantAlpha;
        /// <summary>Alpha Format</summary>
        public byte AlphaFormat;
    }
}