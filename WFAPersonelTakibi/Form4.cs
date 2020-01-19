using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using WFAPersonelTakibi.Data;
using WFAPersonelTakibi.Enums;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form4 : MetroForm
    {


        public Form4()
        {
            InitializeComponent();
        }

        //public Form4(Employee employee) : this()
        //{
        //    this.employee = employee;
        //}


        private Guid id;
        public Form4(Guid id) : this()
        {
            this.id = id;
        }

        ProjectContext db = new ProjectContext();

        private Employee employee;
        private void Form4_Load(object sender, EventArgs e)
        {

            employee = db.Employees.Find(id);

            cmbDepartment.DataSource = db.Departments.ToList();
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.DisplayMember = "Name";


            txtAddress.Text = employee.Address;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtMail.Text = employee.Mail;
            txtPhone.Text = employee.Phone;
            dtBirthDate.Value = employee.BirthDate;
            cmbDepartment.SelectedValue = employee.DepartmentId;

            MetroRadioButton gender = (MetroRadioButton)Controls.Find("rd" + employee.Gender, true)[0];
            gender.Checked = true;
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.BirthDate = dtBirthDate.Value;
            employee.Address = txtAddress.Text;
            employee.Mail = txtMail.Text;
            employee.Phone = txtPhone.Text;
            employee.DepartmentId = (Guid)cmbDepartment.SelectedValue;

            foreach (Control item in metroPanel1.Controls)
            {
                if (item is MetroRadioButton)
                {
                    MetroRadioButton rd = (MetroRadioButton)item;
                    if (rd.Checked)
                    {
                        employee.Gender = (Gender)Enum.Parse(typeof(Gender), rd.Text);
                    }
                }
            }
             
            bool result = false;
            try
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified; 
                result = db.SaveChanges() > 0; 
            }
            catch
            {
                result = false;
            }

            DialogResult dr = MetroMessageBox.Show(
                          this,
                          result ? "Kayıt Güncellendi" : "Kayıt Güncelleme İşlemi Hatası",
                          "Kayıt Güncelleme Bildirimi",
                          MessageBoxButtons.OK,
                          result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (dr == DialogResult.OK && result)
            {
                Form2 frm = new Form2();
                this.Hide();
                frm.ShowDialog();
                return;
            }
        }
    }
}


//if (result)
//{
//    Form2 frm = new Form2();
//    this.Hide();
//    frm.ShowDialog();
//    return;
//}
//else
//    MetroMessageBox.Show(
//                         this,
//                         result ? "Kayıt Güncellendi" : "Kayıt Güncelleme İşlemi Hatası",
//                         "Kayıt Güncelleme Bildirimi",
//                         MessageBoxButtons.OK,
//                         result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
