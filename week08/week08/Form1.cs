using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstraction;S
using week08.Abstractions;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        Toy nextToy();


        private IToyFactory _toyFactory;

        public IToyFactory ToyFactory
        {
            get { return _toyFactory; }
            set { _toyFactory = value;
                DisplayNext();

            }
            
            
        }

        public Form1()
        {
            InitializeComponent();
    ToyFactory = new CarFactory();
            
  
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = ToyFactory.CreateNew();
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var lastPosition = 0;

            foreach (var item in _toys)
            {
                item.MoveToy();
                if (item.Left > lastPosition)
                {
                    lastPosition = item.Left;
                }
            }

            if (lastPosition >= 1000)
            {
                var oldestToy = _toys[0];
                _toys.Remove(oldestToy);
                mainPanel.Controls.Remove(oldestToy);

            }
        }

        private void ballButton_Click(object sender, EventArgs e)
        {
            ToyFactory = new BallFactory()
            {
                BallColor = buttonColor.BackColor
            };

        }

        private void CarButton_Click(object sender, EventArgs e)
        {
            ToyFactory = new CarFactory();
        }

        private void DisplayNext()
        {
            if (nextToy != null)
                this.Controls.Remove(nextToy);
            nextToy = ToyFactory.CreateNew();
            nextToy.Left = label1.Left + label1.Width;
            nextToy.Top = label1.Top;
            this.Controls.Add(nextToy);

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var cd = new ColorDialog();

            cd.Color = button.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = cd.Color;

        }

        private void buttonPresent_Click(object sender, EventArgs e)
        {
            ToyFactory = new PresentFactory()
            {
                BoxColor = buttonBox.BackColor,
                RibbonColor = buttonRibbon.BackColor
            };
        }
    }
}
