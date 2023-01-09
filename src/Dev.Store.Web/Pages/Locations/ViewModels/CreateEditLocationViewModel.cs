using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Locations.ViewModels;

public class CreateEditLocationViewModel
{
    [Display(Name = "LocationName")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "LocationCode")]
    public int? Code { get; set; }

    [Display(Name = "LocationLocationParentId")]
    [HiddenInput]
    public Guid? LocationParentId { get; set; }

}
