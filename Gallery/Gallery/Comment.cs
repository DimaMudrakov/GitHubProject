//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
        public Nullable<int> ImageID { get; set; }
    
        public virtual Image Image { get; set; }
    }
}
