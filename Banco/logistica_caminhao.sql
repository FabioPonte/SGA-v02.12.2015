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
-- Table structure for table `caminhao`
--

DROP TABLE IF EXISTS `caminhao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caminhao` (
  `id` int(11) NOT NULL auto_increment,
  `idtipo_caminhao` int(11) NOT NULL,
  `placa` varchar(15) NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `fk_caminhao_tipo_caminhao1_idx` (`idtipo_caminhao`),
  CONSTRAINT `fk_caminhao_tipo_caminhao1` FOREIGN KEY (`idtipo_caminhao`) REFERENCES `tipo_caminhao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caminhao`
--

LOCK TABLES `caminhao` WRITE;
/*!40000 ALTER TABLE `caminhao` DISABLE KEYS */;
INSERT INTO `caminhao` VALUES (6,17,'GLH-9909'),(7,17,'AFH-7095'),(8,17,'MAU-3604'),(9,1,'ITV-2993'),(10,18,'IQG-4137'),(11,5,'MHH-2194'),(12,5,'KOT-9160'),(13,1,'LUL3003'),(14,5,'CYN-4109'),(15,5,'KWQ-1823'),(16,5,'ERR-5062'),(17,5,'KUR-6446'),(18,5,'ECT-2366'),(19,5,'DBB-1868'),(20,18,'LSK-0739'),(21,18,'IUY-7620'),(22,18,'BWF-9773'),(23,1,'LRL-2182'),(24,18,'LPG-7452'),(25,18,'KMY-8744'),(26,5,'KXJ-1446'),(27,1,'KXM-3190'),(28,5,'AER-5295'),(29,1,'KLK-0038'),(30,18,'KMY8744'),(31,18,'EGJ9356'),(32,11,'CLK - 6804'),(33,18,'DVT-7081'),(34,18,'DVT - 7081'),(35,18,'DVT - 7051'),(36,18,'CQB - 9292'),(37,5,'IJV-6401'),(38,18,'ECT-5065'),(39,5,'DAH-0658'),(40,5,'EDB-9078'),(41,18,'CZX-0833'),(42,5,'LCZ-3265'),(43,5,'CUD-5008'),(44,18,'EGJ-9533'),(45,18,'EWU-0363'),(46,5,'OCX-7446'),(47,18,'IRT-1050'),(48,7,'EKW-9252'),(49,5,'IVC-1153'),(50,5,'IVB-5199'),(51,5,'IVF-3287'),(52,5,'IWE-5781'),(53,5,'LAJ-3953'),(54,5,'JZK-1935'),(55,11,'CUD-5014'),(56,11,'DPE-2007'),(57,11,'FGL-7676'),(58,11,'DAJ-4497'),(59,18,'DBB-9385'),(60,18,'EHH-7515'),(61,5,'NWL-7604'),(62,5,'LRO-9188'),(63,5,'ATG-2070'),(64,5,'IUC-1358'),(65,5,'NEW-5500'),(66,18,'EWU-0366'),(67,18,'IPT-4342'),(68,18,'IRK-0492'),(69,11,'KZZ-3649'),(70,1,'ATH-8476'),(71,11,'MKS-9496'),(72,18,'KZQ-1843'),(73,18,'IBB-7668'),(74,18,'ILJ-5189'),(75,5,'BXJ-3977'),(76,18,'LLK-9264'),(77,5,'MJB-3364'),(78,18,'KNM-7872'),(79,11,'BWF-4052'),(80,5,'IPR-8822'),(81,5,'HRO-8353'),(82,18,'GMQ-0688'),(83,5,'FNG-9580'),(84,18,'IRR-8780'),(85,5,'KGB-5768'),(86,5,'BWS-9163'),(87,18,'EOE-9664'),(88,8,'JLR-6358'),(89,8,'JZS-4366'),(90,8,'BXJ - 0855'),(91,1,'HFD-4734'),(92,18,'EHH-7495'),(93,18,'DVT-7051'),(94,5,'CUD-5019'),(95,18,'EWU0354'),(96,5,'BWN 2763    '),(97,5,'EJV-9417'),(98,1,'DBB-1868'),(99,5,'NKV-9564'),(100,18,'LKY-1541'),(101,1,'JOU-8116'),(102,18,'MQJ-9685'),(103,5,'KOT-7432'),(104,5,'ERY-6349'),(105,5,'HMZ-7756'),(106,18,'EYJ-9531'),(107,18,'KPH-1378'),(108,5,'KCT-7432'),(109,18,'AXF-4375'),(110,18,'NFG-4745'),(111,18,'EFU-4963'),(112,18,'KUO-5573'),(113,1,'IPA9797'),(114,1,'HFD4739'),(115,8,'ATX-3800'),(116,1,'KMH-9540'),(117,18,'EJY-3312'),(118,8,'GQC-8315'),(119,8,'AES-5759'),(120,5,'IWE- 5781'),(121,18,'AMZ8251'),(122,1,'ASJ-5169'),(123,11,'KTT-5868'),(124,11,'KEF-9704'),(125,11,'AEZ-7335'),(126,11,'BWE5219'),(127,11,'IHS-0370'),(128,5,'MIV-7150'),(129,5,'ARU-2325'),(130,5,'INY-1666'),(131,5,'JMW-0019'),(132,5,'BUD-5783'),(133,18,'EHH-7494'),(134,5,'IZM-5577'),(135,18,'AED-7817'),(136,5,'CLK-7866'),(137,5,'MXG - 2459'),(138,5,'IVU-0851'),(139,5,'GMA-6667'),(140,5,'ACG-6788'),(141,5,'GOV-3926'),(142,5,'ACD-5754'),(143,5,'ITC-4969'),(144,5,'EJV-1734'),(145,18,'FDB-0269'),(146,5,'BWK-8799'),(147,5,'LXS-0187'),(148,5,'BTA-7552'),(149,5,'BWM-4722'),(150,5,'MPY-4315'),(151,18,'EGK-6352'),(152,5,'BWH-0175'),(153,5,'IPA-9797'),(154,5,'HEH-4344'),(155,5,'FTV-7763'),(156,5,'LAF-1365'),(157,5,'ITR-7095'),(158,5,'IUJ-5109'),(159,1,'KOT-5517'),(160,1,'00'),(161,1,'KNH9540'),(162,1,'KMH9540'),(163,1,'BWO-2704'),(164,11,'IFB2215'),(165,11,'HBN-8631'),(166,11,'PWJ-5133'),(167,1,'KVC-3842'),(168,1,'OPJ-7573'),(169,1,'EJZ-8698'),(170,11,'KOT-2344'),(171,1,'OPL-3316'),(172,1,'OSH-9863'),(173,1,'LQP-6175'),(174,18,'IMZ-6021'),(175,9,'LWX-4026'),(176,18,'FDB-0793'),(177,11,'CNI-4701'),(178,1,'GKW-6312'),(179,1,'LKT-0181'),(180,1,'KOA-4067'),(181,1,'IZS-0440'),(182,1,'KPM-0177'),(183,8,'KMP-0177'),(184,1,'OPJ-2108'),(185,1,'HBG-0250'),(186,1,'KZR-1128'),(187,1,'KTS-4320'),(188,1,'LYB-7361'),(189,1,'PVK-5390'),(190,4,'BWM-3853'),(191,1,'ELW-7077'),(192,4,'NJL-4250'),(193,18,'AEO-1422'),(194,18,'MFC-9766'),(195,4,'EKH-5675'),(196,5,'CHL-9303'),(197,8,'LYS-0560'),(198,8,'AFZ-1985'),(199,5,'GLK-0458'),(200,1,'CRD-0065'),(201,5,'IUD-0235'),(202,2,'0'),(203,1,'CUD-5045'),(204,5,'IZS 0440 '),(205,5,'DPF-6400'),(206,7,'KNR-5724'),(207,1,'MQJ-9658'),(208,1,'ITT-3449'),(209,1,'AHV-0039'),(210,3,'JDZ-3323'),(211,1,'LQJ-8945'),(213,1,'KNO-1951'),(214,1,'DVT-1438'),(215,13,'HGJ-5045'),(216,1,'OXC-7436'),(217,1,'IGZ2301'),(218,1,'EFV-3688'),(219,1,'OME-7471'),(220,1,'KYY-1619'),(221,1,'GVK-5037'),(222,11,'IHL8834'),(223,4,'JKL-032'),(224,4,'NLW-616'),(225,4,'MLW-616'),(226,1,'ONX-2579'),(227,11,'DPE2579'),(228,11,'CPG-7665'),(229,11,'KZR-2898'),(230,11,'IVE-4848'),(231,8,'KYD-8236'),(232,1,'GNF-1420'),(233,11,'JAQ-0440'),(234,1,'IVE-8489'),(235,4,'AEY-4763'),(236,1,'LOJ-8945'),(237,1,'GXH-7493'),(238,1,'PVO-5479'),(239,1,'OMU-8955'),(240,1,'KTE-6035'),(241,7,'FYR-7030'),(242,1,'HRO-4153'),(243,4,'KMJ-3493'),(244,4,'EKH-5661'),(245,11,'OYD-1304'),(246,18,'DAJ-4099'),(247,1,'EKH5733'),(248,1,'EKH-5733'),(249,1,'EGK-9448'),(250,1,'ZUD-5008'),(251,18,'AQB-6265'),(252,18,'KMJ-3262'),(253,1,'LRQ-0408'),(254,18,'KWX-4880'),(255,18,'KUP-8343'),(256,11,'GKO-4962'),(257,11,'AEY-5661'),(258,11,'IPK-5768'),(259,1,'BXE-5471'),(260,1,'GRB-3242'),(261,1,'KDZ-9748'),(262,11,'LLA-6743'),(263,1,'OUN-8772'),(264,1,'GZG-5319'),(265,11,'BWA-1901'),(266,1,'KRA-2611'),(267,1,'IFX-1678'),(268,1,'LXD-7026'),(269,11,'IVB-3287'),(270,11,'AEE-8673'),(271,11,'BAE-8888'),(272,11,'MIB-1680'),(273,11,'KOL-9463'),(274,11,'IWW-8183'),(275,11,'NTL-0541'),(276,18,'QHL-6323'),(277,11,'IVE-5366'),(278,11,'IVX-2763'),(279,11,'IVC-6965'),(280,1,'GNE-1420'),(281,8,'HUZ-6282'),(282,5,'IVG-0965'),(283,5,'IKF-8035'),(284,5,'DPC-3004'),(285,8,'BWM-8267'),(286,8,'KMS-5733'),(287,8,'KMS-7233'),(288,11,'CPG-4584'),(289,11,'GXH-7494'),(290,8,'JRI-2144'),(291,11,'IIG-7185'),(292,8,'FFN-3012'),(293,1,'IHV-1137'),(294,1,'PVD-4118'),(295,1,'PVD-3833'),(296,1,'LYO-6821'),(297,1,'KNG-1970'),(298,8,'LPI-6026'),(299,4,'KPY-9340'),(300,7,'FIW-1864'),(301,8,'GTR-4740'),(302,8,'MAK-6948'),(303,1,'KMG-3262'),(304,5,'IUP1989'),(305,5,'IUE-3877'),(306,5,'LRL-7123'),(307,5,'ICH-3779'),(308,1,'EKH-5734'),(309,4,'FEY-8279'),(310,11,'EKH-5625'),(311,11,'MQJ-5364'),(312,1,'ISG-6762'),(313,1,'DBB-9344'),(314,1,'GOT-2222'),(315,5,'QHP-4600'),(316,1,'GSF-5408'),(317,1,'NKB-8143'),(318,1,'BWG-8555'),(319,1,'BBL-0721'),(320,18,'GZE-1712'),(321,8,'AAR-2653'),(322,1,'DPE-7665'),(323,1,'CMR-8496'),(324,18,'EOF-1687'),(325,1,'CZZ-5790'),(326,11,'KOE-1818'),(327,11,'EDP-3151'),(328,1,'DVS-4112'),(329,1,'LQQ-9023'),(330,5,'IVC-8142'),(331,18,'KMP-6168'),(332,1,'AMU-5053'),(333,18,'PXC-0530'),(334,8,'KPT-0025'),(335,18,'OPE-9472'),(336,18,'MQU-3282'),(337,4,'KPW-9658'),(338,4,'KPR-8818'),(339,4,'KWK-4601'),(340,4,'MTN-0044'),(341,5,'AMQ-3195'),(342,5,'FJX-2272'),(343,5,'IUG-9530'),(344,11,'AVB-5181'),(345,8,'JTR-4740'),(346,17,'LWX-6520'),(347,11,'KUE-0480'),(348,1,'GDR-4740'),(349,1,'KGU-3992'),(350,5,'IRM-9179'),(351,5,'IZM-5566'),(352,5,'KEG-8690'),(353,5,'NBE-0997'),(354,5,'AMJ-9989'),(355,5,'JMJ-1287'),(356,1,'IXF-0041'),(357,1,'IVC-0380'),(358,1,'IFI-7839'),(359,1,'IDJ-3148'),(360,1,'IBV-4397'),(361,5,'IVB-4397'),(362,1,'IFN-2620'),(363,1,'ICQ-1540'),(364,1,'AOC-0132'),(365,1,'LWS-0018'),(366,5,'AAW-7305'),(367,1,'IVA-6391'),(368,1,'ISR-8548'),(369,1,'IVC-6977'),(370,1,'MOQ-0535'),(371,1,'MQZ-8029'),(372,5,'ISX-7901'),(373,1,'EZY-6349'),(374,8,'EFK-6801'),(375,4,'KPH-4118'),(376,8,'EFV-9408'),(377,8,'LOG-5852'),(378,8,'LOG-8552'),(379,4,'NJL-0720');
/*!40000 ALTER TABLE `caminhao` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23  8:01:13
