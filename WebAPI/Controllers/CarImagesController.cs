using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;
        public CarImagesController(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, int carId)
        {
            var result = _carImageService.Add(file, carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, CarImage carImage)
        {
            var result = _carImageService.Update(file,carImage);
            if (result.Success)
            {
                return Ok(carImage);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagedetailsbycarid")]
        public IActionResult GetCarImageDetailsByCarId(int id)
        {
            var result = _carImageService.GetDetailsByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagebycarid")]
        public IActionResult GetCarImageByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getfilebyid")]
        public IActionResult GetFileById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                var f = System.IO.File.ReadAllBytes(result.Data.ImagePath);
                return File(f, "image/jpeg");
            }

            return BadRequest(result);
        }

    }
}
