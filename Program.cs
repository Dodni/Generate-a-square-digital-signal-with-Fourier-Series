using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //az összefűzéshez kell
            var kiir = new StringBuilder();

            double[] final = new double[8196]; // for final numbers. DC + szinuszok
            double[] sinuses = new double[8196]; // for sinuses. Elsoszinusz, Elsoszinusz + masodikSzinusz,
                                              // Elsoszinusz + masodikSzinusz +harmadikSzinusz es így tovabb

            //példa hossza
            int sampleRate = 8196;

            //tömb hossza
            double[] buffer = new double[8196];
            
            //négyszögjel magassága (csúcsértéke)
            double a = 100;

            //dc komponens
            double DC = a / 2;

            double ketSzerA = 2 * a;
           
            //gamma
            double gamma = ((4 * Math.PI) / sampleRate);

            // pl 1,3,5 pl 1 = seged * 2 - 1
            // majd seged++;
            int seged = 1;

            //első elem a DC (a/2)
            final[0] = DC;

            for (int i = 0; i < 50; i++) // szinuszokat számlálja (az első 50-et adja össze)

            {

                for (int j = 0; j < final.Length; j++) //tömbelemekhez ad hozzá
                {
                    if (i == 0) final[j] = DC;

                    else // az aktuális eredmény időpillanatához hozzávesszük az aktuális szinusz időpillanatát

                    {

                        final[j] += ((ketSzerA / (2 * i - 1) * Math.PI) * Math.Sin((2 * i - 1) * gamma * j));

                    }

                }

            }



            for (int j = 0; j < final.Length; j++) kiir.Append(" " + final[j].ToString() + "\n");
            //for (int j = 1; j < final.Length; j++)
            //{
            //    final[j] = DC; // hozzaadjuk a DC-t a j. elemhez.
            //    sinuses[j] += sinuses[j - 1] + ((ketSzerA / (2 * seged - 1) * Math.PI) * Math.Sin((seged * 2 - 1) * gamma * j)); //a szinuszokat hozzáadjuk egymáshoz
            //    final[j] += sinuses[j]; //amit itt hozzáadjuk a végső számhoz
            //    kiir.Append(" " + final[j].ToString() + "\n"); //összefűzzük az elemeket
            //    seged++;
            //}
           
            using (StreamWriter writetext = new StreamWriter("write14.csv"))
            {
                writetext.WriteLine(kiir);
            }


            //Console.ReadKey();


            //buffer[i] += (((2 * a) / ((i * 2 - 1) * Math.PI)) * sin);

            ////1. elemet előre beírjuk a tömbe
            //buffer[0] = a / 2;
            //kiir.Append(" " + buffer[0].ToString() + "\n");

            //for (int i = 1; i < buffer.Length; i++)
            //{
            //    //időlépésnek ez a szinusz fogja jelenteni (belső ciklus)
            //    for (int j = 0; j < i; j++)
            //    {
            //        seged = Math.Sin((i * 2 - 1) * ((4 * Math.PI) / sampleRate) * j);
            //    }

            //    buffer[i] = (buffer[i - 1] + ((2 * a) / ((i * 2 - 1) * Math.PI)) * seged);
            //    kiir.Append(" " + buffer[i].ToString() + "\n");
            //    seged = 0;
            //}

            ////kell a string összefűzéshez
            //var asd = new StringBuilder();
            //var asd2 = new StringBuilder();
            //int sampleRate = 8000;
            //short[] buffer = new short[8000];
            ////amplitudó
            //double amplitude = 0.25 * short.MaxValue;
            ////frekvencia
            //double frequency = 1000;
            //for (int n = 0; n < buffer.Length; n++)
            //{
            //    buffer[n] = (short)(amplitude * Math.Sin((2 * Math.PI * n * frequency) / sampleRate));
            //    asd.Append(" " + buffer[n].ToString() + "\n");


            //}

            //double[] buff = new double[8000];

            //double a = 1000;
            //asd2.Append(" " + (buff[0] = (a / 2)).ToString() + "\n");
            //int j = 0;
            //for (int i = 1; i < buff.Length; i++)
            //{
            //    buff[i] = (buff[i - 1] + ((2 * a) / ((i * 2 - 1) * Math.PI)) * Math.Sin((i * 2 - 1) * ((4 * Math.PI) / sampleRate) * buffer[j]));

            //    asd2.Append(" " + buff[i].ToString() + "\n");
            //    j++;
            //}


            //using (StreamWriter writetext = new StreamWriter("write6.csv"))
            //{
            //    writetext.WriteLine(asd);
            //}
            //using (StreamWriter writetext = new StreamWriter("write7.csv"))
            //{
            //    writetext.WriteLine(asd2);
            //}
            //Console.ReadKey();
        }
    }
}
