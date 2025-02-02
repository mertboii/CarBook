﻿using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<UpdateFooterAddressCommand> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<UpdateFooterAddressCommand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.FooterAddressID);

            values.Phone = request.Phone;
            values.Address = request.Address;
            values.Description = request.Description;
            values.Email = request.Email;

            await _repository.UpdateAsync(values);
           

        }
    }
}
