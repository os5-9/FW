using System.Data.Entity;

namespace JustWork.Models
{
    public class Model : DbContext
    {
        public Model()
            : base("name=ConnectionBack")
        {
        }
        public DbSet<Specialties> Specialties { get; set; }
    }
}
