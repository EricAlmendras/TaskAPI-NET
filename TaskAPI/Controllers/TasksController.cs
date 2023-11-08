using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTO_s;
using TaskAPI.Infrastructure;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.TaskRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = await _unitOfWork.TaskRepository.GetById(id);
            return Ok(query);
        }
     
        [HttpPost]
        public async Task<IActionResult> Post(TaskRegisterDTO taskRegisterDTO)
        {
            var result = await _unitOfWork.TaskRepository.InsertTask(taskRegisterDTO);
            if (result)
            {

                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "La tarea se registro correctamente");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error Contactar a sistema");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskRegisterDTO taskRegisterDTO)
        {
            var result = await _unitOfWork.TaskRepository.UpdateTask(taskRegisterDTO, id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "La tarea se actualizo correctamente");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error Contactar a sistema");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.TaskRepository.DeleteTask(id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "La tarea se Elimino correctamente");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error Contactar a sistema");
        }
    }
}
