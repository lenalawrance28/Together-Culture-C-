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
using static Software_Engineering1.DashboardForm;

namespace Software_Engineering1
{
    public partial class membershipForm : Form
    {
        string connectionString = "server=localhost;database=theevents;uid=root;pwd=;";
        public membershipForm()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.Show();
            this.Hide();

           
        }

        private void membershipForm_Load(object sender, EventArgs e)
        {
            label18.Text = $"{LoggedInUser.Username}";
        }

        private void button5_Click(object sender, EventArgs e)
        {

            AddMembership("Community Members");
        }

        private void AddMembership(string membershipType)
        {
            string username = LoggedInUser.Username;
           
            if (username == "Guest")
            {
                MessageBox.Show("Please log in to update membership.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET MembershipType = @MembershipType WHERE Username = @Username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MembershipType", membershipType);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{username} Has Joined {membershipType} Sucessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"No user found with username '{username}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddMembership("Key Access Members");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddMembership("Creative Workspace Members");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventForm form1 = new EventForm();
            form1.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close();
        }
    }
}
