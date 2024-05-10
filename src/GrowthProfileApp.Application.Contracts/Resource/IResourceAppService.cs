using Microsoft.Extensions.FileProviders;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace GrowthProfileApp.Resource;

public interface IResourceAppService : IApplicationService, ITransientDependency
{
    IFileInfo GetFileInfo(string virtualPath);
}