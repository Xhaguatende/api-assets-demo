// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetCommandHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAsset;

using Domain.Assets;
using MediatR;
using Repositories;

public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, CreateAssetResponse>
{
    private readonly IAssetRepository _assetRepository;

    public CreateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<CreateAssetResponse> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = new Asset(Guid.NewGuid())
        {
            AssetTypeId = request.AssetTypeId,
            Description = request.Description,
            Name = request.Name
        };

        var createAsset = await _assetRepository.CreateAsync(asset, cancellationToken);

        return new CreateAssetResponse(true, createAsset.Id);
    }
}