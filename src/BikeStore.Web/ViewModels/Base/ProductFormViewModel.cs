using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeStore.Web.ViewModels.Base;

public abstract class ProductFormViewModel
{
    
    [Required(ErrorMessage = "Nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
    [Display(Name = "Nome do produto")]
    public string? ProductName { get; set; }
    
    [Required(ErrorMessage = "Preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero.")]
    [Display(Name = "Preço")]
    public decimal ListPrice { get; set; }
    
    [Required(ErrorMessage = "Marca é obrigatória")]
    [Display(Name = "Marca")]
    public int BrandId { get; set; }
    
    [Required(ErrorMessage = "Categoria é obrigatória")]
    [Display(Name = "Categoria")]
    public int CategoryId { get; set; }
    
    [Range(1900, 2030, ErrorMessage = "Ano deve estar entre 1900 e 2030.")]
    [Display(Name = "Ano do modelo")]
    public short ModelYear { get; set; }
    
    public List<SelectListItem> Brands { get; set; } = [];
    public List<SelectListItem> Categories { get; set; } = [];
    
}