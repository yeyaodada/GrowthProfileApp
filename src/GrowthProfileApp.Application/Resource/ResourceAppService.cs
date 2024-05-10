using Microsoft.Extensions.FileProviders;
using Volo.Abp.VirtualFileSystem;

namespace GrowthProfileApp.Resource;

public class ResourceAppService : GrowthProfileAppAppService, IResourceAppService
{
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ResourceAppService(IVirtualFileProvider virtualFileProvider)
    {
        _virtualFileProvider = virtualFileProvider;
    }

    public IFileInfo GetFileInfo(string path)
    {
        return _virtualFileProvider.GetFileInfo(path);
    }
}