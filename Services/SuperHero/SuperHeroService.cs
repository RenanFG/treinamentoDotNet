using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patrick.Data;
using patrick.Models;

namespace patrick.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return hero;
        }
        public async Task<SuperHero?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();      
            return hero;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.AsNoTracking().ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<SuperHero?> UpdateSuperHero(int id, SuperHero request)
        {
            Console.Write("hola");
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return hero;
        }
    }
}