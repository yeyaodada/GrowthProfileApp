using AutoMapper;
using GrowthProfileApp.Documents;

namespace GrowthProfileApp;

public class GrowthProfileAppApplicationAutoMapperProfile : Profile
{
    public GrowthProfileAppApplicationAutoMapperProfile()
    {
        // 档案
        CreateMap<ProfileDocument, ProfileDocumentDto>();
        CreateMap<CreateUpdateProfileDocumentDto, ProfileDocument>();
        
        // 个人信息
        CreateMap<BasicInfoDocument, BasicInfoDocumentDto>();
        CreateMap<CreateUpdateBasicInfoDocumentDto, BasicInfoDocument>();
    }
}
