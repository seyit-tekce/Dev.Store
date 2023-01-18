using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Dev.Store.Identity
{
	[Authorize(IdentityPermissions.Users.Default)]

	public class UserAppService : IdentityUserAppService
	{

		private readonly IRepository<IdentityUser, Guid> _repository;


		public UserAppService(IdentityUserManager userManager, IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, IOptions<IdentityOptions> identityOptions, IRepository<IdentityUser, Guid> repository) : base(userManager, userRepository, roleRepository, identityOptions)
		{
			_repository = repository;
		}

		[HttpGet]
		[Authorize(StorePermissions.Category.Default)]
		public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
		{
			return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<IdentityUser, IdentityUserDto>(x));
		}


	}
}
