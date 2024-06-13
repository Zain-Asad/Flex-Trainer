using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        bool signup = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!signup)
            {
                signup = true;
                MemberSignupForm form = new MemberSignupForm();
                form.Show();
                this.Hide();
                form.FormClosed += MemberSignupFormForm_FormClosed;
            }
        }
        private void MemberSignupFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            signup = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!signup)
            {
                signup = true;
                TrainerSignupForm form = new TrainerSignupForm();
                form.Show();
                this.Hide();
                form.FormClosed += TrainerSignupFormForm_FormClosed;
            }
        }
        private void TrainerSignupFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            signup = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!signup)
            {
                signup = true;
                GymOwnerSignupForm form = new GymOwnerSignupForm();
                form.Show();
                this.Hide();
                form.FormClosed += GymOwnerSignupFormForm_FormClosed;
            }
        }
        private void GymOwnerSignupFormForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            this.Show();
            signup=false;
        }
    }
}
