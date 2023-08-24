using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreCQRSAndMediatRExample.Application.Queries.Products.Dto;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Abstracts;

namespace NetCoreCQRSAndMediatRExample.Application.Queries.Products
{
    public class ProductGetByIdQuery : IRequestHandler<ProductGetByIdQueryRequest, ProductGetByIdQueryResponse>
    {
        private readonly IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> _productRepository;
        public ProductGetByIdQuery(IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Table.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product == null)
                return new ProductGetByIdQueryResponse();

            return new ProductGetByIdQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                StockCode = product.StockCode,
                Price = product.Price,
                InstallmentPrice = product.InstallmentPrice,
                ListPrice = product.ListPrice,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
