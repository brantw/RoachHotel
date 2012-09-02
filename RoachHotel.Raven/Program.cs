using System;

namespace RoachHotel.Raven
{
    public class Program
    {
        public static void Main()
        {
            var tasks = new Raven();
            
            foreach (var task in tasks.GetData())
            {
                Console.WriteLine(task.Name);
            }

            Console.ReadLine();
        }
    }
}