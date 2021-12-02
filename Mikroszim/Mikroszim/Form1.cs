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


        public Form1()
        {
            InitializeComponent();
            Population = Ember(@"C:\Temp\nép.csv");
            BirthProbabilities = születés(@"C:\Temp\születés.csv");
            DeathProbabilities = halálozás(@"C:\Temp\halál.csv");



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

    }
}
