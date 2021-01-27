using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoData;
using DemoData.Model;
using DemoLogic.IServices;

namespace DemoWeb.Pages.AnimalPages
{
    public class IndexModel : PageModel
    {
        public IList<Animal> Animals { get; set; }

        private readonly IAnimalService _animalservice;
        public IndexModel(IAnimalService animalservice)
        {
            _animalservice = animalservice;
        }
        public async Task OnGetAsync()
        {
            Animals = await _animalservice.GetAnimals();
        }
    }
}
