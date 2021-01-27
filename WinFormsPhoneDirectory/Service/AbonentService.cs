using PhoneDirectoryDAL;
using WinFormsPhoneDirectory.Models;
using System.Linq;

namespace WinFormsPhoneDirectory.Service
{
   public class AbonentService
    {
        public static AbonentViewGrid Search(Mycontext contex, SearcAbonent search)
        {
            // Модель для пошуку абонентів
            AbonentViewGrid model = new AbonentViewGrid();
            // отримуємо усі записи в оперативку
            // var query = context.Doctors.AsEnumerable(); // .AsQueryable();
            // ми формуємо sql запит до БД - нічого не отримуємо 
            var query = contex.phoneDirs.AsQueryable();
           
            // Якщо у search.Name != null
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.Contains(search.LastName));
            }
            // Показує номер сторінки
            int page = search.Page - 1;
            // Кількість рядків, які можна вибрати через ComboBox
            int showItems = search.CountShowOnePage;
            // Всього записів після пошуку
            model.CountRows = query.Count();
            // Запит, який дозволяє сформувати список з DB
            model.abonents = query
                .OrderBy(x => x.Id)
                .Skip(page * showItems)
                .Take(showItems)
                .Select(x => new AbonentItemView
                {
                    Id = x.Id,
                    Name = x.LastName + " " + x.FirstName,
                    NumberPhone = x.NumberPhone,
                    Gender = x.Gender.ToString()
                }).ToList();

            // Кінцевий результат пошуку, який повертає дані по абоненту 
            return model;
        }
    }
}
