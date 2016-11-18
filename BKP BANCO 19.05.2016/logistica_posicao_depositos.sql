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
-- Table structure for table `posicao_depositos`
--

DROP TABLE IF EXISTS `posicao_depositos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `posicao_depositos` (
  `id` int(11) NOT NULL auto_increment,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  `nome1` varchar(45) NOT NULL,
  `nome2` varchar(45) default NULL,
  `nome3` varchar(45) default NULL,
  `obs` varchar(1024) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posicao_depositos`
--

LOCK TABLES `posicao_depositos` WRITE;
/*!40000 ALTER TABLE `posicao_depositos` DISABLE KEYS */;
INSERT INTO `posicao_depositos` VALUES (14,426,280,'1331B','D','D',''),(15,455,335,'1331D','E','E',''),(16,437,336,'1331D','E','D',''),(17,439,273,'1331D','D','E',''),(18,457,273,'1331D','D','D',''),(19,492,335,'1331E','E','E',''),(20,470,334,'1331E','D','D',''),(21,549,338,'1331F','E','E',''),(22,506,332,'1331F','D','D',''),(23,517,106,'1400L','E','E',''),(24,542,106,'1400L','D','D',''),(25,557,104,'1400R','E','E',''),(26,577,102,'1400R','D','D',''),(28,350,174,'1250','A','A',''),(29,338,174,'1250','B','B',''),(30,325,175,'1250','C','C',''),(31,519,216,'1230','C','C',''),(32,498,215,'1231','C','C',''),(33,342,220,'1243','C','C',''),(34,510,188,'1266','C','C',''),(35,86,382,'1361','C','C',''),(36,370,321,'1331A','D','D',''),(37,389,315,'1331C','D','D','');
/*!40000 ALTER TABLE `posicao_depositos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-19  8:42:33
