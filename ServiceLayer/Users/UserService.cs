namespace LeaveManagementSystem.Web.ServiceLayer.Users
{
    public class UserService(UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserService
    {
        public async Task<ApplicationUser> GetLoggedInUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            return user;

        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }
    }
}
