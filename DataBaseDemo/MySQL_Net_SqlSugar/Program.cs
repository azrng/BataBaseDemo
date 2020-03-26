using MySQL_Net_SqlSugar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Net_SqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();

            var info = db.DbUserInfoEntity.GetList();

            Console.WriteLine("测试");
        }
    }
}
