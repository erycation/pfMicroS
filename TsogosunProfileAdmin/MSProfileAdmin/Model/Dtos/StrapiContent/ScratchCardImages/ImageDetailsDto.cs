using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent.ScratchCardImages
{
    public class ImageDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlternativeText { get; set; }
        public string Caption { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Formats Formats { get; set; }
        public string Hash { get; set; }
        public string Ext { get; set; }
        public string Mime { get; set; }
        public double Size { get; set; }
        public string Url { get; set; }
        public string PreviewUrl { get; set; }
        public string provider { get; set; }
        public string Provider_Metadata { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
