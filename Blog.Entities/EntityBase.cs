﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public abstract class EntityBase
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
