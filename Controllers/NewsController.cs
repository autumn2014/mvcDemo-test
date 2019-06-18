using mvcDemo01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;

namespace mvcDemo01.Controllers
{
   
    public class NewsController : ApiController
    {
        SqlConnection conn;
        SqlCommand comm;
        public List<News> listNews = new List<News>()
        {
            new News() {Id=12,Content="新闻内容1",Title="新闻标题5",Num=10 },
             new News() {Id=13,Content="新闻内容2",Title="新闻标题6",Num=10 },
              new News() {Id=24,Content="新闻内容3",Title="新闻标题7",Num=10 },
               new News() {Id=25,Content="新闻内容4",Title="新闻标题8",Num=10 }
        };
        private DataTable GetData()
        {
            
                conn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=mydb;Database=mydb;User ID=sa;Password=123456");
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from db_user", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "mytable");
            conn.Close();
            return ds.Tables[0];
        }
        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(table);
            return JsonString;
        }
        public string getUsersJson()
        {
            return DataTableToJsonWithJsonNet(GetData());
        }

        public DataTable getUsers()
        {
            return GetData();
        }
        public List<News> getAllNews()
        {
            return listNews;
        }
        // GET: api/News
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/News/5
        public string Get(int id)
        {
            return "value:"+id;
        }

        // POST: api/News
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/News/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/News/5
        public void Delete(int id)
        {
        }
    }
}
