using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradeHoraria_.Models
{
    public partial class AspNetUserRoles
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        //[StringLength(128)]
        public string RoleId { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}