namespace WebSocketClient
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbel_name = new System.Windows.Forms.Label();
            this.panelParent = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 44);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(262, 427);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbel_name
            // 
            this.lbel_name.AutoSize = true;
            this.lbel_name.Location = new System.Drawing.Point(98, 146);
            this.lbel_name.Name = "lbel_name";
            this.lbel_name.Size = new System.Drawing.Size(35, 13);
            this.lbel_name.TabIndex = 2;
            this.lbel_name.Text = "label1";
            // 
            // panelParent
            // 
            this.panelParent.BackColor = System.Drawing.Color.White;
            this.panelParent.Controls.Add(this.button1);
            this.panelParent.Controls.Add(this.lbel_name);
            this.panelParent.Location = new System.Drawing.Point(286, 44);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(474, 427);
            this.panelParent.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 483);
            this.Controls.Add(this.panelParent);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelParent.ResumeLayout(false);
            this.panelParent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbel_name;
        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Button button1;
    }
}