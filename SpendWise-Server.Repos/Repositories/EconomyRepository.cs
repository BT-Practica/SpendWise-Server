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
        var verifyUserHasEconomy = await _context.Economies.FirstOrDefaultAsync(u => u.UserId == economiesDto.UserId);
        if(verifyUserHasEconomy != null){
            verifyUserHasEconomy.Amount = economiesDto.Amount;
        }else{
            Economies economy = new Economies
            {
                Amount = economiesDto.Amount,
                RegistrationDate = DateTime.Now,
                UserId = economiesDto.UserId
            };
            await _context.AddAsync(economy);
        }
        await _context.SaveChangesAsync();

    }

    public async Task DeleteEconomy(int id)
    {
        var economies = await _context.Economies.FirstOrDefaultAsync(e => e.Id == id);
        _context.Economies.Remove(economies);
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

    public async Task<Economies> GetEconomyByUserId(int userId)
    {
        var economy = await _context.Economies.FirstOrDefaultAsync(u => u.UserId == userId);
        if(economy == null){
            throw new KeyNotFoundException("User does not have economy added.");
        }
        return economy;
    }

    public async Task UpdateEconomy(EconomyDto economyDto, int id)
    {
        Economies economyToUpdate = _context.Economies.FirstOrDefault(u => u.Id == id);
        economyToUpdate.Amount = economyDto.Amount;
        _context.SaveChangesAsync();
    }
}