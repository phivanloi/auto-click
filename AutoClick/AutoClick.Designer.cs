
namespace AutoClick
{
    partial class AutoClick
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.mouseTimer = new System.Windows.Forms.Timer(this.components);
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(10, 9);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(344, 23);
            this.txtTime.TabIndex = 0;
            this.txtTime.Text = "60000";
            // 
            // mouseTimer
            // 
            this.mouseTimer.Tick += new System.EventHandler(this.MouseTimeDo);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(10, 48);
            this.txtX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(344, 23);
            this.txtX.TabIndex = 1;
            this.txtX.Text = "950";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(9, 85);
            this.txtY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(344, 23);
            this.txtY.TabIndex = 2;
            this.txtY.Text = "630";
            // 
            // AutoClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 119);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtTime);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AutoClick";
            this.Text = "Tự động click chuột";
            this.Resize += new System.EventHandler(this.AutoClick_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Timer mouseTimer;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
    }
}

