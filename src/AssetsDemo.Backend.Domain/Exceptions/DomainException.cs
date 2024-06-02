// -------------------------------------------------------------------------------------
//  <copyright file="DomainException.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException()
    {
    }

    protected DomainException(string message) : base(message)
    {
    }

    protected DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}