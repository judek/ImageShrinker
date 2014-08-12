namespace ImageShrinker
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
            this.textBoxInputFolder = new System.Windows.Forms.TextBox();
            this.buttonInputBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOuputBrowse = new System.Windows.Forms.Button();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonShrink = new System.Windows.Forms.Button();
            this.textBoxNewWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.checkBoxFixOrientation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxInputFolder
            // 
            this.textBoxInputFolder.Location = new System.Drawing.Point(12, 35);
            this.textBoxInputFolder.Name = "textBoxInputFolder";
            this.textBoxInputFolder.Size = new System.Drawing.Size(356, 20);
            this.textBoxInputFolder.TabIndex = 0;
            // 
            // buttonInputBrowse
            // 
            this.buttonInputBrowse.Location = new System.Drawing.Point(374, 33);
            this.buttonInputBrowse.Name = "buttonInputBrowse";
            this.buttonInputBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonInputBrowse.TabIndex = 1;
            this.buttonInputBrowse.Text = "Browse...";
            this.buttonInputBrowse.UseVisualStyleBackColor = true;
            this.buttonInputBrowse.Click += new System.EventHandler(this.buttonInputBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Folder (Folder in which the pictures you want to shrink/resize are)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Folder (wil be created if it does not exist";
            // 
            // buttonOuputBrowse
            // 
            this.buttonOuputBrowse.Location = new System.Drawing.Point(374, 95);
            this.buttonOuputBrowse.Name = "buttonOuputBrowse";
            this.buttonOuputBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonOuputBrowse.TabIndex = 4;
            this.buttonOuputBrowse.Text = "Browse...";
            this.buttonOuputBrowse.UseVisualStyleBackColor = true;
            this.buttonOuputBrowse.Click += new System.EventHandler(this.buttonOuputBrowse_Click);
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Location = new System.Drawing.Point(12, 97);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(356, 20);
            this.textBoxOutputFolder.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 209);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(356, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // buttonShrink
            // 
            this.buttonShrink.Location = new System.Drawing.Point(374, 209);
            this.buttonShrink.Name = "buttonShrink";
            this.buttonShrink.Size = new System.Drawing.Size(75, 23);
            this.buttonShrink.TabIndex = 7;
            this.buttonShrink.Text = "GO!";
            this.buttonShrink.UseVisualStyleBackColor = true;
            this.buttonShrink.Click += new System.EventHandler(this.buttonShrink_Click);
            // 
            // textBoxNewWidth
            // 
            this.textBoxNewWidth.Location = new System.Drawing.Point(12, 149);
            this.textBoxNewWidth.Name = "textBoxNewWidth";
            this.textBoxNewWidth.Size = new System.Drawing.Size(40, 20);
            this.textBoxNewWidth.TabIndex = 8;
            this.textBoxNewWidth.Text = "1024";
            this.textBoxNewWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewWidth_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Shrunk Width in pixels (Height will calculated base on given width)";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(12, 237);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(451, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "This program has no warranties or guarantees;This program is not responsible for " +
    "any damages";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(374, 151);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout.TabIndex = 11;
            this.buttonAbout.Text = "Help/About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // checkBoxFixOrientation
            // 
            this.checkBoxFixOrientation.AutoSize = true;
            this.checkBoxFixOrientation.Checked = true;
            this.checkBoxFixOrientation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFixOrientation.Location = new System.Drawing.Point(12, 175);
            this.checkBoxFixOrientation.Name = "checkBoxFixOrientation";
            this.checkBoxFixOrientation.Size = new System.Drawing.Size(230, 17);
            this.checkBoxFixOrientation.TabIndex = 12;
            this.checkBoxFixOrientation.Text = "Fix orientation and reset XIF orientation Info";
            this.checkBoxFixOrientation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 257);
            this.Controls.Add(this.checkBoxFixOrientation);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNewWidth);
            this.Controls.Add(this.buttonShrink);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOuputBrowse);
            this.Controls.Add(this.textBoxOutputFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInputBrowse);
            this.Controls.Add(this.textBoxInputFolder);
            this.Name = "Form1";
            this.Text = "Image Shrinker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputFolder;
        private System.Windows.Forms.Button buttonInputBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOuputBrowse;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonShrink;
        private System.Windows.Forms.TextBox textBoxNewWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxFixOrientation;
    }
}

