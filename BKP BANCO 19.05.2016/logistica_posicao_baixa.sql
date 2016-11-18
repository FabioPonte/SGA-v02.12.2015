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
-- Table structure for table `posicao_baixa`
--

DROP TABLE IF EXISTS `posicao_baixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `posicao_baixa` (
  `id` int(11) NOT NULL auto_increment,
  `id_produto` int(11) NOT NULL,
  `qtd_baixada` double NOT NULL,
  `qtd_antes` double NOT NULL,
  `qtd_depois` double NOT NULL,
  `io` varchar(15) NOT NULL,
  `usuario` varchar(255) NOT NULL,
  `data` datetime NOT NULL,
  `nota` int(11) default NULL,
  `deposito` varchar(50) default NULL,
  `lado1` varchar(45) default NULL,
  `lado2` varchar(45) default NULL,
  `lote` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posicao_baixa`
--

LOCK TABLES `posicao_baixa` WRITE;
/*!40000 ALTER TABLE `posicao_baixa` DISABLE KEYS */;
INSERT INTO `posicao_baixa` VALUES (1,2,20000,0,20000,'Entrada','ianez','2015-11-05 15:19:30',NULL,NULL,NULL,NULL,NULL),(2,2,2000,20000,22000,'Acrescento','ianez','2015-11-05 15:20:53',NULL,NULL,NULL,NULL,NULL),(3,1,2800,20000,17200,'Saída','ianez','2015-11-05 16:17:01',12585,NULL,NULL,NULL,NULL),(4,3,3600,0,3600,'Entrada','ianez','2016-03-31 09:23:34',NULL,NULL,NULL,NULL,NULL),(5,3,1800,3600,1800,'Saída','ianez','2016-03-31 13:19:01',123,NULL,NULL,NULL,NULL),(6,4,12,0,12,'Entrada','marcio','2016-03-31 19:11:22',NULL,NULL,NULL,NULL,NULL),(7,5,12,0,12,'Entrada','marcio','2016-04-15 12:14:09',NULL,NULL,NULL,NULL,NULL),(8,1,1,17200,17199,'Saída','marcio','2016-04-15 15:32:59',120,NULL,NULL,NULL,NULL),(9,1,17199,17199,0,'Saída','marcio','2016-04-15 15:33:13',120,NULL,NULL,NULL,NULL),(10,2,22000,22000,0,'Saída','marcio','2016-04-15 15:33:25',120,NULL,NULL,NULL,NULL),(11,3,1800,1800,0,'Saída','marcio','2016-04-15 15:33:31',120,NULL,NULL,NULL,NULL),(12,4,12,12,0,'Saída','marcio','2016-04-15 15:33:36',120,NULL,NULL,NULL,NULL),(13,5,12,12,0,'Saída','marcio','2016-04-15 15:33:41',120,NULL,NULL,NULL,NULL),(14,6,12,0,12,'Entrada','marcio','2016-04-19 08:02:38',NULL,NULL,NULL,NULL,NULL),(15,7,12,0,12,'Entrada','marcio','2016-04-19 08:03:27',NULL,NULL,NULL,NULL,NULL),(16,7,12,12,0,'Saída','marcio','2016-04-19 08:04:48',0,NULL,NULL,NULL,NULL),(17,6,12,12,0,'Saída','marcio','2016-04-19 08:04:54',0,NULL,NULL,NULL,NULL),(18,8,22080,0,22080,'Entrada','marcio','2016-05-05 14:45:21',NULL,'1331A','D','D','0057-16-22080'),(19,9,41280,0,41280,'Entrada','marcio','2016-05-05 14:47:16',NULL,'1331A','D','D','0064-16-41280'),(20,10,41280,0,41280,'Entrada','marcio','2016-05-05 14:49:01',NULL,'1331A','D','D','0059-16-41280'),(21,11,7280,0,7280,'Entrada','marcio','2016-05-05 14:50:19',NULL,'1331A','D','D','0007-16-41280'),(22,12,41280,0,41280,'Entrada','marcio','2016-05-05 14:52:01',NULL,'1331A','D','D','0061-16-41280'),(23,13,40320,0,40320,'Entrada','marcio','2016-05-05 14:52:47',NULL,'1331A','D','D','0008-16-41280'),(24,14,22080,0,22080,'Entrada','marcio','2016-05-05 14:53:48',NULL,'1331A','D','D','0009-16-41280'),(25,15,41280,0,41280,'Entrada','marcio','2016-05-05 14:54:15',NULL,'1331A','D','D','0055-16-41280'),(26,16,41280,0,41280,'Entrada','marcio','2016-05-05 14:55:08',NULL,'1331A','D','D','0019-16-41280'),(27,17,41280,0,41280,'Entrada','marcio','2016-05-05 14:55:48',NULL,'1331A','D','D','0011-16-41280'),(28,18,41280,0,41280,'Entrada','marcio','2016-05-05 14:59:48',NULL,'1331A','D','D','0013-16-41280'),(29,19,41280,0,41280,'Entrada','marcio','2016-05-05 15:00:21',NULL,'1331A','D','D','0010-16-41280'),(30,20,41280,0,41280,'Entrada','marcio','2016-05-05 15:01:24',NULL,'1331A','D','D','0016-16-41280'),(31,21,41280,0,41280,'Entrada','marcio','2016-05-05 15:01:51',NULL,'1331A','D','D','0015-16-41280'),(32,22,27840,0,27840,'Entrada','marcio','2016-05-05 15:02:21',NULL,'1331A','D','D','0017-16-41280'),(33,11,5200,7280,12480,'Acrescento','marcio','2016-05-05 15:06:02',NULL,'1331A','D','D','0007-16-41280'),(34,23,38400,0,38400,'Entrada','marcio','2016-05-12 10:21:41',NULL,'1331C','D','D','0028-16-41280'),(35,24,38400,0,38400,'Entrada','marcio','2016-05-12 10:22:16',NULL,'1331C','D','D','0027-16-41280'),(36,25,38400,0,38400,'Entrada','marcio','2016-05-12 10:22:47',NULL,'1331C','D','D','0020-16-41280'),(37,26,38400,0,38400,'Entrada','marcio','2016-05-12 10:23:16',NULL,'1331C','D','D','0043-16-41280'),(38,26,38400,38400,76800,'Acrescento','marcio','2016-05-12 10:24:00',NULL,'1331C','D','D','0043-16-41280'),(39,26,38400,76800,38400,'Saída','marcio','2016-05-12 10:25:21',1,'1331C','D','D','0043-16-41280'),(40,27,38400,0,38400,'Entrada','marcio','2016-05-12 10:26:05',NULL,'1331C','D','D','0044-16-41280'),(41,28,2880,0,2880,'Entrada','marcio','2016-05-12 10:26:54',NULL,'1331C','D','D','0018-16-41280'),(42,27,2880,38400,41280,'Acrescento','marcio','2016-05-12 10:27:23',NULL,'1331C','D','D','0044-16-41280'),(43,24,2880,38400,41280,'Acrescento','marcio','2016-05-12 10:27:55',NULL,'1331C','D','D','0027-16-41280'),(44,29,2880,0,2880,'Entrada','marcio','2016-05-12 10:28:21',NULL,'1331C','D','D','0047-16-41280'),(45,30,41280,0,41280,'Entrada','marcio','2016-05-12 10:29:01',NULL,'1331C','D','D','0046-16-41280'),(46,31,1920,0,1920,'Entrada','marcio','2016-05-12 10:29:39',NULL,'1331C','D','D','0048-16-41280'),(47,32,2880,0,2880,'Entrada','marcio','2016-05-12 10:30:08',NULL,'1331C','D','D','0042-16-41280');
/*!40000 ALTER TABLE `posicao_baixa` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-19  8:43:39
