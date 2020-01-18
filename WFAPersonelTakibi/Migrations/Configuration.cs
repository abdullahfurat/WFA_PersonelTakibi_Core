namespace WFAPersonelTakibi.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WFAPersonelTakibi.Models;

    internal sealed class Configuration
        : DbMigrationsConfiguration<WFAPersonelTakibi.Data.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WFAPersonelTakibi.Data.ProjectContext context)
        {
            //List<Department> departments = new List<Department>
            //{
            //    new Department { Name = "Sistem" },
            //    new Department { Name = "Yazılım" },
            //    new Department { Name = "Muhasebe" },
            //    new Department { Name = "Web Grafik" },
            //    new Department { Name = "Teknik Çizim" },
            //};
             
            //context.Departments.AddRange(departments);
            //context.SaveChanges(); 
        }
    }
}
