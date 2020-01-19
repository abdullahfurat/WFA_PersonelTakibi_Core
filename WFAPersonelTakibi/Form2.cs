using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WFAPersonelTakibi.Data;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();

        void PersonelListesi()
        {
            dgvEmployees.DataSource = db.Employees.Select(x => new
            {

                x.Id,
                x.FirstName,
                x.LastName,
                x.Mail,
                x.Phone,
                x.Department.Name
            }).ToList();
        }

        void PersonelListesi(Guid? id)
        {
            dgvEmployees.DataSource = db.Employees.Where(x => x.DepartmentId == id).Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.Mail,
                x.Phone,
                x.Department.Name
            }).ToList();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = db.Departments.ToList();
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.SelectedIndex = -1;

            PersonelListesi();
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Guid? id = (Guid)cmbDepartment.SelectedValue;
            if (id.HasValue)
            {
                PersonelListesi(id);
            }
        }

        private void tsmDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var id =(Guid) dgvEmployees.SelectedRows[0].Cells[0].Value;
                Form4 frm = new Form4(id);
                this.Hide();
                frm.ShowDialog();



                //Employee employee = db.Employees.Find(id);
                //if (employee != null)
                //{
                //    //Form4 frm = new Form4(employee);
                //    Form4 frm = new Form4(id);
                //    this.Hide();
                //    frm.ShowDialog();
                //}
            }
        }




        private void tsmSil_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var id = dgvEmployees.SelectedRows[0].Cells[0].Value;

                Employee employee = db.Employees.Find(id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    bool result = db.SaveChanges() > 0;

                    if (result)
                    {
                        if (cmbDepartment.SelectedIndex != -1) // Kullanıcı departman seçerek personel silme işlemi yapmıştır
                        {
                            id = cmbDepartment.SelectedValue;
                            PersonelListesi((Guid)id);
                        }
                        else // Kullanıcı departman bazlı Filtre yapmadan personel silme işlemi yapmıştır.
                        {
                            PersonelListesi();
                        }
                    }
                    //return;
                }
            }
            else
                MetroMessageBox.Show(this, "Lütfen silinecek personel seçiniz!", "Kayıt Silme Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmYeni_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }

        private void tsmDetay_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Lütfen personel seçiniz!", "Kayıt Deyat Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Guid? id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;

            if (id.HasValue)
            {
                Employee employee = db.Employees.Find(id);
                if (employee != null)
                {
                    Form3 frm = new Form3(employee);
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }
    }
}


