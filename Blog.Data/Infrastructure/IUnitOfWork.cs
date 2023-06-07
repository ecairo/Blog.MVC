namespace Blog.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}