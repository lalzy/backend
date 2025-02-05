using Npgsql;
using System;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// sudo -u postgres psql
// postgres=# CREATE DATABASE mydatabase;
// CREATE DATABASE
// postgres=# CREATE USER bruker WITH PASSWORD 'Zaq12345';
// CREATE ROLE
// postgres=# GRANT ALL PRIVILEGES ON DATABASE mydatabase TO bruker
// postgres-# 


String setupDatabase(string user="bruker", string password="Zaq12345", string database="mydatabase"){
    string connString = $"Host=localhost;Username={user};Password={password};Database={database}";



    using (var conn = new NpgsqlConnection(connString))
    {
        conn.Open();

        // Query the database
        using (var cmd = new NpgsqlCommand("SELECT version();", conn))
        {
            var version = cmd.ExecuteScalar().ToString();
            return $"PostgreSQL version: {version}";
        }
    }
}

string test = setupDatabase();

app.MapGet("/", () => {
    return Results.Ok(test);
});


app.MapPost("/add", ()=>{
    return Results.Ok("post");
});

app.Run();