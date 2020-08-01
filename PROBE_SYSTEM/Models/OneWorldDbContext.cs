using Microsoft.EntityFrameworkCore;

namespace PROBE_SYSTEM.Models
{
    public class OneWorldDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public OneWorldDbContext(DbContextOptions<OneWorldDbContext> options) : base(options)
        {

        }
        public virtual DbSet<VewInvoiceInquiryModel> vewInvoiceInquiry { get; set; }
    }
}
