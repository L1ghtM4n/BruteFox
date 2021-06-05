/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/


namespace FFBruteforcer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxKey4DbFile = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.labelSelectFile = new System.Windows.Forms.Label();
            this.buttonStartBruteforce = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxKey4DbFile
            // 
            this.textBoxKey4DbFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(67)))), ((int)(((byte)(56)))));
            this.textBoxKey4DbFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKey4DbFile.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKey4DbFile.ForeColor = System.Drawing.Color.White;
            this.textBoxKey4DbFile.Location = new System.Drawing.Point(29, 65);
            this.textBoxKey4DbFile.Name = "textBoxKey4DbFile";
            this.textBoxKey4DbFile.Size = new System.Drawing.Size(242, 44);
            this.textBoxKey4DbFile.TabIndex = 0;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(67)))), ((int)(((byte)(56)))));
            this.buttonSelectFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(173)))), ((int)(((byte)(82)))));
            this.buttonSelectFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(114)))), ((int)(((byte)(96)))));
            this.buttonSelectFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(122)))), ((int)(((byte)(101)))));
            this.buttonSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectFile.Font = new System.Drawing.Font("Myanmar Text", 15.75F);
            this.buttonSelectFile.ForeColor = System.Drawing.Color.White;
            this.buttonSelectFile.Location = new System.Drawing.Point(277, 65);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(48, 44);
            this.buttonSelectFile.TabIndex = 1;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = false;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelSelectFile
            // 
            this.labelSelectFile.AutoSize = true;
            this.labelSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSelectFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(173)))), ((int)(((byte)(82)))));
            this.labelSelectFile.Location = new System.Drawing.Point(29, 46);
            this.labelSelectFile.Name = "labelSelectFile";
            this.labelSelectFile.Size = new System.Drawing.Size(94, 13);
            this.labelSelectFile.TabIndex = 2;
            this.labelSelectFile.Text = "Select key4.db file";
            // 
            // buttonStartBruteforce
            // 
            this.buttonStartBruteforce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(67)))), ((int)(((byte)(56)))));
            this.buttonStartBruteforce.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(173)))), ((int)(((byte)(82)))));
            this.buttonStartBruteforce.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(114)))), ((int)(((byte)(96)))));
            this.buttonStartBruteforce.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(122)))), ((int)(((byte)(101)))));
            this.buttonStartBruteforce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartBruteforce.Font = new System.Drawing.Font("Yu Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartBruteforce.ForeColor = System.Drawing.Color.White;
            this.buttonStartBruteforce.Location = new System.Drawing.Point(29, 135);
            this.buttonStartBruteforce.Name = "buttonStartBruteforce";
            this.buttonStartBruteforce.Size = new System.Drawing.Size(296, 47);
            this.buttonStartBruteforce.TabIndex = 3;
            this.buttonStartBruteforce.Text = "Start";
            this.buttonStartBruteforce.UseVisualStyleBackColor = false;
            this.buttonStartBruteforce.Click += new System.EventHandler(this.buttonStartBruteforce_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAuthor.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(173)))), ((int)(((byte)(82)))));
            this.labelAuthor.Location = new System.Drawing.Point(105, 214);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(143, 17);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "github.com/L1ghtM4n";
            this.labelAuthor.Click += new System.EventHandler(this.labelAuthor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(54)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(349, 246);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.buttonStartBruteforce);
            this.Controls.Add(this.labelSelectFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxKey4DbFile);
            this.MaximumSize = new System.Drawing.Size(365, 285);
            this.MinimumSize = new System.Drawing.Size(360, 280);
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.Text = "Firefox bruteforcer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKey4DbFile;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelSelectFile;
        private System.Windows.Forms.Button buttonStartBruteforce;
        private System.Windows.Forms.Label labelAuthor;
    }
}

