namespace CartAPI.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}
