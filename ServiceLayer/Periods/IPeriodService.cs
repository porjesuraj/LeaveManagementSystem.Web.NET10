namespace LeaveManagementSystem.Web.ServiceLayer.Periods
{
    public interface IPeriodService
    {
        Task<Period> GetCurrentPeriod();
    }



}
