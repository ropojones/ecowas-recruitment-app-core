using Abp.Application.Services;
using EcoRecruit.MultiTenancy.Dto;

namespace EcoRecruit.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

