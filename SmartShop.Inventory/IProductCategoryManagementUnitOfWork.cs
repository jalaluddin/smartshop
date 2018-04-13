namespace SmartShop.Inventory
{
    public interface IProductCategoryManagementUnitOfWork
    {
        IProductCategoryRepository ProductCategoryRepository { get; set; }

        void Dispose();
        void Save();
    }
}