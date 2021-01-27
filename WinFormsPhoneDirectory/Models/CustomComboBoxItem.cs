
namespace WinFormsPhoneDirectory.Models
{
    /// <summary>
    /// додавання даних в комбобокс
    /// </summary>
    public class CustomComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
