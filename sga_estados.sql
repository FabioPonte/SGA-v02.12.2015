CREATE DATABASE  IF NOT EXISTS `sga` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sga`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: sga
-- ------------------------------------------------------
-- Server version	5.5.25a

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uf` varchar(4) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `local` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
INSERT INTO `estados` VALUES (6,'AC','Acre','Norte'),(7,'AL','Alagoas','Nordeste'),(8,'AP','Amapá','Norte'),(9,'AM','Amazonas','Norte'),(10,'BA','Bahia','Nordeste'),(11,'CE','Ceará','Nordeste'),(12,'DF','Distrito Federal','Centro-Oeste'),(13,'ES','Espírito Santo','Sudeste'),(14,'GO','Goiás','Centro-Oeste'),(15,'MA','Maranhão','Nordeste'),(16,'MT','Mato Grosso','Centro-Oeste'),(17,'MS','Mato Grosso do Sul','Centro-Oeste'),(18,'MG','Minas Gerais','Sudeste'),(19,'PA','Pará','Norte'),(20,'PB','Paraíba','Nordeste'),(21,'PR','Paraná','Sul'),(22,'PE','Pernambuco','Nordeste'),(23,'PI','Piauí','Nordeste'),(24,'RJ','Rio de Janeiro','Sudeste'),(25,'RN','Rio Grande do Norte','Nordeste'),(26,'RS','Rio Grande do Sul','Sul'),(27,'RO','Rondônia','Norte'),(28,'SC','Santa Catarina','Sul'),(29,'SP','São Paulo','Sudeste'),(30,'SE','Sergipe','Nordeste'),(31,'TO','Tocantins','Norte');
/*!40000 ALTER TABLE `estados` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-02-19 23:25:48
