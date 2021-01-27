using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoData;
using DemoData.Model;
using Microsoft.AspNetCore.Authorization;
using DemoLogic.IServices;

namespace DemoWeb.Pages.AnimalPages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IAnimalService _animalservice;
        public EditModel(IAnimalService animalservice)
        {
            _animalservice = animalservice;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _animalservice.GetAnimal((int)id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _animalservice.UpdateAnimal(Animal);

            return RedirectToPage("./Index");
        }
    }
}
