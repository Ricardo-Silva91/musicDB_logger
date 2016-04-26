namespace musicDB
{
    partial class AddTrack
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_number = new System.Windows.Forms.Label();
            this.text_title = new System.Windows.Forms.TextBox();
            this.text_number = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(13, 82);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(26, 13);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "title:";
            // 
            // label_number
            // 
            this.label_number.AutoSize = true;
            this.label_number.Location = new System.Drawing.Point(12, 122);
            this.label_number.Name = "label_number";
            this.label_number.Size = new System.Drawing.Size(45, 13);
            this.label_number.TabIndex = 1;
            this.label_number.Text = "number:";
            // 
            // text_title
            // 
            this.text_title.Location = new System.Drawing.Point(16, 99);
            this.text_title.Name = "text_title";
            this.text_title.Size = new System.Drawing.Size(100, 20);
            this.text_title.TabIndex = 2;
            // 
            // text_number
            // 
            this.text_number.Location = new System.Drawing.Point(16, 138);
            this.text_number.Name = "text_number";
            this.text_number.Size = new System.Drawing.Size(100, 20);
            this.text_number.TabIndex = 3;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(16, 176);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(273, 310);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 5;
            this.btn_back.Text = "back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(15, 222);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(35, 13);
            this.label_error.TabIndex = 6;
            this.label_error.Text = "label1";
            this.label_error.Visible = false;
            // 
            // AddTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 345);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.text_number);
            this.Controls.Add(this.text_title);
            this.Controls.Add(this.label_number);
            this.Controls.Add(this.label_title);
            this.Name = "AddTrack";
            this.Text = "AddTrack";
            this.Load += new System.EventHandler(this.AddTrack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_number;
        private System.Windows.Forms.TextBox text_title;
        private System.Windows.Forms.TextBox text_number;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label_error;
    }
}