USE TodoList;

CREATE TABLE Tarefa
(
    Id uniqueidentifier PRIMARY KEY,
    Titulo varchar(100),
    Descricao varchar(255),
    DataCriacao DateTime DEFAULT GETDATE(),
    DataConclusao DateTime DEFAULT GETDATE(),
    IdUsuario uniqueidentifier,
    CONSTRAINT FK_Tarefa_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
