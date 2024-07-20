using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Drawing;

namespace CyberBiology
{
    public partial class Form1 : Form
    {
        List<string> Genomes = new List<string>();
        string[,] field = new string[1001, 1001];
        public Form1()
        {
            InitializeComponent();
            Run();
        }

        private int New_Genome()
        {
            string Genome = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int val = -1; //просто временна€ переменна€
                if (i < 5) // команды генома
                {
                    val = random.Next(0, 100);
                }

                if (val < 10 && val >= 0 && i < 5) //добавление разделителей дл€ удобства сплита, после значени€ энергии разделитель не нужен, поэтому там запись отдельно
                {
                    Genome += '0' + val.ToString() + '|';
                }
                else if (val >= 0)
                {
                    Genome += val.ToString() + '|';
                }

                if (i == 3) //добавл€ем or дл€ удобства воспри€ти€ (см. документацию)
                {
                    Genome += "or|";
                }

                if (i == 5) //энерги€ и направление создани€ нового отростка
                {
                    val = random.Next(10, 75);
                    Genome += val.ToString();
                    val = random.Next(0, 4);
                    Genome += '|' + val.ToString();
                }
            }
            Genomes.Add(Genome);
            UpdateList();
            Display_Genome(Genomes.Count - 1);
            return Genomes.Count - 1;



        }

        private void UpdateList()
        {
            listView1.Items.Clear();
            for (int i = 0; i < Genomes.Count; i++)
            {
                listView1.Items.Add(i.ToString());
            }

        }

        private void Display_Genome(int id)
        {
            string Genome = Genomes[id];
            string[] spl = Genome.Split("|"); //разбиваем геном из монолита на отдельные элементы и выводим в соответствующие пол€
            label1.Text = spl[0];
            label2.Text = spl[1];
            label3.Text = spl[2];
            label4.Text = spl[3];
            label5.Text = spl[4];
            label6.Text = spl[5];
            label7.Text = "E_min: " + spl[6];
            label10.Text = "| " + spl[7];

            label8.Text = "Raw: " + Genome; //выводим монолит, чтобы да

            groupBox2.Text = id.ToString(); //переименовываем заголовок в соответствующий номер генома
        }

        private void Tick(object sender, EventArgs e)
        {

            Redraw();
            foreach (var item in field)
            {
                if (item != null)
                {
                    string[] item_ = item.Split('|');
                    if (item_[2] == "Branch")
                    {
                        Execute_Genome(Int32.Parse(item_[0]), Int32.Parse(item_[1]));
                    }
                    
                }
            }

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
            Random rand = new Random();
            int x = rand.Next(0, 100);
            int y = rand.Next(0, 100);
            Add_New_Branch(x, y);
        }

        private void Mutate()
        {

        }

        private void Save_Genome()
        {

        }

        private void Add_New_Branch(int x, int y)
        {
            Draw(x, y, "Branch");
            int genome_number = New_Genome();
            field[x, y] = x.ToString() + '|' + y.ToString() + "|Branch" + '|' + genome_number.ToString();
            label9.Text = field[x, y];
        }

