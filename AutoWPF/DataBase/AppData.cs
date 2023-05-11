using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AutoWPF.DataBase;

namespace AutoWPF.DataBase
{
    public static class AppData
    {
        public static AMHAEntities db = new AMHAEntities();
    }
}
