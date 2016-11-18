-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 192.168.0.27    Database: logistica
-- ------------------------------------------------------
-- Server version	5.0.22-community-nt

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
-- Not dumping tablespaces as no INFORMATION_SCHEMA.FILES table on this server
--

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados` (
  `id` int(11) NOT NULL auto_increment,
  `uf` varchar(4) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `local` varchar(45) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
INSERT INTO `estados` VALUES (32,'AC','Acre','Norte'),(33,'AL','Alagoas','Nordeste'),(34,'AP','Amapá','Norte'),(35,'AM','Amazonas','Norte'),(36,'BA','Bahia','Nordeste'),(37,'CE','Ceará','Nordeste'),(38,'DF','Distrito Federal','Centro-Oeste'),(39,'ES','Espírito Santo','Sudeste'),(40,'GO','Goiás','Centro-Oeste'),(41,'MA','Maranhão','Nordeste'),(42,'MT','Mato Grosso','Centro-Oeste'),(43,'MS','Mato Grosso do Sul','Centro-Oeste'),(44,'MG','Minas Gerais','Sudeste'),(45,'PA','Pará','Norte'),(46,'PB','Paraíba','Nordeste'),(47,'PR','Paraná','Sul'),(48,'PE','Pernambuco','Nordeste'),(49,'PI','Piauí','Nordeste'),(50,'RJ','Rio de Janeiro','Sudeste'),(51,'RN','Rio Grande do Norte','Nordeste'),(52,'RS','Rio Grande do Sul','Sul'),(53,'RO','Rondônia','Norte'),(54,'RR','Roraima','Norte'),(55,'SC','Santa Catarina','Sul'),(56,'SP','São Paulo','Sudeste'),(57,'SE','Sergipe','Nordeste'),(58,'TO','Tocantins','Norte'),(59,'EX','Exterior','Exterior');
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

-- Dump completed on 2016-03-23  8:03:50
