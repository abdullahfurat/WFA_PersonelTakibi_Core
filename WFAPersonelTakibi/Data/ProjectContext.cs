using System.Data.Entity;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=PersoneTakibiDB;uid=sa;pwd=123";
        }
         
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
