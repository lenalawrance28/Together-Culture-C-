using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Software_Engineering1
{
    public partial class DashboardForm : Form
    {
        private string connectionString = "server=localhost;database=theevents;uid=root;pwd=;";
        public DashboardForm()
        {
            InitializeComponent();
            DisplayMemberCount();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EventForm form1 = new EventForm();
            form1.Show();

            this.Hide();
        }


        private void DisplayMemberCount()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        int memberCount = Convert.ToInt32(command.ExecuteScalar());
                        label4.Text = $"{memberCount}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving member count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public static class LoggedInUser
        {
            private static string _username = "Guest";
            private static bool _isLoggedIn = false;
            public static string Username
            {
                get => _username;
                set => _username = value;
            }


            public static bool IsLoggedIn
            {
                get => _isLoggedIn;
                set => _isLoggedIn = value;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

            LoggedInUser.Username = "Guest";
            LoggedInUser.IsLoggedIn = false;

            LoginForm form5 = new LoginForm();
            this.Hide();
            form5.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            //LoggedInUser.Username = "Guest";
            //LoggedInUser.IsLoggedIn = false;

            //Form5 form5 = new Form5();
            //this.Hide();
            //form5.Show();
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label2.Text = $"{LoggedInUser.Username}";
            label8.Visible = LoggedInUser.IsLoggedIn;

        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            feedbackForm feedbackForm = new feedbackForm();
            feedbackForm.Show();


        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm();
            eventForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            membershipForm membershipForm = new membershipForm();
            membershipForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            membershipForm membershipForm = new membershipForm();
            membershipForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            string currentUsername = LoggedInUser.Username;
            ProfilePage profilePage = new ProfilePage(currentUsername);
            profilePage.Show();
        }
    }
}
