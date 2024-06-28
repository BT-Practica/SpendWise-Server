using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.EconomyDtos;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class EconomyRepository : IEconomyRepository
{
    public readonly DataContext _context;
    public EconomyRepository(DataContext context)
    {
        _context = context;
    }
    public async Task AddEconomy(EconomyDto economiesDto)
    {
        Economies economy = new Economies
        {
            Amount = economiesDto.Amount,
            RegistrationDate = DateTime.Now
        };
        await _context.AddAsync(economy);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEconomy(int id)
    {
        var economies = await _context.Economies.FirstOrDefaultAsync(e => e.Id == id);
        _context.Remove(id);
        await _context.SaveChangesAsync();
    }

    public List<Economies> GetAllEconomies()
    {
        var economies = _context.Economies.ToList();
        return economies;
    }

    public Economies GetEconomy(int id)
    {
        var economies = _context.Economies.FirstOrDefault(e => e.Id == id);
        return economies;
    }

    public async Task UpdateEconomy(EconomyDto economyDto, int id)
    {
        Economies economies = new Economies();
        economies.Amount = economyDto.Amount;
        economies.RegistrationDate = DateTime.Now;

        _context.Update(economies);
        await _context.SaveChangesAsync(true);
    }
}