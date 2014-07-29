using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace ImageShrinker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelStatus.Text = "";
        }

        private void buttonInputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            textBoxInputFolder.Text =  fbd.SelectedPath;
        }


        void OperationStart()
        {
            buttonShrink.Enabled = false;
        }
        
        void OperationComplete()
        {
            buttonShrink.Enabled = true;
            labelStatus.Text = "";
        }

        void UpdateStatus(string statusText)
        {
            labelStatus.Text = statusText;
        }
        
        private void buttonOuputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            textBoxOutputFolder.Text = fbd.SelectedPath;
        }

        private void textBoxNewWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0; 
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);

        }

     
        static readonly int Thumbnail_Orientation = 0x5029;
        static readonly int Orientation = 0x112;

        
        void ShrinkImages(int Width, string inputFolder, string outputFolder)
        {
            float newWidth = (float)Width;

            try
            {

                if (false == Directory.Exists(inputFolder))
                    return;


                //Get all the *.jpg files (pictures) in "." this directory
                DirectoryInfo di = new DirectoryInfo(inputFolder);
                FileInfo[] pictures = di.GetFiles("*.jpg");
                if (pictures.Length < 1)
                {
                    throw new Exception("No JPEG(picture) files found in input folder.");
                }

                
                try
                {
                    if (false == Directory.Exists(outputFolder))
                        Directory.CreateDirectory(outputFolder);
                }
                catch(Exception exp)
                {
                    throw new Exception("Output folder error\r\n:" + exp.Message);
                }

                progressBar1.Maximum = pictures.Length;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;


                Image oldImage = null;
                Image shrunkImage = null;
                Graphics oGraphic = null;

                string directoryPath, newName;
                int smallHeight, smallWidth;


                float shrinkFactor;

                foreach (FileInfo fileinfo in pictures)
                {
                    progressBar1.Value++;

                    try
                    {
                        oldImage = Image.FromFile(fileinfo.FullName);

                        
                        if (oldImage.Width <= newWidth)
                        {
                            Console.WriteLine("Skipping " + fileinfo.Name + "...");
                            continue;// skip this image nothing to do already small
                        }

                        Console.WriteLine("Shrinking " + fileinfo.Name + "...");
                        UpdateStatus("Shrinking " + fileinfo.Name + "...");


                        if (oldImage.Height < oldImage.Width) //Landscape
                            shrinkFactor = oldImage.Width / newWidth;
                        else //Portrait;
                            shrinkFactor = oldImage.Height / newWidth;

                        smallHeight = (int)(oldImage.Height / shrinkFactor);
                        smallWidth = (int)(oldImage.Width / shrinkFactor);

                        //Create new (blank) Image object called "shrunkImage" of new smaller size (canvas)
                        shrunkImage = new Bitmap(smallWidth, smallHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                        //Create new Graphics object called "oGraphic" based on object "shrunkImage" 
                        //with multiple quality attributes
                        oGraphic = Graphics.FromImage(shrunkImage);
                        oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                        oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                        oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        byte oldImageOrinentation = 1;


                        //Set attribute of object "oGraphic" to rectangle of new smaller size (photo on canvas)
                        Rectangle rect = new Rectangle(0, 0, smallWidth, smallHeight);

                        //Draw the old photo in the new rectangle
                        oGraphic.DrawImage(oldImage, rect);

                        //Copy over jpeg meta data
                        foreach (PropertyItem item in oldImage.PropertyItems)
                        {
                      
                            if ((Orientation == item.Id) || (Thumbnail_Orientation == item.Id))
                            {
                              if (item.Type == 0x3)//3 = SHORT A 16-bit (2 -byte) unsigned integer,
                                {

                                   byte test = item.Value[0];

                                   if ((test == 8) || (test == 3) || (test == 5))
                                    {
                                        item.Value[0] = 0x01;
                                        item.Value[0] = 0x00;
                                    }

                                    if (Orientation == item.Id)
                                        oldImageOrinentation = test; //Set orientation to 1 will rotate image later
                                    
                                }
                            }
                            
                            shrunkImage.SetPropertyItem(item);
                        }

                        //Save as a JPEG
                        //directoryPath = System.IO.Path.GetDirectoryName(fileinfo.FullName);
                        directoryPath = outputFolder;
                        newName = directoryPath + "\\" + "s" + ((int)newWidth) + "-" + fileinfo.Name;

                        if (true == checkBoxFixOrientation.Checked)
                        {
                            switch (oldImageOrinentation)
                            {
                                case 8://->
                                    shrunkImage.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                                    break;
                                case 3:
                                    shrunkImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                                    break;
                                case 6:
                                    shrunkImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                                    break;
                                default:
                                    break;
                            }
                                                             
                        }
                          
                        
                        shrunkImage.Save(newName, ImageFormat.Jpeg);


                    }
                    catch (Exception exp)
                    {
                       MessageBox.Show(exp.Message, "Shrink Images",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (oldImage != null) oldImage.Dispose();
                        if (shrunkImage != null) shrunkImage.Dispose();
                        if (oGraphic != null) oGraphic.Dispose();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Shrink Images",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OperationComplete();
            }
        }


       
        void ShrinkImagesThread()
        {
            ShrinkImages(Int32.Parse(textBoxNewWidth.Text),
                textBoxInputFolder.Text, textBoxOutputFolder.Text);
        }
        
        private void buttonShrink_Click(object sender, EventArgs e)
        {

            if (false == Directory.Exists(textBoxInputFolder.Text))
            {
                MessageBox.Show("Invalid Input Folder", "Shrink Images",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            OperationStart();
            Thread t = new Thread(ShrinkImagesThread);
            t.Start();
            //ShrinkImagesThread();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

       
    }
}
