using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Semantics;
using Microsoft.Extensions.Options;
using ShoeStore.Controllers.Resources;
using ShoeStore.Core;
using ShoeStore.Core.Models;

namespace ShoeStore.Controllers
{[Route("/api/shoes/{shoeId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment _host;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PhotoSettings _photoSettings;

        public PhotosController(IHostingEnvironment host, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options)
        {
            _host = host;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoSettings = options.Value;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(int shoeId, int[] colorIds, IFormCollection files)
        {
            if (colorIds.Length != files.Files.Count)
                return BadRequest("Color Id's and files do not match");

            foreach (var file in files.Files)
            {
                if (file == null)
                    return BadRequest("Null file.");
                if (file.Length == 0)
                    return BadRequest("Empty file.");
                if (file.Length > _photoSettings.MaxBytes)
                    return BadRequest("Max file size exceeded.");
                if (_photoSettings.IsSupported(file.FileName))
                    return BadRequest("Invalid file type.");
            }

            var shoe = await _unitOfWork.Shoes.GetShoeAsync(shoeId);

            if (shoe == null)
                return NotFound();

            //var shoe = _unitOfWork.Inventory.Get
            var uploadFoldersPath = Path.Combine(_host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFoldersPath))
                Directory.CreateDirectory(uploadFoldersPath);

            var index = 0;
            var photos = new List<Photo>();

            foreach (var file in files.Files)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadFoldersPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                var photo = new Photo
                {
                    ShoeId = shoeId,
                    ColorId = colorIds[index++],
                    FileName = fileName
                };
                photos.Add(photo);
            }

            _unitOfWork.Photos.Add(photos);
            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<ICollection<Photo>, ICollection<PhotoResource>>(photos));
        }
    }
}