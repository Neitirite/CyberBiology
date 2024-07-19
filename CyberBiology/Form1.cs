using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Timers;
using static System.Net.WebRequestMethods;

namespace CyberBiology
{
    public partial class Form1 : Form
    {
        List<string> Genomes = new List<string>();
        public Form1()
        {
            InitializeComponent();
            New_Genome();
        }
        private void New_Genome()
        {
            string Genome = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int val = -1; //просто временная переменная
                if (i < 5) // команды генома
                {
                    val = random.Next(0, 99);
                }

                if (val < 10 && val >= 0 && i < 5) //добавление разделителей для удобства сплита, после значения энергии разделитель не нужен, поэтому там запись отдельно
                {
                    Genome += '0' + val.ToString() + '|';
                }
                else if(val >= 0)
                {
                    Genome += val.ToString() + '|';
                }

                if (i == 3) //добавляем or для удобства восприятия
                {
                    Genome += "or|";
                }

                if (i == 5) //энергия
                {
                    val = random.Next(10, 75);
                    Genome += val.ToString();
                }
            }
            Genomes.Add(Genome);
            UpdateList();
            Display_Genome(Genomes.Count - 1);




        }
        private void UpdateList()
        {
            listView1.Items.Clear();
            for(int i = 0; i < Genomes.Count; i++)
            {
                listView1.Items.Add(i.ToString());
            }

        }

        private void Display_Genome(int id)
        {
            string Genome = Genomes[id];
            string[] spl = Genome.Split("|"); //разбиваем геном из монолита на отдельные элементы и выводим в соответствующие поля
            label1.Text = spl[0];
            label2.Text = spl[1];
            label3.Text = spl[2];
            label4.Text = spl[3];
            label5.Text = spl[4];
            label6.Text = spl[5];
            label7.Text = "E_min: " + spl[6];

            label8.Text = "Raw: " + Genome; //выводим монолит, чтобы да

            groupBox2.Text = id.ToString(); //переименовываем заголовок в соответствующий номер генома
        }

        private void Tick(object sender, EventArgs e)
        {



        }
        private void Run()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = 100;
            timer.Start();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            New_Genome();
        }
        private void Mutate()
        {

        }
        private void Save_Genom()
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Display_Genome(Int32.Parse(listView1.SelectedItems[0].Text));
            }
            catch { }
            
        }
    }
}
