using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ShrinkImages
{
   
    class Program
    {
       static void Main(string[] args)
        {

           Console.Title = "Shrink Images";
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("This program has no warranties or guarantees.");
           Console.WriteLine("This program is not responsible for any damages.");
           Console.WriteLine("");
           Console.ForegroundColor = ConsoleColor.White;

           float newWidth = 0;
           
           do
            {
                Console.WriteLine("Enter new image width:");
                try
                { 
                    newWidth = (float)Int32.Parse(Console.ReadLine());
                    if ((int)newWidth < 10) 
                        throw new Exception();
                }
                catch { newWidth = 0; }
               
            }while (0 == newWidth);
          
           //Get all the *.jpg files (pictures) in "." this directory
           DirectoryInfo di = new DirectoryInfo(".");
           FileInfo[] pictures = di.GetFiles("*.jpg");
          
           Image oldImage = null;
           Image shrunkImage = null;
           Graphics oGraphic = null;

           string directoryPath, newName;
           int smallHeight, smallWidth;


           float shrinkFactor;

           foreach (FileInfo fileinfo in pictures)
            {
                try
                {
                    oldImage = Image.FromFile(fileinfo.FullName);

                    if (oldImage.Width <= newWidth)
                    {
                        Console.WriteLine("Skipping " + fileinfo.Name + "...");
                        continue;// skip this image nothing to do already small
                    }

                    Console.WriteLine("Shrinking " + fileinfo.Name + "...");


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


                    //Set attribute of object "oGraphic" to rectangle of new smaller size (photo on canvas)
                    Rectangle rect = new Rectangle(0, 0, smallWidth, smallHeight);

                    //Draw the old photo in the new rectangle
                    oGraphic.DrawImage(oldImage, rect);

                    //Copy over jpeg meta data
                    foreach (PropertyItem item in oldImage.PropertyItems)
                        shrunkImage.SetPropertyItem(item);

                    //Save as a JPEG
                    directoryPath = System.IO.Path.GetDirectoryName(fileinfo.FullName);
                    newName = directoryPath + "\\" + "s" + ((int)newWidth) + "-" + fileinfo.Name;
                    shrunkImage.Save(newName, ImageFormat.Jpeg);
                }
                catch (Exception exp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failuer:" + exp.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    if(oldImage != null) oldImage.Dispose();
                    if (shrunkImage != null) shrunkImage.Dispose();
                    if (oGraphic != null) oGraphic.Dispose();
                }
             }

           Console.WriteLine("Operation complete. Press any key to close.");
           Console.ReadKey(true);
        }
    }
}
