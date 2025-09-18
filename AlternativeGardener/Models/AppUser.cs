using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AlternativeGardener.Models;

public class AppUser : IdentityUser
{
  [Required]
  [Display(Name = "First Name")]
  [StringLength(100, ErrorMessage = "First name must be longer than 2 characters and cannot be longer than 100 characters.", MinimumLength = 2)]
  public string? FirstName { get; set; }

  [Required]
  [Display(Name = "Last Name")]
  [StringLength(100, ErrorMessage = "Last name must be longer than 2 characters and cannot be longer than 100 characters.", MinimumLength = 2)]
  public string? LastName { get; set; }

  [NotMapped]
  public string? FullName
  {
    get { return $"{FirstName} {LastName}"; }
  }
}
