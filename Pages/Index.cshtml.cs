using Microsoft.AspNetCore.Mvc.RazorPages;
using carswebapp.Manufacturers;
using carswebapp.Cars;

namespace carswebapp.Pages;

public class IndexModel : PageModel
{
    public List<Offerings> Models;

    //public void OnGet(Models model)
    public void OnGet()
    {
        Brands brands = new Brands();
        //VendorServices vendorServices1 = vendorServices;
        Models = brands.GetModels();
    }
}