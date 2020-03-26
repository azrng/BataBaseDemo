﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Mongo
{
    /// <summary>
    /// 官方 https://api.mongodb.com/csharp/2.2/html/R_Project_CSharpDriverDocs.htm
    ///  https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoService<T> where T : BaseModel
    {
        private readonly IMongoCollection<T> _collection;   //数据表操作对象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        /// <param name="tableName">表名</param>
        public MongoService(DatabaseSettings config, string tableName)
        {
            var client = new MongoClient(config.ConnectionString);    //获取链接字符串

            var database = client.GetDatabase(config.DatabaseName);
            //var database = client.GetDatabase(config.GetSection("MongoDBSetting:DBName").Value);   //数据库名 （不存在自动创建）

            //获取对特定数据表集合中的数据的访问
            _collection = database.GetCollection<T>(tableName);     // （不存在自动创建）
        }

        //Find<T> – 返回集合中与提供的搜索条件匹配的所有文档。
        //InsertOne – 插入提供的对象作为集合中的新文档。
        //ReplaceOne – 将与提供的搜索条件匹配的单个文档替换为提供的对象。
        //DeleteOne – 删除与提供的搜索条件匹配的单个文档。

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>  
        public List<T> GetList()
        {
            return _collection.Find(T => true).ToList();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetModel(string id)
        {
            return _collection.Find<T>(T => T.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public T Add(T T)
        {
            _collection.InsertOne(T);
            return T;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TIn"></param>
        public void Update(string id, T TIn)
        {
            _collection.ReplaceOne(T => T.Id == id, TIn);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="TIn"></param>
        public void Remove(T TIn)
        {
            _collection.DeleteOne(T => T.Id == TIn.Id);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            _collection.DeleteOne(T => T.Id == id);
        }
    }
}