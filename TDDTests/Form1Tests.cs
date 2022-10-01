using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Tests{
    [TestClass()]
    public class Form1Tests{
        //Test for the sort Function
        [TestMethod()]
        public void button3_ClickTest(){
            //Test that the sort function is really sorting the array:

            //Assert.Fail();
            var temp = new Form1();
            int[] testArray = new int[] { 3000, 3900, 5000, 25000, 43000, 49899 };

            Employee[] newarr = new Employee[6];
            newarr[0] = new Employee("", "", "", "", "", "", "43000");
            newarr[1] = new Employee("", "", "", "", "", "", "49899");
            newarr[2] = new Employee("", "", "", "", "", "", " 25000");
            newarr[3] = new Employee("", "", "", "", "", "", "3000");
            newarr[4] = new Employee("", "", "", "", "", "", "3900");
            newarr[5] = new Employee("", "", "", "", "", "", "5000");

            //newarr = temp.Bubble_sort(newarr);
            newarr = temp.CountingSort(newarr);

            for (int i = 0; i < newarr.Length; i++){

                Assert.AreEqual(testArray[i], Int32.Parse(newarr[i].getSalary()));
            }
            //********************************************************************************************//
            //Test that the array has not lost items before and after the sort:

            Assert.AreEqual(6, newarr.Length);

            //********************************************************************************************//
            //Test that sort function returns the right value:

            //Assert.IsNotNull(temp.Bubble_sort(newarr));
            Assert.IsNotNull(temp.CountingSort(newarr));

        }

        //Test for the tax_calculation Function 
        [TestMethod()]
        public void tax_calculationTest(){
            var temp = new Form1();
            //Assert.Fail();
            //10,000  tax = 1187.26
            //15,000  tax = 2204.55
            //45,555  tax = 12990.58
            //60,000  tax = 19779.73

            Assert.AreEqual(1187.26, temp.tax_calculation(10000));
            Assert.AreEqual(2204.55, temp.tax_calculation(15000));
            Assert.AreEqual(12990.58, temp.tax_calculation(45555));
            Assert.AreEqual(19779.73, temp.tax_calculation(60000));

            Assert.AreNotEqual(1187.25, temp.tax_calculation(10000));
            Assert.AreNotEqual(2204.56, temp.tax_calculation(15000));
        }
    }
}