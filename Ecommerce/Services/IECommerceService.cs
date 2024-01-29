using Ecommerce.Requests;
using Ecommerce.Response;

namespace Ecommerce.Services;

public interface IECommerceService
{
    Task<bool> AddOrder(AddOrderRequest request);
    Task<bool> AddProduct(AddProductRequest request);
    Task<bool> AddCustomer(AddCustomerRequest request);

    Task<IEnumerable<ReportResponse>> Report(ReportingRequest request);
}
