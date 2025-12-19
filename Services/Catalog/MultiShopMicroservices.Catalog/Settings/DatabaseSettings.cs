namespace MultiShopMicroservices.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollecionName { get; set; }
        public string ProductDetailCollecionName { get; set; }
        public string ProductImageCollecionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
