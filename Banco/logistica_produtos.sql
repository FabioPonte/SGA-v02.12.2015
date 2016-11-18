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
-- Table structure for table `produtos`
--

DROP TABLE IF EXISTS `produtos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `produtos` (
  `id` int(11) NOT NULL auto_increment,
  `idsap` varchar(10) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `peso` double default NULL,
  `conversao` double default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produtos`
--

LOCK TABLES `produtos` WRITE;
/*!40000 ALTER TABLE `produtos` DISABLE KEYS */;
INSERT INTO `produtos` VALUES (6,'ABA0001','ABAMECTIN DVA 18 EC 4 X 5 L',800,1718),(7,'ACE0001','ACEFATO FERSOL 750 SP 4X5 KG',NULL,NULL),(8,'AMI0001','2,4-D AMINA 72 - 01 LT',864,1107),(9,'AMI0002','2,4-D AMINA 72 - 05 LT',800,1085),(10,'AMI0003','2,4-D AMINA 72 - 20 LT',960,1230),(11,'AMI0004','PREN-D 806 20 L',960,1220),(12,'ATR0001','ATRAZINA ATANOR 50 SC - 01 LT',864,1107),(13,'ATR0002','ATRAZINA ATANOR 50 SC - 05 LT',800,1000),(14,'ATR0003','ATRAZINA ATANOR 50 SC - 20 LT',960,1220),(15,'BIO0001','HI BIO 25% 25 KG',NULL,NULL),(16,'BIO0002','HI BIO 30% 25 KG',NULL,NULL),(17,'BIO0003','HI BIO 35% 25 KG',NULL,NULL),(18,'BIO0004','OXA 35 25 KG',NULL,NULL),(19,'CLO0001','CLORIM CX 15 X 300G',337.5,NULL),(20,'CLO0002','CLORIMURON CX 4,5 KG',NULL,NULL),(21,'COB0001','COBRE ATAR 25 KG EXP',1000,1200),(22,'COB0002','COBRE ATAR BR 18X1 KG',900,997),(23,'COB0003','COBRE ATAR BR 6X3 KG',900,1045),(24,'COB0004','COBRE ATAR BR 25 KG',1000,1200),(25,'CON0001','RECONIL 10X1 KG',660,1000),(26,'CON0002','RECONIL 25 KG',1000,1200),(27,'COP0001','RECOP 25 KG EXP',1040,1200),(28,'COP0002','RECOP 25 KG EXP NORUEGA',1040,1200),(29,'COP0003','RECOP 10X1 KG',720,740),(30,'COP0004','RECOP 25 KG',1000,1032.727273),(31,'FOS0001','CLORPIRIFOS FERSOL 480 20LTS',1220,NULL),(32,'GLI0001','GLIFOSATO ATAR 48 20 L - NAC',960,1185.92),(33,'GLI0002','GLIFOSATO ATAR 48 6X1 LT',864,1050),(34,'GLI0003','GLIFOSATO ATAR 48 4X5 LT',800,1030),(35,'GLI0004','GLIFOSATO ATAR 48 20 LT',960,1220),(36,'GLI0005','GLIFOSATO ATANOR 48-01 LT',1107,NULL),(37,'GLI0006','GLIFOSATO ATANOR 48-05 LT',960,NULL),(38,'GLI0007','GLIFOSATO ATANOR 48-20 LT',1220,NULL),(39,'GLI0008','GLIFOSATO ATANOR-01 LT',1107,NULL),(40,'GLI0009','GLIFOSATO ATANOR-05 LT',960,NULL),(41,'GLI0010','GLIFOSATO ATANOR-20 LT',1220,NULL),(42,'GLI0011','GLIFOSATO ZAMBA - 01 LT',1107,NULL),(43,'GLI0012','GLIFOSATO ZAMBA - 05 LT',960,NULL),(44,'GLI0013','GLIFOSATO ZAMBA - 20 LT',1220,NULL),(45,'GLI0014','RONAT - A - 01 LT',1107,NULL),(46,'GLI0015','RONAT - A - 05 LT',960,NULL),(47,'GLI0016','RONAT - A - 20 LT',1220,NULL),(48,'HID0001','HIDROXIDO DE COBRE TECNICO',NULL,NULL),(49,'IMI0001','IMIDAGOLD 10 X 1KG',900,NULL),(50,'IMI0002','CIGARAL 70 WP 10 X 1 KG',NULL,NULL),(51,'LAM0001','TRINCA CX 15 X 1',720,NULL),(52,'LAM0002','TRINCA CX 4 X 5',900,NULL),(53,'NIC0001','LIMPIDU  4 X 5L',900,NULL),(54,'OXI0001','OXICLORETO CUPR TEC 57% BR',NULL,NULL),(55,'OXI0002','CUPROXINA WP 25 KG',NULL,NULL),(56,'OXI0003','OXICLORETO CUPRICO TEC. 57%',NULL,NULL),(57,'OXI0004','OXICLORURO DE COBRE ATANOR',NULL,NULL),(58,'OXI0005','OXIDO CUPROSO TECNICO 83%',NULL,NULL),(59,'OXI0006','COPPER OXYCHLORIDE 50% WP',NULL,NULL),(60,'OXI0007','COPPER OXYCHLORIDE TECHNICAL 57%',NULL,NULL),(61,'OXI0008','COPPER OXYCHLORIDE TECHNICAL 57% HG',NULL,NULL),(62,'TEB0001','ODIN 430 SC 4 X 5 LTS',800,NULL),(63,'TRI0001','TRIFLURALINA ATANOR 445 EC',NULL,NULL),(64,'OXI0009','OXICLORETO CUPR TEC 57% BR 400 KG',400,420);
/*!40000 ALTER TABLE `produtos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:01:38
