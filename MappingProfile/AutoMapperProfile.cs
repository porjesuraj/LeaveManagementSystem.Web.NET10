using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.MappingProfile
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            // Create your mapping configurations here
            // Example:
            // CreateMap<SourceModel, DestinationModel>();

            //    CreateMap<LeaveType, IndexViewModel>().ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
            CreateMap<LeaveType, LeaveReadOnlyViewModel>().ReverseMap();

            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();

        }
    }
}
