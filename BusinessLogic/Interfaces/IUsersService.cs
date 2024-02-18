using DataAccess.Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Get(IEnumerable<string> ids);
        User? Get(string id);
    }
}
