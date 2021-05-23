using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Models.ViewModel
{
    public class PersonProfilVM
    {
        //function da donen değer kolonları ile birebir aynı olmalı
        public int personprofilId1 { get; set; }
        public string firstname1 { get; set; }
        public string lastname1 { get; set; }
        public string sehir { get; set; }//functionda bu deger donmediği için null olur.
    }
}
