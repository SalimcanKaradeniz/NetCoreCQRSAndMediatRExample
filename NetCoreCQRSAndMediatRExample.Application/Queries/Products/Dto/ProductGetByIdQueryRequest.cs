using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCQRSAndMediatRExample.Application.Queries.Products.Dto
{
    public class ProductGetByIdQueryRequest : IRequest<ProductGetByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
