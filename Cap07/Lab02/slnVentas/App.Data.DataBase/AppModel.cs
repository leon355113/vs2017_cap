namespace App.Data.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using App.Entities.Base;

    public partial class AppModel : DbContext
    {
        public AppModel()
            : base("name=AppModel")
        {
            Database.SetInitializer<AppModel>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Marca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnidadMedida>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.UnidadMedida)
                .WillCascadeOnDelete(false);
        }
    }
}
