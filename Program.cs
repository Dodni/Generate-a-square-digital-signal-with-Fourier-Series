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
            
            //kell a string összefűzéshez
            var asd = new StringBuilder();
            var asd2 = new StringBuilder();
            int sampleRate = 8000;
            short[] buffer = new short[8000];
            //amplitudó
            double amplitude = 0.25 * short.MaxValue;
            //frekvencia
            double frequency = 1000;
            for (int n = 0; n < buffer.Length; n++)
            {
                buffer[n] = (short)(amplitude * Math.Sin((2 * Math.PI * n * frequency) / sampleRate));
                asd.Append(" " + buffer[n].ToString() + "\n");
                
                
            }
            
            double[] buff = new double[8000];

            double a = 1000;
            asd2.Append(" " + (buff[0] = (a / 2)).ToString() + "\n");
            int j = 0;
            for (int i = 1; i < buff.Length; i++)
            {
                buff[i] = (buff[i - 1] + ((2 * a) / ((i * 2 - 1) * Math.PI)) * Math.Sin((i * 2 - 1) * ((4 * Math.PI) / sampleRate) * buffer[j]));
               
                asd2.Append(" " + buff[i].ToString() + "\n");
                j++;
            }


            using (StreamWriter writetext = new StreamWriter("write6.csv"))
            {
                writetext.WriteLine(asd);
            }
            using (StreamWriter writetext = new StreamWriter("write7.csv"))
            {
                writetext.WriteLine(asd2);
            }
            Console.ReadKey();
        }
    }
}
