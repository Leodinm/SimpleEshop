using Application.Persistence;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{

    public class UpadateProductCommandHandler : IRequestHandler<UpadateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpadateProductCommandHandler> _logger;


        public UpadateProductCommandHandler(IProductsRepository productRepository, IMapper mapper, ILogger<UpadateProductCommandHandler> logger)
        {
            _productsRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

      

        public async Task<Unit> Handle(UpadateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productsRepository.GetByIdAsync(request.id);
            if (productToUpdate == null)
            {
                throw new ProductNotFound(request.id);
            }

            _mapper.Map(request, productToUpdate, typeof(UpadateProductCommand), typeof(Product));


            await _productsRepository.UpdateAsync(productToUpdate);

            _logger.LogInformation($"Product {productToUpdate.Id} is successfully updated.");

            return Unit.Value;
            
        }
    }
   
}
