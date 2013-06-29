using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class ClientConfiguraton : EntityTypeConfiguration<Client>
    {
        public ClientConfiguraton()
        {
            HasKey(x => x.ClientId);
            Property(x => x.ClientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}