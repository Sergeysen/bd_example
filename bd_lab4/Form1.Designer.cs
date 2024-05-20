namespace bd_lab4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPageEnterprise = new TabPage();
            buttonCreate = new Button();
            buttonDelete = new Button();
            textBoxName = new TextBox();
            textBoxFax = new TextBox();
            textBoxPhone = new TextBox();
            textBoxAdress = new TextBox();
            label7 = new Label();
            comboBoxRegNumber = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBoxFormsOfOwnership = new ComboBox();
            comboBoxIndustry = new ComboBox();
            buttonUpdate = new Button();
            dataGridView1 = new DataGridView();
            buttonSelect = new Button();
            Menu = new TabControl();
            tabPageEnterprise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Menu.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageEnterprise
            // 
            tabPageEnterprise.Controls.Add(buttonCreate);
            tabPageEnterprise.Controls.Add(buttonDelete);
            tabPageEnterprise.Controls.Add(textBoxName);
            tabPageEnterprise.Controls.Add(textBoxFax);
            tabPageEnterprise.Controls.Add(textBoxPhone);
            tabPageEnterprise.Controls.Add(textBoxAdress);
            tabPageEnterprise.Controls.Add(label7);
            tabPageEnterprise.Controls.Add(comboBoxRegNumber);
            tabPageEnterprise.Controls.Add(label6);
            tabPageEnterprise.Controls.Add(label5);
            tabPageEnterprise.Controls.Add(label4);
            tabPageEnterprise.Controls.Add(label3);
            tabPageEnterprise.Controls.Add(label2);
            tabPageEnterprise.Controls.Add(label1);
            tabPageEnterprise.Controls.Add(comboBoxFormsOfOwnership);
            tabPageEnterprise.Controls.Add(comboBoxIndustry);
            tabPageEnterprise.Controls.Add(buttonUpdate);
            tabPageEnterprise.Controls.Add(dataGridView1);
            tabPageEnterprise.Controls.Add(buttonSelect);
            tabPageEnterprise.Location = new Point(4, 24);
            tabPageEnterprise.Name = "tabPageEnterprise";
            tabPageEnterprise.Padding = new Padding(3);
            tabPageEnterprise.Size = new Size(794, 417);
            tabPageEnterprise.TabIndex = 0;
            tabPageEnterprise.Text = "Предприятие";
            tabPageEnterprise.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(191, 297);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 19;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(95, 297);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 18;
            buttonDelete.Text = "Удаление";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(549, 256);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 17;
            // 
            // textBoxFax
            // 
            textBoxFax.Location = new Point(443, 256);
            textBoxFax.Name = "textBoxFax";
            textBoxFax.Size = new Size(100, 23);
            textBoxFax.TabIndex = 13;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(334, 256);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(100, 23);
            textBoxPhone.TabIndex = 11;
            // 
            // textBoxAdress
            // 
            textBoxAdress.Location = new Point(228, 256);
            textBoxAdress.Name = "textBoxAdress";
            textBoxAdress.Size = new Size(100, 23);
            textBoxAdress.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(549, 238);
            label7.Name = "label7";
            label7.Size = new Size(106, 15);
            label7.TabIndex = 16;
            label7.Text = "Укажите название";
            // 
            // comboBoxRegNumber
            // 
            comboBoxRegNumber.FormattingEnabled = true;
            comboBoxRegNumber.Location = new Point(8, 256);
            comboBoxRegNumber.Name = "comboBoxRegNumber";
            comboBoxRegNumber.Size = new Size(121, 23);
            comboBoxRegNumber.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(443, 238);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 14;
            label6.Text = "Укажите факс";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(334, 238);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 12;
            label5.Text = "Укажите телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 238);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 9;
            label4.Text = "Укажите адрес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 238);
            label3.Name = "label3";
            label3.Size = new Size(203, 15);
            label3.TabIndex = 8;
            label3.Text = "Выберите регистрационный номер";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 155);
            label2.Name = "label2";
            label2.Size = new Size(243, 15);
            label2.TabIndex = 7;
            label2.Text = "Выберите название формы собственности";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 155);
            label1.Name = "label1";
            label1.Size = new Size(162, 15);
            label1.TabIndex = 6;
            label1.Text = "Выберите название отрасли";
            // 
            // comboBoxFormsOfOwnership
            // 
            comboBoxFormsOfOwnership.FormattingEnabled = true;
            comboBoxFormsOfOwnership.Location = new Point(300, 173);
            comboBoxFormsOfOwnership.Name = "comboBoxFormsOfOwnership";
            comboBoxFormsOfOwnership.Size = new Size(248, 23);
            comboBoxFormsOfOwnership.TabIndex = 5;
            // 
            // comboBoxIndustry
            // 
            comboBoxIndustry.Location = new Point(8, 173);
            comboBoxIndustry.Name = "comboBoxIndustry";
            comboBoxIndustry.Size = new Size(258, 23);
            comboBoxIndustry.TabIndex = 4;
            comboBoxIndustry.SelectedIndexChanged += comboBoxIndustry_SelectedIndexChanged;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(8, 297);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(740, 150);
            dataGridView1.TabIndex = 1;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(482, 297);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 0;
            buttonSelect.Text = "Вывод";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click_1;
            // 
            // Menu
            // 
            Menu.Controls.Add(tabPageEnterprise);
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.SelectedIndex = 0;
            Menu.Size = new Size(802, 445);
            Menu.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Menu);
            Name = "Form1";
            Text = "Гуськов Лабораторная";
            Load += Form1_Load;
            tabPageEnterprise.ResumeLayout(false);
            tabPageEnterprise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPageEnterprise;
        private Button buttonCreate;
        private Button buttonDelete;
        private TextBox textBoxName;
        private TextBox textBoxFax;
        private TextBox textBoxPhone;
        private TextBox textBoxAdress;
        private Label label7;
        private ComboBox comboBoxRegNumber;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxFormsOfOwnership;
        private ComboBox comboBoxIndustry;
        private Button buttonUpdate;
        private DataGridView dataGridView1;
        private Button buttonSelect;
        private TabControl Menu;
    }
}