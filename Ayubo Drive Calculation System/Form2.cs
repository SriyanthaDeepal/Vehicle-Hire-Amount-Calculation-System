/*  Name: Adding Vehicle to System
    Date of creation: 2022/02/24
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FillCombo();
            ShowDataInGrid();
        }

        //Creating Databse Connection
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AyubooDrive;Integrated Security=True";
        SqlConnection con;
        SqlCommand runQuery;
        SqlDataReader read;
        SqlDataAdapter dataadapter;
        DataSet ds;
        DataTable dataTable;


        //Define a function to add item into combo box
        void FillCombo()
        {
            string query = "SELECT VehicleTypeID FROM VehicleType;";
            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            while (read.Read())
            {
                string typeID = Convert.ToString(read["VehicleTypeID"]);
                frm2_cmbBox.Items.Add(typeID);
            }
            read.Close();
            con.Close();
        }
        
     

        private void frm2_showBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Vehicle WHERE VehicleID = '" + frm2_txtBox1.Text + "'";

                con = new SqlConnection(conString);
                runQuery = new SqlCommand(query, con);
                con.Open();
                read = runQuery.ExecuteReader();
                while (read.Read())
                {
                    frm2_cmbBox.Text = read[1].ToString();
                    frm2_txtBox4.Text = read[2].ToString();
                    frm2_txtBox5.Text = read[3].ToString();
                    frm2_dateTimePicker1.Value = Convert.ToDateTime(read[4].ToString());
                    
                }
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Adding new data records to database
        private void frm2_addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Vehicle (VehicleID, VehicleTypeID, RegistrationNumber, Brand, RegistrationDate ) VALUES ('" + frm2_txtBox1.Text + "','" + frm2_cmbBox.SelectedItem.ToString() + "','" + frm2_txtBox4.Text + "', '" + frm2_txtBox5.Text + "', '" + frm2_dateTimePicker1.Value.ToString() + "')";
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
        
        // Show data using selected items in combo box
        void frm2_cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM VehicleType WHERE VehicleTypeID = '" + frm2_cmbBox.SelectedItem.ToString() + "'";

            con = new SqlConnection(conString);
            runQuery = new SqlCommand(query, con);
            con.Open();
            read = runQuery.ExecuteReader();
            while (read.Read())
            {
                frm2_txtBox3.Text = read[1].ToString();
            }
            con.Close();
        }
        
        // When exit buttion click application form move to first form
        private void frm2_exitBtn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        // Create a function to clear data in textboxes
        void clear()
        {
            frm2_txtBox1.Clear();
            frm2_txtBox3.Clear();
            frm2_txtBox4.Clear();
            frm2_txtBox5.Clear();
            
        }

        // Create function show data in datagrid view
        void ShowDataInGrid()
        {
            try
            {
                string query = "SELECT * FROM Vehicle";
                con = new SqlConnection(conString);
                dataadapter = new SqlDataAdapter(query, con);
                ds = new DataSet();
                con.Open();
                dataadapter.Fill(ds, "Vehicle");
                con.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Vehicle";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        // When refresh button click, datagrid view updated
        private void frm2_BtnRefresh_Click(object sender, EventArgs e)
        {
            ShowDataInGrid();
        }

        // When update button clicked, update existing data records
        private void frm2_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Vehicle SET VehicleTypeID = '" + frm2_cmbBox.SelectedItem.ToString() + "', RegistrationNumber = '" + frm2_txtBox4.Text + "',Brand = '" + frm2_txtBox5.Text + "', RegistrationDate = '" + frm2_dateTimePicker1.Value.ToString() + "', VehicleTypeID = '" + frm2_cmbBox.SelectedItem.ToString() + "' WHERE VehicleID = '" + frm2_txtBox1.Text + "'";

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


        // Data records deleting by press delete button
        private void frm2_btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Vehicle WHERE VehicleID = '" + frm2_txtBox1.Text + "'";
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
