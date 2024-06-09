using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Peiton.Core.Entities;

namespace Peiton.Infrastructure;

public class PeitonDbContext : DbContext
{
    public PeitonDbContext(DbContextOptions<PeitonDbContext> options) : base(options)
    {

    }

    public string DateAsString(DateTime date) => throw new NotSupportedException();
    public string IntAsString(int value) => throw new NotSupportedException();
    public string DecimalAsString(decimal value) => throw new NotSupportedException();

    public DbSet<Capitulo> Capitulo => Set<Capitulo>();
    public DbSet<Partida> Partida => Set<Partida>();
    public DbSet<Tutelado> Tutelado => Set<Tutelado>();
    public DbSet<Usuario> Usuario => Set<Usuario>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDbFunction(this.GetType().GetMethod("DateAsString", new[] { typeof(DateTime) })!)
                    .HasTranslation(args =>
                        new SqlFunctionExpression("CONVERT",
                            new[] {
                                new SqlFragmentExpression("varchar"),
                                args.First(),
                                new SqlFragmentExpression("103")
                            },
                            false,
                            new[] { false },
                            typeof(string),
                            null
                        ));

        modelBuilder.HasDbFunction(this.GetType().GetMethod("IntAsString", new[] { typeof(int) })!)
                    .HasTranslation(args =>
                        new SqlFunctionExpression("CONVERT",
                            new[] {
                                new SqlFragmentExpression("varchar"),
                                args.First()
                            },
                            false,
                            new[] { false },
                            typeof(string),
                            new StringTypeMapping("varchar", System.Data.DbType.String)
                        ));

        //replace(convert(varchar, Gastos, 2),'.',',')
        modelBuilder.HasDbFunction(this.GetType().GetMethod("DecimalAsString", new[] { typeof(decimal) })!)
        .HasTranslation(args =>
        {

            var convertExpression = new SqlFunctionExpression(
                        "CONVERT",
                        new SqlExpression[]
                        {
                            new SqlFragmentExpression("varchar"),
                            args.First(),
                            new SqlFragmentExpression("2")
                        },
                        false,
                        new[] { false },
                        typeof(string),
                        new StringTypeMapping("varchar", System.Data.DbType.String));

            var replaceExpression = new SqlFunctionExpression(
                        "REPLACE",
                        new SqlExpression[]
                        {
                            convertExpression,
                            new SqlFragmentExpression("'.'"),
                            new SqlFragmentExpression("','")
                        },
                        false,
                        new[] { false },
                        typeof(string),
                        new StringTypeMapping("varchar", System.Data.DbType.String));

            return replaceExpression;
        });

    }
}
