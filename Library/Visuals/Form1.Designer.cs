﻿namespace Library
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being utilizados.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Biblioteca Offline";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daniel German - 1128127";

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Registración";

            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(281, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Nombre";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(281, 219);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(232, 27);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Apellido";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(281, 252);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(232, 27);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "ID de Usuario";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(281, 285);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(232, 27);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Email";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(281, 318);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(232, 27);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Número de Teléfono";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click); // Asegúrate de que este evento esté vinculado

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Formulario de Registro";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
    }
}
