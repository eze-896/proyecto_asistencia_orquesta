-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: bdorquesta
-- ------------------------------------------------------
-- Server version	9.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumno` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dni` int DEFAULT NULL,
  `nombre` varchar(25) DEFAULT NULL,
  `apellido` varchar(25) DEFAULT NULL,
  `telefono_padres` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno`
--

LOCK TABLES `alumno` WRITE;
/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES (1,47453412,'ezequiel','irusta','2915707175'),(2,12543761,'martin','perez','2915606140'),(3,24422211,'Nicolás','Gallardo','12312354'),(4,47456621,'raul','jimenez','2915837018');
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alumno_instrumento`
--

DROP TABLE IF EXISTS `alumno_instrumento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumno_instrumento` (
  `id_alumno` int DEFAULT NULL,
  `id_instrumento` int DEFAULT NULL,
  UNIQUE KEY `alumno_instrumento_unique` (`id_alumno`,`id_instrumento`),
  KEY `alumno_instrumento_instrumento_orquesta_fk` (`id_instrumento`),
  CONSTRAINT `alumno_instrumento_alumno_fk` FOREIGN KEY (`id_alumno`) REFERENCES `alumno` (`id`),
  CONSTRAINT `alumno_instrumento_instrumento_orquesta_fk` FOREIGN KEY (`id_instrumento`) REFERENCES `instrumento_orquesta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno_instrumento`
--

LOCK TABLES `alumno_instrumento` WRITE;
/*!40000 ALTER TABLE `alumno_instrumento` DISABLE KEYS */;
INSERT INTO `alumno_instrumento` VALUES (2,11),(3,6),(4,19);
/*!40000 ALTER TABLE `alumno_instrumento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asistencia`
--

DROP TABLE IF EXISTS `asistencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asistencia` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_alumno` int NOT NULL,
  `actividad_orquestal` enum('ensayo','clase_instrumento','clase_lenguaje','concierto') NOT NULL,
  `fecha` datetime NOT NULL,
  `presente` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `asistencia_alumno_FK` (`id_alumno`),
  CONSTRAINT `asistencia_alumno_FK` FOREIGN KEY (`id_alumno`) REFERENCES `alumno` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asistencia`
--

LOCK TABLES `asistencia` WRITE;
/*!40000 ALTER TABLE `asistencia` DISABLE KEYS */;
INSERT INTO `asistencia` VALUES (1,3,'ensayo','2025-10-06 00:00:00',1),(2,2,'ensayo','2025-10-06 00:00:00',1),(3,3,'clase_lenguaje','2025-10-06 00:00:00',1),(4,4,'clase_lenguaje','2025-10-06 00:00:00',1),(5,1,'clase_lenguaje','2025-10-24 00:00:00',1),(6,2,'clase_lenguaje','2025-10-24 00:00:00',1),(7,4,'clase_lenguaje','2025-10-10 00:00:00',1),(8,2,'clase_lenguaje','2025-10-10 00:00:00',1),(9,2,'clase_lenguaje','2025-11-02 00:00:00',1),(10,3,'clase_instrumento','2025-10-10 00:00:00',1),(11,1,'clase_instrumento','2025-10-10 00:00:00',1),(12,4,'clase_instrumento','2025-10-10 00:00:00',1);
/*!40000 ALTER TABLE `asistencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrumento`
--

DROP TABLE IF EXISTS `instrumento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instrumento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(25) NOT NULL,
  `catedra` enum('percusion','cuerda','viento_metales','viento_maderas') NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrumento`
--

LOCK TABLES `instrumento` WRITE;
/*!40000 ALTER TABLE `instrumento` DISABLE KEYS */;
INSERT INTO `instrumento` VALUES (1,'Violín','cuerda'),(2,'Viola','cuerda'),(3,'Violoncello','cuerda'),(4,'Contrabajo','cuerda'),(5,'Arpa','cuerda'),(6,'Flauta','viento_maderas'),(7,'Flautín','viento_maderas'),(8,'Oboe','viento_maderas'),(9,'Corno Inglés','viento_maderas'),(10,'Clarinete','viento_maderas'),(11,'Clarinete Bajo','viento_maderas'),(12,'Fagot','viento_maderas'),(13,'Contrafagot','viento_maderas'),(14,'Trompeta','viento_metales'),(15,'Trombón','viento_metales'),(16,'Trombón Bajo','viento_metales'),(17,'Tuba','viento_metales'),(18,'Corno Francés','viento_metales'),(19,'Timbales','percusion'),(20,'Bombo','percusion'),(21,'Caja','percusion'),(22,'Platillos','percusion'),(23,'Xilófono','percusion'),(24,'Campanas Tubulares','percusion'),(25,'Triángulo','percusion');
/*!40000 ALTER TABLE `instrumento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrumento_orquesta`
--

DROP TABLE IF EXISTS `instrumento_orquesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instrumento_orquesta` (
  `id` int NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `instrumento_orquesta_ibfk_1` FOREIGN KEY (`id`) REFERENCES `instrumento` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrumento_orquesta`
--

LOCK TABLES `instrumento_orquesta` WRITE;
/*!40000 ALTER TABLE `instrumento_orquesta` DISABLE KEYS */;
INSERT INTO `instrumento_orquesta` VALUES (1),(6),(11),(19);
/*!40000 ALTER TABLE `instrumento_orquesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dni` int DEFAULT NULL,
  `nombre` varchar(25) DEFAULT NULL,
  `apellido` varchar(25) DEFAULT NULL,
  `telefono` varchar(25) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `id_instrumento` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `profesor_instrumento_orquesta_FK` (`id_instrumento`),
  CONSTRAINT `profesor_instrumento_orquesta_FK` FOREIGN KEY (`id_instrumento`) REFERENCES `instrumento_orquesta` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesor`
--

LOCK TABLES `profesor` WRITE;
/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES (1,45876123,'marta','gutierrez','123675433','hola@2.com',1),(2,76098123,'martin','perez','123096749','hola@gmail.com',19);
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `contrasena` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'ezequiel','99800b85d3383e3a2fb45eb7d0066a4879a9dad0'),(2,'ezequiel','eb6a2f962bb597f98b2c2b9c4698da19710ddfa3');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'bdorquesta'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-15 23:04:58
