﻿using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress
{
    internal class EditUserAddressCommandHandler:IBaseCommandHandler<EditUserAddressCommand>
    {
        public EditUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        private readonly IUserRepository _repository;
        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user =await _repository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                var address = new UserAddress(request.Shire, request.City, request.PostalCode,
                    request.PostalAddress, request.PhoneNumber, request.Name, request.Family,
                    request.NationalCode);
                user.EditAddress(address,request.Id);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}