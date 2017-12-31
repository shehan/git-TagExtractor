namespace GitTagExtractor
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.checkBoxFiles = new System.Windows.Forms.CheckBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFileTypes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File:";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(13, 32);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(327, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(13, 186);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(327, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 215);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(327, 167);
            this.textBoxLog.TabIndex = 3;
            this.textBoxLog.Text = "Log:";
            // 
            // checkBoxFiles
            // 
            this.checkBoxFiles.AutoSize = true;
            this.checkBoxFiles.Checked = true;
            this.checkBoxFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFiles.Enabled = false;
            this.checkBoxFiles.Location = new System.Drawing.Point(13, 58);
            this.checkBoxFiles.Name = "checkBoxFiles";
            this.checkBoxFiles.Size = new System.Drawing.Size(97, 17);
            this.checkBoxFiles.TabIndex = 4;
            this.checkBoxFiles.Text = "Save Tag Files";
            this.checkBoxFiles.UseVisualStyleBackColor = true;
            this.checkBoxFiles.CheckedChanged += new System.EventHandler(this.checkBoxFiles_CheckedChanged);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Enabled = false;
            this.textBoxDestination.Location = new System.Drawing.Point(13, 100);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(327, 20);
            this.textBoxDestination.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination Directory:";
            // 
            // textBoxFileTypes
            // 
            this.textBoxFileTypes.Enabled = false;
            this.textBoxFileTypes.Location = new System.Drawing.Point(13, 145);
            this.textBoxFileTypes.Name = "textBoxFileTypes";
            this.textBoxFileTypes.Size = new System.Drawing.Size(327, 20);
            this.textBoxFileTypes.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Included Files Types:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 392);
            this.Controls.Add(this.textBoxFileTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxFiles);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Git - Tag Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBoxFiles;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFileTypes;
        private System.Windows.Forms.Label label3;
    }
}

