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

const string USER = "bruker";
const string PASSWORD = "Zaq12345";
const string DATABASE = "postgres";

String getConnString(string user="user", string password="", string database="mydatabase"){
    return $"Host=localhost;Username={user};Password={password};Database={database}";

}

string connString = getConnString(USER, PASSWORD, DATABASE);

List<String> getData(string connString){
    using (var conn = new NpgsqlConnection(connString))
    {
        conn.Open();

        // Query the database
        using (var cmd = new NpgsqlCommand($"SELECT * FROM oppgave;", conn))
        {
            using (var reader = cmd.ExecuteReader()){
                List<string> results = new List<string>();
                while(reader.Read()){
                     string row = $"{reader["titel"]}, {reader["beskrivelse"]}, {reader["status"]}";
                    results.Add(row);
                }
                return results;
            }
        }
    }
}

void setData(oppgaveRequest data){
    
}

app.MapGet("/", () => {
    string test = "";
    foreach(string text in getData(connString)){
        test += text;
    }
    return Results.Ok(test);
});


app.MapPost("/add", ()=>{
    Console.WriteLine("tet");
    return Results.Ok("post");
});

app.Run();