using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Keywords.Keyword.ViewModels;

public class CreateEditKeywordViewModel
{
    [Display(Name = "KeywordName")]
    public string Name { get; set; }
}
