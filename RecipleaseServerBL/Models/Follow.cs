using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Follow
    {
        public int FollowId { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
