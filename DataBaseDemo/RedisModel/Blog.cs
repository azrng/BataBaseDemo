﻿using System;

namespace RedisModel
{
    [Serializable]
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
