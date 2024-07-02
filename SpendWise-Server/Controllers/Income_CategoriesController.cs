using Microsoft.AspNetCore.Mvc;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models.DTOs.Income_CategoryDtos;


//update-database and test it
namespace SpendWise_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Income_CategoriesController : ControllerBase
    {
        private readonly IIncome_CategoriesService _categoriesService;

        public Income_CategoriesController(IIncome_CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("GetIncomeCategories")]
        public IActionResult GetIncomeCategories()
        {
            return Ok(_categoriesService.GetAllIncomeCategories());
        }
        [HttpGet("GetIncomeCategory")]
        public IActionResult GetIncomeCategory(int id)
        {
            return Ok(_categoriesService.GetSingleIncomeCategoryById(id));
        }

        [HttpPost("AddIncomeCategories")]
        public IActionResult AddIncomeCategories(IncomeDto categoryDto)
        {
            _categoriesService.AddIncomeCategories(categoryDto);
            return Ok("The income categories what succesfully added");
        }

        [HttpPut("UpdateIncomeCategories")]
        public IActionResult UpdateIncomeCategories(IncomeDto categoryDto, int id)
        {
            _categoriesService.UpdateIncomeCategories(categoryDto, id);
            return Ok();
        }

        [HttpDelete("DeleteIncomeCategories")]
        public IActionResult DeleteIncomeCategories(int id)
        {
            _categoriesService.DeleteIncomeCategories(id);
            return Ok("The income categories what succesfully deleted");
        }

    }
}
