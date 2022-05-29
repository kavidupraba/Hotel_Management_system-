using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _10026274
{
    public partial class Form1 : Form
    {
        SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\C# Practical\10026274.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text != null)
                {
                    con.Open();

                    int ISBN = Convert.ToInt16(textBox1.Text);
                    string Name = textBox2.Text;
                    string Author = textBox3.Text;
                    string qry = "insert into Login values('" + ISBN + "','" + Name + "','" + Author + "')";
                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show($"{Name} is sucsessfully added");
                    }
                    else
                    {
                        MessageBox.Show("Somthing is Wroeng");
                    }
                    con.Close();
                    button5.PerformClick();
                }
                else
                {
                    MessageBox.Show("Plz enter your ISBN");
                }
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                con.Close();
                button5.PerformClick();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                int ISBN = Convert.ToInt16(textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter("select * from login where ISBN=' " + ISBN + " '", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                }
            
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                {
                    con.Open();

                    int ISBN = Convert.ToInt16(textBox1.Text);
                    string Name = textBox2.Text;
                    string Author = textBox3.Text;
                    string qry = "update Login set Name='"+Name+"',Author='"+Author+"' where ISBN='"+ISBN+" '";
                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show($"{Name} is sucsessfully Updated");
                    }
                    else
                    {
                        MessageBox.Show("Somthing is Wroeng");
                    }
                    con.Close();
                    button5.PerformClick();
                }
                else
                {
                    MessageBox.Show("Plz enter your ISBN");
                    button5.PerformClick();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                con.Close();
                button5.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                {
                    con.Open();

                    int ISBN = Convert.ToInt16(textBox1.Text);
                    string Name = textBox2.Text;
                    string Author = textBox3.Text;
                    string qry =" delete login where ISBN='"+ISBN+"'";
                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show($"  sucsessfully  Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Somthing is Wroeng");
                    }
                    con.Close();
                    button5.PerformClick();
                }
                else
                {
                    MessageBox.Show("Plz enter your ISBN");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                button5.PerformClick();
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
