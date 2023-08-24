using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreCQRSAndMediatRExample.Application.Commands.Products.Dto;
using NetCoreCQRSAndMediatRExample.Application.Queries.Products.Dto;
using System.Runtime.CompilerServices;

namespace NetCoreCQRSAndMediatRExample.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;
        public ProductsController(IMediator mediator)
        { 
            _mediator = mediator;
        }
        #region Command
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        #endregion
        #region Queries
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(ProductGetAllQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] ProductGetByIdQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        #endregion
    }
}