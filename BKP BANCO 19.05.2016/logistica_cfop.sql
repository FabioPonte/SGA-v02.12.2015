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
-- Table structure for table `cfop`
--

DROP TABLE IF EXISTS `cfop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cfop` (
  `id` int(11) NOT NULL auto_increment,
  `ocfop` varchar(255) NOT NULL,
  `cor` varchar(45) default NULL,
  `ignorar` int(11) default NULL,
  `apelido` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cfop`
--

LOCK TABLES `cfop` WRITE;
/*!40000 ALTER TABLE `cfop` DISABLE KEYS */;
INSERT INTO `cfop` VALUES (2,'999  ESTORNO DE nfE NAO CANCELADA NO PRAZO LEGAL','#FF0000',1,'999  ESTORNO DE nfE NAO CANCELADA NO PRAZO LEGAL'),(3,'999  Estorno de NFe nao cancelada no prazo legal',NULL,NULL,NULL),(4,'999  estorno de nfe nao cancelada no prazo legal',NULL,NULL,NULL),(5,'999 Estorno de NFE nao cancelada no prazo legal',NULL,NULL,NULL),(6,'COMPLEMENTAR DE ICMS','#000000',1,'ICMS'),(7,'COMPLEMENTO DO ICMS',NULL,NULL,NULL),(8,'Complemento do ICMS',NULL,NULL,NULL),(9,'Compra para comercializacao',NULL,NULL,NULL),(10,'Compra para comercializacao originada de enc  Rec futuro',NULL,NULL,NULL),(11,'Compra para industrializacao',NULL,NULL,NULL),(12,'Dev venda de mercadoria adquirida ou recebida de terceiros',NULL,NULL,NULL),(13,'Devolucao de compra de material de uso ou consumo',NULL,NULL,NULL),(14,'Devolucao de compra para comercializacao',NULL,NULL,NULL),(15,'Devolucao de compra para industrializacao',NULL,NULL,NULL),(16,'Devolucao de venda de producao do estabelecimento',NULL,NULL,NULL),(17,'Devvenda de mercadoria adquirida ou recebida de terceiros',NULL,NULL,NULL),(18,'Lacto efettitba estoqdecorrente perdaroubo deterioracao',NULL,NULL,NULL),(19,'Lanc efet  tit  simples  fat decorrente de compra  rece fut',NULL,NULL,NULL),(20,'Lanc efet a titulo de simples fat compra para receb futuro',NULL,NULL,NULL),(21,'Lancefettitde simpfaturamento decorvenda entrega futura',NULL,NULL,NULL),(22,'Lancefettitde simples faturamdecorvenda entrega futura',NULL,NULL,NULL),(23,'Lcto titulo simples fat decorrente compra ecbto futuro',NULL,NULL,NULL),(24,'Outra entr mercadoria ou prest de servico nao especificado',NULL,NULL,NULL),(25,'Outra entrmercadoria ou prest de servico nao especificado',NULL,NULL,NULL),(26,'Outra saida de merc ou prest de servico nao especificado',NULL,NULL,NULL),(27,'Outra saida de merc ou prestde servico nao especificado',NULL,NULL,NULL),(28,'Outra saida mercadoria prest de serv nao especificado','#FF0000',1,'Outra saida mercadoria prest de serv nao especificado'),(29,'REMESSA DE AMOSTRA GRATIS',NULL,NULL,NULL),(30,'REMESSA PARA CONSERTO',NULL,NULL,NULL),(31,'REMESSA PARA TESTE',NULL,NULL,NULL),(32,'RETORNO DE REMESSA PARA LOCACAO',NULL,NULL,NULL),(33,'Remde merc por conta e ordem de terceirosem venda a ordem',NULL,NULL,NULL),(34,'Remessa de mercadoria ou bem para conserto ou reparo',NULL,NULL,NULL),(35,'Remessa em bonificacao doacao ou brinde',NULL,NULL,NULL),(36,'Remessa para deposito fechado ou armazem geral',NULL,NULL,NULL),(37,'Ret de mercadoria ou bem recebido para conserto ou reparo',NULL,NULL,NULL),(38,'Retorno de bem recebido por conta de contrato de comodato',NULL,NULL,NULL),(39,'Retorno de mercadoria ou bem recebido para demonstracao',NULL,NULL,NULL),(40,'Transfmercadoria adquirida ou recebida de terceiros',NULL,NULL,NULL),(41,'VENDA MERC ENT CONTA ADQ A ORDEM',NULL,NULL,NULL),(42,'Ven de mercadqou recebtercorigde encentr futura',NULL,NULL,NULL),(43,'Venda MercAdqou recebtercque nao deva por ele transitar',NULL,NULL,NULL),(44,'Venda de merc adq de terc q nao deva por ele transitar',NULL,NULL,NULL),(45,'Venda de mercadoria adquirida ou recebida de terceiros',NULL,NULL,NULL),(46,'Venda de mercadqou recebtercorigde encompentr futura',NULL,NULL,NULL),(47,'Venda de producao do estabelecimento',NULL,NULL,NULL),(48,'Venda mercAdqou recebtercque nao deva por ele transitar',NULL,NULL,NULL),(49,'Venda mercadqou recebida de terceirosdesta nao contrib',NULL,NULL,NULL),(50,'Venda mercadquou recebde tercorigencp entrega futura',NULL,NULL,NULL);
/*!40000 ALTER TABLE `cfop` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-19  8:43:10
