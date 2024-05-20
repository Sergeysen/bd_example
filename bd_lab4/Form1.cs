using bd_lab4.classes;
using bd_lab4.entity;

namespace bd_lab4
{
    public partial class Form1 : Form
    {
        private int registrationNumber;
        private string name;
        private string adress;
        private string phone;
        private string fax;
        private string industy;
        private string formOfOwnership;
        public Form1()
        {
            InitializeComponent();
            FillComboBoxes();
            comboBoxRegNumber.KeyPress += new KeyPressEventHandler(comboBox_KeyPress);
            textBoxPhone.KeyPress += new KeyPressEventHandler(comboBox_KeyPress);
            textBoxFax.KeyPress += new KeyPressEventHandler(comboBox_KeyPress);
        }
        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void FillComboBoxes()
        {
            List<string> industryTypes = UseBd.GetAllIndustryTypes();
            comboBoxIndustry.Items.AddRange(industryTypes.ToArray());
            List<string> formsOfOwnership = UseBd.GetAlFormsOfOwnership();
            comboBoxFormsOfOwnership.Items.AddRange(formsOfOwnership.ToArray());
            List<Enterprise> enterprises = UseBd.GetAllEnterprises();
            foreach (Enterprise enterprise in enterprises)
            {
                comboBoxRegNumber.Items.Add(enterprise.RegistrationNumber);
            }
        }



        private void buttonSelect_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            List<Enterprise> enterprises = UseBd.GetAllEnterprises();
            dataGridView1.DataSource = enterprises;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxRegNumber.Text != "" && textBoxName.Text != "" && textBoxAdress.Text != "" && textBoxPhone.Text != "" && textBoxFax.Text != "" && comboBoxIndustry.Text != "" && comboBoxFormsOfOwnership.Text != "")
            {
                registrationNumber = Int32.Parse(comboBoxRegNumber.Text);
                name = textBoxName.Text;
                adress = textBoxAdress.Text;
                phone = textBoxPhone.Text;
                fax = textBoxFax.Text;
                industy = comboBoxIndustry.Text;
                formOfOwnership = comboBoxFormsOfOwnership.Text;
                UseBd.UpdateEnterprise(registrationNumber, name, adress, phone, fax, industy, formOfOwnership);
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxRegNumber.Text != "")
            {
                UseBd.DeleteEnterprise(Int32.Parse(comboBoxRegNumber.Text));
            }
            else
                MessageBox.Show("Необходимо выбрать номер предприятия");
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxRegNumber.Text != "" && textBoxName.Text != "" && textBoxAdress.Text != "" && textBoxPhone.Text != "" && textBoxFax.Text != "" && comboBoxIndustry.Text != "" && comboBoxFormsOfOwnership.Text != "")
            {
                registrationNumber = Int32.Parse(comboBoxRegNumber.Text);
                name = textBoxName.Text;
                adress = textBoxAdress.Text;
                phone = textBoxPhone.Text;
                fax = textBoxFax.Text;
                industy = comboBoxIndustry.Text;
                formOfOwnership = comboBoxFormsOfOwnership.Text;
                UseBd.AddNewEnterprise(name, adress, phone, fax, industy, formOfOwnership, registrationNumber);
            }
            else
                MessageBox.Show("Заполните все поля");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFormsOfOwnership.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIndustry.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void comboBoxIndustry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}