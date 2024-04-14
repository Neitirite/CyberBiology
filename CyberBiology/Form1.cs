using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
using System.Timers;
using static System.Net.WebRequestMethods;

namespace CyberBiology
{
    public partial class Form1 : Form
    {
        public int[] gen1 = new int[4];
        public int[] gen2 = new int[4];
        public int[] gen3 = new int[4];
        public int[] gen4 = new int[4];
        public int counter = 0;



        public Form1()
        {
            InitializeComponent();
            pregen();
        }
        private void pregen()
        {
            Random random = new Random();
            gen1 = [random.Next(0, 5), random.Next(0, 5), random.Next(0, 5), random.Next(0, 5)];
            gen2 = [random.Next(0, 5), random.Next(0, 5), random.Next(0, 5), random.Next(0, 5)];
            gen3 = [random.Next(0, 5), random.Next(0, 5), random.Next(0, 5), random.Next(0, 5)];
            gen4 = [random.Next(0, 5), random.Next(0, 5), random.Next(0, 5), random.Next(0, 5)];
            listView1.Items.Add("0");
            updateLabels();
            

            
            
        }
        private void updateLabels()
        {
            label1.Text = gen1[0].ToString();
            label2.Text = gen1[1].ToString();
            label3.Text = gen1[2].ToString();
            label4.Text = gen1[3].ToString();
            label5.Text = gen2[0].ToString();
            label6.Text = gen2[1].ToString();
            label7.Text = gen2[2].ToString();
            label8.Text = gen2[3].ToString();
            label9.Text = gen3[0].ToString();
            label10.Text = gen3[1].ToString();
            label11.Text = gen3[2].ToString();
            label12.Text = gen3[3].ToString();
            label13.Text = gen4[0].ToString();
            label14.Text = gen4[1].ToString();
            label15.Text = gen4[2].ToString();
            label16.Text = gen4[3].ToString();
        }
        public void run(object sender, EventArgs e)
        {

            
            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        gen1[random.Next(0, 4)] = random.Next(0, 5);
                        break;

                    case 1:
                        gen2[random.Next(0, 4)] = random.Next(0, 5);
                        break;

                    case 2:
                        gen3[random.Next(0, 4)] = random.Next(0, 5);
                        break;

                    case 3:
                        gen4[random.Next(0, 4)] = random.Next(0, 5);
                        break;

                }
                counter++;
                listView1.Items.Add(counter.ToString());
            }
            updateLabels();
            
                
            
        }
        private void tick()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(run);
            timer.Interval = 100;
            timer.Start();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Visible = false;
            tick();
        }

    }
}
