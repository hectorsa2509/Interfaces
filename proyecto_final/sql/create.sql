-- Base de datos para el CCU
create database if not exists ccu;

-- Indicamos que usaremos la base de datos yumyum para crear las tablas
use ccu;

-- Borramos las siguientes tablas si ya existen en la BD
drop table if exists Reservacion cascade;
drop table if exists TipoVisita cascade;
drop table if exists TipoVisitante cascade;
drop table if exists Usuario cascade;
drop table if exists Visita cascade;


SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Base de datos: ccu
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla Reservacion
--

CREATE TABLE Reservacion (
  id_reservacion int(11) NOT NULL,
  id_usuario int(11) NOT NULL,
  id_visita int(11) NOT NULL,
  num_personas int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla TipoVisita
--

CREATE TABLE TipoVisita (
  id_tipo_visita int(11) NOT NULL,
  tipo_visita varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla TipoVisitante
--

CREATE TABLE TipoVisitante (
  id_tipo_visitante int(11) NOT NULL,
  tipo_visitante varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla Usuario
--

CREATE TABLE Usuario (
  id_usuario int(11) NOT NULL,
  nombre varchar(32) NOT NULL,
  apellido varchar(32) NOT NULL,
  fecha_nacimiento date NOT NULL,
  correo varchar(128) NOT NULL,
  contrasenia varchar(256) NOT NULL,
  telefono varchar(16) DEFAULT NULL,
  cuenta_valida bit(1) NOT NULL,
  notificaciones bit(1) NOT NULL,
  idTipoVisitante int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla Visita
--

CREATE TABLE Visita (
  id_visita int(11) NOT NULL,
  id_tipo_visita int(11) NOT NULL,
  cupo int(11) NOT NULL,
  lugares_ocupados int(11) NOT NULL,
  fecha date NOT NULL,
  hora time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla Reservacion
--
ALTER TABLE Reservacion
  ADD PRIMARY KEY (id_reservacion);

--
-- Indices de la tabla TipoVisita
--
ALTER TABLE TipoVisita
  ADD PRIMARY KEY (id_tipo_visita);

--
-- Indices de la tabla TipoVisitante
--
ALTER TABLE TipoVisitante
  ADD PRIMARY KEY (id_tipo_visitante);

--
-- Indices de la tabla Usuario
--
ALTER TABLE Usuario
  ADD PRIMARY KEY (id_usuario),
  ADD UNIQUE KEY correo (correo);

--
-- Indices de la tabla Visita
--
ALTER TABLE Visita
  ADD PRIMARY KEY (id_visita);


--
-- Llaves foráneas
--

--
-- FOREIGN_KEY de la tabla Usuario
--
ALTER TABLE Usuario
ADD FOREIGN KEY (id_tipo_visitante) REFERENCES TipoVisitante(id_tipo_visitante);

--
-- FOREIGN_KEY de la tabla Visita
--
ALTER TABLE Visita
ADD FOREIGN KEY (id_tipo_visita) REFERENCES TipoVisita(id_tipo_visita);

--
-- FOREIGN_KEY de la tabla Reservacion
--
ALTER TABLE Reservacion
ADD FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario);

ALTER TABLE Reservacion
ADD FOREIGN KEY (id_visita) REFERENCES Visita(id_visita);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla Reservacion
--
ALTER TABLE Reservacion
  MODIFY id_reservacion int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla TipoVisita
--
ALTER TABLE TipoVisita
  MODIFY id_tipo_visita int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla TipoVisitante
--
ALTER TABLE TipoVisitante
  MODIFY id_tipo_visitante int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla Usuario
--
ALTER TABLE Usuario
  MODIFY id_usuario int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla Visita
--
ALTER TABLE Visita
  MODIFY id_visita int(11) NOT NULL AUTO_INCREMENT;

-- Usuario para acceder a la B. D. 
CREATE USER if not exists 'ccu'@'localhost' IDENTIFIED BY 'dAT31R0l';
GRANT ALL PRIVILEGES ON ccu.* TO 'ccu'@'localhost';