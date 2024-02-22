using AutoMapper;
using Employ_of_Company.Models;

namespace Employ_of_Company
{
    public class Mapping_Config_Employ : Profile
    {
        public Mapping_Config_Employ()
        {

            CreateMap<EmployDTO, EmployInfo>().ReverseMap();
            CreateMap<EmployUpdateDTO, EmployInfo>().ReverseMap();
            
        }

    }
}
