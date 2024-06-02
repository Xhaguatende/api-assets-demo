// -------------------------------------------------------------------------------------
//  <copyright file="UpdateAssetCommandHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.UpdateAsset;
using MediatR;
using Repositories;

public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand, UpdateAssetResponse>
{
    private readonly IAssetRepository _assetRepository;

    public UpdateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<UpdateAssetResponse> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

        if (asset == null)
        {
            return new UpdateAssetResponse(false, Guid.Empty, $"The asset ({request.Id}) does not exist");
        }

        asset.AssetTypeId = request.AssetTypeId;
        asset.Description = request.Description;
        asset.Name = request.Name;

        var updateAsset = await _assetRepository.UpdateAsync(asset, cancellationToken);

        return new UpdateAssetResponse(true, updateAsset.Id, string.Empty);
    }
}