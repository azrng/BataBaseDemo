using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySQL_NetCore_EFCore.Entity
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [Table("userinfo")]
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
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
