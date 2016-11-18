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
-- Table structure for table `tabelafrete_carreta`
--

DROP TABLE IF EXISTS `tabelafrete_carreta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabelafrete_carreta` (
  `id` int(11) NOT NULL auto_increment,
  `idTransportadoras` int(11) NOT NULL,
  `idCentroDistribuicao` int(11) NOT NULL,
  `Destino` varchar(4) NOT NULL,
  `Valor_Icms` double NOT NULL,
  `Valor_Pallets` double NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `fk_TabelaFrete_Carreta_Transportadoras1_idx` (`idTransportadoras`),
  KEY `fk_TabelaFrete_Carreta_CentroDistribuicao1_idx` (`idCentroDistribuicao`),
  CONSTRAINT `fk_TabelaFrete_Carreta_CentroDistribuicao1` FOREIGN KEY (`idCentroDistribuicao`) REFERENCES `centrodistribuicao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TabelaFrete_Carreta_Transportadoras1` FOREIGN KEY (`idTransportadoras`) REFERENCES `transportadoras` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tabelafrete_carreta`
--

LOCK TABLES `tabelafrete_carreta` WRITE;
/*!40000 ALTER TABLE `tabelafrete_carreta` DISABLE KEYS */;
/*!40000 ALTER TABLE `tabelafrete_carreta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-19  8:42:19