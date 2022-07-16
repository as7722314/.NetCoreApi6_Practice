using System;
using System.Collections.Generic;

namespace WebRest2Application.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
