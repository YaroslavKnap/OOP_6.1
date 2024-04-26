using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_6._1
{
    public partial class Form1 : Form
    {
        private WolfCollection wolfCollection = new WolfCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddWolf_Click_1(object sender, EventArgs e)
        {
            // Додати вовка до колекції
            double weight = Convert.ToDouble(txtWeight.Text);
            int age = Convert.ToInt32(txtAge.Text);
            double dailyMaintenanceCost = Convert.ToDouble(txtMaintenanceCost.Text);
            string breed = txtBreed.Text;
            string naturalHabitat = txtHabitat.Text;

            Wolf wolf = new Wolf(weight, age, dailyMaintenanceCost, breed, naturalHabitat);
            wolfCollection.Add(wolf);
            //MessageBox.Show(txtWeight.Text + txtAge.Text + txtMaintenanceCost.Text + txtBreed.Text + txtHabitat.Text);
            // Оновити список вовків у ListBox
            UpdateWolfListBox();
        }
        
        private void UpdateWolfListBox()
        {
            listBoxWolves.Items.Clear();
            foreach (Wolf wolf in wolfCollection)
            {
                listBoxWolves.Items.Add(wolf.GetInfo());
            }
        }

        private void listBoxWolves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWolves.SelectedIndex != -1)
            {
                Wolf selectedWolf = wolfCollection.GetWolfByIndex(listBoxWolves.SelectedIndex);
                MessageBox.Show(wolfCollection.GetWolfInfo(selectedWolf), "Wolf Information");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void txtMaintenanceCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }
    // Базовий клас Animal
    class Animal
    {
        public double Weight { get; }
        public int Age { get; }
        public double DailyMaintenanceCost { get; }

        public Animal(double weight, int age, double dailyMaintenanceCost)
        {
            Weight = weight;
            Age = age;
            DailyMaintenanceCost = dailyMaintenanceCost;
        }

        public virtual string GetInfo()
        {
            return $"Weight: {Weight}, Age: {Age}, Daily Maintenance Cost: {DailyMaintenanceCost}";
        }
    }

    // Похідний клас Wolf
    class Wolf : Animal
    {
        public string Breed { get; }
        public string NaturalHabitat { get; }

        public Wolf(double weight, int age, double dailyMaintenanceCost, string breed, string naturalHabitat) : base(weight, age, dailyMaintenanceCost)
        {
            Breed = breed;
            NaturalHabitat = naturalHabitat;
        }

        public override string GetInfo()
        {
            return $"Breed: {Breed}, Natural Habitat: {NaturalHabitat}, " + base.GetInfo();
        }
    }

    // Колекція об'єктів Wolf з використанням Hashtable та List<>
    class WolfCollection
    {
        //ІНДУВ ЗАВДАННЯ 
        private List<Wolf> wolves = new List<Wolf>();
        private Hashtable hashtable = new Hashtable();

        // Додати вовка до колекції
        public void Add(Wolf wolf)
        {
            hashtable.Add(wolf.GetHashCode(), wolf); // Додати в Hashtable
            wolves.Add(wolf);
        }

        // Отримати вовка за індексом
        public Wolf GetWolfByIndex(int index)
        {
            if (index >= 0 && index < wolves.Count)
            {
                return wolves[index];
            }
            else
            {
                return null; // або викинути виняток, якщо потрібно
            }
        }
        //ЗАВДАННЯ 3 в новоствореному класі реалізувати методи для перебору елементів колекції
        //та узагальненої колекції, відображення інформації про певний елемент колекції;
        // Повертає перебирач для колекції
        public IEnumerator<Wolf> GetEnumerator()
        {
            return wolves.GetEnumerator();
        }

        // Повертає інформацію про певного вовка
        public string GetWolfInfo(Wolf wolf)
        {
            return wolf.GetInfo();
        }
    }
}
