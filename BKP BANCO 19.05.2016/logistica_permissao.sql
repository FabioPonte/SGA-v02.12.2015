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
-- Table structure for table `permissao`
--

DROP TABLE IF EXISTS `permissao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permissao` (
  `id` int(11) NOT NULL auto_increment,
  `modulo` varchar(45) NOT NULL,
  `programa` varchar(120) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissao`
--

LOCK TABLES `permissao` WRITE;
/*!40000 ALTER TABLE `permissao` DISABLE KEYS */;
INSERT INTO `permissao` VALUES (1,'Logística','Analize Manual'),(2,'Logística','Analize XML'),(3,'Logística','Centro Distribuição'),(4,'Logística','Transportadora'),(5,'Logística','Tabela Frete'),(6,'Logística','Tabela Produtos'),(7,'Supply','Condição dos Estoques'),(8,'Almoxarifado','Cadastro de Itens'),(9,'Almoxarifado','Cadastro de requisitantes'),(10,'Almoxarifado','Cadastro de Fabricantes'),(11,'Almoxarifado','Cadastro de Grupo'),(12,'Almoxarifado','Lista de Itens'),(13,'Almoxarifado','Baixa de Itens'),(14,'Almoxarifado','Manutenção de Itens'),(15,'Correção','Retorno Sap'),(16,'Correção','Retorno NOta'),(17,'Correção','Resumo'),(18,'Correção','Lista de Resumo'),(19,'Usuário','Cadastro de Usuário'),(20,'Usuário','Grupo de Usuário'),(21,'Usuário','Permissões'),(22,'Portaria','Cadastro de Motorista'),(23,'Portaria','Cadastro de Caminhão'),(24,'Expedicao','Fazer Expedição'),(25,'Correção','Listagem'),(26,'Relatórios','Criar Relatórios'),(27,'Relatórios','Gerar Relatórios'),(28,'Supply','Inventário'),(29,'Material','Manutenção'),(30,'Material','Recebimento'),(31,'Material','Baixa'),(32,'Material','Configuração'),(33,'Material','Relatórios'),(40,'Portaria','Aviso de Recebimento'),(41,'Alarme','Alarme'),(42,'Estoque','Cadastro'),(43,'Estoque','Ingresso'),(44,'Estoque','Baixa'),(45,'Estoque','Movimentação');
/*!40000 ALTER TABLE `permissao` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-19  8:41:45
