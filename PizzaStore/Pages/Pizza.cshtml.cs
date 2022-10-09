using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty] //ini buat mengikat model dan spy bisa mengakses data dr model
        public Pizza NewPizza { get; set; } = new();

        public List<Pizza> pizzas = new();
        /* Saat metode OnGet dipanggil, hasil metode PizzaService.GetAll() akan ditetapkan ke variabel pizzas. 
         * Variabel ini akan dapat diakses oleh template halaman Razor, di mana variabel ini akan ditulis ke tabel 
         * yang mencantumkan pizza yang tersedia. */

        public void OnGet()
        {
            //ini utk ambil data puizza
            pizzas = PizzaService.GetAll();
        }

        /* Properti IsGlutenFree adalah nilai boolean.
         * Anda dapat menggunakan metode utilitas untuk 
         * memformat nilai boolean sebagai string. */

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }

        /* Kelas PizzaModel sekarang memiliki penanganan halaman OnPost asinkron. 
         * OnPost dijalankan saat pengguna memposting formulir halaman Pizza. 
         * Anda juga dapat menggunakan akhiran penamaan Async opsional, OnPostAsync. */

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //ini actionnya yaitu namabh item
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //ini actionnya yaitu namabh item
            PizzaService.Update(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

    }
}
