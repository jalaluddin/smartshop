namespace SmartShop.Inventory
{
    public interface IProductManagementUnitOfWork
    {
        ProductImageRepository ProductImageRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        void Dispose();
        void Save();
    }
}