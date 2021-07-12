using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Name: Michael Mena
 * Date: 10/29/2020
 * This program is a Windows form application that gets the info of an order at a hair salon and displays each option witht eh corresponding price
 * I, Michael Mena, 000817498 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */
namespace Lab3B
{
    public partial class Form1 : Form
    {
        public List<chargeAble> allChargeable = new List<chargeAble>(); // Creates the list of all chargeable objects in the order
        /*
         * This method checks checks to see if there are any matching 
         * objects in the allChargeable list to make sure that there are no duplicates.
         * Returns true or false depending on if it contains the string
         */
        bool doesContain(string name)
        {
            bool temp = false;
            foreach(chargeAble x in allChargeable)
            {
                if(x.Name == name)
                {
                    temp = true;
                }
            }
            return temp;
        }
        
        /*
         * Initializes the form
         */
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Select a service list box
         */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * Price list box
         */
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * charged item listbox
         */
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * Hairdresser dropdown list box
         */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        /*
         * Add services button
         * 
         * When clicked, this button emptys the "Charged items" listbox and the "Price" listbox
         * It then has a switch case which checks if there are any items in the "allChargeable" list and then 
         * adds the hairdresser to the list first.
         */

        private void button1_Click(object sender, EventArgs e)
        {
            lbCharged.Items.Clear();
            lbPrice.Items.Clear();

            /*
             * This is an if statement which contains a switch case that checks if there are any items in the "allChargeable" list and then 
             * adds the hairdresser to the list first as long as it starts off empty
             */
            if (allChargeable.Count == 0)
            {
                switch (ddlHairdresser.SelectedIndex)
                {
                    case 0:
                        allChargeable.Add(new chargeAble("Jane", 30.00));
                        break;
                    case 1:
                        allChargeable.Add(new chargeAble("Pat", 45.00));
                        break;
                    case 2:
                        allChargeable.Add(new chargeAble("Ron", 40.00));
                        break;
                    case 3:
                        allChargeable.Add(new chargeAble("Sue", 45.00));
                        break;
                    case 4:
                        allChargeable.Add(new chargeAble("Pat", 45.00));
                        break;
                }
            }
        
            /*
             * This switch case uses the "doesContain" method to make sure that there are no duplicate objects being added to
             * the allChargeable list and then add the items to it
             */
            switch (lbService.SelectedIndex)
            {
                case 0:
                    if (doesContain("Cut") == false){
                        allChargeable.Add(new chargeAble("Cut", 30.00)); }
                     break;
                case 1:
                    if (doesContain("Wash, blow-dry, and style") == false)
                    {
                        allChargeable.Add(new chargeAble("Wash, blow-dry, and style", 20.00));
                    }
                    break;
                case 2:
                    if (doesContain("Colour") == false)
                    {
                        allChargeable.Add(new chargeAble("Colour", 40.00));
                    }
                    break;
                case 3:
                    if (doesContain("Highlights") == false)
                    {
                        allChargeable.Add(new chargeAble("Highlights", 50.00));
                    }
                    break;
                case 4:
                    if (doesContain("Extensions") == false)
                    {
                        allChargeable.Add(new chargeAble("Extensions", 200.00));
                    }
                    break;
                case 5:
                    {
                    if (doesContain("Up-do") == false)
                    {
                        allChargeable.Add(new chargeAble("Up-do", 60.00));
                    }
                    break;
                    }


            }
            /*
             * This foreach loop adds each of the Names of items to the "Charged items" listbox
             * and also add the price of each item to the "Price" listbox
             */
            foreach(chargeAble x in allChargeable)
            {
                lbCharged.Items.Add(x.Name);
                lbPrice.Items.Add(x.Price);
            }

        }

        /*
         * This button closes the form
         */
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /**
         * This button resets the form
         */
        private void button3_Click(object sender, EventArgs e)
        {
            ddlHairdresser.SelectedIndex = ddlHairdresser.FindStringExact("Jane");
            lbCharged.Items.Clear();
            lbPrice.Items.Clear();
            allChargeable.Clear();
            ddlHairdresser.Focus();
            totalPrice.Text = "";


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /*
         * This label displays the final price
         */
        private void totalPrice_Click(object sender, EventArgs e)
        {

        }

        /*
         * This button calculates the final price and adds it to the "Total" label
         */
        private void button2_Click(object sender, EventArgs e)
        {

            double total = 0;
            foreach(chargeAble x in allChargeable)
            {
                total +=x.Price;
            }
            totalPrice.Text = "$" + total.ToString() + ".00";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }
