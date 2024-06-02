// -------------------------------------------------------------------------------------
//  <copyright file="GetAssetTypeByIdQuery.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAssetTypeById;

using MediatR;

public record GetAssetTypeByIdQuery(Guid Id) : IRequest<GetAssetTypeByIdResponse>;