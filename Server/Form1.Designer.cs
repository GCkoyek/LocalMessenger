using System.Drawing;
using System.Windows.Forms;
using System;

namespace Server
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label statusLabel;
        private bool isDragging = false;
        private Point mouseOffset;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.White;
            this.sendButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.Location = new System.Drawing.Point(664, 531);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(76, 43);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Wyślij";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.Color.White;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputTextBox.ForeColor = System.Drawing.Color.Black;
            this.inputTextBox.Location = new System.Drawing.Point(15, 531);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(645, 44);
            this.inputTextBox.TabIndex = 2;
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.Color.White;
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputTextBox.ForeColor = System.Drawing.Color.Black;
            this.outputTextBox.Location = new System.Drawing.Point(15, 41);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(726, 487);
            this.outputTextBox.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(248, 10);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(258, 19);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status: Oczekiwanie na połączenie...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(720, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 41);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 599);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.statusLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ServerForm";
            this.Text = "z";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ServerForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ServerForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ServerForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void ServerForm_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(this);
        }

        private void SetRoundedCorners(Form form)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(form.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(form.Width - radius - 1, form.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, form.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            form.Region = new System.Drawing.Region(path);
        }

        private void ServerForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseOffset = new Point(e.X, e.Y);
            }
        }

        private void ServerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left = e.X + this.Left - mouseOffset.X;
                this.Top = e.Y + this.Top - mouseOffset.Y;
            }
        }

        private void ServerForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private Label label1;
        private PictureBox pictureBox1;
    }
}
