using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopMicroservices.Mikorservis.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShopMicroservices.Mikorservis.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoryDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
