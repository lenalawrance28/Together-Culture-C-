using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Software_Engineering1.Class1;
using static Software_Engineering1.DashboardForm;


namespace Software_Engineering1
{
    public partial class BookingForm : Form
    {
        
        private string EventName;
        private string EventDescription;
        private DateTime EventDate;

        public BookingForm()
        {
            InitializeComponent();
        }
        public BookingForm(int eventid, string eventname, string eventdescription, DateTime eventdate)
        {
            
            
            EventName = eventname;
            EventDescription = eventdescription;
            EventDate = eventdate;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
          
        
            //label1.Text = $"{EventName}";
            //label14.Text = $"Event Date: {EventDate:yyyy-MM-dd}";
            //label4.Text = EventDescription;
            //label4.MaximumSize = new Size(300, 0); // 300 pixels wide, unlimited height
        

        }

    
        private void label8_Click(object sender, EventArgs e)
        {

        }

        public static class SharedData
        {
            public static string LoggedInUser { get; set; }
        }
    

        private void button7_Click(object sender, EventArgs e)
        {
            string username = LoggedInUser.Username;
            string eventName = label1.Text;
            string guestName = textBox1.Text;
            string guestEmail = textBox2.Text;
            int ticketCount = (int)numericUpDown1.Value;
            Class1.BookingHelper.BookTicket( username, eventName, guestName, guestEmail, ticketCount);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        internal void LoadEventDetail(String eventname)
        {
            var eventDetails = BookingHelper.RetrieveEvent(eventname);
            if (eventDetails != null)
            {

                //lblEventName.Text = $"Name: {eventDetails.EventName}";
                //lblEventDescription.Text = $"Description: {eventDetails.EventDescription}";
                //lblEventDate.Text = $"Date: {eventDetails.EventDate.ToShortDateString()}";
                //lblEventTime.Text = $"Time: {eventDetails.EventTime}";

                label1.Text = $"{eventDetails.EventName}";
                label14.Text = $"Date: {eventDetails.EventDate.ToShortDateString()}";
                label4.Text = $"Description: {eventDetails.EventDescription}";
                //label4.MaximumSize = new Size(300, 0); // 300 pixels wide, unlimited height
            }
            else
            {
                MessageBox.Show("Event not found.");
            }

        }




    }
}
