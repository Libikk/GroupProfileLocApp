// <auto-generated />
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileLocation.Domain.ORM.Models
{
    [Table("SocialType")]
    public partial class SocialType
    {
        public SocialType()
        {
            Socials = new HashSet<Social>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("iconURL")]
        [StringLength(250)]
        public string IconUrl { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(Social.SocialType))]
        public virtual ICollection<Social> Socials { get; set; }
    }
}
