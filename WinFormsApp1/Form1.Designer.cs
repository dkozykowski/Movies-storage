
namespace WinFormsApp1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.maxRatingBox = new System.Windows.Forms.TextBox();
            this.minRatingBox = new System.Windows.Forms.TextBox();
            this.maxBudgetBox = new System.Windows.Forms.TextBox();
            this.minBudgetBox = new System.Windows.Forms.TextBox();
            this.imaxCheckBox = new System.Windows.Forms.CheckBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startTime);
            this.groupBox1.Controls.Add(this.endTime);
            this.groupBox1.Controls.Add(this.maxRatingBox);
            this.groupBox1.Controls.Add(this.minRatingBox);
            this.groupBox1.Controls.Add(this.maxBudgetBox);
            this.groupBox1.Controls.Add(this.minBudgetBox);
            this.groupBox1.Controls.Add(this.imaxCheckBox);
            this.groupBox1.Controls.Add(this.titleBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search options";
            // 
            // startTime
            // 
            this.startTime.Location = new System.Drawing.Point(169, 91);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(215, 23);
            this.startTime.TabIndex = 15;
            this.startTime.Value = new System.DateTime(1900, 1, 1, 19, 45, 0, 0);
            // 
            // endTime
            // 
            this.endTime.Location = new System.Drawing.Point(446, 91);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(210, 23);
            this.endTime.TabIndex = 14;
            // 
            // maxRatingBox
            // 
            this.maxRatingBox.Location = new System.Drawing.Point(530, 47);
            this.maxRatingBox.Name = "maxRatingBox";
            this.maxRatingBox.Size = new System.Drawing.Size(159, 23);
            this.maxRatingBox.TabIndex = 13;
            // 
            // minRatingBox
            // 
            this.minRatingBox.Location = new System.Drawing.Point(354, 47);
            this.minRatingBox.Name = "minRatingBox";
            this.minRatingBox.Size = new System.Drawing.Size(117, 23);
            this.minRatingBox.TabIndex = 12;
            // 
            // maxBudgetBox
            // 
            this.maxBudgetBox.Location = new System.Drawing.Point(530, 20);
            this.maxBudgetBox.Name = "maxBudgetBox";
            this.maxBudgetBox.Size = new System.Drawing.Size(159, 23);
            this.maxBudgetBox.TabIndex = 11;
            // 
            // minBudgetBox
            // 
            this.minBudgetBox.Location = new System.Drawing.Point(354, 19);
            this.minBudgetBox.Name = "minBudgetBox";
            this.minBudgetBox.Size = new System.Drawing.Size(117, 23);
            this.minBudgetBox.TabIndex = 10;
            // 
            // imaxCheckBox
            // 
            this.imaxCheckBox.AutoSize = true;
            this.imaxCheckBox.Location = new System.Drawing.Point(101, 59);
            this.imaxCheckBox.Name = "imaxCheckBox";
            this.imaxCheckBox.Size = new System.Drawing.Size(15, 14);
            this.imaxCheckBox.TabIndex = 9;
            this.imaxCheckBox.UseVisualStyleBackColor = true;
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(72, 22);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(179, 23);
            this.titleBox.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(483, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rating min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Budget min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Release date from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "3D Imax";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(758, 29);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(214, 107);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(937, 386);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MoviesForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.CheckBox imaxCheckBox;
        private System.Windows.Forms.TextBox minBudgetBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.TextBox maxRatingBox;
        private System.Windows.Forms.TextBox minRatingBox;
        private System.Windows.Forms.TextBox maxBudgetBox;
    }
}

