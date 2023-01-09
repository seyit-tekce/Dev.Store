using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Locations.ViewModels;

public class CreateEditLocationViewModel
{
    [Display(Name = "LocationName")]
    public string Name { get; set; }

    [Display(Name = "LocationCode")]
    public string Code { get; set; }

    [Display(Name = "LocationPid")]
    public Guid? Pid { get; set; }

    [Display(Name = "LocationLocationParentId")]
    public Guid? LocationParentId { get; set; }

}
