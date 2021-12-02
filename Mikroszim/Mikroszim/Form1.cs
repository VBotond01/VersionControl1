using Mikroszim.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszim
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rand = new Random(1234);
        public string fájlnév { get; set; }


        public Form1()
        {
            InitializeComponent();
            Population = Ember(@"C:\Temp\nép.csv");
            BirthProbabilities = születés(@"C:\Temp\születés.csv");
            DeathProbabilities = halálozás(@"C:\Temp\halál.csv");

            // dataGridView1.DataSource = Population;

            for (int year = 2005; year < 2025 ; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year,Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();

                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Woman && x.IsAlive
                                    select x).Count();

                Console.WriteLine(string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));

            }
        
        }

        public List<Person> Ember(string fájl)
        {
            List<Person> Ember = new List<Person>();

            using (StreamReader sr = new StreamReader(fájl, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    Ember.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumberOfChildren = int.Parse(line[2])

                    }
                    ) ;                           
                }                  
            }
                return Ember;

        }

        public List<BirthProbability> születés(string fájl)
        {
            List<BirthProbability> szüli = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(fájl, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    szüli.Add(new BirthProbability()
                    {
                        
                        Age = int.Parse(line[0]),
                        NumberOfChildren = int.Parse(line[1]),
                        BornRates = double.Parse(line[2])

                    }
                    );
                }
            }
            return szüli;

        }

        public List<DeathProbability> halálozás (string fájl)
        {
            List<DeathProbability> halál = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(fájl, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    halál.Add(new DeathProbability()
                    {

                        Age = int.Parse(line[1]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        DeathRates = double.Parse(line[2])

                    }
                    );
                }
            }
            return halál;

        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;
            var age = year - person.BirthYear;

            var halál = ( from x in DeathProbabilities
                          where x.Gender == person.Gender && x.Age == age
                          select x.DeathRates).FirstOrDefault();

            if(rand.NextDouble() <= halál)
            person.IsAlive = false;
            if (person.IsAlive && person.Gender == Gender.Woman)
            {

                var birthrates = (from x in BirthProbabilities
                                  where x.Age == age
                                  select x.BornRates).FirstOrDefault();
                if(rand.NextDouble() <= birthrates)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NumberOfChildren = 0;
                    újszülött.Gender = (Gender)(rand.Next(1, 3));
                    Population.Add(újszülött);
                }
            }


            
        }
        private void Simulation()
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simulation();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog asd = new OpenFileDialog())
            {
                asd.InitialDirectory = "C:\\";
                asd.FilterIndex = 2;

                if (asd.ShowDialog() == DialogResult.OK)
                {
                    fájlnév = asd.FileName;
                }
                
            }
        }
    }
}
