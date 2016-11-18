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
-- Table structure for table `conhecimento`
--

DROP TABLE IF EXISTS `conhecimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conhecimento` (
  `id` int(11) NOT NULL auto_increment,
  `idFaturas` int(11) NOT NULL,
  `chave` varchar(48) NOT NULL,
  `emissao` datetime default NULL,
  `oconhecimento` varchar(6) NOT NULL,
  `nota_fiscal` varchar(15) NOT NULL,
  `Origem` varchar(15) NOT NULL,
  `R_nome` varchar(45) default NULL,
  `R_cnpj` varchar(45) default NULL,
  `R_incr` varchar(45) default NULL,
  `R_cidade` varchar(15) default NULL,
  `R_telefone` varchar(15) default NULL,
  `D_nome` varchar(45) default NULL,
  `D_cnpj` varchar(45) default NULL,
  `D_incr` varchar(45) default NULL,
  `D_cidade` varchar(15) default NULL,
  `D_telefone` varchar(45) default NULL,
  `Tomador_cnpj` varchar(45) default NULL,
  `Produto` varchar(45) default NULL,
  `Valor_mercadoria` double default NULL,
  `Peso` double NOT NULL,
  `Volume` double default NULL,
  `Volume_esperado` double default NULL,
  `Icms` double default NULL,
  `Valor_total` double NOT NULL,
  `Valor_receber` double NOT NULL,
  `Valor_receber_esperado` double NOT NULL,
  `Motorista` varchar(45) default NULL,
  `Placa` varchar(15) default NULL,
  `Obs` varchar(1024) default NULL,
  PRIMARY KEY  (`id`),
  KEY `fk_Conhecimento_Faturas1_idx` (`idFaturas`),
  CONSTRAINT `fk_Conhecimento_Faturas1` FOREIGN KEY (`idFaturas`) REFERENCES `faturas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conhecimento`
--

LOCK TABLES `conhecimento` WRITE;
/*!40000 ALTER TABLE `conhecimento` DISABLE KEYS */;
/*!40000 ALTER TABLE `conhecimento` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:00:45
