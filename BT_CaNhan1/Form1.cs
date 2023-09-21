using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace BT_CaNhan1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addItemToList("2180607970", "Nguyễn Lâm Sơn", "Công nghệ thông tin", "10");
            addItemToList("2180600001", "Trần Văn Abc", "Ngôn ngữ Anh", "5.5");
            addItemToList("2180601123", "Đào Thị Lcm", "Quản trị kinh doanh", "3.3");
        }

        public void addItemToList(string id, string name, string faculty, string score)
        {
            dgvStudent.Rows.Add(dgvStudent.RowCount + 1, id, name, faculty, score);
        }

        public bool isNotExistId(string id)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[1].Value.ToString() == id)
                    return false;
            }
            return true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.mainForm = this;
            form2.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.mainForm = this;
            form2.Show();
        }

        private string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }


        private void txtFindName_TextChanged(object sender, EventArgs e)
        {    
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                string name = dgvStudent.Rows[i].Cells[2].Value.ToString();
                string findName = txtFindName.Text;

                name = RemoveDiacritics(name);
                findName = RemoveDiacritics(findName);

                bool contains = name.IndexOf(findName, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    dgvStudent.Rows[i].Visible = true;
                }
                else
                {
                    dgvStudent.Rows[i].Visible = false;
                }
            }
        }
    }
}
