﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories
{
    public class Income_CategoriesRepository : IIncome_CategoriesRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        public Income_CategoriesRepository(DataContext context, ILogger<Income> logger)
        {
            _logger = logger;
            _context = context;
        }

        public void AddIncomeCategories(IncomeDto categoryDto)
        {
            Income categories = new Income() { Name = categoryDto.Name };


            _context.AddAsync(categories);
            _context.SaveChangesAsync();

        }

        public void DeleteIncomeCategories(int id)
        {
            var incomeCat = _context.Income_Categories.FirstOrDefault(i => i.Id == id);
            if (incomeCat != null)
            {
                _logger.LogError("The income category dosent exist");
            }
            _context.Remove(incomeCat);
            _context.SaveChanges();
        }

        public List<Income> GetIncomeCategories()
        {
            IEnumerable<Income> categories = _context.Income_Categories.
                AsNoTracking().ToList();
            return _context.Income_Categories.ToList();

        }

        public Income GetIncomeCategoryById(int id)
        {
            Income? incomeCat = _context.Income_Categories.AsNoTracking().FirstOrDefault(i => i.Id == id);
            if (incomeCat != null)
            {
                _logger.LogError("The income category dosent exist");
            }

            return incomeCat;
        }

        public void UpdateIncomeCategories(IncomeDto categoryDto, int id)
        {
            var incomeCat = _context.Income_Categories.FirstOrDefault(i => i.Id == id);
            if (incomeCat != null)
            {
                _logger.LogError("The income category dosent exist");
            }
            incomeCat.Name = categoryDto.Name;

            _context.Update(incomeCat);
            _context.SaveChanges();
        }
    }
}
