using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoData;
using DemoData.Model;
using Microsoft.AspNetCore.Authorization;
using DemoLogic.IServices;

namespace DemoWeb.Pages.AnimalPages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IAnimalService _animalservice;
        public DeleteModel(IAnimalService animalservice)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _animalservice.DeleteAnimal((int)id);

            return RedirectToPage("./Index");
        }
    }
}
