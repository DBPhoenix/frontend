using Core.Entities;

namespace Mvc.Models;

public class IndexViewModel : BaseViewModel
{
    public required Country[] Countries { get; init; }
    public required string[] Regions { get; init; }
}
