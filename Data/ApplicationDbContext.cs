using FGO_CE_Manager.Data.CEModels;
using FGO_CE_Manager.Data.EventModels;
using Microsoft.EntityFrameworkCore;

namespace FGO_CE_Manager.Data
{
    public class ApplicationDbContext :DbContext
    {
        //CE
        public DbSet<CE> CE { get; set; }
        public DbSet<CE_ExtraAssets> ExtraAssets { get; set; }
        public DbSet<CE_Skill> Skill { get; set; }
        public DbSet<ExtraAssets_CharaGraph> CharaGraph { get; set; }
        public DbSet<ExtraAssets_Faces> Faces { get; set; }
        public DbSet<Functions_Sval> Sval { get; set; }
        public DbSet<Skills_Function> Function { get; set; }

        //Event
        public DbSet<FGOEvent> Event { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
