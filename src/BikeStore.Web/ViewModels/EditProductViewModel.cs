using System.ComponentModel.DataAnnotations;
using BikeStore.Web.ViewModels.Base;

namespace BikeStore.Web.ViewModels;

public class EditProductViewModel : ProductFormViewModel
{
    [Required]
    public int Id { get; set; }
}