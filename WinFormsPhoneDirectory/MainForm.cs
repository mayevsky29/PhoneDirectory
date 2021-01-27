using Microsoft.EntityFrameworkCore;
using PhoneDirectoryDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsPhoneDirectory.Models;
using WinFormsPhoneDirectory.Service;

namespace WinFormsPhoneDirectory
{
    public partial class MainForm : Form
    {
       
        private readonly Mycontext context;
        // Виводить першу сторінку
        private int _page = 1;
        public MainForm()
        {

            context = new Mycontext();
            // Завантажує форму
            InitializeComponent();
            // Клас, який додає та відображає існуючих абононетів у DB
            DbSeeder.SeedPhone(context);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

           
                // Коли відбувається читання даних, викликається пошук і відображає всіх абонентів

                SearchAbonent();

            // Дозволяє вибирати у комбобоксі кількість записів на сторінці
            cbCountShowOnePage.Items.AddRange(
                    new List<CustomComboBoxItem> {
                            new CustomComboBoxItem { Id=1, Name="10" },
                            new CustomComboBoxItem { Id=2, Name="20" },
                            new CustomComboBoxItem { Id=3, Name="30" },
                            new CustomComboBoxItem { Id=4, Name="50" }
                       }.ToArray()
                    );
                cbCountShowOnePage.SelectedIndex = 0;
            
        }
        private SearcAbonent GetSearchInputValue()
        {
            // Введення даних, за якими відбувається пошук абонентів
            // Знайти інформацію про абонента можна за прізвищем або ім’ям
            SearcAbonent search = new SearcAbonent();
            search.FirstName = txtName.Text;
            search.LastName = txtLastName.Text;
            var countSelect = cbCountShowOnePage.SelectedItem as CustomComboBoxItem;
            search.CountShowOnePage = int.Parse(countSelect.Name);
           
            return search;
        }
        private void SearchAbonent(SearcAbonent search = null)
        {
            
            dataGridView1.Rows.Clear();
          // Якщо не показала результату після пошуку, потрібно робити новий
            search ??= new SearcAbonent();

            search.Page = _page;
            // Створення зміної з даними в результаті пошуку
            var result = AbonentService.Search(context, search);
            // Цикл, який виводить результати пошуку 
            foreach (var item in result.abonents)
            {
                object[] row = {
                        item.Id,
                        item.Name,
                        item.NumberPhone,
                        item.Gender
                    };
                dataGridView1.Rows.Add(row);
            }
            // Показує діапазон початкового та кінцевого рядка на сторінці і загальну к-сть елементів
            int begin = (_page - 1) * search.CountShowOnePage + 1;
            int end = begin + (search.CountShowOnePage - 1);
            lblRange.Text = $"Показ: {begin} - {end}";
            lblCount.Text = "Всього записів: " + result.CountRows.ToString();

            int totalPage = (int)Math.Ceiling((double)result.CountRows / search.CountShowOnePage);

            //Малюю кнопки 1, 2, ...
            int positionX = 10;
            int dx = 50;
            // Очищення контролсів у GroupBox
            gbBoxButtons.Controls.Clear();
            // Цикл дозволяє рухатися по сторінках вперед і назад
            for (int i = 1; i <= totalPage; i++)
            {
                Button btn = new Button();
                btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                btn.Location = new System.Drawing.Point(positionX, 10);
                btn.Name = $"btnPage{i}";
                btn.Size = new System.Drawing.Size(45, 45);
                btn.Text = $"{i}";
                btn.UseVisualStyleBackColor = true;

                btn.Click += new System.EventHandler(this.btnPage_Click);
                gbBoxButtons.Controls.Add(btn);
                positionX += dx;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbGenders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        // Обробка кнопки сторінка в GroupBox
        private void btnPage_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            _page = int.Parse(s);
            SearchAbonent(GetSearchInputValue());
        }
        // Кнопка дозволяє рухатися на 1 сторінку вперед
        private void btnRight_Click(object sender, EventArgs e)
        {
            _page += 1;
            SearchAbonent(GetSearchInputValue());
        }
        // Кнопка дозволяє рухатися на 1 сторінку назад
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page -= 1;
                SearchAbonent(GetSearchInputValue());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Якщо робимо пошук переходимо на початок
            _page = 1;
            SearchAbonent(GetSearchInputValue());
        }
    }
}
