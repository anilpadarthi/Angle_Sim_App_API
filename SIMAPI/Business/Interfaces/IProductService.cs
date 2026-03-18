using SIMAPI.Data.Dto;
using SIMAPI.Data.Models;
using SIMAPI.Data.Models.Export;

namespace SIMAPI.Business.Interfaces
{
    public interface IProductService
    {
        //Product
        Task<CommonResponse> CreateAsync(ProductDto request);
        Task<CommonResponse> AddProductImageAsync(ProductImageModel request);
        //Task<CommonResponse> CreateBundleProductAsync(BundleProductRequestModel request);
        Task<CommonResponse> UpdateAsync(ProductDto request);
        Task<CommonResponse> UpdateStatusAsync(int id, bool status);
        Task<CommonResponse> UpdateDisplayOrderAsync(int id, int displayOrder);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
        Task<CommonResponse> GetAllProductsAsync(ProductSearchModel request);
        Task<CommonResponse> DeleteProductAsync(int id);
        Task<IEnumerable<ProductExportDto>> ExportAllProductsAsync();
        Task<CommonResponse> AddQuantityAsync(int id, int quantity);


    }
}
