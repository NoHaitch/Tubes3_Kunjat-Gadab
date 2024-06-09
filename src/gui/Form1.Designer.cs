using System;
using System.Drawing;

namespace src.gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeTakenText = new System.Windows.Forms.Label();
            this.matchPercentageText = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.identityLabel = new System.Windows.Forms.Label();
            this.BMButton = new System.Windows.Forms.Button();
            this.KMPButton = new System.Windows.Forms.Button();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.uploadedBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadedText = new System.Windows.Forms.Label();
            this.matchedText = new System.Windows.Forms.Label();
            this.selectImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.fingerBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.panel1.Controls.Add(this.timeTakenText);
            this.panel1.Controls.Add(this.matchPercentageText);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.identityLabel);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1000, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 900);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timeTakenText
            // 
            this.timeTakenText.AutoSize = true;
            this.timeTakenText.BackColor = System.Drawing.Color.Transparent;
            this.timeTakenText.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.timeTakenText.ForeColor = System.Drawing.Color.White;
            this.timeTakenText.Location = new System.Drawing.Point(44, 72);
            this.timeTakenText.Name = "timeTakenText";
            this.timeTakenText.Size = new System.Drawing.Size(224, 32);
            this.timeTakenText.TabIndex = 3;
            this.timeTakenText.Text = "Time Taken:  ms";
            this.timeTakenText.Hide();
            // 
            // matchPercentageText
            // 
            this.matchPercentageText.AutoSize = true;
            this.matchPercentageText.BackColor = System.Drawing.Color.Transparent;
            this.matchPercentageText.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchPercentageText.ForeColor = System.Drawing.Color.White;
            this.matchPercentageText.Location = new System.Drawing.Point(396, 72);
            this.matchPercentageText.Name = "matchPercentageText";
            this.matchPercentageText.Size = new System.Drawing.Size(126, 32);
            this.matchPercentageText.TabIndex = 7;
            this.matchPercentageText.Text = "Match: %";
            this.matchPercentageText.Hide();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(552, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 45);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exit_clicked);
            this.exitButton.MouseEnter += new System.EventHandler(this.exit_enter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exit_leave);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(507, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(45, 45);
            this.minimizeButton.TabIndex = 6;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimize_clicked);
            this.minimizeButton.MouseEnter += new System.EventHandler(this.minimize_enter);
            this.minimizeButton.MouseLeave += new System.EventHandler(this.minimize_leave);
            // 
            // identityLabel
            // 
            this.identityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.identityLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.identityLabel.Font = new System.Drawing.Font("Cascadia Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(41)))), ((int)(((byte)(71)))));
            this.identityLabel.Location = new System.Drawing.Point(50, 120);
            this.identityLabel.Name = "identityLabel";
            this.identityLabel.Size = new System.Drawing.Size(500, 700);
            this.identityLabel.TabIndex = 3;
            this.identityLabel.Text = resources.GetString("identityLabel.Text");
            // 
            // BMButton
            // 
            this.BMButton.BackColor = System.Drawing.Color.Black;
            this.BMButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.BMButton.FlatAppearance.BorderSize = 4;
            this.BMButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.BMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMButton.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.BMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.BMButton.Location = new System.Drawing.Point(498, 720);
            this.BMButton.Name = "BMButton";
            this.BMButton.Size = new System.Drawing.Size(100, 60);
            this.BMButton.TabIndex = 1;
            this.BMButton.Text = "BM";
            this.BMButton.UseVisualStyleBackColor = true;
            this.BMButton.Click += new System.EventHandler(this.toggleAlgorithmClick);
            // 
            // KMPButton
            // 
            this.KMPButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            this.KMPButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.KMPButton.FlatAppearance.BorderSize = 4;
            this.KMPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.KMPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KMPButton.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.KMPButton.ForeColor = System.Drawing.Color.White;
            this.KMPButton.Location = new System.Drawing.Point(402, 720);
            this.KMPButton.Name = "KMPButton";
            this.KMPButton.Size = new System.Drawing.Size(100, 60);
            this.KMPButton.TabIndex = 1;
            this.KMPButton.Text = "KMP";
            this.KMPButton.UseVisualStyleBackColor = true;
            this.KMPButton.Click += new System.EventHandler(this.toggleAlgorithmClick);
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.BackColor = System.Drawing.Color.Black;
            this.SelectFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.SelectFileButton.FlatAppearance.BorderSize = 3;
            this.SelectFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.SelectFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            this.SelectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileButton.Font = new System.Drawing.Font("Cascadia Mono", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.SelectFileButton.Location = new System.Drawing.Point(130, 720);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(220, 60);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.Enabled = false;
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            this.SearchButton.FlatAppearance.BorderSize = 3;
            this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Cascadia Mono", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            this.SearchButton.Location = new System.Drawing.Point(650, 720);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(220, 60);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Black;
            this.Title.Font = new System.Drawing.Font("Cascadia Mono", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(41)))), ((int)(((byte)(71)))));
            this.Title.Location = new System.Drawing.Point(121, 30);
            this.Title.Margin = new System.Windows.Forms.Padding(0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(758, 74);
            this.Title.TabIndex = 3;
            this.Title.Text = "FINGERPRINT IDENTIFIER";
            // 
            // uploadedBox
            // 
            this.uploadedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uploadedBox.Location = new System.Drawing.Point(130, 180);
            this.uploadedBox.Name = "uploadedBox";
            this.uploadedBox.Size = new System.Drawing.Size(300, 400);
            this.uploadedBox.TabIndex = 4;
            this.uploadedBox.TabStop = false;
            this.uploadedBox.Image = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::src.Properties.Resources.Logo_Red;
            this.pictureBox1.Location = new System.Drawing.Point(23, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // uploadedText
            // 
            this.uploadedText.AutoSize = true;
            this.uploadedText.BackColor = System.Drawing.Color.Black;
            this.uploadedText.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(41)))), ((int)(((byte)(71)))));
            this.uploadedText.Location = new System.Drawing.Point(136, 603);
            this.uploadedText.Name = "uploadedText";
            this.uploadedText.Size = new System.Drawing.Size(294, 32);
            this.uploadedText.TabIndex = 3;
            this.uploadedText.Text = "Uploaded Fingerprint";
            this.uploadedText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // matchedText
            // 
            this.matchedText.AutoSize = true;
            this.matchedText.BackColor = System.Drawing.Color.Black;
            this.matchedText.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(41)))), ((int)(((byte)(71)))));
            this.matchedText.Location = new System.Drawing.Point(580, 603);
            this.matchedText.Name = "matchedText";
            this.matchedText.Size = new System.Drawing.Size(280, 32);
            this.matchedText.TabIndex = 3;
            this.matchedText.Text = "Matched Fingerprint";
            this.matchedText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectImageDialog
            // 
            this.selectImageDialog.FileName = "selectImageDialog";
            // 
            // fingerBox
            // 
            this.fingerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fingerBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.fingerBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("fingerBox.InitialImage")));
            this.fingerBox.Location = new System.Drawing.Point(570, 180);
            this.fingerBox.Name = "fingerBox";
            this.fingerBox.Size = new System.Drawing.Size(300, 400);
            this.fingerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fingerBox.TabIndex = 5;
            this.fingerBox.TabStop = false;
            this.fingerBox.Image = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.matchedText);
            this.Controls.Add(this.fingerBox);
            this.Controls.Add(this.uploadedBox);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.BMButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.KMPButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.uploadedText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label identityLabel;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button KMPButton;
        private System.Windows.Forms.Button BMButton;
        private System.Windows.Forms.PictureBox uploadedBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label uploadedText;
        private System.Windows.Forms.Label matchedText;
        private System.Windows.Forms.Label matchPercentageText;
        private System.Windows.Forms.Label timeTakenText;
        private System.Windows.Forms.OpenFileDialog selectImageDialog;
        private System.Windows.Forms.PictureBox fingerBox;
    }
}

