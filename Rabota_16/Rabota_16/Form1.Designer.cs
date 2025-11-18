using System.ComponentModel;
using System.Windows.Forms;

namespace Rabota_16
{
    partial class Knopka
    {
        private IContainer components = null;

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
            this.SuspendLayout();
            // 
            // Knopka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Name = "Knopka";
            this.Text = "Лабораторная работа 16. Вариант 12";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Knopka_Load);
            this.ResumeLayout(false);
        }
    }
}

