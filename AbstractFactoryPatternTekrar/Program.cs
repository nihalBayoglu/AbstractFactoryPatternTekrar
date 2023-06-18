using System;

namespace AbstractFactoryPatternTekrar
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory(new OracleFactory());
            factory.Start();
            Console.WriteLine("");
            Factory factory1 = new Factory(new MongoFactory());
            factory1.Start();
        }
    }
}
