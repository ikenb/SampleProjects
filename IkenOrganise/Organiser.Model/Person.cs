﻿using System.ComponentModel.DataAnnotations;

namespace Organiser.Model
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
