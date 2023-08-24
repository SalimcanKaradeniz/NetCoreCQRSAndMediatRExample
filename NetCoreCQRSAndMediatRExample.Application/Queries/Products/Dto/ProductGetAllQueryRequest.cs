using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCQRSAndMediatRExample.Application.Queries.Products.Dto
{
    public class ProductGetAllQueryRequest : IRequest<List<ProductGetAllQueryResponse>>
    {

    }
}
