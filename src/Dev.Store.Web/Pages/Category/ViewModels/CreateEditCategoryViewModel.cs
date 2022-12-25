using Dev.Store.Entities.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Entities.Category.ViewModels;

public class CreateEditCategoryViewModel
{
    [Display(Name = "CategoryName")]
    public string Name { get; set; }

    [Display(Name = "CategoryLink")]
    public string Link { get; set; }

    [Display(Name = "CategoryDescription")]
    public string Description { get; set; }

    [Display(Name = "CategoryPid")]
    public Guid? Pid { get; set; }

}
