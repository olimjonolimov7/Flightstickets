using Flightstickets.Models;

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(int userId);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
