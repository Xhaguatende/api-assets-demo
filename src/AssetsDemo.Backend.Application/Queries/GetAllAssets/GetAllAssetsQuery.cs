// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetsQuery.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssets;

using MediatR;

public record GetAllAssetsQuery : IRequest<List<GetAllAssetsResponse>>;