﻿using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommece.Infrastructure.DbContext;

public class DapperDbContext
{
  private readonly IConfiguration _configuration;
  private readonly IDbConnection _connection;

  public DapperDbContext(IConfiguration configuration)
  {
    _configuration = configuration;
    string? connectionString = _configuration.GetConnectionString("PostgresConnection");

    _connection = new NpgsqlConnection(connectionString);
  }
  
  public IDbConnection Connection => _connection;
}