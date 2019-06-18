using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcDemo01.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Num { get; set; }
    }
}