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
using var.Entities;

namespace var
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        List<decimal> nyereségekRendezve;
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList(); //A ToList fontos
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();


            List<decimal> Nyereségek = new List<decimal>(); // csak decimális értékek vannak benne

            // felhasználótól szokás bekérni
            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30); //DateTimePicker.Value és beállítani az alap értékét
            

            TimeSpan z = záróDátum - kezdőDátum;

            for (int i = 0; i < z.Days - intervalum; i++) //garantálva van hogy nem fogunk kicsúzni a záródátumunkból
            {
             /*   DateTime ablakZáró = kezdőDátum.AddDays(i + intervalum);
                DateTime ablakNyitó = kezdőDátum.AddDays(i);
                decimal ny = GetPortfolioValue(ablakZáró) -
                            GetPortfolioValue(ablakNyitó); */

                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString()); //20%-os konfidencia szint mellett max ennyi veszteségünk lehet

            /*    int elemszam = Portfolio.Count();
                decimal részvényekszáma = (from x in Portfolio 
                                           select x.Volume).Sum();

                var otp = from x in Ticks
                          where x.Index.Trim().Equals("OTP")
                          select new
                          {
                              x.Index,
                              x.Price
                          };
                Console.WriteLine("OTP darabszám: " + otp.Count().ToString());
                var top = from o in otp
                          where o.Price > 7000
                          select o;
                Console.WriteLine("OTP darabszám több mint 7000: " + top.Count().ToString());

                var topsum = (from t in top
                              select t.Price).Sum();

                DateTime minDátum = (from x in Ticks
                                     select x.TradingDay).Min();
                DateTime maxdátum = (from x in Ticks
                                     select x.TradingDay).Max();
                int elteltNapokSzáma = (maxdátum - minDátum).Days;
                Console.WriteLine((elteltNapokSzáma).ToString());

                var kapcsolt = from x in Ticks
                               join
                                    y in Portfolio
                                on x.Index equals y.Index
                               select new
                               {
                                   Index = x.Index,
                                   Date = x.TradingDay,
                                   Value = x.Price,
                                   Volume = y.Volume

                               };

                dataGridView1.DataSource = kapcsolt.ToList();  */

        }

        private void CreatePortfolio()
        {
        //    PortfolioItem p = new PortfolioItem();
         //   p.Index = "OTP";
         //   p.Volume = 10;
         //   Portfolio.Add(p);
         //Egyszerűsítés:
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
     
        }

        private decimal GetPortfolioValue(DateTime date)
        {

            // decimal value =0 ; .... return value; ez fontos!
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                              orderby x.TradingDay
                              /// ezzel garantálni tudjuk hogy az általunk megadott dátumhoz 
                              /// legközelebbi értékkel fogunk számolni
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath; //indulómappájából lekéri az indulókönyvtárat, itt nyílik ki a mentés

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                sw.WriteLine("Időszak; Nyereség"); //fejléc
                for (int i = 0; i < nyereségekRendezve.Count(); i++)
                {
                    sw.WriteLine(string.Format(
                        "{0};{1}",
                       i, 
                   //     Math.Round((double)i / (double)nyereségekRendezve.Count(), 2), //%-ot látom ezzel
                        nyereségekRendezve[i]  //hányadik elemről beszélünk
                        ));
                }
            }
            
        }
    }


}
