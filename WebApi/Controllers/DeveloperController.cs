using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("count/{count}")]
        public async Task<IActionResult> GetPopularDevelopers(int count)
        {
            var popularDevelopers = await _unitOfWork.Developer.GetPopularDevelopersAsync(count);
            return Ok(popularDevelopers);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeveloperAndProject()
        {
            var developer = new Developer()
            {
                Followers = 35,
                Name = "Ali"
            };

            var project = new Project()
            {
                Name = "Project1"
            };

            await _unitOfWork.Developer.AddAsync(developer);
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}