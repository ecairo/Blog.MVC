using System;

namespace Blog.Entities
{
    public interface IEntityBase
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}