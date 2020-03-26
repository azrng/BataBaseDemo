using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySQL_Net_SqlSugar.Entity
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [SugarTable("userinfo")]
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public int IsValid { get; set; }
    }
}
