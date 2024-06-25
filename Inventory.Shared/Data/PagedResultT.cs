

namespace Inventory.Shared.Data
{
    public class PagedResultT<T>:PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }
        public PagedResultT()
        {
            Results = new List<T>();
        }
    }
}
