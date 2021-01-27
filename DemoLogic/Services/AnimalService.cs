using DemoData;
using DemoData.Model;
using DemoLogic.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogic.Services
{
    public class AnimalService : IAnimalService
    {
        ApplicationDbContext _context;
        public AnimalService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int animalid)
        {
            var removal = await _context.Animals.Where(x => x.Id == animalid).FirstOrDefaultAsync();
            _context.Animals.Remove(removal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Animal>> GetAnimals()
        {
            var list = _context.Animals.OrderBy(x => x.Name).ToListAsync();
            return await list;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            var result = await _context.Animals.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}
