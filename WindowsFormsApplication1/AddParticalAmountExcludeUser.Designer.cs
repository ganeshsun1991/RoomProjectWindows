namespace WindowsFormsApplication1
{
    partial class AddParticalAmountExcludeUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParticalAmountExcludeUser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlUserList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescrption = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MoveFromAll = new System.Windows.Forms.Button();
            this.btnMoveFromOne = new System.Windows.Forms.Button();
            this.btnMoveToAll = new System.Windows.Forms.Button();
            this.btnMoveToOne = new System.Windows.Forms.Button();
            this.UserToList = new System.Windows.Forms.ListBox();
            this.UserFromList = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ddlUserList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 79);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(264, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exclude User & Add Amount";
            // 
            // ddlUserList
            // 
            this.ddlUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserList.FormattingEnabled = true;
            this.ddlUserList.Location = new System.Drawing.Point(633, 6);
            this.ddlUserList.Name = "ddlUserList";
            this.ddlUserList.Size = new System.Drawing.Size(127, 21);
            this.ddlUserList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(549, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access by";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescrption);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MoveFromAll);
            this.groupBox1.Controls.Add(this.btnMoveFromOne);
            this.groupBox1.Controls.Add(this.btnMoveToAll);
            this.groupBox1.Controls.Add(this.btnMoveToOne);
            this.groupBox1.Controls.Add(this.UserToList);
            this.groupBox1.Controls.Add(this.UserFromList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(4, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 357);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exclude User & Amount";
            // 
            // txtDescrption
            // 
            this.txtDescrption.Location = new System.Drawing.Point(208, 303);
            this.txtDescrption.Multiline = true;
            this.txtDescrption.Name = "txtDescrption";
            this.txtDescrption.Size = new System.Drawing.Size(162, 36);
            this.txtDescrption.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descrption";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(207, 271);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(162, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(16, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(207, 240);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(162, 22);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter the Partical Amont";
            // 
            // MoveFromAll
            // 
            this.MoveFromAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MoveFromAll.Location = new System.Drawing.Point(228, 176);
            this.MoveFromAll.Name = "MoveFromAll";
            this.MoveFromAll.Size = new System.Drawing.Size(56, 32);
            this.MoveFromAll.TabIndex = 6;
            this.MoveFromAll.Text = "<<";
            this.MoveFromAll.UseVisualStyleBackColor = true;
            this.MoveFromAll.Click += new System.EventHandler(this.MoveFromAll_Click);
            // 
            // btnMoveFromOne
            // 
            this.btnMoveFromOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMoveFromOne.Location = new System.Drawing.Point(228, 136);
            this.btnMoveFromOne.Name = "btnMoveFromOne";
            this.btnMoveFromOne.Size = new System.Drawing.Size(56, 32);
            this.btnMoveFromOne.TabIndex = 5;
            this.btnMoveFromOne.Text = "<";
            this.btnMoveFromOne.UseVisualStyleBackColor = true;
            this.btnMoveFromOne.Click += new System.EventHandler(this.btnMoveFromOne_Click);
            // 
            // btnMoveToAll
            // 
            this.btnMoveToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMoveToAll.Location = new System.Drawing.Point(230, 89);
            this.btnMoveToAll.Name = "btnMoveToAll";
            this.btnMoveToAll.Size = new System.Drawing.Size(56, 32);
            this.btnMoveToAll.TabIndex = 4;
            this.btnMoveToAll.Text = ">>";
            this.btnMoveToAll.UseVisualStyleBackColor = true;
            this.btnMoveToAll.Click += new System.EventHandler(this.btnMoveToAll_Click);
            // 
            // btnMoveToOne
            // 
            this.btnMoveToOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveToOne.Location = new System.Drawing.Point(230, 44);
            this.btnMoveToOne.Name = "btnMoveToOne";
            this.btnMoveToOne.Size = new System.Drawing.Size(56, 32);
            this.btnMoveToOne.TabIndex = 3;
            this.btnMoveToOne.Text = ">";
            this.btnMoveToOne.UseVisualStyleBackColor = true;
            this.btnMoveToOne.Click += new System.EventHandler(this.btnMoveToOne_Click);
            // 
            // UserToList
            // 
            this.UserToList.FormattingEnabled = true;
            this.UserToList.ItemHeight = 16;
            this.UserToList.Location = new System.Drawing.Point(307, 26);
            this.UserToList.Name = "UserToList";
            this.UserToList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.UserToList.Size = new System.Drawing.Size(186, 196);
            this.UserToList.TabIndex = 1;
            // 
            // UserFromList
            // 
            this.UserFromList.FormattingEnabled = true;
            this.UserFromList.ItemHeight = 16;
            this.UserFromList.Location = new System.Drawing.Point(18, 26);
            this.UserFromList.Name = "UserFromList";
            this.UserFromList.Size = new System.Drawing.Size(186, 196);
            this.UserFromList.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.basic1_113_user_delete_remove_5121;
            this.pictureBox1.Location = new System.Drawing.Point(533, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(53, 614);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 48);
            this.panel2.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(524, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 33);
            this.button5.TabIndex = 4;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(396, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 33);
            this.button4.TabIndex = 3;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(274, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 33);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(148, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(20, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(7, 631);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(35, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(773, 150);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AddParticalAmountExcludeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(802, 673);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddParticalAmountExcludeUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exclude User & Add Amount";
            this.Load += new System.EventHandler(this.AddParticalAmountExcludeUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlUserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox UserToList;
        private System.Windows.Forms.Button MoveFromAll;
        private System.Windows.Forms.Button btnMoveFromOne;
        private System.Windows.Forms.Button btnMoveToAll;
        private System.Windows.Forms.Button btnMoveToOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox UserFromList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtDescrption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}