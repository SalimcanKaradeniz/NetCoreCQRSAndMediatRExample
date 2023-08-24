using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreCQRSAndMediatRExample.Application.Queries.Products.Dto;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Abstracts;

namespace NetCoreCQRSAndMediatRExample.Application.Queries.Products
{
    public class ProductGetAllQuery : IRequestHandler<ProductGetAllQueryRequest, List<ProductGetAllQueryResponse>>
    {
        private readonly IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> _productRepository;

        public ProductGetAllQuery(IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductGetAllQueryResponse>> Handle(ProductGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.Table.Select(x => new ProductGetAllQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                StockCode = x.StockCode,
                Quantity = x.Quantity,
                Price = x.Price,
                InstallmentPrice = x.InstallmentPrice,
                ListPrice = x.ListPrice,
                CreateTime = x.CreateTime,
            }).ToListAsync();
        }
    }
}
