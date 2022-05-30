CREATE DATABASE  IF NOT EXISTS `LMBA` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `LMBA`;
-- MySQL dump 10.13  Distrib 8.0.29, for Linux (x86_64)
--
-- Host: localhost    Database: LMBA
-- ------------------------------------------------------
-- Server version	8.0.29-0ubuntu0.20.04.3

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Cargo`
--

DROP TABLE IF EXISTS `Cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cargo` (
  `idCargo` int NOT NULL AUTO_INCREMENT,
  `nombreCargo` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `descripcion` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `estado` int NOT NULL DEFAULT '1',
  `idDepartamento` int NOT NULL,
  PRIMARY KEY (`idCargo`),
  KEY `RefDepartamento1` (`idDepartamento`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cargo`
--

LOCK TABLES `Cargo` WRITE;
/*!40000 ALTER TABLE `Cargo` DISABLE KEYS */;
INSERT INTO `Cargo` VALUES (1,'Analista de sistemas','Analiza los sistemas',1,1),(2,'Disenador','Hace disenos',1,2),(3,'Consultor','Hace consultas',1,1),(4,'Experto de soporte','Soporta',1,1),(5,'Analista de Negocios','Analiza negocios',3,3),(6,'Conserje','Limpia cosas',3,2);
/*!40000 ALTER TABLE `Cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Departamento`
--

DROP TABLE IF EXISTS `Departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Departamento` (
  `idDepartamento` int NOT NULL AUTO_INCREMENT,
  `nombreDepartamento` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `ext` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `estado` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`idDepartamento`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Departamento`
--

LOCK TABLES `Departamento` WRITE;
/*!40000 ALTER TABLE `Departamento` DISABLE KEYS */;
INSERT INTO `Departamento` VALUES (1,'Desarrollo','15',NULL,1),(2,'Diseno','16',NULL,1),(3,'Negocios','17',NULL,1);
/*!40000 ALTER TABLE `Departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Empleado`
--

DROP TABLE IF EXISTS `Empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Empleado` (
  `idEmpleado` int NOT NULL AUTO_INCREMENT,
  `numCedula` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `estado` int NOT NULL DEFAULT '1',
  `primerNombre` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `segundoNombre` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `primerApellido` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `segundoApellido` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `fechaNacimiento` datetime NOT NULL,
  `sexo` bit(1) NOT NULL DEFAULT b'1',
  `fechaIngreso` datetime DEFAULT NULL,
  `direccion` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `observacion` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `fotoEmpleado` longblob,
  `telefono` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `emailPersonal` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `emailCorporativo` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `idCargo` int NOT NULL,
  `id_user` int DEFAULT NULL,
  `PIN` varchar(4) NOT NULL,
  `idHorario` int NOT NULL,
  PRIMARY KEY (`idEmpleado`),
  UNIQUE KEY `id_user_UNIQUE` (`id_user`),
  KEY `RefCargo16` (`idCargo`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Empleado`
--

LOCK TABLES `Empleado` WRITE;
/*!40000 ALTER TABLE `Empleado` DISABLE KEYS */;
INSERT INTO `Empleado` VALUES (1,'001-190101-1009G',2,'Armando','Alexander','Meza','Lopez','2001-01-19 00:00:00',_binary '','2022-04-28 00:00:00','asdf','Observa bien.',NULL,'77665604','a','armando@lmba.com',1,NULL,'1234',1),(2,'001-151001-2192A',2,'Alejandra','','Prado','Sanchez','2001-10-15 00:00:00',_binary '\0','2022-04-28 00:00:00','fdsa','',NULL,'55558888','','ale@lmba.com',2,NULL,'1234',1),(3,'001-010101-0101M',1,'Mabel','Aryeris','Garcia','Hernandez','2001-01-01 00:00:00',_binary '\0','2022-04-28 00:00:00','asdfasdfasdf',NULL,NULL,'11111111',NULL,'mabel@lmba.com',3,NULL,'1234',1),(4,'002-020202-0202B',1,'Blanca','Tais','Rosales','Martinez','2002-02-02 00:00:00',_binary '\0','2022-04-28 00:00:00','pqwoiejr',NULL,NULL,'22222222',NULL,'blanca@lmba.com',4,NULL,'1234',1),(5,'003-030303-0303L',1,'Luis','Antonio','Jimenez','Rizo','2003-03-03 00:00:00',_binary '','2002-04-28 00:00:00','sdngap',NULL,NULL,'33333333',NULL,'luis@lmba.com',5,NULL,'1234',1),(6,'asdf',3,'asdf','asdf','asdf','xdxdxd','2003-03-03 00:00:00',_binary '\0','2003-03-03 00:00:00','984984',NULL,NULL,'89879874',NULL,'asdf@lmba.com',1,NULL,'1234',1),(7,'1234',2,'1234','','1234','','2022-05-25 00:00:00',_binary '\0','2022-05-25 00:00:00','1234','1234',NULL,'666','','',1,NULL,'1234',2),(8,'asdf',3,'Hola','','Test','','2022-05-25 00:00:00',_binary '','2022-05-25 00:00:00','1234','1234',NULL,'asdfasdf','','asdf',1,NULL,'1234',2),(10,'001-190101-1009X',1,'Juansito','','Perez','','2003-05-28 00:00:00',_binary '','2022-05-28 00:00:00','xxxxxxxxxx','',NULL,'','','',2,NULL,'1234',2);
/*!40000 ALTER TABLE `Empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Horario`
--

DROP TABLE IF EXISTS `Horario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Horario` (
  `idHorario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `horaInicio` time NOT NULL,
  `horaSalida` time NOT NULL,
  `estado` int NOT NULL DEFAULT '1',
  `almuerzo` time DEFAULT NULL,
  PRIMARY KEY (`idHorario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Horario`
--

LOCK TABLES `Horario` WRITE;
/*!40000 ALTER TABLE `Horario` DISABLE KEYS */;
INSERT INTO `Horario` VALUES (1,'regular','08:30:00','17:05:00',1,'01:00:00'),(2,' seguridad1','06:00:00','18:00:00',1,'01:00:00'),(3,'123','08:00:00','20:00:00',1,'01:00:00');
/*!40000 ALTER TABLE `Horario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Justificacion`
--

DROP TABLE IF EXISTS `Justificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Justificacion` (
  `idJustificacion` int NOT NULL AUTO_INCREMENT,
  `estado` int DEFAULT '1',
  `descripcion` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  `fechaEntrada` datetime NOT NULL,
  `fechaSalida` datetime NOT NULL,
  `horaEntrada` time NOT NULL,
  `horaSalida` time DEFAULT NULL,
  PRIMARY KEY (`idJustificacion`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Justificacion`
--

LOCK TABLES `Justificacion` WRITE;
/*!40000 ALTER TABLE `Justificacion` DISABLE KEYS */;
INSERT INTO `Justificacion` VALUES (15,1,'TEST','2022-05-03 00:00:00','2022-05-04 00:00:00','00:00:00','05:00:00'),(16,1,'Prueba Hola','2022-05-29 00:00:00','2022-05-29 00:00:00','08:30:00','17:00:00');
/*!40000 ALTER TABLE `Justificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `VwCargo`
--

DROP TABLE IF EXISTS `VwCargo`;
/*!50001 DROP VIEW IF EXISTS `VwCargo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwCargo` AS SELECT 
 1 AS `ID`,
 1 AS `Cargo`,
 1 AS `Departamento`,
 1 AS `Descripcion`,
 1 AS `idDepartamento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwDepartamento`
--

DROP TABLE IF EXISTS `VwDepartamento`;
/*!50001 DROP VIEW IF EXISTS `VwDepartamento`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwDepartamento` AS SELECT 
 1 AS `ID`,
 1 AS `Departamento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwEmpleado`
--

DROP TABLE IF EXISTS `VwEmpleado`;
/*!50001 DROP VIEW IF EXISTS `VwEmpleado`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwEmpleado` AS SELECT 
 1 AS `ID`,
 1 AS `Cedula`,
 1 AS `Nombres`,
 1 AS `Apellidos`,
 1 AS `Cargo`,
 1 AS `Departamento`,
 1 AS `Telefono`,
 1 AS `Email`,
 1 AS `idCargo`,
 1 AS `idDepartamento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwHorario`
--

DROP TABLE IF EXISTS `VwHorario`;
/*!50001 DROP VIEW IF EXISTS `VwHorario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwHorario` AS SELECT 
 1 AS `idHorario`,
 1 AS `nombre`,
 1 AS `horaInicio`,
 1 AS `horaSalida`,
 1 AS `estado`,
 1 AS `almuerzo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwRegistro`
--

DROP TABLE IF EXISTS `VwRegistro`;
/*!50001 DROP VIEW IF EXISTS `VwRegistro`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwRegistro` AS SELECT 
 1 AS `idRegistro`,
 1 AS `estado`,
 1 AS `fecha`,
 1 AS `horaEntrada`,
 1 AS `horaSalida`,
 1 AS `idJustificacion`,
 1 AS `entradaH`,
 1 AS `salidaH`,
 1 AS `almuerzo`,
 1 AS `idEmpleado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwRol`
--

DROP TABLE IF EXISTS `VwRol`;
/*!50001 DROP VIEW IF EXISTS `VwRol`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwRol` AS SELECT 
 1 AS `ID`,
 1 AS `Rol`,
 1 AS `Opciones`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwUser`
--

DROP TABLE IF EXISTS `VwUser`;
/*!50001 DROP VIEW IF EXISTS `VwUser`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwUser` AS SELECT 
 1 AS `id_user`,
 1 AS `firstNombre`,
 1 AS `firstApellido`,
 1 AS `email`,
 1 AS `pwd`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `empleadoRegistro`
--

DROP TABLE IF EXISTS `empleadoRegistro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleadoRegistro` (
  `idEmpleadoRegistro` int NOT NULL AUTO_INCREMENT,
  `idRegistro` int NOT NULL,
  `idEmpleado` int NOT NULL,
  PRIMARY KEY (`idEmpleadoRegistro`),
  KEY `RefregistroES12` (`idRegistro`),
  KEY `RefEmpleado13` (`idEmpleado`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleadoRegistro`
--

LOCK TABLES `empleadoRegistro` WRITE;
/*!40000 ALTER TABLE `empleadoRegistro` DISABLE KEYS */;
INSERT INTO `empleadoRegistro` VALUES (1,1,1),(2,2,1),(3,3,1),(4,10,2),(5,18,2);
/*!40000 ALTER TABLE `empleadoRegistro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion`
--

DROP TABLE IF EXISTS `opcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opcion` (
  `id_opcion` int NOT NULL AUTO_INCREMENT,
  `opcion` varchar(50) NOT NULL,
  `estado` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_opcion`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion`
--

LOCK TABLES `opcion` WRITE;
/*!40000 ALTER TABLE `opcion` DISABLE KEYS */;
INSERT INTO `opcion` VALUES (1,'empleados',1),(2,'registros',1),(3,'cargos',1),(4,'departamentos',1),(5,'rol',1),(6,'opcion',1),(7,'usuarios',1);
/*!40000 ALTER TABLE `opcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registroES`
--

DROP TABLE IF EXISTS `registroES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registroES` (
  `idRegistro` int NOT NULL AUTO_INCREMENT,
  `estado` int NOT NULL DEFAULT '1',
  `fecha` datetime DEFAULT CURRENT_TIMESTAMP,
  `horaEntrada` time DEFAULT NULL,
  `horaSalida` time DEFAULT NULL,
  `idJustificacion` int DEFAULT NULL,
  PRIMARY KEY (`idRegistro`),
  KEY `RefJustificacion14` (`idJustificacion`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registroES`
--

LOCK TABLES `registroES` WRITE;
/*!40000 ALTER TABLE `registroES` DISABLE KEYS */;
INSERT INTO `registroES` VALUES (1,1,'2022-05-03 00:00:00','08:00:00','17:00:00',15),(2,1,'2022-05-04 00:00:00','08:00:00','15:00:00',15),(3,1,'2022-05-05 00:00:00','07:59:00','16:58:00',NULL),(10,1,'2022-05-29 00:00:00','14:21:13','17:00:00',16),(18,1,'2022-05-28 00:00:00','14:47:20','15:22:20',NULL);
/*!40000 ALTER TABLE `registroES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `rol` varchar(50) NOT NULL,
  `estado` varchar(50) NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'admin','1'),(2,'visitante','1');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolOpcion`
--

DROP TABLE IF EXISTS `rolOpcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rolOpcion` (
  `id_rolOpcion` int NOT NULL AUTO_INCREMENT,
  `id_opcion` int NOT NULL,
  `id_rol` int NOT NULL,
  PRIMARY KEY (`id_rolOpcion`),
  KEY `Refopcion8` (`id_opcion`),
  KEY `Refrol9` (`id_rol`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolOpcion`
--

LOCK TABLES `rolOpcion` WRITE;
/*!40000 ALTER TABLE `rolOpcion` DISABLE KEYS */;
INSERT INTO `rolOpcion` VALUES (1,1,1),(2,2,1),(3,2,2),(4,3,2);
/*!40000 ALTER TABLE `rolOpcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `user` varchar(50) NOT NULL,
  `pwd` varchar(50) NOT NULL,
  `nombres` varchar(50) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `pwd_temp` varchar(50) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `estado` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_user`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin','123','Armando','Meza','321','armando.meza8921@est.uca.edu.ni',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userRol`
--

DROP TABLE IF EXISTS `userRol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userRol` (
  `id_UserRol` int NOT NULL AUTO_INCREMENT,
  `id_rol` int NOT NULL,
  `id_user` int NOT NULL,
  PRIMARY KEY (`id_UserRol`),
  KEY `Refrol10` (`id_rol`),
  KEY `Refuser11` (`id_user`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userRol`
--

LOCK TABLES `userRol` WRITE;
/*!40000 ALTER TABLE `userRol` DISABLE KEYS */;
/*!40000 ALTER TABLE `userRol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `VwCargo`
--

/*!50001 DROP VIEW IF EXISTS `VwCargo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwCargo` AS select `Cargo`.`idCargo` AS `ID`,`Cargo`.`nombreCargo` AS `Cargo`,`Departamento`.`nombreDepartamento` AS `Departamento`,`Cargo`.`descripcion` AS `Descripcion`,`Departamento`.`idDepartamento` AS `idDepartamento` from (`Cargo` join `Departamento` on((`Cargo`.`idDepartamento` = `Departamento`.`idDepartamento`))) where (`Cargo`.`estado` <> 3) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwDepartamento`
--

/*!50001 DROP VIEW IF EXISTS `VwDepartamento`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwDepartamento` AS select `Departamento`.`idDepartamento` AS `ID`,`Departamento`.`nombreDepartamento` AS `Departamento` from `Departamento` where (`Departamento`.`estado` <> 3) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwEmpleado`
--

/*!50001 DROP VIEW IF EXISTS `VwEmpleado`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwEmpleado` AS select `Empleado`.`idEmpleado` AS `ID`,`Empleado`.`numCedula` AS `Cedula`,concat(`Empleado`.`primerNombre`,' ',(case when (`Empleado`.`segundoNombre` is null) then '' else `Empleado`.`segundoNombre` end)) AS `Nombres`,concat(`Empleado`.`primerApellido`,' ',(case when (`Empleado`.`segundoApellido` is null) then '' else `Empleado`.`segundoApellido` end)) AS `Apellidos`,`Cargo`.`nombreCargo` AS `Cargo`,`Departamento`.`nombreDepartamento` AS `Departamento`,`Empleado`.`telefono` AS `Telefono`,`Empleado`.`emailCorporativo` AS `Email`,`Empleado`.`idCargo` AS `idCargo`,`Cargo`.`idDepartamento` AS `idDepartamento` from ((`Empleado` join `Cargo` on((`Empleado`.`idCargo` = `Cargo`.`idCargo`))) join `Departamento` on((`Cargo`.`idDepartamento` = `Departamento`.`idDepartamento`))) where (`Empleado`.`estado` <> 3) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwHorario`
--

/*!50001 DROP VIEW IF EXISTS `VwHorario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwHorario` AS select `Horario`.`idHorario` AS `idHorario`,`Horario`.`nombre` AS `nombre`,`Horario`.`horaInicio` AS `horaInicio`,`Horario`.`horaSalida` AS `horaSalida`,`Horario`.`estado` AS `estado`,`Horario`.`almuerzo` AS `almuerzo` from `Horario` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwRegistro`
--

/*!50001 DROP VIEW IF EXISTS `VwRegistro`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwRegistro` AS select `registroES`.`idRegistro` AS `idRegistro`,`registroES`.`estado` AS `estado`,`registroES`.`fecha` AS `fecha`,`registroES`.`horaEntrada` AS `horaEntrada`,`registroES`.`horaSalida` AS `horaSalida`,`registroES`.`idJustificacion` AS `idJustificacion`,`Horario`.`horaInicio` AS `entradaH`,`Horario`.`horaSalida` AS `salidaH`,`Horario`.`almuerzo` AS `almuerzo`,`Empleado`.`idEmpleado` AS `idEmpleado` from (((`registroES` join `empleadoRegistro` on((`registroES`.`idRegistro` = `empleadoRegistro`.`idRegistro`))) join `Empleado` on((`empleadoRegistro`.`idEmpleado` = `Empleado`.`idEmpleado`))) join `Horario` on((`Empleado`.`idHorario` = `Horario`.`idHorario`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwRol`
--

/*!50001 DROP VIEW IF EXISTS `VwRol`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwRol` AS select `rol`.`id_rol` AS `ID`,`rol`.`rol` AS `Rol`,group_concat(`opcion`.`opcion` order by `opcion`.`id_opcion` ASC separator ', ') AS `Opciones` from ((`rol` left join `rolOpcion` on((`rol`.`id_rol` = `rolOpcion`.`id_rol`))) left join `opcion` on((`rolOpcion`.`id_opcion` = `opcion`.`id_opcion`))) where (`rol`.`estado` <> 3) group by `rol`.`id_rol`,`rol`.`rol` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwUser`
--

/*!50001 DROP VIEW IF EXISTS `VwUser`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `VwUser` AS select `user`.`id_user` AS `id_user`,`user`.`nombres` AS `firstNombre`,`user`.`apellidos` AS `firstApellido`,`user`.`email` AS `email`,`user`.`pwd` AS `pwd` from `user` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-29 21:03:43
