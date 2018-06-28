using System;
using System.Data.SQLite;

namespace FootballOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=C:/Users/Lenovo/Documents/Visual Studio 2015/Projects/FootballOptimizer/FootballOptimizer/db/database.db");
            connection.Open();




            //IOptimization optimization = new Simple1v1OptimizationWithoutBall();

            //for (int i = 0; i < 100000; i++)
            //{
            //    Console.WriteLine("Era: " + i);

            //    optimization.Era();
            //}

            Console.WriteLine("finish");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
