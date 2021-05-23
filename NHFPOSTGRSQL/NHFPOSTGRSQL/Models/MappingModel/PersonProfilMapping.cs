using FluentNHibernate.Mapping;
using NHFPOSTGRSQL.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Models.MappingModel
{
    public class PersonProfilMapping : ClassMap<personprofil>
    {

        public PersonProfilMapping() : base()
        {
            Id(x => x.personprofilid).GeneratedBy.Identity();
            Map(x => x.firstname);
            Map(x => x.lastname);
            Table("personprofil");

        }
    }
}
