﻿using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Genre
{
    public class UpdateGenreDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}
