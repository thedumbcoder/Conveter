﻿namespace Conveter
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
               this.txtbhavcopy = new System.Windows.Forms.TextBox();
               this.button1 = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.button2 = new System.Windows.Forms.Button();
               this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
               this.label2 = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // txtbhavcopy
               // 
               this.txtbhavcopy.Location = new System.Drawing.Point(88, 31);
               this.txtbhavcopy.Name = "txtbhavcopy";
               this.txtbhavcopy.Size = new System.Drawing.Size(147, 20);
               this.txtbhavcopy.TabIndex = 0;
               this.txtbhavcopy.TextChanged += new System.EventHandler(this.txtbhavcopy_TextChanged);
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(241, 31);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(75, 23);
               this.button1.TabIndex = 1;
               this.button1.Text = "Browse";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(12, 38);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(75, 13);
               this.label1.TabIndex = 2;
               this.label1.Text = "BhavCopy File";
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(88, 76);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(147, 23);
               this.button2.TabIndex = 3;
               this.button2.Text = "Convert to Ami Broker File";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(12, 127);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(0, 13);
               this.label2.TabIndex = 4;
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(727, 154);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.button2);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.txtbhavcopy);
               this.Name = "Form1";
               this.Text = "Form1";
               this.Load += new System.EventHandler(this.Form1_Load);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TextBox txtbhavcopy;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.OpenFileDialog openFileDialog1;
          private System.Windows.Forms.Label label2;
     }
}

