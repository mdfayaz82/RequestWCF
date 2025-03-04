using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RequestSample.Models;

namespace RequestSample
{
    public class RequestDBContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}