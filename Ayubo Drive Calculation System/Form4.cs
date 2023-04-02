/*  Name: Vehicle Hiring Calculation
    Date of creation: 2022/02/27
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            showGridView1();
            showGridView2();
            fillPackageID();
            fillDriverID();
     
        }


        //Creating Databse Connection
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AyubooDrive;Integrated Security=True";
        SqlConnection con;
        SqlCommand runQuery;
        SqlDataReader read;
        SqlDataAdapter dataadapter;
        DataSet ds;
        DataTable dataTable;


        // Declare variable for derive values from database and calculations
        float driverFee;
        float overNightDriverCharge;
        float standardRate;
        float maximumKM;
        float maximumHours;
        float waitingCharges;
        float startKm;
        float endKm;
        float numOfDays;
        float tDif;
        float hireAmount;
        TimeSpan startTime;
        TimeSpan endTime;
        TimeSpan timeDifference;

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        // Start up window will pop up when exit button click
        private void frm4_BtnExit_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        // Show data of hiring packages from data grid 01
        void showGridView1()
        {
            try
            {
                // write a query to retrieve all packages data into data grid
                string query = "SELECT * FROM HirePackages";
                con = new SqlConnection(conString);
                dataadapter = new SqlDataAdapter(query, con);
                ds = new DataSet();
                con.Open();
                dataadapter.Fill(ds, "HirePackages");
                con.Close();
                frm4_dataGridView1.DataSource = ds;
                frm4_dataGridView1.DataMember = "HirePackages";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        // Show data of vehicle types from data grid 02
        void showGridView2()
        {
            try
            {
                // write a query to retrieve all vehicle into data grid 2
                string query = "SELECT * FROM VehicleType";
                con = new SqlConnection(conString);
                dataadapter = new SqlDataAdapter(query, con);
                ds = new DataSet();
                con.Open();
                dataadapter.Fill(ds, "VehicleType");
                con.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "VehicleType";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        // Create a function to add items to package ids combo box
        void fillPackageID()
        {
            {
                // Write a query to retrieve data from hire packages table
                string query = "SELECT PackageID FROM HirePackages;";
                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                // Read each package id and add them as item to combo box
                while (read.Read())
                {
                    string packageID = Convert.ToString(read["PackageID"]);
                    frm4_cmbBox1.Items.Add(packageID);
                }
                read.Close();
                con.Close();
            }
        }

        // Create a function to add items to driver ids combo box
        void fillDriverID()
        {
            {
                // Write a query to retrieve data from driver datatable
                string query = "SELECT DriverID FROM Driver;";
                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                // Read each driver Id and add them as item to combo box
                while (read.Read())
                {
                    string packageID = Convert.ToString(read["DriverID"]);
                    frm4_cmbBox2.Items.Add(packageID);
                }
                read.Close();
                con.Close();
            }
        }

        private void frm4_dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        // If package id selected, this code part executing
        private void frm4_cmbBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select data from hire package data table
            string query = "SELECT StandardRate, MaximumKm, MaximumHouse, WaitingCharges FROM HirePackages  WHERE PackageID = '" + frm4_cmbBox1.SelectedItem.ToString() + "'";

            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();

            // Read derived data and assign them to declared variables
            while (read.Read())
            {
                standardRate = float.Parse(read[0].ToString());
                maximumKM = float.Parse(read[1].ToString());
                maximumHours = float.Parse(read[2].ToString());
                waitingCharges = float.Parse(read[3].ToString());               
            }
            con.Close();
        }

        // Get time from date time picker when user add a input
        private void frm4_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            startTime = frm4_dateTimePicker1.Value.TimeOfDay;
        }

        // Get the time from datetime picker when user add a input
        private void frm4_dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {  
            endTime = frm4_dateTimePicker2.Value.TimeOfDay;  
            // After user input two time from data time pickers, calcuate difference between two time
            timeDifference = endTime - startTime;
            frm4_txtBox4.Text = standardRate.ToString();
            // Day tour function is calling when datetime picker value is changed.
            dayTour();
            
        }

        // Crete a function to calcuate day tours details 
        void dayTour()
        {
            // Get time difernce as a float
            tDif = timeDifference.Hours;
            // If time difference is greater than maxium hours of the package execute following code
            if (tDif > maximumHours)
            {
                // Get additional hourse by substract maximum hourse from time difference
                float waitHours = tDif - maximumHours;
                // Calcuate wait charges according to additional waiting hours
                float waitCharge = (waitHours * waitingCharges);
                // Calculate hire amount
                hireAmount = waitCharge + standardRate + driverFee;
                frm4_txtBox1.Text = hireAmount.ToString();
                frm4_txtBox5.Text = waitCharge.ToString();
            }
            // If time difference is not greater than maximum hourse, the following code executing
            else
            {
                // Calculate hire amount according to user need
                hireAmount = standardRate + driverFee;
                frm4_txtBox1.Text = hireAmount.ToString();
            }

            frm4_txtBox8.Text = hireAmount.ToString();
            frm4_txtBox10.Text = driverFee.ToString();
        }

        // Create a function to calculate long tours details
        void longTour()
        {
            // If text box give a empty input for convert to float, it assign zeros for stop occuring exception errors
            if (frm4_txtBox2.Text == "" || frm4_txtBox3.Text =="" || frm4_txtBox9.Text == "")
            {
                numOfDays = 0;
                startKm = 0;
                endKm = 0;    
            }
            // If text box gives a input then assign them to declared variable by converting to float
            else
            {
                numOfDays = float.Parse(frm4_txtBox9.Text, 0.00);
                startKm = float.Parse(frm4_txtBox2.Text, 0.00);
                endKm = float.Parse(frm4_txtBox3.Text, 0.00);
            }
            // Calculate Km difference
            float differKm = endKm - startKm;
            // If long tour book for 1 day following codes executing
            if (numOfDays == 1)
            {
                // If Km difference is greater than maximum allowed km then calculate extra Km charges
                if(differKm > maximumKM)
                {
                    float extraKmCharges = (differKm - maximumKM) * waitingCharges;
                    hireAmount = extraKmCharges + standardRate + driverFee;
                    frm4_txtBox7.Text = extraKmCharges.ToString();
                }
                // If km difference is not greater than maximum allowed km then is not calculate extra Km charges
                else
                {
                    hireAmount = standardRate + driverFee;
                }
                frm4_txtBox4.Text = standardRate.ToString();
                frm4_txtBox8.Text = hireAmount.ToString();
                frm4_txtBox10.Text = driverFee.ToString();

            }

            else
            {
                // If hiring day are more than 1 then calculate over night charges and output charges to users
                float standCharge = standardRate * numOfDays;
                float overNight = numOfDays * 400;
                float overNightDriveCharge = overNightDriverCharge * numOfDays;
                float overNightCharges = overNight + overNightDriveCharge;
                hireAmount = standCharge + overNight + overNightDriveCharge;
                frm4_txtBox4.Text = standCharge.ToString();
                frm4_txtBox6.Text = overNightCharges.ToString();
                frm4_txtBox8.Text = hireAmount.ToString();
                frm4_txtBox10.Text = overNightDriveCharge.ToString();

            }
        }

        // Create a function to text items of textboxes and combo boxes
        void clear()
        {
            frm4_cmbBox1.ResetText();
            frm4_cmbBox2.ResetText();
            frm4_cmbBox3.ResetText();
            frm4_txtBox1.Clear();
            frm4_txtBox2.Clear();
            frm4_txtBox3.Clear();
            frm4_txtBox4.Clear();   
            frm4_txtBox5.Clear();
            frm4_txtBox6.Clear();
            frm4_txtBox7.Clear();
            frm4_txtBox8.Clear();
            frm4_txtBox9.Clear();
            frm4_txtBox10.Clear();
        }

        // If clear button pressed clear function will called
        private void frm4_clearBtn2_Click(object sender, EventArgs e)
        {
            clear();
        }

        // When drive id is choosed by the user driver data are derived from driver datatables.
        private void frm4_cmbBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT Fee, OverNightRate FROM Driver  WHERE DriverID = '" + frm4_cmbBox2.SelectedItem.ToString() + "'";


            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            // Read derived data and assign them to declared variables
            while (read.Read())
            {
                driverFee = float.Parse(read[0].ToString());
                overNightDriverCharge = float.Parse(read[1].ToString());
            }
            con.Close();
        }

        // If last km is inputted, the long tour function will called
        private void frm4_txtBox3_TextChanged(object sender, EventArgs e)
        {
            longTour();
        }

        // Used to give a option for user to choose tour type
        private void frm4_cmbBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tourType = frm4_cmbBox3.SelectedItem.ToString();
            if (tourType == "Day Tour")
            {
                frm4_dateTimePicker1.Show();
                frm4_dateTimePicker2.Show();
                label5.Show();
                label6.Show();
                frm4_txtBox2.Hide();
                frm4_txtBox3.Hide();
                frm4_txtBox9.Hide();
                label4.Hide();
                label14.Hide();
                label15.Hide(); 
            }
            else if (tourType == "Long Tour")
            {
                frm4_txtBox2.Show();
                frm4_txtBox3.Show();
                frm4_txtBox9.Show();
                label4.Show();
                label14.Show();
                label15.Show();
                frm4_dateTimePicker1.Hide();
                frm4_dateTimePicker2.Hide();
                label5.Hide();
                label6.Hide();
            }
        }

        // When add button clicked user given inputs are record into the hire data table
        private void frm4_addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Write a query to add data to hire data table
                string query = "INSERT INTO Hire (HireID, PackageID, StartKm, EndKm, StartTime, EndTime, BaseHireCharge, WaitingCharges, OverNightStayCharges, StandardKmCharges, HireAmount ) VALUES ('" + frm4_txtBox1.Text + "','" + frm4_cmbBox1.SelectedItem.ToString() + "','" + frm4_txtBox2.Text + "', '"+frm4_txtBox3.Text+"',  '" + frm4_dateTimePicker1.Value.ToString() + "', '" + frm4_dateTimePicker2.Value.ToString() + "', '" + frm4_txtBox4.Text + "', '" + frm4_txtBox5.Text + "', '" + frm4_txtBox6.Text + "', '" + frm4_txtBox7.Text + "', '" + frm4_txtBox8.Text + "')";
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

        // When show button is clicked it derived data from database and show them to user
        private void frm4_showBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Select all data from hire data table
                string query = "SELECT * FROM Hire WHERE HireID = '" + frm4_txtBox1.Text + "'";

                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                while (read.Read())
                {
                    // Show all data to user
                    frm4_cmbBox1.Text = read[1].ToString();
                    frm4_txtBox2.Text = read[2].ToString();
                    frm4_txtBox3.Text = read[3].ToString();
                    frm4_dateTimePicker1.Value = DateTime.Parse(read[4].ToString());
                    frm4_dateTimePicker2.Value = DateTime.Parse(read[5].ToString());
                    frm4_txtBox4.Text = read[6].ToString();
                    frm4_txtBox5.Text = read[7].ToString();
                    frm4_txtBox6.Text = read[8].ToString();
                    frm4_txtBox7.Text = read[9].ToString();
                    frm4_txtBox8.Text = read[10].ToString();
                }
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Press Again Show Button..!");
            }
        }

        //when update button clicked exiciting data record update with new data
        private void frm4_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Write a query to update hire data table
                string query = "UPDATE Hire SET PackageID = '" + frm4_cmbBox1.SelectedItem.ToString() + "', StartKm = '" +frm4_txtBox2.Text + "', EndKm = '" + frm4_txtBox3.Text + "', StartTime = '" + frm4_dateTimePicker1.Value.ToString() + "', EndTime = '" + frm4_dateTimePicker2.Value.ToString() + "', BaseHireCharge = '" + frm4_txtBox4.Text + "', WaitingCharges = '"+frm4_txtBox5.Text+"', OverNightStayCharges = '"+frm4_txtBox6.Text+"', StandardKmCharges = '"+frm4_txtBox7.Text+"', HireAmount ='"+frm4_txtBox8.Text+"' WHERE HireID = '" + frm4_txtBox1.Text + "'";

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
            // Call clear function
            clear();

        }

        // When clear button click, clear function will call
        private void frm4_clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        // When delete button press, then existing records will deleted sing hire id
        private void frm4_deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Hire WHERE HireID = '" + frm4_txtBox1.Text + "'";
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
    }
}

