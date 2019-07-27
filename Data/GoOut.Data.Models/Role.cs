namespace GoOut.Data.Models
{
    using System;
    using Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public Role(string name)
               : base(name)
        { }

        // Audit info
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}