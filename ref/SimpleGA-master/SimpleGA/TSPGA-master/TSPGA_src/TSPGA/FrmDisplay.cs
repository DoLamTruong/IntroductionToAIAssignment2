using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPGA
{
    public partial class FrmDisplay : Form
    {
        private GA _ga;
        private City[] _cities;
        private DNA _dna;

        public FrmDisplay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_cities != null)
            {
                var gr = e.Graphics;

                SolidBrush br = new SolidBrush(Color.White);
                gr.FillRectangle(br, 0, 0, this.Width, this.Height);

                br = new SolidBrush(Color.Blue);
                for (int i = 0; i < _cities.Length; i++)
                {
                    gr.FillEllipse(br, _cities[i].X - 5, _cities[i].Y - 5, 10, 10);
                }

                if (_dna != null)
                {
                    var pen = new Pen(Color.Green, 3);
                    for (int i = 0; i < _dna.Genes.Length; i++)
                    {
                        var c1 = _cities[_dna.Genes[i]];
                        var c2 = _cities[_dna.Genes[(i + 1) % _cities.Length]];
                        gr.DrawLine(pen, c1.X, c1.Y, c2.X, c2.Y);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_ga != null)
            {
                var stepSize = int.Parse(txtStepSize.Text);
                _dna = _ga.Evolution(stepSize);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Please reset workspace first.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nCities = int.Parse(txtNCities.Text);
            var nSample = int.Parse(txtNSamples.Text);
            var mRate = double.Parse(txtMutationRate.Text);
            var stepSize = int.Parse(txtStepSize.Text);

            _ga = new GA(nCities, nSample, mRate);
            _ga.InitCities(500, 550);
            _ga.InitPopulation();
            _cities = _ga.Cities;
            _dna = null;

            this.Refresh();
        }
    }
}
