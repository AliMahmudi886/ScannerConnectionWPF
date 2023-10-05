using System;
using System.Windows.Forms;
using WIA;
using System.IO;
using WIACommonDialog = WIA.CommonDialog;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Drawing;
using Image = System.Drawing.Image;
using static System.Net.Mime.MediaTypeNames;

namespace ScannerConnection
{
    public partial class Form1 : Form
    {
        DeviceManager deviceManager = new DeviceManager();
        DeviceInfo firstScannerAvailable = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckScannerConnection();
            PopulateScannerList();
        }
        private List<DeviceInfo> ListAvailableScanners()
        {
            List<DeviceInfo> scanners = new List<DeviceInfo>();
            DeviceManager manager = new DeviceManager();

            foreach (DeviceInfo deviceInfo in manager.DeviceInfos)
            {
                if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                {
                    scanners.Add(deviceInfo);
                }
            }

            return scanners;
        }
        private void PopulateScannerList()
        {
            List<DeviceInfo> scanners = ListAvailableScanners();

            // Clear the list (in case of updates)
            ScannerList.Items.Clear();

            // Add the scanner names to the list
            foreach (DeviceInfo scanner in scanners)
            {
                ScannerList.Items.Add(scanner.Properties["Name"].get_Value());
            }
        }
        private Device ConnectToSelectedScanner()
        {
            if (ScannerList.SelectedIndex >= 0)
            {
                DeviceManager manager = new DeviceManager();
                DeviceInfo selectedDeviceInfo = ListAvailableScanners()[ScannerList.SelectedIndex];
                Device connectedScanner = selectedDeviceInfo.Connect();
                return connectedScanner;
            }
            else
            {
                MessageBox.Show("Chooose a scanner");
                return null;
            }
        }


        private void btnScanner_Click(object sender, EventArgs e)
        {

            List<Image> images = new List<Image>();
            Device connectedScanner = ConnectToSelectedScanner();

            if (connectedScanner != null && connectedScanner.Items.Count>0)
            {
                try
                {
                    WIA.Item item = connectedScanner.Items[1] as WIA.Item;
                    try
                    {
                        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
                        // scan image
                        WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                        WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);

                        // save to temp file
                        string fileName = Path.GetTempFileName();
                        File.Delete(fileName);
                        image.SaveFile(fileName);
                        image = null;
                        // add file to output list
                        images.Add(Image.FromFile(fileName));
                        // Load the scanned image from the temporary file
                        Image scannedImage = Image.FromFile(fileName);

                        // Display the scanned image in the PictureBox
                        picScanImage.Image = scannedImage;

                        // Add the scanned image to the list of images (if needed)
                        images.Add(scannedImage);
                    }
                    catch (Exception exc)
                    {
                        throw exc;
                    }




                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void CheckScannerConnection()
        {
            List<DeviceInfo> scanners = ListAvailableScanners();

            if (scanners.Count > 0)
            {
                // At least one scanner is connected
                lblConnectionStatus.Text = "Scanner is Connected";
            }
            else
            {
                // No scanners are connected
                lblConnectionStatus.Text = "Scanner is not Connected";
            }
        }
        private void ScannerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (picScanImage.Image != null)
                {
                    // Define the folder path where you want to save the PDF files
                    string folderPath = @"D:\Scanned-Documents\";

                    // Create the folder if it doesn't exist
                    Directory.CreateDirectory(folderPath);

                    // Generate a unique PDF file name based on timestamp
                    string pdfFileName = Path.Combine(folderPath, DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");

                    // Initialize a FileStream to write the PDF file
                    using (FileStream fs = new FileStream(pdfFileName, FileMode.Create))
                    {
                        Document pdfDocument = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(pdfDocument, fs);
                        pdfDocument.Open();

                        // Create an image and add it to the PDF document
                        using (MemoryStream stream = new MemoryStream())
                        {
                            picScanImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                            pdfDocument.Add(pdfImage);
                        }

                        pdfDocument.Close();
                    }

                    MessageBox.Show("Scanned document saved as PDF: " + pdfFileName);
                }
                else
                {
                    MessageBox.Show("No scanned image available to save as PDF.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
