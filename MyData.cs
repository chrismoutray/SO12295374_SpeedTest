using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO12295374_SpeedTest
{
    public class MyData
    {
        public int firstValue { get; set; }
        public int secondValue { get; set; }
        public int thirdValue { get; set; }

        public static MyData[] GetList(int max)
        {
            var r = new Random();

            var data = new List<MyData>();

            for (int i = 0; i < max; i++)
            {
                data.Add(new MyData() 
                {
                    firstValue = r.Next(255), 
                    secondValue = r.Next(255), 
                    thirdValue = r.Next(255) 
                });
            }

            return data.ToArray();
        }
    }
}
