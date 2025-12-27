using AutoMapper;
using LeaveManagementSystem.Web.Models;
using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.MappingProfile
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {

        public LeaveAllocationAutoMapperProfile()
        {

             CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
             CreateMap<Period, PeriodVM>().ReverseMap();
            CreateMap<EmployeeListVM, ApplicationUser>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveEditAllocationVM>().ReverseMap();

        }
    }
}
