using NHFPOSTGRSQL.Models.EntityModel;
using NHFPOSTGRSQL.Models.ViewModel;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Models.NHFHelper.NHFData
{
    public class PersonProfilFactory
    {
        public static List<personprofil> GetPersonProfil()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<personprofil>().ToList();
            }
        }
        public static List<PersonProfilVM> F_GetPersonProfil()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.CreateSQLQuery("select * from getpersonlist()")
                                        .SetResultTransformer((new AliasToBeanResultTransformer(typeof(PersonProfilVM))))
                                        .List<PersonProfilVM>().ToList();
            }
        }
        public static bool AddPerson(personprofil model)
        {
            bool rslt = false;
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                try
                {
                    var aa=(int)session.Save(model);
                    transaction.Commit();
                    rslt = aa>0;
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                return rslt;
            }
        }

        public static string F_AddPerson(personprofil model)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var result = session.CreateSQLQuery($"select * from addpersonelf(:firstname,:lastname)")
                 .SetParameter("firstname", model.firstname)
                 .SetParameter("lastname", model.lastname)
                 .UniqueResult<string>();

                return result;
            }
        }
        public static string P_AddPerson(personprofil model)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var result = session.CreateSQLQuery($"call addpersonel(:firstname,:lastname,null)")
                 .SetParameter("firstname", model.firstname)
                 .SetParameter("lastname", model.lastname )
                 .UniqueResult<string>();

                return result;
            }
        }
       
        
        public static string UpdatePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                try
                {

                    var person = session.Get<personprofil>(id);
                    person.firstname += " updated.";
                    person.lastname += " updated.";
                    session.Update(person);
                    transaction.Commit();

                    return $"{person.personprofilid} {person.firstname} {person.lastname}  olarak güncellendi.";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                return null;
            }
        }
        public static string F_UpdatePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var person = session.Get<personprofil>(id);
                var result = session.CreateSQLQuery($"select * from updatepersonelf(:id,:fname,:lname)")
                  .SetParameter("id", id)
                 .SetParameter("fname", person.firstname + " f_updated")
                 .SetParameter("lname", person.lastname + " f_updated")
                 .UniqueResult<string>();
                return result;
            }
        }
        public static string P_UpdatePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var person = session.Get<personprofil>(id);
                var result = session.CreateSQLQuery($"call updatepersonelp(:id,:fname,:lname,null)")
                  .SetParameter("id", id)
                 .SetParameter("fname", person.firstname + " p_updated")
                 .SetParameter("lname", person.lastname + " p_updated")
                 .UniqueResult<string>(); //.ExecuteUpdate();

                return result;
            }
        }

        public static string DeletePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                try
                {

                    var person = session.Get<personprofil>(id);
                    session.Delete(person);
                    transaction.Commit();
                    return $"personprofilid= {person.personprofilid} olan kayıt silindi.";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                return null;
            }
        }
        public static string F_DeletePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var result = session.CreateSQLQuery($"select * from deletepersonelf(:id)")
                  .SetParameter("id", id)
                 .UniqueResult<string>(); //.ExecuteUpdate();

                return result;
            }
        }
        public static string P_DeletePerson(int id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var result = session.CreateSQLQuery("call deletepersonelp(:id,null)")
                  .SetParameter("id", id)
                 .UniqueResult<string>();

                return result;
            }
        }
    }
}
