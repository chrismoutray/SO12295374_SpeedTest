using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO12295374_SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 1000000;
            var data = MyData.GetList(max);

            Console.WriteLine(string.Format("Processing {0} items", max)); 
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Interation {0}", i));
                Console.WriteLine();
                Console.WriteLine("Index Count\tMethod Name\t\tExecution Time (Milliseconds)");

                RunTest(data, getIndex, "getIndex (@ellic)" );
                RunTest(data, getIndex5, "getIndex5 (@Chris)"); 
                RunTest(data, getIndex2, "getIndex2 (@mbm)");
                //RunTest(data, getIndex3, "getIndex3", "@GazTheDestroyer"); // doesn't produce a correct result
                RunTest(data, getIndex4, "getIndex4 (@Steve)");
                
            }
            
            Console.WriteLine();
            Console.WriteLine("NOTE Index Count shows a sum of the index's returned, all results should match therefore proving the method works");
            Console.WriteLine(); 
            Console.WriteLine("Any key to exit.");
            Console.Read();
        }

        private static void RunTest(MyData[] data, Func<MyData, int> func, string methodName)
        {
            int total = 0; 
            
            var sw = System.Diagnostics.Stopwatch.StartNew();

            foreach (var item in data)
            {
                total += func(item);
            }

            sw.Stop();

            Console.WriteLine(string.Format("{2}\t{0}\t{1}", methodName, sw.ElapsedMilliseconds, total));
        }

        static int getIndex(MyData obj)
        {
            if (obj.firstValue < 15)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 2;
                    else
                        return 3;
                }
            }
            else if (obj.firstValue < 41)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 4;
                    else
                        return 5;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 6;
                    else
                        return 7;
                }
            }
            else if (obj.firstValue < 90)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 8;
                    else
                        return 9;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 10;
                    else
                        return 11;
                }
            }
            else if (obj.firstValue < 128)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 12;
                    else
                        return 13;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 14;
                    else
                        return 15;
                }
            }
            else if (obj.firstValue < 166)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 16;
                    else
                        return 17;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 18;
                    else
                        return 19;
                }
            }
            else if (obj.firstValue < 196)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 20;
                    else
                        return 21;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 22;
                    else
                        return 23;
                }
            }
            else if (obj.firstValue < 205)
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 24;
                    else
                        return 25;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 26;
                    else
                        return 27;
                }
            }
            else
            {
                if (obj.secondValue < 200)
                {
                    if (obj.thirdValue < 125)
                        return 28;
                    else
                        return 29;
                }
                else
                {
                    if (obj.thirdValue < 125)
                        return 30;
                    else
                        return 31;
                }
            }
        }

        static int getIndex2(MyData obj)
        {
            int[] limitList = new int[] { 15, 41, 90, 128, 166, 196, 205 };
            int index = 0;
            foreach (int val in limitList)
            {
                if (obj.firstValue < val)
                    break; //break on first encounter
                index += 4;
            }

            if (obj.secondValue >= 200)
                index += 2;

            if (obj.thirdValue >= 125)
                index++;

            return index;
        }
        
        static int getIndex3(MyData obj)
        {
            int[] firstCutoffs = new int[] { 15, 41, 90, 128, 166, 196, 205 };
            int index = 0;

            for (int n = 0; obj.firstValue > firstCutoffs[n] && n < firstCutoffs.Length; n++)
                index += 4;

            if (obj.secondValue >= 200)
                index += 2;

            if (obj.thirdValue >= 125)
                index++;

            return index;
        }

        static int getIndex4(MyData obj)
        {
            Dictionary<int, int> firstValue = new Dictionary<int, int>();
            firstValue.Add(15, 0);
            firstValue.Add(41, 4);
            firstValue.Add(90, 8);
            firstValue.Add(128, 12);
            firstValue.Add(166, 16);
            firstValue.Add(196, 20);
            firstValue.Add(205, 24);
            firstValue.Add(256, 28);

            int mainIndex = 0;
            KeyValuePair<int, int> firstIndex = firstValue.FirstOrDefault(x => obj.firstValue < x.Key);
            mainIndex = firstIndex.Value;
            mainIndex += (obj.secondValue < 200 ? 0 : 2);
            mainIndex += (obj.thirdValue < 125 ? 0 : 1);
            return mainIndex;
        }

        static int getIndex5(MyData obj)
        {
            int index = 0;

            if (obj.firstValue < 15)
                index = 0;
            else if (obj.firstValue < 41)
                index = 4;
            else if (obj.firstValue < 90)
                index = 8;
            else if (obj.firstValue < 128)
                index = 12;
            else if (obj.firstValue < 166)
                index = 16;
            else if (obj.firstValue < 196)
                index = 20;
            else if (obj.firstValue < 205)
                index = 24;
            else
                index = 28;

            if (obj.secondValue >= 200)
                index += 2;

            if (obj.thirdValue >= 125)
                index++;

            return index;
        }
    }
}
