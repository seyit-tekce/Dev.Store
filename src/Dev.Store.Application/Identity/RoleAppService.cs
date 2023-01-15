using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Dev.Store.Identity
{
    [Authorize(IdentityPermissions.Roles.Default)]
    public class RoleAppService : IdentityRoleAppService
    {
        private readonly IRepository<IdentityRole, Guid> _repository;

        public RoleAppService(IdentityRoleManager roleManager, IIdentityRoleRepository roleRepository, IRepository<IdentityRole, Guid> repository) : base(roleManager, roleRepository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(StorePermissions.Category.Default)]
        public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
        {
            return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<IdentityRole, IdentityRoleDto>(x));
        }


    }
}
