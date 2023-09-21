using System;
using System.Windows.Forms;

namespace BT_CaNhan1
{
    public partial class Form2 : Form
    {
        public Form1 mainForm;
        public Form2()
        {
            InitializeComponent();
            cmbFaculty.SelectedIndex = 0;
        }

        private bool isValidData()
        {
            if (txtId.Text != "" && txtName.Text != "" && txtScore.Text != "" && cmbFaculty.SelectedIndex >= 0)
            {
                return true;
            }
            return false;
        }

        private bool isValidScore()
        {
            if (txtScore.Text.Contains(","))
                return false;

            bool valid = float.TryParse(txtScore.Text,out float result);
            if (valid)
            {
                float score = float.Parse(txtScore.Text);
                if (score < 0 || score > 10)
                    return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidData())
                    throw new Exception("Vui lòng nhập đầy đủ thông tin.");
                if (!mainForm.isNotExistId(txtId.Text))
                    throw new Exception("MSSV đã tồn tại");
                if (!isValidScore())
                    throw new Exception("Điểm số không hợp lệ.");

                mainForm.addItemToList(txtId.Text, txtName.Text, cmbFaculty.SelectedItem.ToString(), txtScore.Text);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
