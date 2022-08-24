using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradeHoraria_.Models
{
    public partial class AspNetUserLogins
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string LoginProvider { get; set; }

        [StringLength(128)]
        public string ProviderKey { get; set; }

        [StringLength(128)]
        public string AspNetUsers_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}