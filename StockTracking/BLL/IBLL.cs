
namespace StockTracking.BLL
{
    interface IBLL<T, K> where T : class where K : class
    {
        K Select(bool isDeleted);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(T entity);
    }
}
