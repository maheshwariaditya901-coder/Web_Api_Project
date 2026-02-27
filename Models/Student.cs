using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Project.Models;

public partial class Student
{
    public int Id { get; set; } 

    public string Name { get; set; } = null!;

    [Required]
    public string? Email { get; set; }

    [Range(1, 100)]
    public int? Age { get; set; }

    [Required]
    public string? Course { get; set; }

    public DateTime? CreatedDate { get; set; }
}
