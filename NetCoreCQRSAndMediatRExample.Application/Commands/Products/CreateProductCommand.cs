using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreCQRSAndMediatRExample.Application.Commands.Products.Dto;
using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCQRSAndMediatRExample.Application.Commands.Products
{
    public class CreateProductCommand : IRequestHandler<CreateProductRequest,CreateProductResponse>
    {
        private readonly IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> _productsRepository;
        public CreateProductCommand(IRepository<NetCoreCQRSAndMediatRExample.Domain.Entities.Products> productsRepository)
        {
                _productsRepository = productsRepository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request,CancellationToken cancellationToken)
        {
            var product = await _productsRepository.Table.FirstOrDefaultAsync(x => x.StockCode == request.StockCode);
            if (product != null)
                return new CreateProductResponse { Message = "Girdiğiniz stok kodu farklı bir ürün tarafından kullanılmaktadır.Lütfen kontrol ediniz.", Success = false};

            var newProduct = new NetCoreCQRSAndMediatRExample.Domain.Entities.Products
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StockCode = request.StockCode,
                Quantity = request.Quantity,
                Price = request.Price,
                InstallmentPrice = request.InstallmentPrice,
                ListPrice = request.ListPrice,
                CreateTime = DateTime.Now,
            };

            await _productsRepository.InsertAsync(newProduct);
            await _productsRepository.SaveAllAsync();

            return new CreateProductResponse
            {
                Success = newProduct.Id != Guid.Empty ? true : false, 
                Id = newProduct.Id,
            };

        }
    }
}
