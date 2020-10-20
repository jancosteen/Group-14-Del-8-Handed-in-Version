using MDR_Angular.Configuration;
using MDR_Angular.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MDR_Angular.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MDR_AngularDbContextFactory : IDesignTimeDbContextFactory<MDR_AngularDbContext>
    {
        public MDR_AngularDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MDR_AngularDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MDR_AngularDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MDR_AngularConsts.ConnectionStringName));

            return new MDR_AngularDbContext(builder.Options);
        }
    }
}
