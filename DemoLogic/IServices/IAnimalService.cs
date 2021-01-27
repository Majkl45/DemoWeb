using DemoData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogic.IServices
{
    public interface IAnimalService
    {
        Task CreateAnimal(Animal animal);
        Task DeleteAnimal(int animalid);
        Task UpdateAnimal(Animal animal);
        Task<List<Animal>> GetAnimals();
        Task<Animal> GetAnimal(int id);
    }
}


