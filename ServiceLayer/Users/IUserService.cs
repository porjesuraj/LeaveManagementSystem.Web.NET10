namespace LeaveManagementSystem.Web.ServiceLayer.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetLoggedInUser();
        Task<ApplicationUser> GetUserById(string userId);


    }
}
