CREATE TABLE Usuario (
    idUsuario INTEGER PRIMARY KEY AUTOINCREMENT,
    nomeUsuario TEXT NOT NULL,
    senha INTEGER NOT NULL
);

CREATE TABLE Ficha (
    idFicha INTEGER PRIMARY KEY AUTOINCREMENT,
    nomePersonagem TEXT NOT NULL,
    nomePlayer TEXT NOT NULL,
    nivel INTEGER NOT NULL,
    classe TEXT NOT NULL,
    raca TEXT NOT NULL,
    antecedente TEXT,
    alinhamento TEXT,
    pontosVida INTEGER NOT NULL,
    ca INTEGER NOT NULL,
    deslocamento INTEGER NOT NULL,
    idUsuario INTEGER,
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario) ON DELETE SET NULL
);

CREATE TABLE Atributos (
    idAtributos INTEGER PRIMARY KEY AUTOINCREMENT,
    forca INTEGER,
    destreza INTEGER,
    constituicao INTEGER,
    inteligencia INTEGER,
    sabedoria INTEGER,
    carisma INTEGER,
    idFicha INTEGER
    FOREIGN KEY (idFicha) REFERENCES Ficha(idFicha) ON DELETE SET NULL
);
