USE TuttiFruttiDB;  
GO

CREATE TABLE BanderasJuego (
 IdBandera int NOT NULL,
 IdJuego int NOT NULL,
 NombreUsuario varchar(255) NOT NULL,
 Bandera varchar(255) NOT NULL
);
GO

-- --------------------------------------------------------

--
-- Table structure for table Chat
--

CREATE TABLE Chat (
 IdJuego int NOT NULL,
 Texto text NOT NULL
);
GO

-- --------------------------------------------------------

--
-- Table structure for table Juego
--

CREATE TABLE Juego (
 Id int NOT NULL,
 Nombre varchar(255) NOT NULL,
 IdPropietario int NOT NULL,
 Capacidad int NOT NULL,
 Unidos int NOT NULL,
 Estado varchar(255) NOT NULL
);
GO


-- --------------------------------------------------------

--
-- Table structure for table Palabras
--

CREATE TABLE Palabras (
 Palabra varchar(255) NOT NULL,
 Categoria varchar(255) NOT NULL,
 Letra varchar(1) NOT NULL
);
GO

-- --------------------------------------------------------

--
-- Table structure for table PalabrasDudosas
--

CREATE TABLE PalabrasDudosas (
 Id int NOT NULL,
 IdJuego int NOT NULL,
 Palabra varchar(255) NOT NULL,
 Categoria varchar(255) NOT NULL,
 Letra varchar(1) NOT NULL,
 Votos int NOT NULL,
 Aprobados int NOT NULL
);
GO

-- --------------------------------------------------------

--
-- Table structure for table Ronda
--

CREATE TABLE Ronda (
 IdRespuesta int NOT NULL,
 Jugador varchar(255) NOT NULL,
 IdJuego int NOT NULL,
 NroRonda int NOT NULL,
 Letra varchar(1) NOT NULL,
 Nombre varchar(255) NOT NULL,
 Animal varchar(255) NOT NULL,
 Color varchar(255) NOT NULL,
 Objeto varchar(255) NOT NULL,
 Lugar varchar(255) NOT NULL,
 Comida varchar(255) NOT NULL,
 Puntos int NOT NULL,
 TuttiFrutti int NOT NULL
);
GO

-- --------------------------------------------------------

--
-- Table structure for table Usuario
--

CREATE TABLE Usuario (
 Id int NOT NULL,
 NombreUsuario varchar(255) NOT NULL,
 Contraseña varchar(255) NOT NULL,
 FotoPerfil varbinary(max) NOT NULL
);
GO

--
-- Indexes for dumped tables
--

--
-- Indexes for table BanderasJuego
--
ALTER TABLE BanderasJuego
 ADD PRIMARY KEY (IdBandera);
GO
 
--
-- Indexes for table Chat
--
ALTER TABLE Chat
 ADD PRIMARY KEY (IdJuego);
GO

--
-- Indexes for table Juego
--
ALTER TABLE Juego
 ADD PRIMARY KEY (Id);
GO

--
-- Indexes for table Palabras
--
ALTER TABLE Palabras
 ADD PRIMARY KEY (Palabra,Categoria);
GO

--
-- Indexes for table PalabrasDudosas
--
ALTER TABLE PalabrasDudosas
 ADD PRIMARY KEY (Id);
GO

--
-- Indexes for table Ronda
--
ALTER TABLE Ronda
 ADD PRIMARY KEY (IdRespuesta);
GO
--
-- Indexes for table Usuario
--
ALTER TABLE Usuario
 ADD PRIMARY KEY (Id);
GO