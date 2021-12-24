using Microsoft.EntityFrameworkCore;

namespace Initial_Clean_Architecture_With_Identity.Domain.Interfaces;

public interface IDbConfig
{
    void InstallDbConfig(ModelBuilder modelBuilder);
}

