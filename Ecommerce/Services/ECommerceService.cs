using AutoMapper;
using Ecommerce.Context;
using Ecommerce.Exceptions;
using Ecommerce.Models;
using Ecommerce.Requests;
using Ecommerce.Response;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services;

public class EcommerceService : IECommerceService
{
    private readonly MasterContext _context;
    private readonly IMapper _mapper;
    public EcommerceService(MasterContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<bool> AddCustomer(AddCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        await _context.AddAsync(customer);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> AddOrder(AddOrderRequest request)
    {
        var product = (await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId));

        if (product != null && product.Stock <= 0)
        {
            throw new ApiException("Sorry the stock is not enough");
        }

        var order = _mapper.Map<Order>(request);
        await _context.AddAsync(order);

        product.Stock -= 1;
        _context.Update(product);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> AddProduct(AddProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        await _context.AddAsync(product);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ReportResponse>> Report(ReportingRequest request)
    {
        var query = _context.Orders.AsQueryable();
        if (request.CreateDateStart != null)
        {
            query = query.Where(x => x.CreateDate >= request.CreateDateStart);
        }
        if (request.CreateDateEnd != null)
        {
            query = query.Where(x => x.CreateDate <= request.CreateDateEnd);
        }

        if (!string.IsNullOrEmpty(request.Name) || !string.IsNullOrEmpty(request.Surname))
        {
            query = query.Include(x => x.Customer);

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(x => x.Customer.Name == request.Name);
            }

            if (!string.IsNullOrEmpty(request.Surname))
            {
                query = query.Where(x => x.Customer.Surname == request.Surname);
            }
        }
        var actualList = await query.ToListAsync();

        var grouped = actualList.GroupBy(x => x.CustomerId);

        var resp = new List<ReportResponse>();

        foreach (var group in grouped)
        {
            resp.Add(new ReportResponse { Customer = _context.Customers.Find(group.Key), Orders = group.ToList() });
        }

        return resp;
    }
}
