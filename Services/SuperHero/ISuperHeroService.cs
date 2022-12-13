using patrick.Models;

namespace patrick.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<SuperHero> AddHero(SuperHero hero);
        Task<SuperHero>? UpdateSuperHero(int id, SuperHero request);
        Task<SuperHero>? DeleteHero(int id);
    }
}