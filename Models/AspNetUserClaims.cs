using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradeHoraria_.Models
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUsers_Id { get; set; }

        [StringLength(128)]
        public string ClaimType { get; set; }

        [StringLength(128)]
        public string ClaimValue { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}