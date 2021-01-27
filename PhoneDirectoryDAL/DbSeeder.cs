using System.Linq;

namespace PhoneDirectoryDAL
{
   public static class DbSeeder
    {
        public static void SeedPhone(Mycontext context)
        {
            /// <summary>
            /// Якщо база даних == null, тоді додаються дані у таблицю
            /// </summary>

            if (context.phoneDirs.Count() == 0)
            {
                context.phoneDirs.Add(
                    new PhoneDir
                    {
                        FirstName = "Петро",
                        LastName = "Махно",
                        NumberPhone = 0685567456,
                        Gender = Gender.Male
                    });
               context.phoneDirs.Add(
                    new PhoneDir
                    {
                        FirstName = "Вася",
                        LastName = "Пригода",
                        NumberPhone = 0685423457,
                        Gender = Gender.Male
                    });
                context.phoneDirs.Add(
                    new PhoneDir
                    {
                        FirstName = "Харитина",
                        LastName = "Витрибенько",
                        NumberPhone = 0502536789,
                        Gender = Gender.Female
                    });
                context.phoneDirs.Add(
                  new PhoneDir
                  {
                      FirstName = "Інна",
                      LastName = "Петик",
                      NumberPhone = 0502536789,
                      Gender = Gender.Female
                  });
               context.SaveChanges();
            }

        }
    }
}
