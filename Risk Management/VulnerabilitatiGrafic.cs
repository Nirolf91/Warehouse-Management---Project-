using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using System.Collections.Generic;

namespace Risk_Management
{
    public partial class VulnerabilitatiGrafic : Form
    {
        private DataGridView dataGridView1;

        public VulnerabilitatiGrafic(DataGridView dataGridView)
        {
            InitializeComponent();
            this.dataGridView1 = dataGridView;
        }

        private void VulnerabilitatiGrafic_Load(object sender, EventArgs e)
        {
            // Creare obiect PlotView pentru a afișa graficul
            var plotView = new PlotView();

            // Creare obiect PlotModel pentru definirea graficului
            var plotModel = new PlotModel { Title = "Reprezentarea Nivlului de Risc" };

            // Adăugare serie de date pentru diagrama de bare
            var barSeries = new BarSeries
            {
                FillColor = OxyColors.Blue,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            // Creare listă pentru categorii
            var categories = new List<string>();

            // Adaugare date pentru grafic
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Nivelul_riscului"].Value != null && row.Cells["Probabilitatea_de_aparitie"].Value != null)
                {
                    double nivelRisc = Math.Round(Convert.ToDouble(row.Cells["Nivelul_riscului"].Value), 2);
                    double probabilitateAparitie = Math.Round(Convert.ToDouble(row.Cells["Probabilitatea_de_aparitie"].Value), 2);

                    // Adăugare bară în serie
                    barSeries.Items.Add(new BarItem { Value = nivelRisc });

                    // Adăugare categorie
                    categories.Add(probabilitateAparitie.ToString("F2"));
                }
            }

            // Adăugare serie de date la grafic
            plotModel.Series.Add(barSeries);

            // Definire axe
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left, Key = "CategoryAxis", ItemsSource = categories };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Nivelul riscului", MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, StringFormat = "F2" };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);

            // Afișare grafic în PlotView
            plotView.Model = plotModel;

            // Setarea dimensiunilor și a layout-ului pentru PlotView
            plotView.Dock = DockStyle.Fill;

            // Adăugarea PlotView la formular
            this.Controls.Add(plotView);
        }
    }
}
