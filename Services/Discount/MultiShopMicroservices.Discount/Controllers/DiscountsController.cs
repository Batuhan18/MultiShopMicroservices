using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Discount.Dtos;
using MultiShopMicroservices.Discount.Services;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        var values = await _discountService.GetAllCouponAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        var values = await _discountService.GetByIdCouponAsync(id);
        return Ok(values);
    }

    [HttpGet("GetCodeDetailByCode")]
    public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
    {
        var values = await _discountService.GetCodeDetailByCodeAsync(code);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
    {
        await _discountService.CreateCouponDto(createCouponDto);
        return Ok("Kupon başarıyla oluşturuldu");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteCouponDto(id);
        return Ok("Kupon başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
    {
        await _discountService.UpdateCouponDto(updateCouponDto);
        return Ok("Kupon başarıyla güncellendi");
    }

    [HttpGet("GetDiscountCouponRate")]
    public IActionResult GetDiscountCouponRate(string code)
    {
        var values = _discountService.GetDiscountCouponRate(code);
        return Ok(values);
    }
}