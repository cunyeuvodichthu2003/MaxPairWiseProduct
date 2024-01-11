using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPairProduct
{
    internal class Program
    {
       static ulong MaxPair(List<ulong> list) 
        {
            int maxIndex1 =-1,maxIndex2 =-1;
            for (int i =0;i<list.Count;i++) 
            {
                
                if (maxIndex1 == -1||list[maxIndex1] < list[i])
                {
                    maxIndex1 = i;
                }    
                
            }
            for(int i = 0;i<list.Count;i++)
            {
                if (i != maxIndex1 && (maxIndex2==-1||list[maxIndex2] < list[i]) )
                {
                   maxIndex2 = i;
                }
            }    
            return list[maxIndex1] * list[maxIndex2];
        }
        static ulong SlowMaxPair(List<ulong> list)
        {
            ulong BestResult =0;
            for(int i =0;i<list.Count-1;i++)
            {
                for(int j=i+1;j<list.Count;j++)
                {
                    if (list[i] * list[j] > BestResult)
                        BestResult = list[i] * list[j];
                }    
            }    
            return BestResult;
        }
        static void Main(string[] args)
        {
            //StressTest();
            MainAlgo();
        }
        private static void MainAlgo() 
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            List<ulong> list = new List<ulong>();
            for (int i = 0; i < n; i++)
            {
                list.Add(ulong.Parse(input[i]));
            }
            Console.WriteLine(MaxPair(list));
            Console.ReadLine();
        }

        private static void StressTest()
        {
            Random random = new Random();

            while (true)
            {
                int n = random.Next(2, 1000);
                Console.WriteLine(n);
                //string[] input = Console.ReadLine().Split(' ');
                List<ulong> list = new List<ulong>();
                for (int i = 0; i < n; i++)
                {
                    list.Add((ulong)random.Next(1, 100000));
                    Console.Write(list[i] + " ");
                }
                if (MaxPair(list) == SlowMaxPair(list))
                {
                    Console.WriteLine("OK !!!");
                }
                else
                {
                    Console.WriteLine("Wrong Answear !!!: " + MaxPair(list) + " &&& " + SlowMaxPair(list));
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
