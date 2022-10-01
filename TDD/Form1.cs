using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*A program which brings a Graphical user interface with the option of adding a single employee by input
    from the user or adding 10,000 employees at a click ,button that allows to calculate tax for each employee
    ,button that allow to sort employees by salary and shows the sorting time. */

// Creators : Vladimir davidzon - 317648632 ,Michael ilkanyaev - 318216678
namespace TDD
{
    public partial class Form1 : Form{

        private Employee[] temp;
        public Form1(){
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e){ }

        private void label8_Click(object sender, EventArgs e){ }

        private void textBox4_TextChanged(object sender, EventArgs e){ }

        private void textBox2_TextChanged(object sender, EventArgs e){ }

        //A function that creates an employee with user input
        private void button1_Click(object sender, EventArgs e){
            string TheId = id.Text;
            string Name = name.Text;
            string Lastname = lastname.Text;
            string Email = email.Text;
            string Salary = salary.Text;
            string Telephone = telephone.Text;
            string Address = address.Text;

            Employee tempObj = new Employee(TheId, Name, Lastname, Email, Telephone, Address, Salary);
            if (temp == null){
                Employee[] newarr = new Employee[1];
                newarr[0] = tempObj;
                temp = newarr;
            }
            else{
                // create a new array of size n+1
                Employee[] newarr = new Employee[temp.Length + 1];

                for (int i = 0; i < temp.Length; i++)
                    newarr[i] = temp[i];

                newarr[temp.Length] = tempObj;
                temp = newarr;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e){ }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e){ }

        //A function that prints the employees
        private void button4_Click(object sender, EventArgs e){
            listView1.Items.Clear();
            for (int i = 0; i < temp.Length; i++) {

                ListViewItem listviewitem = new ListViewItem(new string[] { temp[i].getSalary(), temp[i].getID(), temp[i].getfirstName() + " " + temp[i].getlastName() });

                listView1.Items.Add(listviewitem);
            }
        }

