namespace assignment2.Repositories
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}