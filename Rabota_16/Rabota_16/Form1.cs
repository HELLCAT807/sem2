using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rabota_16
{
    public partial class Knopka : Form
    {
        private bool captured = false;
        private Button RunningButton;

        public Knopka()
        {
            InitializeComponent();
            InitializeButton();
        }

        private void InitializeButton()
        {
            RunningButton = new Button();
            RunningButton.Text = "Нажми меня!";
            RunningButton.Size = new Size(100, 50);
            RunningButton.BackColor = Color.Red;
            Controls.Add(RunningButton);

            RunningButton.MouseHover += RunningButton_MouseHover;
            DoubleClick += endOfProgramm;
            Resize += Knopka_Resize;
        }

        private void Knopka_Load(object sender, EventArgs e)
        {
            RunningButton.Location = new Point(
                (ClientSize.Width - RunningButton.Width) / 2,
                (ClientSize.Height - RunningButton.Height) / 2
            );
        }

        private void RunningButton_MouseHover(object sender, EventArgs e)
        {
            if (!captured)
            {
                RandomPosition();
            }
        }

        private void RandomPosition()
        {
            Random random = new Random();

            int maxX = ClientSize.Width - RunningButton.Width;
            int maxY = ClientSize.Height - RunningButton.Height;

            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;

            RunningButton.Location = new Point(
                random.Next(0, maxX + 1),
                random.Next(0, maxY + 1)
            );
        }

        private void endOfProgramm(object sender, EventArgs e)
        {
            captured = true;
            RunningButton.Text = "Поймал";
            RunningButton.BackColor = Color.Green;
            RunningButton.MouseHover -= RunningButton_MouseHover;
        }

        private void Knopka_Resize(object sender, EventArgs e)
        {
            if (RunningButton == null) return;

            int x = RunningButton.Location.X;
            int y = RunningButton.Location.Y;

            int maxX = ClientSize.Width - RunningButton.Width;
            int maxY = ClientSize.Height - RunningButton.Height;

            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;

            if (x > maxX) x = maxX;
            if (y > maxY) y = maxY;
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            RunningButton.Location = new Point(x, y);
        }
    }
}
