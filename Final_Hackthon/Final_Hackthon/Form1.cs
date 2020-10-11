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

namespace Final_Hackthon
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string syntax = "Select Heart_Rate,Tme_Min from symptoms_info";
            cmd = new SqlCommand(syntax,con);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                this.chart1.Series["Series2"].Points.AddXY(dr.GetInt32(1), dr.GetInt32(0));
                chart1.ChartAreas[0].AxisX.Title = "Time_Mins";
                chart1.ChartAreas[0].AxisY.Title = "Heart_Rate";

                
            }
            con.Close();

            con.Open();
            SqlCommand cmd1;
            SqlDataReader dr1;
            string syntax1 = "Select AVG(Heart_Rate) from symptoms_info";
            cmd1 = new SqlCommand(syntax1, con);
            dr1 = cmd1.ExecuteReader();
            dr1.Read();
            solidGauge1.Value = dr1.GetInt32(0);
            if(dr1.GetInt32(0) > 100)
            {
                textBox4.Text = "!!!HEART-TYCARDI0 !!";
            }
            else
            {
                textBox4.Text = " Healthy HEART";
            }
            con.Close();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)     // average blood pressure
        {
            con.Open();
            string syntax = "Select AVG(Blood_Pressure) from symptoms_info";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            int temp = dr.GetInt32(0);
            if(temp > 120)
            {
                textBox5.Text = "!! HIGH BLOOD PRESSURE !!";
            }
            else if(temp < 80)
            {
                textBox5.Text = "!! LOW BLOOD PRESSURE !!";
            }
            else
            {
                textBox5.Text = " STABLE BLOOD PRESSURE";
            }
            con.Close();
            solidGauge2.Value = temp;
            angularGauge1.Value = temp;
        }

        private void button4_Click(object sender, EventArgs e)            // height,weight,BMI
        {
            con.Open();
            string syntax = "Select Height, Weight from Person_Info where Id=4";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            int temp, temp1;
            while(dr.Read())
            {
                textBox1.Text = dr.GetInt32(0).ToString();
                textBox2.Text = dr.GetInt32(1).ToString();
            }
            con.Close();
            temp = int.Parse(textBox1.Text);
            temp1 = int.Parse(textBox2.Text);
            Double bmi;
            float j;
            j = (temp/100);
            Double k = j*j;
            int p = temp1;
            bmi = (p/k);
            if(bmi > 39.5)
            {
                textBox6.Text = "!! OBESSE CLASS !!";
            }
            else if(bmi < 19)
            {
                textBox6.Text = "!! WEAK !!";
            }
            else
            {
                textBox6.Text = "FIT BODY";
            }
            textBox3.Text = bmi.ToString("N");
            
        }

        private void button5_Click(object sender, EventArgs e)     // body temperature
        {
            solidGauge4.Value = 36;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string syntax = "select SUM(Steps) from symptoms_info";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            solidGauge3.Value = dr.GetInt32(0);
            con.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string syntax = "Select Respiratory,Tme_Min from symptoms_info";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.chart2.Series["Series1"].Points.AddXY(dr.GetInt32(1), dr.GetInt32(0));
                chart2.ChartAreas[0].AxisX.Title = "Time_Mins";
                chart2.ChartAreas[0].AxisY.Title = "Breath_Rate";


            }
            con.Close();

            con.Open();
            SqlCommand cmd1;
            SqlDataReader dr1;
            string syntax1 = "Select AVG(Respiratory) from symptoms_info";
            cmd1 = new SqlCommand(syntax1, con);
            dr1 = cmd1.ExecuteReader();
            dr1.Read();
            solidGauge5.Value = dr1.GetInt32(0);
            angularGauge2.Value = dr1.GetInt32(0);
            if(dr1.GetInt32(0) < 12)
            {
                textBox7.Text = "!! LOW BREATH RATE !!";
            }
            else if (dr1.GetInt32(0) > 25)
            {
                textBox7.Text = "!! HIGH BREATH RATE !!";
            }
            else
            {
                textBox7.Text = " NORMAL BREATH RATE";
            }
            con.Close();


        }
    }
}
