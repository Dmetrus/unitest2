using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using US_5A_Net.models;

namespace US_5A_Net
{
    public partial class AirportForm : Form
    {
        private readonly List<Flights> flights;

        private readonly BindingSource BinSource;
        public AirportForm()
        {
            InitializeComponent();
            FlightsDGV.AutoGenerateColumns = false;
            flights = new List<Flights>();
            BinSource = new BindingSource();
            BinSource.DataSource = flights;
            FlightsDGV.DataSource = BinSource;
        }
        

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задание выполнил: Черницкий Дмитрий", "Аэропорт",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AddTool_Click(object sender, EventArgs e)
        {
            var infoForm = new FlightsForm();
            
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                flights.Add(infoForm.Flights);
                BinSource.ResetBindings(false);
                InfoStatCal();
            }
        }


        private void DeleteTool_Click(object sender, EventArgs e)
        {
            var id = (Flights)FlightsDGV.Rows[FlightsDGV.SelectedRows[0].Index].DataBoundItem;
            if(MessageBox.Show($"Вы действительно хотите удалить рейс {id.numflight}, прилетающий {id.eta:G}?",
                "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flights.Remove(id);
                BinSource.ResetBindings(false);
                InfoStatCal();
            }
        }

       
        private void ChangeTool_Click(object sender, EventArgs e)
        {
            var id = (Flights)FlightsDGV.Rows[FlightsDGV.SelectedRows[0].Index].DataBoundItem;
            var infoForm = new FlightsForm(id);
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                id.numflight = infoForm.Flights.numflight;
                id.type = infoForm.Flights.type;
                id.eta = infoForm.Flights.eta;
                id.countPas = infoForm.Flights.countPas;
                id.pricePas = infoForm.Flights.pricePas;
                id.countCrew = infoForm.Flights.countCrew;
                id.priceCrew = infoForm.Flights.priceCrew;
                id.procDop = infoForm.Flights.procDop;
                BinSource.ResetBindings(false);
                InfoStatCal();
            }
        }


        private void FlightsDGV_SelectionChanged(object sender, EventArgs e)
        {
            DeliteMenu.Enabled =
            ChangeMenu.Enabled =
            DeliteTool.Enabled = 
            ChangeTool.Enabled = 
            FlightsDGV.SelectedRows.Count > 0;
        }


        private void InfoStatCal()
        {
            CountFlightsTSSL.Text = $"Кол-во рейсов {flights.Count}";
            CountPasTSSL.Text = $"Всего пассажиров {flights.Sum(x => x.countPas)}";
            CountCrewTSSL.Text = $"Всего экипажа {flights.Sum(x => x.countCrew)}";
            SumTSSL.Text = $"Общая сумма {flights.Sum(x => x.sum)}";
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
