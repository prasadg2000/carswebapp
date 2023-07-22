﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using carswebapp.Manufacturers;
using carswebapp.Cars;

namespace carswebapp.Pages;

public class IndexModel : PageModel
{
    public List<Offerings>? course;

    //public void OnGet(Models model)
    public void OnGet()
    {
        Models model = new Models();
        //VendorServices vendorServices1 = vendorServices;
        course = model.GetModels();
    }
}