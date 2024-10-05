namespace Bookclub_desktop
{
    partial class Form1
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
            this.ClubGrid = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banned = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClubGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ClubGrid
            // 
            this.ClubGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClubGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Gender,
            this.Birth_day,
            this.Banned});
            this.ClubGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClubGrid.Location = new System.Drawing.Point(0, 77);
            this.ClubGrid.Name = "ClubGrid";
            this.ClubGrid.RowHeadersWidth = 51;
            this.ClubGrid.RowTemplate.Height = 24;
            this.ClubGrid.Size = new System.Drawing.Size(939, 427);
            this.ClubGrid.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Név";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.Width = 125;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Nem";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.Width = 125;
            // 
            // Birth_day
            // 
            this.Birth_day.DataPropertyName = " Birth_date";
            this.Birth_day.HeaderText = "Születésnap";
            this.Birth_day.MinimumWidth = 6;
            this.Birth_day.Name = "Birth_day";
            this.Birth_day.Width = 125;
            // 
            // Banned
            // 
            this.Banned.DataPropertyName = "Banned";
            this.Banned.HeaderText = "Kitiltva";
            this.Banned.MinimumWidth = 6;
            this.Banned.Name = "Banned";
            this.Banned.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Banned.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tiltás/ Tiltás visszavonása";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClubGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClubGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ClubGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth_day;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Banned;
    }
}

