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
-- Table structure for table `relatorios`
--

DROP TABLE IF EXISTS `relatorios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `relatorios` (
  `id` int(11) NOT NULL auto_increment,
  `nome` varchar(45) NOT NULL,
  `descricao` varchar(1024) default NULL,
  `osql` varchar(5000) NOT NULL,
  `idusuarios` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `relatorios`
--

LOCK TABLES `relatorios` WRITE;
/*!40000 ALTER TABLE `relatorios` DISABLE KEYS */;
INSERT INTO `relatorios` VALUES (1,'Lista de Estados Cadastrados','Lista','select * from estados',1),(2,'Historico de Lotes','','select descricao,posicao,data,sum(quantidade) quantidade from condicaoestoque x where posicao like (\'%BIN-LOCATION%\') group by descricao,posicao,data order by 1,2,3',1),(3,'Todas as Notas Expedidas','Todas as notas expedidas','select * from expedicao',1),(4,'Relatório de Expedição','','select r.data \'Data_Expedicao\',e.data \'Data_Faturamento\',e.nota \'Nota\',e.cliente \'Cliente\',e.estado \'Estado\'  from romaneio r,expedicao e where e.idromaneio=r.id',3),(5,'Relatório de Expedicao','','select r.data \'Data_Expedicao\',e.data \'Data_Faturamento\',e.nota \'Nota\',e.cliente \'Cliente\',e.estado \'Estado\'  from romaneio r,expedicao e where e.idromaneio=r.id',1),(6,'Entrega Futura SGA','Mostra toda entrega futura que ainda existe no SGA','SELECT cd,item,descricao \"Descr\",lote \"Lote\",quantidade \"Quantidade\",obs \"Cliente\",fabricacao \"Fab\",validade \"Val\", nota_siger \"Nota Siger\" FROM ACERTO_LOTE WHERE QUANTIDADE > 0',3),(7,'Entrega futura','','SELECT cd,item,descricao \"Descr\",lote \"Lote\",quantidade \"Quantidade\",obs \"Cliente\",fabricacao \"Fab\",validade \"Val\", nota_siger \"Nota Siger\" FROM ACERTO_LOTE WHERE QUANTIDADE > 0',1),(8,'Entrega Futura','','SELECT cd,item,descricao \"Descr\",lote \"Lote\",quantidade \"Quantidade\",obs \"Cliente\",fabricacao \"Fab\",validade \"Val\", nota_siger \"Nota Siger\" FROM ACERTO_LOTE WHERE QUANTIDADE > 0',2),(9,'Expedida Com Placa.','','select distinct r.id,r.data,m.nome,m.cnh,c.placa,e.nota,e.cidade,e.estado,p.nome Produto,e.lote,e.liquido,t.nome from romaneio r, motorista m,caminhao c,expedicao e,produtos p,transportadoras t where m.id=r.idmotorista and c.id=r.idcaminhao  and e.idromaneio=r.id and e.idprodutos=p.id and r.idtransportadoras=t.id',1),(10,'Relatorio de Aviso','','select a.id,a.empresa,a.produto,a.placa,a.motorista,a.nota,av.usuario,a.data Chegada,av.data Avisada from aviso a, aviso_recebido av where av.idaviso=a.id',1),(11,'Relatorio de Aviso','','select a.id,a.empresa,a.produto,a.placa,a.motorista,a.nota,av.usuario,a.data Chegada,av.data Avisada from aviso a, aviso_recebido av where av.idaviso=a.id',6),(12,'Relatorio de Aviso','','select a.id,a.empresa,a.produto,a.placa,a.motorista,a.nota,av.usuario,a.data Chegada,av.data Avisada from aviso a, aviso_recebido av where av.idaviso=a.id',10),(13,'INVENTÁRIO SGA','','select \'SGA\',item,descricao,lote,quantidade from acerto_lote where quantidade >0',2),(14,'INVENTÁRIO SGA','','select \'SGA\',item,descricao,lote,quantidade from acerto_lote where quantidade >0',3),(15,'INVENTÁRIO SGA','','select \'SGA\',item,descricao,lote,quantidade from acerto_lote where quantidade >0',6),(16,'INVENTÁRIO SGA','','select \'SGA\',item,descricao,lote,quantidade from acerto_lote where quantidade >0',4),(17,'INVENTARIO SGA','','select \'SGA\',item,descricao,lote,quantidade from acerto_lote where quantidade >0',1),(18,'RELATÓRIO DE AVISO','','select a.id,a.empresa,a.produto,a.placa,a.motorista,a.nota,av.usuario,a.data Chegada,av.data Avisada from aviso a, aviso_recebido av where av.idaviso=a.id',4);
/*!40000 ALTER TABLE `relatorios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:01:09
