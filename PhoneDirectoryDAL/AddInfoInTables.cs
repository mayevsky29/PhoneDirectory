//using Bogus;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PhoneDirectoryDAL
//{
//    public class AddInfoInTables
//    {
//        public void NumberPhone(Mycontext contex)
//        {
//            Random random = new Random();
//            List<PhoneDir> numberPhones = new List<PhoneDir>();
//            var phones = new Faker<PhoneDir>("uk")


//                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
//                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
//                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender));

               
              
               


//            for (int i = 0; i < 490; i++)
//            {
//                myListDocs.Add(doctor.Generate());
//            }
//            foreach (var item in myListDocs)
//            {
//                context.Doctors.Add(
//                    new Doctor
//                    {
//                        FirstName = item.FirstName,
//                        LastName = item.LastName,
//                        Login = item.Login,
//                        Password = PasswordManager.HashPassword(item.Password),
//                        Department = context.Departments
//                        .FirstOrDefault(x => x.Name == "Хіругрія"),
//                        Image = item.Image,
//                        Stage = item.Stage
//                    });

//            }
//        }
//    }
//}
