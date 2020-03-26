using MySQL_Net_SqlSugar.Entity;
using System;

namespace MySQL_NetCore_SqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();

            var info = db.DbUserInfoEntity.GetList();


            Console.WriteLine("Hello World!");
        }
    }
}
