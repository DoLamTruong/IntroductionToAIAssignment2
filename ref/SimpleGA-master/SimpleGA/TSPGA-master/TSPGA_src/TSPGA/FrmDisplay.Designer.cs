namespace TSPGA
{
    partial class FrmDisplay
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNCities = new System.Windows.Forms.TextBox();
            this.txtNSamples = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMutationRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStepSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Evolve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(698, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# of cities";
            // 
            // txtNCities
            // 
            this.txtNCities.Location = new System.Drawing.Point(700, 30);
            this.txtNCities.Name = "txtNCities";
            this.txtNCities.Size = new System.Drawing.Size(68, 20);
            this.txtNCities.TabIndex = 2;
            this.txtNCities.Text = "10";
            // 
            // txtNSamples
            // 
            this.txtNSamples.Location = new System.Drawing.Point(700, 70);
            this.txtNSamples.Name = "txtNSamples";
            this.txtNSamples.Size = new System.Drawing.Size(68, 20);
            this.txtNSamples.TabIndex = 4;
            this.txtNSamples.Text = "500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "# of samples";
            // 
            // txtMutationRate
            // 
            this.txtMutationRate.Location = new System.Drawing.Point(700, 110);
            this.txtMutationRate.Name = "txtMutationRate";
            this.txtMutationRate.Size = new System.Drawing.Size(68, 20);
            this.txtMutationRate.TabIndex = 6;
            this.txtMutationRate.Text = ".01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "mutation rate";
            // 
            // txtStepSize
            // 
            this.txtStepSize.Location = new System.Drawing.Point(700, 150);
            this.txtStepSize.Name = "txtStepSize";
            this.txtStepSize.Size = new System.Drawing.Size(68, 20);
            this.txtStepSize.TabIndex = 8;
            this.txtStepSize.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(698, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "evol. step size";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(697, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtStepSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMutationRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNSamples);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNCities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmDisplay";
            this.Text = "Display map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNCities;
        private System.Windows.Forms.TextBox txtNSamples;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMutationRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStepSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}