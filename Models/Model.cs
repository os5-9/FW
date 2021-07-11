using System.Data.Entity;

namespace JustWork.Models
{
    public class Model : DbContext
    {
        public Model()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<Specialties> Specialties { get; set; }
    }
}