        //A function that creates 10,000 employees
        private void button2_Click(object sender, EventArgs e){
            Random rnd = new Random();
            string Salary,firstname, lastname,id, Email,ADDRESS, Telephone;
            for (int i = 0; i < 10000; i++){
              
                ADDRESS = Guid.NewGuid().ToString("n").Substring(0, 8);
                Email = GenerateName(rnd.Next(2, 7)) + "@gmail.com";
                id = RandomDigits(9);
                firstname = GenerateName(rnd.Next(3, 6));
                lastname = GenerateName(rnd.Next(4, 7));
                Salary = rnd.Next(3000, 50001).ToString(); // returns random integers >= 3000 and < 50,001
                Telephone = "0"+ RandomDigits(2) +"-"+ RandomDigits(7);

                Employee tempObj = new Employee(id, firstname, lastname, Email, Telephone, ADDRESS, Salary);
                if (temp == null){
                    Employee[] newarr = new Employee[1];
                    newarr[0] = tempObj;
                    temp = newarr;
                }
                else{
                    // create a new array of size n+1
                    Employee[] newarr = new Employee[temp.Length + 1];

                    for (int j = 0; j < temp.Length; j++)
                        newarr[j] = temp[j];

                    newarr[temp.Length] = tempObj;
                    temp = newarr;
                }
            }
        }
        //A function that returns random digits
        public string RandomDigits(int length){
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
        //A function that generate names for employees
        public static string GenerateName(int len){
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        //A function that closes the program
        private void button5_Click(object sender, EventArgs e){
            this.Close();
        }
        //A function that calaculates the Tax of the employee
        public double tax_calculation(double salary){
            //double after_tax, sum1, sum2, sum3, sum4, sum5, sum6;
            //if (salary <= 6450){
            //    after_tax = salary * 0.1;
            //}
            //if (salary <= 9240){
            //    sum1 = 6450 * 0.1;
            //    sum2 = (salary - 6450) * 0.14;
            //    after_tax = sum1 + sum2;
            //}
            //if (salary <= 14840){
            //    sum1 = 6450 * 0.1;
            //    sum2 = (9240 - 6451) * 0.14;
            //    sum3 = (salary - 9241) * 0.2;
            //    after_tax = sum1 + sum2 + sum3;
            //}
            //if (salary <= 20620){
            //    sum1 = 6450 * 0.1;
            //    sum2 = (9240 - 6451) * 0.14;
            //    sum3 = (14840 - 9241) * 0.2;
            //    sum4 = (salary - 14841) * 0.31;
            //    after_tax = sum1 + sum2 + sum3 + sum4;
            //}
            //if (salary <= 42910){
            //    sum1 = 6450 * 0.1;
            //    sum2 = (9240 - 6451) * 0.14;
            //    sum3 = (14840 - 9241) * 0.2;
            //    sum4 = (20620 - 14841) * 0.31;
            //    sum5 = (salary - 20621) * 0.35;
            //    after_tax = sum1 + sum2 + sum3 + sum4 + sum5;
            //}
            //if  (salary <= 50000)       {
            //    sum1 = 6450 * 0.1;
            //    sum2 = (9240 - 6451) * 0.14;
            //    sum3 = (14840 - 9241) * 0.2;
            //    sum4 = (20620 - 14841) * 0.31;
            //    sum5 = (42910 - 20621) * 0.35;
            //    sum6 = (salary - 42911) * 0.47;
            //    after_tax = sum1 + sum2 + sum3 + sum4 + sum5 + sum6;
            //}
            //return after_tax;

            //After Refactoring:
            double after_tax, sum1, sum2, sum3, sum4, sum5, sum6;
            
            if (salary <= 6450){
                after_tax = salary * 0.1;
            }
            else if (salary <= 9240){
                sum1 = 6450 * 0.1;
                sum2 = (salary - 6450) * 0.14;
                after_tax = sum1 + sum2;
            }
            else if (salary <= 14840){
                sum1 = 6450 * 0.1;
                sum2 = (9240 - 6451) * 0.14;
                sum3 = (salary - 9241) * 0.2;
                after_tax = sum1 + sum2 + sum3;
            }
            else if (salary <= 20620){
                sum1 = 6450 * 0.1;
                sum2 = (9240 - 6451) * 0.14;
                sum3 = (14840 - 9241) * 0.2;
                sum4 = (salary - 14841) * 0.31;
                after_tax = sum1 + sum2 + sum3 + sum4;
            }
            else if (salary <= 42910){
                sum1 = 6450 * 0.1;
                sum2 = (9240 - 6451) * 0.14;
                sum3 = (14840 - 9241) * 0.2;
                sum4 = (20620 - 14841) * 0.31;
                sum5 = (salary - 20621) * 0.35;
                after_tax = sum1 + sum2 + sum3 + sum4 + sum5;
            }
            else{
                sum1 = 6450 * 0.1;
                sum2 = (9240 - 6451) * 0.14;
                sum3 = (14840 - 9241) * 0.2;
                sum4 = (20620 - 14841) * 0.31;
                sum5 = (42910 - 20621) * 0.35;
                sum6 = (salary - 42911) * 0.47;
                after_tax = sum1 + sum2 + sum3 + sum4 + sum5 + sum6;
            }
            return after_tax;
        }


        public void button6_Click(object sender, EventArgs e){

            if (listView1.SelectedItems.Count > 0) {
                ListViewItem item = listView1.SelectedItems[0];
                double after_tax;

                double salaryInDouble = Convert.ToDouble(item.SubItems[0].Text.ToString());

                after_tax = tax_calculation(salaryInDouble);

                label10.Text = (after_tax.ToString("0.00"));
                Refresh();
            }
        }
        public Employee[] Bubble_sort(Employee[] temp){
            DateTime start;
            TimeSpan time;

            start = DateTime.Now;
            Employee temp2;
            for (int j = 0; j <= temp.Length - 2; j++){
                for (int i = 0; i <= temp.Length - 2; i++){
                    if (Int32.Parse(temp[i].getSalary()) > Int32.Parse(temp[i + 1].getSalary())){
                        temp2 = temp[i + 1];
                        temp[i + 1] = temp[i];
                        temp[i] = temp2;
                    }
                }
            }
            time = DateTime.Now - start;
            sorttime.Text = String.Format("{0}.{1} sec", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));
            return temp;
        }

        // function for counting sort
        public Employee[] CountingSort(Employee[] temp){
            DateTime start;
            TimeSpan time;

            start = DateTime.Now;

            Employee[] sortedArray = new Employee[temp.Length];
            
            // find smallest and largest value
            int minVal = Int32.Parse(temp[0].getSalary());
            int maxVal = Int32.Parse(temp[0].getSalary());

            for (int i = 1; i < temp.Length; i++){
                if (Int32.Parse(temp[i].getSalary()) < minVal)
                    minVal = Int32.Parse(temp[i].getSalary());
                else if (Int32.Parse(temp[i].getSalary()) > maxVal) 
                    maxVal = Int32.Parse(temp[i].getSalary());
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < temp.Length; i++){
                counts[Int32.Parse(temp[i].getSalary()) - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++){
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = temp.Length - 1; i >= 0; i--){
                sortedArray[counts[Int32.Parse(temp[i].getSalary()) - minVal]--] = temp[i];
            }

            temp = sortedArray;
            time = DateTime.Now - start;
            sorttime.Text = String.Format("{0}.{1} sec", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));
            return temp;
        } 

        public void button3_Click(object sender, EventArgs e){

            //activation of Bubble sort in run time O(n^2)
            //temp= Bubble_sort(temp);
            //-------------------------------------------------------------//
            //activation of Counting Sort in run time O(n)
            temp = CountingSort(temp);

            //activation of the function that prints the list view items 
            button4_Click(sender, e);
        }
    }
    public class Employee{

        private string ID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string Address;
        private string Salary;

        public Employee(string ID, string firstName, string lastName, string email, string phone, string Address, string Salary){

            this.ID = ID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.Address = Address;
            if (Int32.Parse(Salary) > 50000)
                this.Salary = "50000";
            else if(Int32.Parse(Salary) < 3000)
                this.Salary = "3000";
            else
                this.Salary = Salary;
        }
        public string getID() { return ID; }
        public string getfirstName() { return firstName; }
        public string getlastName(){ return lastName; }
        public string getSalary() { return Salary; }
    }

}
