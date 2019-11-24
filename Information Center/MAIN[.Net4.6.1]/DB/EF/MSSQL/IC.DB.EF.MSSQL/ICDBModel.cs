namespace IC.DB.EF.MSSQL
{
    using System.Data.Entity;

    using IC.DB.DataLayer;
    
    /// <summary>
    /// Presents ICDB Model for Entity Framework DB Context
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    public class ICDBModel : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ICDBModel()
            : base("name=ICDBModel")
        {
        }

        public DbSet<Advertising> Advertising { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<ContentTranslation> ContentTranslation { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyRate> CurrencyRate { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductAction> ProductAction { get; set; }
        public DbSet<ProductLog> ProductLog { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<RetailAction> RetailAction { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<StoreAction> StoreAction { get; set; }
        public DbSet<StoreAdvertising> StoreAdvertising { get; set; }
        public DbSet<SystemTranslation> SystemTranslation { get; set; }
        public DbSet<Terminal> Terminal { get; set; }
        public DbSet<TerminalCurrency> TerminalCurrency { get; set; }
        public DbSet<TerminalLanguage> TerminalLanguage { get; set; }
        public DbSet<Version> Version { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyRate>().Property(obj => obj.RateValue).HasPrecision(20, 10);
            modelBuilder.Entity<ProductPrice>().Property(obj => obj.PriceValue).HasPrecision(20, 10);

            base.OnModelCreating(modelBuilder);
        }
    }
}