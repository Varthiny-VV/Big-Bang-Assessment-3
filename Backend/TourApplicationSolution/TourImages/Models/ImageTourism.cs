﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourImages.Models
{
    public class ImageTourism
    {
        [Key]
        public int ImageId { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public int PackageId { get; set; }
        [NotMapped]
        public List<IFormFile> Image { get; set; }
    }
}
