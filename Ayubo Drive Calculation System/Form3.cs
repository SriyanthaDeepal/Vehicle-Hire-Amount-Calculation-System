/*  Name: Vehicle Renting Calculation
    Date of creation: 2022/02/25
    Author: A. A. Sriyantha Deepal 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ayubo_Drive_Calculation_System
{
    public partial class Form3 : Form

    {


        public Form3()
        {
            InitializeComponent();
            filVehicleCombo();
            fillDriverCombo();
            ShowDataInGrid1();
            ShowDataInhGrid2();
        }


        // Declare variables to assign values 
        float vehicleRatePerDay;
        float vehicleRatePerWeek;
        float vehicleRatePerMonth;
        float driverRate;
        float rentFee;
        DateTime rentDate;
        DateTime returnDate;
        int difference;
        float totalDays;



        //Creating Databse Connection
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AyubooDrive;Integrated Security=True";
        SqlConnection con;
        SqlCommand runQuery;
        SqlDataReader read;
        SqlDataAdapter dataadapter;
        DataSet ds;
        DataTable dataTable;
        string hireDriver;

        // Create a function to derive VehicleIDs from database
        void filVehicleCombo()
        {
            // Write a query to retrieve data from vehicle
            string query = "SELECT VehicleID FROM Vehicle;";
            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            // Read each vehicle Id and add them as item to combo box
            while (read.Read())
            {
                string vehicleID = Convert.ToString(read["VehicleID"]);
                frm3_cmbBox1.Items.Add(vehicleID);
            }
            read.Close();
            con.Close();
        }


        // Create a function to derive driver ids from drive data table
        void fillDriverCombo()
        {
            // Write a query to retrieve data from driver table
            string query = "SELECT DriverID FROM Driver;";
            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            // Read each driver ID and add them as items to combo box
            while (read.Read())
            {
                string typeID = Convert.ToString(read["DriverID"]);
                frm3_cmbBox3.Items.Add(typeID);
            }
            read.Close();
            con.Close();
        }



        // Retrieve date from date time picker 1
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rentDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
        }


        // Hide driver IDs combo box when Form3 is loaded 
        private void Form3_Load(object sender, EventArgs e)
        {
            frm3_cmbBox3.Hide();

        }


        // Checking whether user choose a item from combo box hire driver
        private void frm3_cmbBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If user select item 'YES' then unhide the driver IDs combo box
            string wantDriver = frm3_cmbBox2.SelectedItem.ToString();
            if (wantDriver == "Yes")
            {
                frm3_cmbBox3.Show();
            }
            //If user select item 'NO' then hide further driver IDs combo box
            else
            {
                frm3_cmbBox3.Hide();
            }
        }


        // Create a function to show vehicle database details
        void ShowDataInGrid1()
        {
            try
            {
                // write a query to retrieve all vehicle data into data grid
                string query = "SELECT * FROM Vehicle";
                con = new SqlConnection(conString);
                dataadapter = new SqlDataAdapter(query, con);
                ds = new DataSet();
                con.Open();
                dataadapter.Fill(ds, "Vehicle");
                con.Close();
                frm3_dataGridView1.DataSource = ds;
                frm3_dataGridView1.DataMember = "Vehicle";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }


        //Create a function to show driver database table details
        void ShowDataInhGrid2()
        {
            try
            {
                // Write a query to retrieve all driver data into data grid 2
                string query = "SELECT * FROM Driver";
                con = new SqlConnection(conString);
                dataadapter = new SqlDataAdapter(query, con);
                ds = new DataSet();
                con.Open();
                dataadapter.Fill(ds, "Driver");
                con.Close();
                frm3_dataGridView2.DataSource = ds;
                frm3_dataGridView2.DataMember = "Driver";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }


        // Retrieve Rent payment option when user select a vehicle
        private void frm3_cmbBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                // Write a query to derive Rent per day, week and month from database to do calculations
                string query = "SELECT RentPerDay, RentPerWeek, RentPerMonth FROM VehicleType INNER JOIN Vehicle ON VehicleType.VehicleTypeID = Vehicle.VehicleTypeID WHERE VehicleID = '" + frm3_cmbBox1.SelectedItem.ToString() + "'";

                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                // Read derived data and assign them to declared variables
                while (read.Read())
                {
                    vehicleRatePerDay = float.Parse(read[0].ToString());
                    vehicleRatePerWeek = float.Parse(read[1].ToString());
                    vehicleRatePerMonth = float.Parse((read[2].ToString()));
                }
                con.Close();
            
        }

        // Retrive driver fee from database when user select a driver
        private void frm3_cmbBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Write a query to derive driver fee from database to do calculations
            string query = "SELECT Fee FROM Driver WHERE DriverID = '" + frm3_cmbBox3.SelectedItem.ToString() + "'";

            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            // Read derived data and assign it to declared variable
            while (read.Read())
            {
                driverRate = float.Parse(read[0].ToString());
            }
            con.Close();
        }


        // Derive date from user input
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Assign derive date to declared variable
            returnDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
            // Get the difference between two days to get total rent days
            difference = (returnDate.Date - rentDate.Date).Days;
            // Convert total days into  float for calcualtions
            totalDays = float.Parse(difference.ToString());
            // Call calculation function
            calculation();
        }


        // Create a function to calculate rend fee
        void calculation()
        {

            // If total days are more than 0 and less than 7 then do per day calculation
            if (totalDays > 0 && totalDays < 7)
            {   
                // Calcualte driver per day and vehcle fee per day and multiply it by days
                rentFee = (driverRate * totalDays) + (vehicleRatePerDay * totalDays);
            }

            // If total days are eqal or morethan 7 and less than 30 then do per week calculation
            else if (totalDays >= 7 && totalDays < 30)
            {
                // Get remaining days after weeks 
                float mod = totalDays % 7;
                // Get total week of rented
                float totalWeeks = (totalDays - mod) / 7;
                // Calculate rent per week and after remaining days
                rentFee = (totalWeeks * vehicleRatePerWeek) + (vehicleRatePerDay * mod) + (totalDays * driverRate);
            }

            // If total day are more than 30 then do per month calculation
            else if (totalDays >= 30)
            {
                // Get remaing days after months
                float monthMod = totalDays % 30;
                // Get remaing weeks from remaing days
                float weekMod = monthMod / 7;
                // Get total months
                float totalMonths = (totalDays - monthMod) / 30;
                //Get total weeks
                float totalWeeks = (monthMod - weekMod) / 7;
                //Calculate rend per months, weeks and days
                rentFee = (totalMonths * vehicleRatePerMonth) + (vehicleRatePerWeek * totalWeeks) + (vehicleRatePerDay * weekMod) + (totalDays * driverRate);
            }
            frm3_txtBox2.Text = String.Format("{0:0.00}", rentFee);
        }


        // Insert data records of rent details
        private void frm3_addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Write a query to add data to rent data table
                string query = "INSERT INTO Rent (RentID, VehicleID, HireDriver, DriverID, RentDate, ReturnDate, RentAmount) VALUES ('" + frm3_txtBox1.Text + "','" + frm3_cmbBox1.SelectedItem.ToString() + "','" +frm3_cmbBox2.SelectedItem.ToString() + "', '" + frm3_cmbBox3.SelectedItem.ToString() + "', '" + dateTimePicker1.Value.ToString() + "', '" + dateTimePicker2.Value.ToString() + "', '" + frm3_txtBox2.Text + "')";
                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                runQuery.ExecuteNonQuery();
                MessageBox.Show("Data added Succesfully!");
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Data didn't added to the system...!");
            }
            clear();
        }


        // Write a query to read existing data records from data table
        private void frm3_showBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Rent WHERE RentID = '" + frm3_txtBox1.Text + "'";

                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                while (read.Read())
                {
                    frm3_cmbBox1.Text = read[1].ToString();
                    frm3_cmbBox2.Text = read[2].ToString();
                    frm3_cmbBox3.Text = read[3].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(read[4]);
                    dateTimePicker2.Value = Convert.ToDateTime(read[5]);
                    frm3_txtBox2.Text = read[6].ToString();
                }
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Press Show Button Again ...!");
            }
        }


        // Update exisiting data records of rent data table
        private void frm3_UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Rent SET VehicleID = '" + frm3_cmbBox1.SelectedItem.ToString() + "', HireDriver = '"+frm3_cmbBox2.SelectedItem.ToString()+ "', DriverID = '" + frm3_cmbBox3.SelectedItem.ToString() + "', RentDate = '" + dateTimePicker1.Value.ToString() + "', ReturnDate = '" + dateTimePicker2.Value.ToString() + "', RentAmount = '" + frm3_txtBox2.Text + "' WHERE RentID = '" + frm3_txtBox1.Text + "'";

                con = new SqlConnection(conString);
                con.Open();
                runQuery = new SqlCommand(query, con);
                runQuery.ExecuteNonQuery();
                MessageBox.Show("Data updated successfully!");
                con.Close();
            }
            catch (System.Exception ex)
            {
                throw;
            }
            clear();

        }


        // Deleting data records from rent data table
        private void frm3_DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Rent WHERE RentID = '" + frm3_txtBox1.Text + "'";
                con = new SqlConnection(conString);
                con.Open();
                runQuery = new SqlCommand(query, con);
                runQuery.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Succesfully!");
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            clear();
        }


        // Call clear funtion to clear text box data
        private void frm3_BtnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        // Create function to clear data of text boxes
        void clear()
        {
            frm3_txtBox1.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            frm3_txtBox2.Clear();
            frm3_cmbBox1.ResetText();
            frm3_cmbBox2.ResetText();
            frm3_cmbBox3.ResetText();
        }

        // If exit button click system pop up first form
        private void frm3_exitBtn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}




