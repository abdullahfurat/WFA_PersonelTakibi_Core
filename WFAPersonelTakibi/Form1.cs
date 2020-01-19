using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WFAPersonelTakibi.Data;
using WFAPersonelTakibi.Enums;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        void ClearForm(Control cls)
        {

            foreach (Control control in cls.Controls)
            {
                if (control is MetroTextBox)
                {
                    control.Text = "";
                }
                else if (control is TextBox)
                {
                    control.Text = "";
                }
                else if (control is MetroDateTime)
                {
                    MetroDateTime dt = (MetroDateTime)control;
                    dt.Value = DateTime.Now;
                }
                else if (control is MetroComboBox)
                {
                    MetroComboBox cmb = (MetroComboBox)control;
                    cmb.SelectedIndex = -1;
                }
                else if (control is PictureBox)
                {
                    PictureBox pcb = (PictureBox)control; 
                    foreach (Control item in metroPanel1.Controls)
                    {
                        if (item is MetroRadioButton)
                        {
                            MetroRadioButton rd = (MetroRadioButton)item;
                            pcb.Image = Image.FromFile(Environment.CurrentDirectory + $@"\..\..\Images\{rd.Name.ToLower().Replace("rd", "")}.jpg");
                        }
                    }

                }
                else if(control is GroupBox)
                {
                    GroupBox grb = (GroupBox)control;
                    ClearForm(grb);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = db.Departments.ToList();
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.DisplayMember = "Name";

            foreach (Control item in metroPanel1.Controls)
            {
                if (item is MetroRadioButton)
                {
                    MetroRadioButton rd = (MetroRadioButton)item;
                    pcbImageUrl.Image = Image.FromFile(Environment.CurrentDirectory + $@"\..\..\Images\{rd.Name.ToLower().Replace("rd", "")}.jpg");
                }
            }
        }




        ProjectContext db = new ProjectContext();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Lütfen Departman Seçiniz!", "Kayıt Ekleme Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee employee = new Employee();
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

            // Resim Seçme 

            db.Employees.Add(employee);
            bool result = db.SaveChanges() > 0;
            MetroMessageBox.Show(
                this,
                result ? "Kayıt Başarıyla Eklendi" : "Kayıt Ekleme İşlemi Hatası",
                "Kayıt Ekleme Bildirimi",
                MessageBoxButtons.OK,
                result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            ClearForm(this);
        }

        private void pcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbImageUrl.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            MetroRadioButton rd = (MetroRadioButton)sender;
            pcbImageUrl.Image = Image.FromFile(Environment.CurrentDirectory + $@"\..\..\Images\{rd.Name.ToLower().Replace("rd", "")}.jpg");
        }
    }
}