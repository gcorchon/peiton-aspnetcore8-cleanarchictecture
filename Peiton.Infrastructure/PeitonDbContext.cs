using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

using Peiton.Contracts.Caja;
using Peiton.Contracts.Asientos;

using Peiton.Core.Entities;
using Peiton.Contracts.Consultas;


namespace Peiton.Infrastructure;

public class PeitonDbContext : DbContext
{
    public PeitonDbContext(DbContextOptions<PeitonDbContext> options) : base(options)
    {

    }

    public string DateAsString(DateTime date) => throw new NotSupportedException();


    public string IntAsString(int value) => throw new NotSupportedException();
    public string DecimalAsString(decimal value) => throw new NotSupportedException();

    public IQueryable<Saldo> ContabilidadObtenerSaldos(int ano) => FromExpression(() => ContabilidadObtenerSaldos(ano));
    public IQueryable<ConsultaListItem> ObtenerConsultasAlmacenadas(int usuarioId) => FromExpression(() => ObtenerConsultasAlmacenadas(usuarioId));

    public bool EsVisitado(string nombre, string datos) => throw new NotSupportedException();

    public DbSet<Account> Account => Set<Account>();
    public DbSet<Capitulo> Capitulo => Set<Capitulo>();
    public DbSet<Credencial> Credencial => Set<Credencial>();
    public DbSet<EntidadFinanciera> EntidadFinanciera => Set<EntidadFinanciera>();


    public DbSet<Partida> Partida => Set<Partida>();
    public DbSet<Tutelado> Tutelado => Set<Tutelado>();
    public DbSet<Usuario> Usuario => Set<Usuario>();

    public DbSet<VwCajaAMTA> VwCajaAMTA => Set<VwCajaAMTA>();

    public DbSet<VwCategoria> VwCategoria => Set<VwCategoria>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var saldo = modelBuilder.Entity<Saldo>();
        saldo.HasNoKey();
        saldo.Property(s => s.Ejecutado).HasColumnType("money");
        saldo.Property(s => s.Pendiente).HasColumnType("money");
        saldo.Property(s => s.PorcEjecutado).HasColumnType("money");
        saldo.Property(s => s.Presupuesto).HasColumnType("money");

        modelBuilder.HasDbFunction(this.GetType().GetMethod("DateAsString", [typeof(DateTime)])!)
                    .HasTranslation(args =>
                        new SqlFunctionExpression("CONVERT",
                            [
                                new SqlFragmentExpression("varchar"),
                                args.First(),
                                new SqlFragmentExpression("103")
                            ],
                            false,
                            [false],
                            typeof(string),
                            null
                        ));

        modelBuilder.HasDbFunction(this.GetType().GetMethod("IntAsString", [typeof(int)])!)
                    .HasTranslation(args =>
                        new SqlFunctionExpression("CONVERT",
                            [
                                new SqlFragmentExpression("varchar"),
                                args.First()
                            ],
                            false,
                            [false],
                            typeof(string),
                            new StringTypeMapping("varchar", System.Data.DbType.String)
                        ));

        modelBuilder.HasDbFunction(this.GetType().GetMethod("EsVisitado", [typeof(string), typeof(string)])!)
                   .HasTranslation(args =>
                       new SqlFunctionExpression("dbo.EsVisitado",
                           [
                               args.ElementAt(0),
                                args.ElementAt(1)
                           ],
                           false,
                           [false, false],
                           typeof(bool),
                           new BoolTypeMapping("bit", System.Data.DbType.Boolean)
                       ));

        //replace(convert(varchar, Gastos, 2),'.',',')
        modelBuilder.HasDbFunction(this.GetType().GetMethod("DecimalAsString", new[] { typeof(decimal) })!)
        .HasTranslation(args =>
        {

            var convertExpression = new SqlFunctionExpression(
                        "CONVERT",
                        [
                            new SqlFragmentExpression("varchar"),
                            args.First(),
                            new SqlFragmentExpression("2")
                        ],
                        false,
                        [false],
                        typeof(string),
                        new StringTypeMapping("varchar", System.Data.DbType.String));

            var replaceExpression = new SqlFunctionExpression(
                        "REPLACE",
                        [
                            convertExpression,
                            new SqlFragmentExpression("'.'"),
                            new SqlFragmentExpression("','")
                        ],
                        false,
                        [false],
                        typeof(string),
                        new StringTypeMapping("varchar", System.Data.DbType.String));

            return replaceExpression;
        });

        modelBuilder.HasDbFunction(this.GetType().GetMethod("ContabilidadObtenerSaldos", [typeof(int)])!);
        modelBuilder.HasDbFunction(this.GetType().GetMethod("ObtenerConsultasAlmacenadas", [typeof(int)])!);

    }
}
