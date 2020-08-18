namespace BoxOfficeTestTask.Repositories.Queries
{
    public class Query<T> : IQuery<T> where T : class
    {
    }

    public interface IQuery<T> where T : class
    { 
    }
}
