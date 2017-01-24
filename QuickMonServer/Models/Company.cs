#region Using

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace QuickMonServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [MaxLength(250)]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [DefaultValue(true)]
        public bool Enable { get; set; }

        [DefaultValue(1)]
        public int MaxBranch { get; set; }

        [DefaultValue(1)]
        public int MaxDivision { get; set; }

        [DefaultValue(1)]
        public int MaxManager { get; set; }

        [DefaultValue(1)]
        public int MaxStaff { get; set; }

        public DateTime ActiveDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LicenseKey { get; set; }

        public virtual ICollection<Branch> Branchs { get; set; }
        
    }
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [MaxLength(250)]
        public string BranchName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }
        public bool IsDefault { get; set; }
        public bool UseCompanyInfo { get; set; }

        public virtual Company Company { get; set; }
    }
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DivisionId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [MaxLength(250)]
        public string DivisionName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }
        public bool IsDefault { get; set; }
        public bool UseBranchInfo { get; set; }
        public bool UseCompanyInfo { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}