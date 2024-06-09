using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.gui
{
    public partial class Form1 : Form
    {
        
        private bool isKMP;
        private string absolutePath;
        private Dictionary<string, string> asciiMap;
        private string matchingName;
        private float percentage;

        public Form1(Dictionary<string, string> _asciiMap)
        {
            this.absolutePath = null;
            this.isKMP = true;
            this.asciiMap = _asciiMap;
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            uploadedBox.SizeMode = PictureBoxSizeMode.Zoom;
            fingerBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_enter(object sender, EventArgs e)
        {
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
        }

        private void exit_leave(object sender, EventArgs e)
        {
            this.exitButton.ForeColor = System.Drawing.Color.White;
        }

        private void minimize_clicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimize_enter(object sender, EventArgs e)
        {
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
        }

        private void minimize_leave(object sender, EventArgs e)
        {
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
        }

        /*
        private void prevButton_clicked(object sender, EventArgs e)
        {

        }

        private void nextButton_clicked(object sender, EventArgs e)
        {

        }
        */

        private void SelectFileButton_click(object sender, EventArgs e)
        {
            using (selectImageDialog = new OpenFileDialog())
            {
                selectImageDialog.InitialDirectory = "c:\\";
                selectImageDialog.Filter = "Image files (*.bmp) | *.bmp;";
                selectImageDialog.FilterIndex = 1;
                selectImageDialog.RestoreDirectory = true;

                if (selectImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.absolutePath = selectImageDialog.FileName;
                    Uri absolutePathUri = new Uri(this.absolutePath);
                    uploadedBox.Image = Image.FromFile(this.absolutePath);
                    setSearchStatus(true);
                }
                else {
                    uploadedBox.Image = null;
                    setSearchStatus(false);
                }

                this.timeTakenText.Hide();
                this.matchPercentageText.Hide();
            }
        }

        private void SearchButton_click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool noException = false;
            try
            { 
                if (isKMP)
                {
                   (this.matchingName, this.percentage) = FingerprintMatching.FingerprintAnalysisKMP(this.absolutePath, this.asciiMap);
                    this.matchPercentageText.Text = $"Match: {this.percentage.ToString()}%";
                    Console.WriteLine(this.matchingName);
                    noException = true;
                }
                else
                {
                    (this.matchingName, this.percentage) = FingerprintMatching.FingerprintAnalysisBM(this.absolutePath, this.asciiMap);
                    this.matchPercentageText.Text = $"Match: {this.percentage.ToString()}%";
                    Console.WriteLine(this.matchingName);
                    noException = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { 
                stopwatch.Stop();
            }
            if (noException)
            {
                this.timeTakenText.Text = $"Time Taken: {stopwatch.ElapsedMilliseconds.ToString()} ms";
                this.timeTakenText.Show();
                this.matchPercentageText.Show();
            }
        }

        private void toggleAlgorithmClick(object sender, EventArgs e)
        {
            isKMP = isKMP ^ true;
            if (isKMP)
            {
                this.KMPButton.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
                this.KMPButton.ForeColor = Color.White;
                this.BMButton.BackColor = Color.Black;
                this.BMButton.ForeColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            } 
            else 
            {
                this.BMButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
                this.BMButton.ForeColor = Color.White;
                this.KMPButton.BackColor = Color.Black;
                this.KMPButton.ForeColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            }
        }

        private void setSearchStatus(bool enable) 
        {
            if (enable)
            {
                this.SearchButton.Enabled = true;
                this.SearchButton.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
                this.SelectFileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
                this.SelectFileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
                this.SearchButton.ForeColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(28)))), ((int)(((byte)(65)))));
            }
            else 
            {
                this.SearchButton.Enabled = false;
                this.SearchButton.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
                this.SearchButton.ForeColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(16)))), ((int)(((byte)(28)))));
            }
        }
    }
}
