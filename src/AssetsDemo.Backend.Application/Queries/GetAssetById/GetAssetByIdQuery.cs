// -------------------------------------------------------------------------------------
//  <copyright file="GetAssetByIdQuery.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAssetById;

using MediatR;

public record GetAssetByIdQuery(Guid Id) : IRequest<GetAssetByIdResponse>;