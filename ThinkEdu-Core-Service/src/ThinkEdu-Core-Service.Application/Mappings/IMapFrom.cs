using AutoMapper;

namespace ThinkEdu_Core_Service.Application.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}