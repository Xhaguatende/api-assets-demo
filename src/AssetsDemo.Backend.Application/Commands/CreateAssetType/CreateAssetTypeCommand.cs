// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetTypeCommand.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAssetType;

using MediatR;

public record CreateAssetTypeCommand : IRequest<CreateAssetTypeResponse>
{
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}