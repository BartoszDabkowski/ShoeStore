using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Controllers.Resources;
using ShoeStore.Core;
using ShoeStore.Core.Models;
using ShoeStore.Persistence;

namespace ShoeStore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BrandsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("api/brands")]
        public async Task<IEnumerable<BrandResource>> GetBrandsAsync()
        {
            var brands = await _unitOfWork.Brands.GetBrandsAsync();

            return _mapper.Map<IEnumerable<Brand>,IEnumerable<BrandResource>>(brands);
        }
    }
}