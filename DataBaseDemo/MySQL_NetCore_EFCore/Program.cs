using MySQL_NetCore_EFCore.Entity;
using System;
using System.Linq;

namespace MySQL_NetCore_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();

            var info = db.UserInfoEntities.ToList();


            Console.WriteLine("Hello World!");
        }
    }
}
