namespace SmartShop.Inventory
{
    public interface IProductCategoryManagementUnitOfWork
    {
        ProductCategoryRepository ProductCategoryRepository { get; set; }

        void Dispose();
        void Save();
    }
}