        private void Add_Transport_Cell(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 1000 && y < 1000)
            {
                Draw(x, y, "Transport");
                field[x, y] = x.ToString() + '|' + y.ToString() + "|Transport" + "|null";
            }
        }
        private void Add_Leaf_Cell(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 1000 && y < 1000)
            {
                Draw(x, y, "Leaf");
                field[x, y] = x.ToString() + '|' + y.ToString() + "|Leaf" + "|null";
            }
        }
        private void Add_NatRoot_Cell(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 1000 && y < 1000)
            {
                Draw(x, y, "Root_nat");
                field[x, y] = x.ToString() + '|' + y.ToString() + "|Root_nat" + "|null";
            }
        }
        private void Add_EnRoot_Cell(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 1000 && y < 1000)
            {
            Draw(x, y, "Root_en");
            field[x, y] = x.ToString() + '|' + y.ToString() + "|Root_en" + "|null";
            }
        }
        private void Add_NaturalBranch(int x, int y, int genome_number)
        {
            if(x >= 0 && y >= 0 && x < 1000 && y < 1000)
            {
                Draw(x, y, "Branch");
                field[x, y] = x.ToString() + '|' + y.ToString() + "|Branch" + '|' + genome_number.ToString();
            }
            
        }

        private void Draw(int x, int y, string type)
        {
            var g = panel1.CreateGraphics();
            Color color = new Color();
            switch (type)
            {
                case "Branch":
                    color = Color.Yellow;
                    break;
                case "Root_en":
                    color = Color.Blue;
                    break;
                case "Root_nat":
                    color = Color.Orange;
                    break;
                case "Transport":
                    color = Color.White;
                    break;
                case "Leaf":
                    color = Color.Green;
                    break;
            }
            Brush b = new SolidBrush(color);
            g.FillRectangle(b, new Rectangle(x * 10, y * 10, 10, 10));
        }
        private void Redraw()
        {
            foreach (var item in field)
            {
                if (item != null)
                {
                    string[] item_ = item.Split('|');
                    Draw(Int32.Parse(item_[0]), Int32.Parse(item_[1]), item_[2]);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Display_Genome(Int32.Parse(listView1.SelectedItems[0].Text));
            }
            catch { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 10);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Redraw();
        }





        void Execute_Genome(int x, int y)
        {
            int Genome_id = Int32.Parse(field[x, y].Split('|')[3]);
            string[] commands = Genomes[Genome_id].Split('|');
            bool left = true, right = true, up = true, down = true;
            switch (commands[7])
            {
                case "0":
                    left = false;
                    if (x > 0 && y > 0 && x < 1000 && y < 1000 && field[x - 1, y] == null)
                        Add_NaturalBranch(x - 1, y, Genome_id);
                    break;
                case "1":
                    up = false;
                    if (x > 0 && y > 0 && x < 1000 && y < 1000 && field[x, y - 1] == null)
                        Add_NaturalBranch(x, y - 1, Genome_id);
                    break;
                case "2":
                    right = false;
                    if (x > 0 && y > 0 && x < 1000 && y < 1000 && field[x + 1, y] == null)
                        Add_NaturalBranch(x + 1, y, Genome_id);
                    break;
                case "3":
                    down = false;
                    if (x > 0 && y > 0 && x < 1000 && y < 1000 && field[x, y + 1] == null)
                        Add_NaturalBranch(x, y + 1, Genome_id);
                    break;
            }
            if(x > 0 && y > 0 && x < 999 && y < 999)
            {
                if (Int32.Parse(commands[0]) < 20 && left == true) //Ћист
                {
                    if (field[x - 1, y] == null && field[x - 1, y + 1] == null && field[x - 1, y - 1] == null)
                        Add_Leaf_Cell(x - 1, y);
                
                }
                if (Int32.Parse(commands[1]) < 20 && up == true)
                {
                    if (field[x, y - 1] == null && field[x + 1, y - 1] == null && field[x -1, y - 1] == null)
                        Add_Leaf_Cell(x, y - 1);
                }
                if (Int32.Parse(commands[2]) < 20 && right == true)
                {
                    if (field[x + 1, y] == null && field[x + 1, y + 1] == null && field[x + 1, y - 1] == null)
                        Add_Leaf_Cell(x + 1, y);
                }
                if (Int32.Parse(commands[3]) < 20 && down == true)
                {
                    if (field[x, y + 1] == null && field[x + 1, y + 1] == null && field[x - 1, y + 1] == null)
                        Add_Leaf_Cell(x, y + 1);
                }

                if (Int32.Parse(commands[0]) >= 20 && Int32.Parse(commands[0]) < 40 && left == true) // орень орг.
                {
                    if (    field[x - 1, y] == null && field[x - 1, y + 1] == null && field[x - 1, y - 1] == null)
                        Add_NatRoot_Cell(x - 1, y);
                }
                if (Int32.Parse(commands[0]) >= 20 && Int32.Parse(commands[0]) < 40 && up == true)
                {
                    if (field[x, y - 1] == null && field[x + 1, y - 1] == null && field[x - 1, y - 1] == null)
                        Add_NatRoot_Cell(x, y - 1);
                }
                if (Int32.Parse(commands[0]) >= 20 && Int32.Parse(commands[0]) < 40 && right == true)
                {
                    if (field[x + 1, y] == null && field[x + 1, y + 1] == null && field[x + 1, y - 1] == null)
                        Add_NatRoot_Cell(x + 1, y);
                }
                if (Int32.Parse(commands[0]) >= 20 && Int32.Parse(commands[0]) < 40 && down == true)
                {
                    if (field[x, y + 1] == null && field[x + 1, y + 1] == null && field[x - 1, y + 1] == null)
                        Add_NatRoot_Cell(x, y + 1);
                }

                if (Int32.Parse(commands[0]) >= 40 && Int32.Parse(commands[0]) < 60 && left == true) // орень энерг.
                {
                    if (field[x - 1, y] == null && field[x - 1, y + 1] == null && field[x - 1, y - 1] == null)
                        Add_EnRoot_Cell(x - 1, y);
                }
                if (Int32.Parse(commands[0]) >= 40 && Int32.Parse(commands[0]) < 60 && up == true)
                {
                    if (field[x, y - 1] == null && field[x + 1, y - 1] == null && field[x - 1, y - 1] == null)
                        Add_EnRoot_Cell(x, y - 1);
                }
                if (Int32.Parse(commands[0]) >= 40 && Int32.Parse(commands[0]) < 60 && right == true)
                {
                    if (field[x + 1, y] == null && field[x + 1, y + 1] == null && field[x + 1, y - 1] == null)
                        Add_EnRoot_Cell(x + 1, y);
                }
                if (Int32.Parse(commands[0]) >= 40 && Int32.Parse(commands[0]) < 60 && down == true)
                {
                    if (field[x, y + 1] == null && field[x + 1, y + 1] == null && field[x - 1, y + 1] == null)
                        Add_EnRoot_Cell(x, y + 1);
                }

                if (Int32.Parse(commands[0]) >= 90 && Int32.Parse(commands[0]) < 100 && left == true) //ќтросток
                {
                    if (field[x - 1, y] == null && field[x - 1, y + 1] == null && field[x - 1, y - 1] == null)
                        Add_New_Branch(x - 1, y);
                }
                if (Int32.Parse(commands[0]) >= 90 && Int32.Parse(commands[0]) < 100 && up == true)
                {
                    if (field[x, y - 1] == null && field[x + 1, y - 1] == null && field[x - 1, y - 1] == null)
                        Add_New_Branch(x, y - 1);
                }
                if (Int32.Parse(commands[0]) >= 90 && Int32.Parse(commands[0]) < 100 && right == true)
                {
                    if (field[x + 1, y] == null && field[x + 1, y + 1] == null && field[x + 1, y - 1] == null)
                        Add_New_Branch(x + 1, y);
                }
                if (Int32.Parse(commands[0]) >= 90 && Int32.Parse(commands[0]) < 100 && down == true)
                {
                    if (field[x, y + 1] == null && field[x + 1, y + 1] == null && field[x - 1, y + 1] == null)
                        Add_New_Branch(x, y + 1);
                }
            }


            
            Add_Transport_Cell(x, y);
        }
    }
}