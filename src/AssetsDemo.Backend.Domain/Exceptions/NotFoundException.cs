// -------------------------------------------------------------------------------------
//  <copyright file="NotFoundException.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.Exceptions;

public abstract class NotFoundException : DomainException
{
    protected NotFoundException()
    {
    }

    protected NotFoundException(string message) : base(message)
    {
    }

    protected NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}