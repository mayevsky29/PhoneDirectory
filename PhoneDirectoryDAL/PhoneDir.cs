using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneDirectoryDAL
{
 /// <summary>
 /// Клас для роботи з таблицею DB
 /// </summary>
    [Table ("tblPhoneDir")]
    public class PhoneDir
    {
        [Key]
        public int Id { get; set; }
        public int NumberPhone{ get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
    }
    // Метод, який дозволяє виділяти абонентів по статті
    public enum Gender
        { Male = 0, Female = 1 }
}

