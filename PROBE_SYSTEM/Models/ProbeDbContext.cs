using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PROBE_SYSTEM.Models
{
    public class ProbeDbContext:DbContext
    {
        public ProbeDbContext(DbContextOptions<ProbeDbContext> options):base(options){}
        public DbSet<ProbeStockModel> ProbeStock { get; set; }
        public DbSet<UploadData> UploadData { get; set; }
    }
}
