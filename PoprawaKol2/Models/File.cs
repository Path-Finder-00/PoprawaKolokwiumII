using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoprawaKol2.Models
{
    public class File
    {
        public int FileID { get; set; }
        public int TeamID { get; set; }
        [Required, MaxLength(100)]
        public string FileName { get; set; }
        [Required, MaxLength(4)]
        public string FileExtension { get; set; }
        [Required]
        public int FileSize { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
    }
}
