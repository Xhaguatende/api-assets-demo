// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetTypeCommandHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAssetType;

using Domain.AssetTypes;
using MediatR;
using Repositories;

public class CreateAssetTypeCommandHandler : IRequestHandler<CreateAssetTypeCommand, CreateAssetTypeResponse>
{
    private readonly IAssetTypeRepository _assetTypeRepository;

    public CreateAssetTypeCommandHandler(IAssetTypeRepository assetTypeRepository)
    {
        _assetTypeRepository = assetTypeRepository;
    }

    public async Task<CreateAssetTypeResponse> Handle(
        CreateAssetTypeCommand request,
        CancellationToken cancellationToken)
    {
        var assetType = new AssetType(Guid.NewGuid())
        {
            Name = request.Name,
            Description = request.Description
        };

        await _assetTypeRepository.CreateAsync(assetType, cancellationToken);

        return new CreateAssetTypeResponse(true, assetType.Id);
    }
}