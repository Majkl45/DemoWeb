using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoData;
using DemoData.Model;
using Microsoft.AspNetCore.Authorization;
using DemoLogic.IServices;

namespace DemoWeb.Pages.AnimalPages
{
    [Authorize]
    public class CreateModel : PageModel
    {

        private readonly IAnimalService _animalservice;
        public CreateModel(IAnimalService animalservice)
        {
            _animalservice = animalservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _animalservice.CreateAnimal(Animal);

            return RedirectToPage("./Index");
        }
    }
}
