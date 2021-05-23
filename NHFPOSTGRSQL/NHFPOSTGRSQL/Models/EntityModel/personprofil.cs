using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Models.EntityModel
{
    public class personprofil
    {
        public virtual int personprofilid { get; set; }
        public virtual string firstname { get; set; }
        public virtual string lastname { get; set; }
    }
}
