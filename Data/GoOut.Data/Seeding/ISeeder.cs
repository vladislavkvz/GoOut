namespace GoOut.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(DbContext dbContext, IServiceProvider serviceProvider);
    }
}