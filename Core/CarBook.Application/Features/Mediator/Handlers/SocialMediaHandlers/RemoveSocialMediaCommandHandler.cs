using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler:IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {   
            var value = await _socialMediaRepository.GetByIdAsync(request.Id);
            await _socialMediaRepository.RemoveAsync(value);
        }
    }
}
