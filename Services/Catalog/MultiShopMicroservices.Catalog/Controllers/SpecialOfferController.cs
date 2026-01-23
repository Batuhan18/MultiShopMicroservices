using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Catalog.Dtos.SpecialOfferDtos;
using MultiShopMicroservices.Catalog.Services.SpecialOfferServices;

namespace MultiShopMicroservices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel teklif başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel teklif başarıyla güncellendi");
        }
    }
}
