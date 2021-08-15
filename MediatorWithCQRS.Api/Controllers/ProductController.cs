using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.Queries;
using MediatorWithCQRS.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FindProductQueryResult>> GetProductById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var query = new FindProductByIdQuery();
                    query.Id = id;
                    var result = await _mediator.Send(query);
                    return Ok(result); 
                }
                else
                {
                    throw new ArgumentException("Id menor ou igual a 0");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar produto: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FindProductQueryResult>>> GetProducts()
        {
            try
            {
                var query = new FindProductsQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar produtos: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CommandResult>> AddProduct([FromBody] CreateProductCommand createProductCommand)
        {
            try
            {
                if (createProductCommand.IsValid())
                {
                    var result = await _mediator.Send(createProductCommand);
                    return Ok(result);
                }
                else
                {
                    throw new ArgumentException("Valores nulos ou vazios");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<CommandResult>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            try
            {
                if (updateProductCommand.IsValid())
                {
                    var result = await _mediator.Send(updateProductCommand);
                    return Ok(result);
                }
                else
                {
                    throw new ArgumentException("Valores nulos ou vazio");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandResult>> DeleteProductById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var query = new DeleteProductCommand();
                    query.Id = id;
                    var result = await _mediator.Send(query);
                    return Ok(result);
                }
                else
                {
                    throw new ArgumentException("Id menor ou igual a 0");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar produto: {ex.Message}");
            }
        }
    }
}
