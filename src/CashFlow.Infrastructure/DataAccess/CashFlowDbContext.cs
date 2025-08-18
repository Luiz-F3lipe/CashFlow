using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Server=127.0.0.1;Database=cashflow;Uid=root;Pwd=password";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 43));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}