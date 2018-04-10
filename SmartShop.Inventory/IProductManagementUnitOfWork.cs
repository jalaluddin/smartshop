namespace SmartShop.Inventory
{
    public interface IProductManagementUnitOfWork
    {
        ProductImageRepository ProductImageRepository { get; set; }
        ProductRepository ProductRepository { get; set; }
        void Dispose();
        void Save();
    }
}