using System.Collections.Generic;

namespace WinFormsPhoneDirectory.Models
{
    public class AbonentViewGrid
    {
        /// <summary>
        /// Записи, які ми відображаємо у пошуку
        /// </summary>
        public List<AbonentItemView> abonents { get; set; }
        /// <summary>
        /// Загальна кількість записів, які ми знайшли
        /// </summary>
        public int CountRows { get; set; }
    }
    public class AbonentItemView
    {
        public int Id { get; set; }
        /// <summary>
        /// Повне ім’я (прізвище + ім’я) абонента
        /// </summary>
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string Gender { get; set; }
    }
}
