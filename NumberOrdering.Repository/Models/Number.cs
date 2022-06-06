using System;
using System.ComponentModel.DataAnnotations;

namespace NumberOrdering.Repository.Models
{
    public class Number
    {
        // Unused but can easily add saving to DB as well.
        [Key]
        public Guid Guid { get; set; }
        public int Value { get; set; }
    }
}
