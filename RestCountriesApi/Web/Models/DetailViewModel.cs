using Core.Entities;

namespace Web.Models;

public class DetailViewModel : BaseViewModel
{
    public required Country Country { get; set; }
}