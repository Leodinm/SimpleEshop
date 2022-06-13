using Application.Exceptions;
using Application.Persistence;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;


        public DeleteOrderCommandHandler(IProductsRepository productRepository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _productsRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete= await _productsRepository.GetByIdAsync(request.Id);
            if (productToDelete == null)
            {
                throw new ProductNotFound(request.Id);
            }
            await _productsRepository.DeleteAsync(productToDelete);
            return Unit.Value;
        }
    }
}
