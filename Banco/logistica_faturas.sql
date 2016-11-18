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
-- Table structure for table `faturas`
--

DROP TABLE IF EXISTS `faturas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faturas` (
  `id` int(11) NOT NULL auto_increment,
  `idTransportadoras` int(11) NOT NULL,
  `idCentroDistribuicao` int(11) NOT NULL,
  `Fatura` varchar(20) NOT NULL,
  `Vlr_Bruto` double default NULL,
  `Vlr_Liquido` double default NULL,
  `Data_Vencimento` datetime default NULL,
  `Data_Emissao` datetime default NULL,
  `Data_inclusao` datetime default NULL,
  `NomeSacado` varchar(45) default NULL,
  `ENDERECO` varchar(45) default NULL,
  `MUNICIPIO` varchar(45) default NULL,
  `BAIRRO` varchar(45) default NULL,
  `ESTADO` varchar(45) default NULL,
  `CEP` varchar(45) default NULL,
  `INSCEST` varchar(45) default NULL,
  `CNPJMF` varchar(45) default NULL,
  `OBS` varchar(1024) default NULL,
  PRIMARY KEY  (`id`),
  KEY `fk_Faturas_Transportadoras_idx` (`idTransportadoras`),
  KEY `fk_Faturas_CentroDistribuicao1_idx` (`idCentroDistribuicao`),
  CONSTRAINT `fk_Faturas_CentroDistribuicao1` FOREIGN KEY (`idCentroDistribuicao`) REFERENCES `centrodistribuicao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Faturas_Transportadoras` FOREIGN KEY (`idTransportadoras`) REFERENCES `transportadoras` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faturas`
--

LOCK TABLES `faturas` WRITE;
/*!40000 ALTER TABLE `faturas` DISABLE KEYS */;
/*!40000 ALTER TABLE `faturas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:03:05
