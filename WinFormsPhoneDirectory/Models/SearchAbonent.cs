
namespace WinFormsPhoneDirectory.Models
{
    /// <summary>
    /// здійснення пошуку абонентів
    /// </summary>
    public class SearcAbonent
    {
        // Поля для пошуку
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int Page { get; set; }
        /// <summary>
        /// Кількість записів на сторінці по замовчуванню
        /// </summary>
        public int CountShowOnePage { get; set; } = 10;
    }
}
