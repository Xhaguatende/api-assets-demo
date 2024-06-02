// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetTypesQuery.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssetTypes;

using MediatR;

public record GetAllAssetTypesQuery : IRequest<List<GetAllAssetTypesResponse>>;