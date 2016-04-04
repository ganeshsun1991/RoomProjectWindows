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
            this.ddlUserList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UserToList = new System.Windows.Forms.ListBox();
            this.btnMoveToOne = new System.Windows.Forms.Button();
            this.btnMoveToAll = new System.Windows.Forms.Button();
            this.btnMoveFromOne = new System.Windows.Forms.Button();
            this.MoveFromAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserFromList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(786, 79);
            this.panel1.TabIndex = 0;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(769, 135);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MoveFromAll);
            this.groupBox1.Controls.Add(this.btnMoveFromOne);
            this.groupBox1.Controls.Add(this.btnMoveToAll);
            this.groupBox1.Controls.Add(this.btnMoveToOne);
            this.groupBox1.Controls.Add(this.UserToList);
            this.groupBox1.Controls.Add(this.UserFromList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(4, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exclude User & Amount";
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.basic1_113_user_delete_remove_5121;
            this.pictureBox1.Location = new System.Drawing.Point(536, 254);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            // AddParticalAmountExcludeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(786, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddParticalAmountExcludeUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exclude User & Add Amount";
            this.Load += new System.EventHandler(this.AddParticalAmountExcludeUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlUserList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox UserToList;
        private System.Windows.Forms.Button MoveFromAll;
        private System.Windows.Forms.Button btnMoveFromOne;
        private System.Windows.Forms.Button btnMoveToAll;
        private System.Windows.Forms.Button btnMoveToOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox UserFromList;
    }
}