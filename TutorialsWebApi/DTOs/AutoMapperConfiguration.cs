using AutoMapper;
using TutorialsWebApi.Models;

namespace TutorialsWebApi.DTOs
{
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClassRoom, ClassRoomDTO>()
                   .ForMember(x => x.StudentsClassRoom, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<StudentsClassRoom, StudentsClassRoomDTO>()
                   .ReverseMap();

                cfg.CreateMap<Students, StudentsDTO>()
                   .ForMember(x => x.StudentsClassRoom, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<Teachers, TeachersDTO>()
                   .ForMember(x => x.ClassRoom, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<Subjects, SubjectsDTO>()
                   .ForMember(x => x.ClassRoom, o => o.Ignore())
                   .ReverseMap();

            });

        }
    }
}
