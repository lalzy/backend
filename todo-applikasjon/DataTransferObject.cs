class oppgaveRequest{
    public required string Title {get;set;}
    public required string beskrivelse  {get;set;}
    public required string status  {get;set;}
}

// postgres=# CREATE TABLE oppgave (titel TINYTEXT, beskrivelse TEXT, status TINYTEXT)