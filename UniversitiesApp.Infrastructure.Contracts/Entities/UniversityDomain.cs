﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniversitiesApp.Infrastructure.Contracts.Entities;


public partial class UniversityDomain
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Domain { get; set; }
    public int UniversityId { get; set; }

    [ForeignKey("UniversityId")]
    [InverseProperty("UniversityDomain")]
    public virtual University University { get; set; }
}