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
-- Table structure for table `itens`
--

DROP TABLE IF EXISTS `itens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itens` (
  `id` int(11) NOT NULL auto_increment,
  `idfabricantes` int(11) default NULL,
  `idgrupo_itens` int(11) NOT NULL,
  `idprioridades` int(11) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `ncm` varchar(45) default NULL,
  `valor` double default NULL,
  `localizacao` varchar(45) default NULL,
  `obs` varchar(1024) default NULL,
  `item_estoque` tinyint(1) default NULL,
  `maetrial_consumo` tinyint(1) default NULL,
  `quantidade` double NOT NULL,
  `min` double NOT NULL,
  `medio` double NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `fk_itens_fabricantes_idx` (`idfabricantes`),
  KEY `fk_itens_grupo_itens1_idx` (`idgrupo_itens`),
  KEY `fk_itens_prioridades1_idx` (`idprioridades`),
  CONSTRAINT `fk_itens_fabricantes` FOREIGN KEY (`idfabricantes`) REFERENCES `fabricantes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_itens_grupo_itens1` FOREIGN KEY (`idgrupo_itens`) REFERENCES `grupo_itens` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_itens_prioridades1` FOREIGN KEY (`idprioridades`) REFERENCES `prioridades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itens`
--

LOCK TABLES `itens` WRITE;
/*!40000 ALTER TABLE `itens` DISABLE KEYS */;
INSERT INTO `itens` VALUES (4,4,11,5,'ROLAMENTO 6318','',890,'','',1,0,10,2,4),(5,5,12,5,'DETERGENTE EM PÓ','',NULL,'','MATERIAL DE LIMPEZA DO ESCRITÓRIO',1,0,13,1,3),(6,6,12,5,'PASTA CRISTAL','34.05.40.00',2.99,'RESENDE','PASTA UTILIZADA PARA REMOÇÃO DE GRAXA DAS MÃOS DOS MECÂNICOS',0,0,30,10,15);
/*!40000 ALTER TABLE `itens` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:00:30
