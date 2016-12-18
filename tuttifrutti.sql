-- phpMyAdmin SQL Dump
-- version 4.6.5.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 18, 2016 at 06:55 PM
-- Server version: 10.1.18-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `TuttiFrutti`
--
CREATE DATABASE IF NOT EXISTS `TuttiFrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `TuttiFrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);
--
-- Database: `id360830_tuttifrutti`
--
CREATE DATABASE IF NOT EXISTS `id360830_tuttifrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `id360830_tuttifrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);
--
-- Database: `id360830_tuttifrutti`
--
CREATE DATABASE IF NOT EXISTS `id360830_tuttifrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `id360830_tuttifrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);
--
-- Database: `id360830_tuttifrutti`
--
CREATE DATABASE IF NOT EXISTS `id360830_tuttifrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `id360830_tuttifrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);
--
-- Database: `id360830_tuttifrutti`
--
CREATE DATABASE IF NOT EXISTS `id360830_tuttifrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `id360830_tuttifrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);
--
-- Database: `id360830_tuttifrutti`
--
CREATE DATABASE IF NOT EXISTS `id360830_tuttifrutti` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `id360830_tuttifrutti`;

-- --------------------------------------------------------

--
-- Table structure for table `BanderasJuego`
--

CREATE TABLE `BanderasJuego` (
  `IdBandera` int(10) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NombreUsuario` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Bandera` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chat`
--

CREATE TABLE `Chat` (
  `IdJuego` int(10) NOT NULL,
  `Texto` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Juego`
--

CREATE TABLE `Juego` (
  `Id` int(10) NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdPropietario` int(10) NOT NULL,
  `Capacidad` int(10) NOT NULL,
  `Unidos` int(10) NOT NULL,
  `Estado` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Palabras`
--

CREATE TABLE `Palabras` (
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `PalabrasDudosas`
--

CREATE TABLE `PalabrasDudosas` (
  `Id` int(11) NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `Palabra` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Votos` int(11) NOT NULL,
  `Aprobados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Ronda`
--

CREATE TABLE `Ronda` (
  `IdRespuesta` int(10) NOT NULL,
  `Jugador` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IdJuego` int(10) NOT NULL,
  `NroRonda` int(10) NOT NULL,
  `Letra` varchar(1) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Animal` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Color` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Objeto` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Lugar` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Comida` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Puntos` int(10) NOT NULL,
  `TuttiFrutti` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(10) NOT NULL,
  `NombreUsuario` int(255) NOT NULL,
  `Contraseña` int(255) NOT NULL,
  `FotoPerfil` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `BanderasJuego`
--
ALTER TABLE `BanderasJuego`
  ADD PRIMARY KEY (`IdBandera`);

--
-- Indexes for table `Chat`
--
ALTER TABLE `Chat`
  ADD PRIMARY KEY (`IdJuego`);

--
-- Indexes for table `Juego`
--
ALTER TABLE `Juego`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Palabras`
--
ALTER TABLE `Palabras`
  ADD PRIMARY KEY (`Palabra`,`Categoria`),
  ADD KEY `Palabra` (`Palabra`);

--
-- Indexes for table `PalabrasDudosas`
--
ALTER TABLE `PalabrasDudosas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Ronda`
--
ALTER TABLE `Ronda`
  ADD PRIMARY KEY (`IdRespuesta`);

--
-- Indexes for table `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
