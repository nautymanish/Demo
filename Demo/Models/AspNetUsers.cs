﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    //public class AspNetUsers
    //{
    //    public int Id {get;set;}                  
    ////public string Email  {get;set;}               
    ////public string EmailConfirmed  {get;set;}      
    //public string PasswordHash   {get;set;}       
    ////public string SecurityStamp    {get;set;}     
    ////public string PhoneNumber  {get;set;}         
    ////public string PhoneNumberConfirmed {get;set;} 
    ////public string TwoFactorEnabled   {get;set;}  
    ////public string LockoutEndDateUtc  {get;set;}  
    ////public string LockoutEnabled     {get;set;}   
    ////public string AccessFailedCount  {get;set;}   
    //public string UserName       {get;set;}       
    //}
    public partial class AspNetUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUsers()
        {
            Questions = new HashSet<Question>();
        }

        public string Id { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}