using Core.Entities;

namespace Mvc.Models;

public class DetailViewModel : BaseViewModel
{
    public required Country Country { get; set; }
}