using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Webapi2.Modules;
using System.Collections;

namespace Webapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            ArrayList list = new ArrayList();
            MYsql my = new MYsql();
            string sql = "select * from test;";
            MySqlDataReader sdr = my.Reader(sql);
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                }
                list.Add(ht);
            }
            return list;
        }

    }
}
