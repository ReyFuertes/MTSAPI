using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.Application.Common.Interfaces;
using MTS.Application.Requests.Categories.Commands;
using MTS.Application.Requests.Images.Queries;

namespace MTS.API.Controllers
{
    public class ItemsController : AuthorizedControllerBase
    {
        private IFileManager _fileManager;

        public ItemsController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        //For image upload testing only thrue swagger.
        [HttpPost("single-file")]
        public async Task Upload(IFormFile file)
        {
            await _fileManager.UploadFileAsyncTest(file);
        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<IActionResult> GetImageFile(string fileName)
        {
            //fileName = "0ab873dc-14b1-4e90-bef7-508688c791e1";
            var response = await Mediator.Send(new DownloadImageQuery { FileName = fileName });

            return File(response.BlobStream, response.ContentType, response.FileName);
        }
    }
}
