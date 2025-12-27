using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.MappingProfile
{
    public class LeaveTypeAutoMapperProfile : Profile
    {

        public LeaveTypeAutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveReadOnlyViewModel>().ReverseMap();

            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }
    }
}
