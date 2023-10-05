namespace ScannerConnection
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
            this.ScannerList = new System.Windows.Forms.ComboBox();
            this.btnScanner = new System.Windows.Forms.Button();
            this.picScanImage = new System.Windows.Forms.PictureBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnSaveAsPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picScanImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ScannerList
            // 
            this.ScannerList.FormattingEnabled = true;
            this.ScannerList.Location = new System.Drawing.Point(500, 25);
            this.ScannerList.Name = "ScannerList";
            this.ScannerList.Size = new System.Drawing.Size(288, 21);
            this.ScannerList.TabIndex = 0;
            this.ScannerList.SelectedIndexChanged += new System.EventHandler(this.ScannerList_SelectedIndexChanged);
            // 
            // btnScanner
            // 
            this.btnScanner.Location = new System.Drawing.Point(12, 12);
            this.btnScanner.Name = "btnScanner";
            this.btnScanner.Size = new System.Drawing.Size(75, 23);
            this.btnScanner.TabIndex = 1;
            this.btnScanner.Text = "Scan";
            this.btnScanner.UseVisualStyleBackColor = true;
            this.btnScanner.Click += new System.EventHandler(this.btnScanner_Click);
            // 
            // picScanImage
            // 
            this.picScanImage.Location = new System.Drawing.Point(12, 79);
            this.picScanImage.Name = "picScanImage";
            this.picScanImage.Size = new System.Drawing.Size(776, 359);
            this.picScanImage.TabIndex = 2;
            this.picScanImage.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(659, 9);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(35, 13);
            this.lblConnectionStatus.TabIndex = 3;
            this.lblConnectionStatus.Text = "label1";
            // 
            // btnSaveAsPdf
            // 
            this.btnSaveAsPdf.Location = new System.Drawing.Point(12, 50);
            this.btnSaveAsPdf.Name = "btnSaveAsPdf";
            this.btnSaveAsPdf.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAsPdf.TabIndex = 4;
            this.btnSaveAsPdf.Text = "Save As Pdf";
            this.btnSaveAsPdf.UseVisualStyleBackColor = true;
            this.btnSaveAsPdf.Click += new System.EventHandler(this.btnSaveAsPdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveAsPdf);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.picScanImage);
            this.Controls.Add(this.btnScanner);
            this.Controls.Add(this.ScannerList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScanImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ScannerList;
        private System.Windows.Forms.Button btnScanner;
        private System.Windows.Forms.PictureBox picScanImage;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Button btnSaveAsPdf;
    }
}

