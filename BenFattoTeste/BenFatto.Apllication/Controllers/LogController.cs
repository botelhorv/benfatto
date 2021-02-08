using System;
using System.IO;
using BenFatto.Domain.Entities;
using BenFatto.Service.Services;
using BenFatto.Service.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenFatto.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private LogService service = new LogService();

        [HttpGet("GeneralFilter")]
        public ActionResult GeneralFilter(string search)
        {
            try
            {
                return new ObjectResult(service.GeneralSearch(search));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("FilterByDate")]
        public ActionResult FilterByDate(DateTime? beginDate, DateTime? endDate)
        {
            try
            {
                return new ObjectResult(service.SearchByDate(beginDate, endDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Log item)
        {
            try
            {
                service.Post<LogValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Log item)
        {
            try
            {
                service.Put<LogValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Import")]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                using var ms = new MemoryStream();

                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                var text = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);

                service.LogImport(text);

                return new NoContentResult();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
