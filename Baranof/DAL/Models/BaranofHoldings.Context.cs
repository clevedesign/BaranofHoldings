﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class barano5_Entities : DbContext
    {
        public barano5_Entities()
            : base("name=barano5_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Approach> Approaches { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<Overview> Overviews { get; set; }
        public virtual DbSet<PortfolioContent> PortfolioContents { get; set; }
        public virtual DbSet<Strategy> Strategies { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
    }
}
