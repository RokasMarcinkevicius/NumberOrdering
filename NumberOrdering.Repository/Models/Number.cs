using System;
using System.ComponentModel.DataAnnotations;

namespace NumberOrdering.Repository.Models
{
    public class Number
    {
        [Key]
        public Guid Guid { get; set; }
        public int Value { get; set; }
    }
}
