using MetroFramework.Forms;
using System;
using System.Drawing;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form3 : MetroForm
    {


        public Form3()
        {
            InitializeComponent();
        }

        private Employee employee;
        public Form3(Employee employee) : this()
        {
            this.employee = employee;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblMail.Text = employee.Mail;
            lblPhone.Text = employee.Phone;
            lblAddress.Text = employee.Address;
            lblLastName.Text = employee.LastName;
            lblFirstName.Text = employee.FirstName;
            lblGender.Text = employee.Gender.ToString();
            lblDepartment.Text = employee.Department.Name;
            lblBirthDate.Text = employee.BirthDate.ToString();

            //pcbImageUrl.Image = Image.FromFile(employee.ImageUrl);
        }
    }
}
