using Initial_Clean_Architecture_With_Identity.Domain.Constants;
using Initial_Clean_Architecture_With_Identity.Domain.Entities.Common;
using Initial_Clean_Architecture_With_Identity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Initial_Clean_Architecture_With_Identity.Domain.DbConfigs;

public class ModificationDateDbConfig : IDbConfig
{
    public void InstallDbConfig(ModelBuilder modelBuilder)
    {
        var entitiesTypes = Assembly.GetExecutingAssembly().ExportedTypes.Where(x =>
         typeof(IModificationDate).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

        entitiesTypes.ForEach(entityType => modelBuilder.Entity(entityType)
                 .Property(nameof(IModificationDate.ModificationDate))
                 .HasColumnType(SQLConst.SmallDateTimeType)
                 .HasDefaultValueSql(SQLConst.CurrentUTCDateFunction)
                 );
    }

}

