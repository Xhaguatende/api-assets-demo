// -------------------------------------------------------------------------------------
//  <copyright file="SqlServerSettings.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Settings;

public class SqlServerSettings
{
    public string ConnectionString { get; set; } = string.Empty;

    public bool UseInMemory { get; set; }
}