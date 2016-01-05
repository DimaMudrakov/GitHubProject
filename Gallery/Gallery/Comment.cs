namespace Gallery
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int ID { get; set; }
        public System.DateTime CreateTS { get; set; }
        public string Imgtext { get; set; }
        public int ImageSize { get; set; }
        public int ImageID { get; set; }
    
        public virtual Image Image { get; set; }
    }
}
