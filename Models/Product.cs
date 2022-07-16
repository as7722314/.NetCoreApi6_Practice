using System;
using System.Collections.Generic;

namespace WebRest2Application.Models
{
    public partial class Product
    {
        public string? Name { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Img { get; set; }
        public string? Index { get; set; }
        public int Id { get; set; }
    }
}
