using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Enums.Comments
{
    public enum CommentStatus
    {
        Active,
        Hidden,
        Deleted,
        Pending,
        Approved,
        Flagged,
        Spam
    }
}
