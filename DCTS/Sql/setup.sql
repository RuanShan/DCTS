-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: dcts_dev
-- ------------------------------------------------------
-- Server version	5.7.11

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
-- Table structure for table `Cities`
--

DROP TABLE IF EXISTS `Cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cities` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(24) DEFAULT '',
  `nationId` int(10) unsigned NOT NULL DEFAULT '0',
  `nationCode` varchar(12) NOT NULL DEFAULT '',
  `title` varchar(45) DEFAULT NULL,
  `localTitle` varchar(45) DEFAULT NULL,
  `position` int(11) NOT NULL DEFAULT '0',
  `enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=585 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cities`
--

LOCK TABLES `Cities` WRITE;
/*!40000 ALTER TABLE `Cities` DISABLE KEYS */;
INSERT INTO `Cities` VALUES (1,'',0,'USA','夏威夷檀香山','Honolulu',0,1),(2,'',0,'USA','阿拉斯加安克雷奇','Anchorage',0,1),(3,'',0,'CAN','温哥华','Vancouver',0,1),(4,'',0,'USA','旧金山','San Francisco',0,1),(5,'',0,'USA','西雅图','Seattle',0,1),(6,'',0,'USA','洛杉矶','Los Angeles',0,1),(7,'',0,'CAN','阿克拉维克','Aklavik',0,1),(8,'',0,'CAN','艾德蒙顿','Edmonton',0,1),(9,'',0,'USA','凤凰城','Phoenix',0,1),(10,'',0,'USA','丹佛','Denver',0,1),(11,'',0,'MEX','墨西哥城','Mexico City',0,0),(12,'',0,'CAN','温尼伯','Winnipeg',0,1),(13,'',0,'USA','休斯敦','Houston',0,1),(14,'',0,'USA','明尼亚波利斯','Minneapolis',0,1),(15,'',0,'USA','圣保罗','St. Paul',0,1),(16,'',0,'USA','新奥尔良','New Orleans',0,1),(17,'',0,'USA','芝加哥','Chicago',0,1),(18,'',0,'USA','蒙哥马利','Montgomery',0,1),(19,'',0,'GTM','危地马拉','Guatemala',0,0),(20,'',0,'SLV','圣萨尔瓦多','San Salvador',0,0),(21,'',0,'HND','特古西加尔巴','Tegucigalpa',0,0),(22,'',0,'NIC','马那瓜','Managua',0,0),(23,'',0,'CUB','哈瓦那','Havana',0,0),(24,'',0,'USA','印地安纳波利斯','Indianapolis',0,1),(25,'',0,'USA','亚特兰大','Atlanta',0,1),(26,'',0,'USA','底特律','Detroit',0,1),(27,'',0,'USA','华盛顿哥伦比亚特区','Washington DC',0,1),(28,'',0,'USA','费城','Philadelphia',0,1),(29,'',0,'CAN','多伦多','Toronto',0,1),(30,'',0,'CAN','渥太华','Ottawa',0,1),(31,'',0,'BHS','拿骚','Nassau',0,0),(32,'',0,'PER','利马','Lima',0,0),(33,'',0,'JAM','金斯敦','Kingston',0,0),(34,'',0,'KHM','波哥大','Bogota',0,0),(35,'',0,'USA','纽约','New York',0,1),(36,'',0,'CAN','蒙特利尔','Montreal',0,1),(37,'',0,'USA','波士顿','Boston',0,1),(38,'',0,'NZL','惠灵顿','Wellington',0,1),(39,'',0,'NZL','查塔姆群岛','Chatham Island',0,1),(40,'',0,'1','香港','Hong Kong',0,1),(41,'',0,'1','北京','Beijing',0,1),(42,'',0,'1','上海','Shanghai',0,1),(43,'',0,'1','台北','Taipei',0,1),(44,'',0,'1','普吉岛',NULL,0,0),(45,'',0,'1','曼谷',NULL,0,0),(46,'',0,'1','曼谷',NULL,0,0),(47,'',0,'1','普吉岛',NULL,0,0),(48,'',0,'USA','索维拉',NULL,0,0),(49,'',0,'USA','索维拉',NULL,0,0),(50,'',0,'USA','索维拉',NULL,0,0),(51,'',0,'USA','马拉喀什',NULL,0,0),(52,'',0,'USA','马拉喀什',NULL,0,0),(53,'',0,'USA','马拉喀什',NULL,0,0),(54,'',0,'USA','马拉喀什',NULL,0,0),(55,'',0,'USA','马拉喀什',NULL,0,0),(56,'',0,'USA','梅尔祖卡',NULL,0,0),(57,'',0,'USA','梅克内斯',NULL,0,0),(58,'',0,'USA','梅克内斯',NULL,0,0),(59,'',0,'USA','梅克内斯',NULL,0,0),(60,'',0,'USA','梅克内斯',NULL,0,0),(61,'',0,'USA','菲斯',NULL,0,0),(62,'',0,'USA','菲斯',NULL,0,0),(63,'',0,'USA','菲斯',NULL,0,0),(64,'',0,'USA','菲斯',NULL,0,0),(65,'',0,'USA','菲斯',NULL,0,0),(66,'',0,'USA','菲斯',NULL,0,0),(67,'',0,'USA','菲斯',NULL,0,0),(68,'',0,'USA','舍夫沙万',NULL,0,0),(69,'',0,'USA','舍夫沙万',NULL,0,0),(70,'',0,'USA','舍夫沙万',NULL,0,0),(71,'',0,'USA','丹吉尔',NULL,0,0),(72,'',0,'USA','丹吉尔',NULL,0,0),(73,'',0,'USA','艾西拉 ',NULL,0,0),(74,'',0,'USA','卡萨布兰卡',NULL,0,0),(75,'',0,'USA','卡萨布兰卡',NULL,0,0),(76,'',0,'USA','卡萨布兰卡',NULL,0,0),(77,'',0,'1','普吉岛',NULL,0,0),(78,'',0,'1','普吉岛',NULL,0,0),(79,'',0,'1','曼谷',NULL,0,0),(80,'',0,'1','曼谷',NULL,0,0),(81,'',0,'1','曼谷',NULL,0,0),(82,'',0,'1','曼谷',NULL,0,0),(83,'',0,'1','曼谷',NULL,0,0),(84,'',0,'1','普吉岛',NULL,0,0),(85,'',0,'USA','索维拉',NULL,0,0),(86,'',0,'USA','索维拉',NULL,0,0),(87,'',0,'USA','索维拉',NULL,0,0),(88,'',0,'USA','马拉喀什',NULL,0,0),(89,'',0,'USA','马拉喀什',NULL,0,0),(90,'',0,'USA','马拉喀什',NULL,0,0),(91,'',0,'USA','马拉喀什',NULL,0,0),(92,'',0,'USA','马拉喀什',NULL,0,0),(93,'',0,'USA','梅尔祖卡',NULL,0,0),(94,'',0,'USA','梅克内斯',NULL,0,0),(95,'',0,'USA','梅克内斯',NULL,0,0),(96,'',0,'USA','梅克内斯',NULL,0,0),(97,'',0,'USA','梅克内斯',NULL,0,0),(98,'',0,'USA','菲斯',NULL,0,0),(99,'',0,'USA','菲斯',NULL,0,0),(100,'',0,'USA','菲斯',NULL,0,0),(101,'',0,'USA','菲斯',NULL,0,0),(102,'',0,'USA','菲斯',NULL,0,0),(103,'',0,'USA','菲斯',NULL,0,0),(104,'',0,'USA','菲斯',NULL,0,0),(105,'',0,'USA','舍夫沙万',NULL,0,0),(106,'',0,'USA','舍夫沙万',NULL,0,0),(107,'',0,'USA','舍夫沙万',NULL,0,0),(108,'',0,'USA','丹吉尔',NULL,0,0),(109,'',0,'USA','丹吉尔',NULL,0,0),(110,'',0,'USA','艾西拉 ',NULL,0,0),(111,'',0,'USA','卡萨布兰卡',NULL,0,0),(112,'',0,'USA','卡萨布兰卡',NULL,0,0),(113,'',0,'USA','卡萨布兰卡',NULL,0,0),(114,'',0,'1','普吉岛',NULL,0,0),(115,'',0,'1','普吉岛',NULL,0,0),(116,'',0,'1','曼谷',NULL,0,0),(117,'',0,'1','曼谷',NULL,0,0),(118,'',0,'1','曼谷',NULL,0,0),(119,'',0,'1','曼谷',NULL,0,0),(120,'',0,'1','曼谷',NULL,0,0),(121,'',0,'1','普吉岛',NULL,0,0),(122,'',0,'USA','索维拉',NULL,0,0),(123,'',0,'USA','索维拉',NULL,0,0),(124,'',0,'USA','索维拉',NULL,0,0),(125,'',0,'USA','马拉喀什',NULL,0,0),(126,'',0,'USA','马拉喀什',NULL,0,0),(127,'',0,'USA','马拉喀什',NULL,0,0),(128,'',0,'USA','马拉喀什',NULL,0,0),(129,'',0,'USA','马拉喀什',NULL,0,0),(130,'',0,'USA','梅尔祖卡',NULL,0,0),(131,'',0,'USA','梅克内斯',NULL,0,0),(132,'',0,'USA','梅克内斯',NULL,0,0),(133,'',0,'USA','梅克内斯',NULL,0,0),(134,'',0,'USA','梅克内斯',NULL,0,0),(135,'',0,'USA','菲斯',NULL,0,0),(136,'',0,'USA','菲斯',NULL,0,0),(137,'',0,'USA','菲斯',NULL,0,0),(138,'',0,'USA','菲斯',NULL,0,0),(139,'',0,'USA','菲斯',NULL,0,0),(140,'',0,'USA','菲斯',NULL,0,0),(141,'',0,'USA','菲斯',NULL,0,0),(142,'',0,'USA','舍夫沙万',NULL,0,0),(143,'',0,'USA','舍夫沙万',NULL,0,0),(144,'',0,'USA','舍夫沙万',NULL,0,0),(145,'',0,'USA','丹吉尔',NULL,0,0),(146,'',0,'USA','丹吉尔',NULL,0,0),(147,'',0,'USA','艾西拉 ',NULL,0,0),(148,'',0,'USA','卡萨布兰卡',NULL,0,0),(149,'',0,'USA','卡萨布兰卡',NULL,0,0),(150,'',0,'USA','卡萨布兰卡',NULL,0,0),(151,'',0,'1','啥地方',NULL,0,0),(152,'',0,'1','普吉岛',NULL,0,0),(153,'',0,'1','曼谷',NULL,0,0),(154,'',0,'1','曼谷',NULL,0,0),(155,'',0,'1','普吉岛',NULL,0,0),(156,'',0,'USA','索维拉',NULL,0,0),(157,'',0,'USA','索维拉',NULL,0,0),(158,'',0,'USA','索维拉',NULL,0,0),(159,'',0,'USA','马拉喀什',NULL,0,0),(160,'',0,'USA','马拉喀什',NULL,0,0),(161,'',0,'USA','马拉喀什',NULL,0,0),(162,'',0,'USA','马拉喀什',NULL,0,0),(163,'',0,'USA','马拉喀什',NULL,0,0),(164,'',0,'USA','梅尔祖卡',NULL,0,0),(165,'',0,'USA','梅克内斯',NULL,0,0),(166,'',0,'USA','梅克内斯',NULL,0,0),(167,'',0,'USA','梅克内斯',NULL,0,0),(168,'',0,'USA','梅克内斯',NULL,0,0),(169,'',0,'USA','菲斯',NULL,0,0),(170,'',0,'USA','菲斯',NULL,0,0),(171,'',0,'USA','菲斯',NULL,0,0),(172,'',0,'USA','菲斯',NULL,0,0),(173,'',0,'USA','菲斯',NULL,0,0),(174,'',0,'USA','菲斯',NULL,0,0),(175,'',0,'USA','菲斯',NULL,0,0),(176,'',0,'USA','舍夫沙万',NULL,0,0),(177,'',0,'USA','舍夫沙万',NULL,0,0),(178,'',0,'USA','舍夫沙万',NULL,0,0),(179,'',0,'USA','丹吉尔',NULL,0,0),(180,'',0,'USA','丹吉尔',NULL,0,0),(181,'',0,'USA','艾西拉 ',NULL,0,0),(182,'',0,'USA','卡萨布兰卡',NULL,0,0),(183,'',0,'USA','卡萨布兰卡',NULL,0,0),(184,'',0,'USA','卡萨布兰卡',NULL,0,0),(185,'',0,'1','普吉岛',NULL,0,0),(186,'',0,'1','普吉岛',NULL,0,0),(187,'',0,'1','曼谷',NULL,0,0),(188,'',0,'1','曼谷',NULL,0,0),(189,'',0,'1','曼谷',NULL,0,0),(190,'',0,'1','曼谷',NULL,0,0),(191,'',0,'1','曼谷',NULL,0,0),(192,'',0,'1','普吉岛',NULL,0,0),(193,'',0,'USA','索维拉',NULL,0,0),(194,'',0,'USA','索维拉',NULL,0,0),(195,'',0,'USA','索维拉',NULL,0,0),(196,'',0,'USA','马拉喀什',NULL,0,0),(197,'',0,'USA','马拉喀什',NULL,0,0),(198,'',0,'USA','马拉喀什',NULL,0,0),(199,'',0,'USA','马拉喀什',NULL,0,0),(200,'',0,'USA','马拉喀什',NULL,0,0),(201,'',0,'USA','梅尔祖卡',NULL,0,0),(202,'',0,'USA','梅克内斯',NULL,0,0),(203,'',0,'USA','梅克内斯',NULL,0,0),(204,'',0,'USA','梅克内斯',NULL,0,0),(205,'',0,'USA','梅克内斯',NULL,0,0),(206,'',0,'USA','菲斯',NULL,0,0),(207,'',0,'USA','菲斯',NULL,0,0),(208,'',0,'USA','菲斯',NULL,0,0),(209,'',0,'USA','菲斯',NULL,0,0),(210,'',0,'USA','菲斯',NULL,0,0),(211,'',0,'USA','菲斯',NULL,0,0),(212,'',0,'USA','菲斯',NULL,0,0),(213,'',0,'USA','舍夫沙万',NULL,0,0),(214,'',0,'USA','舍夫沙万',NULL,0,0),(215,'',0,'USA','舍夫沙万',NULL,0,0),(216,'',0,'USA','丹吉尔',NULL,0,0),(217,'',0,'USA','丹吉尔',NULL,0,0),(218,'',0,'USA','艾西拉 ',NULL,0,0),(219,'',0,'USA','卡萨布兰卡',NULL,0,0),(220,'',0,'USA','卡萨布兰卡',NULL,0,0),(221,'',0,'USA','卡萨布兰卡',NULL,0,0),(222,'',0,'1','普吉岛',NULL,0,0),(223,'',0,'1','普吉岛',NULL,0,0),(224,'',0,'1','曼谷',NULL,0,0),(225,'',0,'1','曼谷',NULL,0,0),(226,'',0,'1','曼谷',NULL,0,0),(227,'',0,'1','曼谷',NULL,0,0),(228,'',0,'1','曼谷',NULL,0,0),(229,'',0,'1','普吉岛',NULL,0,0),(230,'',0,'USA','索维拉',NULL,0,0),(231,'',0,'USA','索维拉',NULL,0,0),(232,'',0,'USA','索维拉',NULL,0,0),(233,'',0,'USA','马拉喀什',NULL,0,0),(234,'',0,'USA','马拉喀什',NULL,0,0),(235,'',0,'USA','马拉喀什',NULL,0,0),(236,'',0,'USA','马拉喀什',NULL,0,0),(237,'',0,'USA','马拉喀什',NULL,0,0),(238,'',0,'USA','梅尔祖卡',NULL,0,0),(239,'',0,'USA','梅克内斯',NULL,0,0),(240,'',0,'USA','梅克内斯',NULL,0,0),(241,'',0,'USA','梅克内斯',NULL,0,0),(242,'',0,'USA','梅克内斯',NULL,0,0),(243,'',0,'USA','菲斯',NULL,0,0),(244,'',0,'USA','菲斯',NULL,0,0),(245,'',0,'USA','菲斯',NULL,0,0),(246,'',0,'USA','菲斯',NULL,0,0),(247,'',0,'USA','菲斯',NULL,0,0),(248,'',0,'USA','菲斯',NULL,0,0),(249,'',0,'USA','菲斯',NULL,0,0),(250,'',0,'USA','舍夫沙万',NULL,0,0),(251,'',0,'USA','舍夫沙万',NULL,0,0),(252,'',0,'USA','舍夫沙万',NULL,0,0),(253,'',0,'USA','丹吉尔',NULL,0,0),(254,'',0,'USA','丹吉尔',NULL,0,0),(255,'',0,'USA','艾西拉 ',NULL,0,0),(256,'',0,'USA','卡萨布兰卡',NULL,0,0),(257,'',0,'USA','卡萨布兰卡',NULL,0,0),(258,'',0,'USA','卡萨布兰卡',NULL,0,0),(259,'',0,'1','啥地方',NULL,0,0),(260,'',0,'1','普吉岛',NULL,0,0),(261,'',0,'1','曼谷',NULL,0,0),(262,'',0,'1','曼谷',NULL,0,0),(263,'',0,'1','普吉岛',NULL,0,0),(264,'',0,'USA','索维拉',NULL,0,0),(265,'',0,'USA','索维拉',NULL,0,0),(266,'',0,'USA','索维拉',NULL,0,0),(267,'',0,'USA','马拉喀什',NULL,0,0),(268,'',0,'USA','马拉喀什',NULL,0,0),(269,'',0,'USA','马拉喀什',NULL,0,0),(270,'',0,'USA','马拉喀什',NULL,0,0),(271,'',0,'USA','马拉喀什',NULL,0,0),(272,'',0,'USA','梅尔祖卡',NULL,0,0),(273,'',0,'USA','梅克内斯',NULL,0,0),(274,'',0,'USA','梅克内斯',NULL,0,0),(275,'',0,'USA','梅克内斯',NULL,0,0),(276,'',0,'USA','梅克内斯',NULL,0,0),(277,'',0,'USA','菲斯',NULL,0,0),(278,'',0,'USA','菲斯',NULL,0,0),(279,'',0,'USA','菲斯',NULL,0,0),(280,'',0,'USA','菲斯',NULL,0,0),(281,'',0,'USA','菲斯',NULL,0,0),(282,'',0,'USA','菲斯',NULL,0,0),(283,'',0,'USA','菲斯',NULL,0,0),(284,'',0,'USA','舍夫沙万',NULL,0,0),(285,'',0,'USA','舍夫沙万',NULL,0,0),(286,'',0,'USA','舍夫沙万',NULL,0,0),(287,'',0,'USA','丹吉尔',NULL,0,0),(288,'',0,'USA','丹吉尔',NULL,0,0),(289,'',0,'USA','艾西拉 ',NULL,0,0),(290,'',0,'USA','卡萨布兰卡',NULL,0,0),(291,'',0,'USA','卡萨布兰卡',NULL,0,0),(292,'',0,'USA','卡萨布兰卡',NULL,0,0),(293,'',0,'1','普吉岛',NULL,0,0),(294,'',0,'1','普吉岛',NULL,0,0),(295,'',0,'1','曼谷',NULL,0,0),(296,'',0,'1','曼谷',NULL,0,0),(297,'',0,'1','曼谷',NULL,0,0),(298,'',0,'1','曼谷',NULL,0,0),(299,'',0,'1','曼谷',NULL,0,0),(300,'',0,'1','普吉岛',NULL,0,0),(301,'',0,'USA','索维拉',NULL,0,0),(302,'',0,'USA','索维拉',NULL,0,0),(303,'',0,'USA','索维拉',NULL,0,0),(304,'',0,'USA','马拉喀什',NULL,0,0),(305,'',0,'USA','马拉喀什',NULL,0,0),(306,'',0,'USA','马拉喀什',NULL,0,0),(307,'',0,'USA','马拉喀什',NULL,0,0),(308,'',0,'USA','马拉喀什',NULL,0,0),(309,'',0,'USA','梅尔祖卡',NULL,0,0),(310,'',0,'USA','梅克内斯',NULL,0,0),(311,'',0,'USA','梅克内斯',NULL,0,0),(312,'',0,'USA','梅克内斯',NULL,0,0),(313,'',0,'USA','梅克内斯',NULL,0,0),(314,'',0,'USA','菲斯',NULL,0,0),(315,'',0,'USA','菲斯',NULL,0,0),(316,'',0,'USA','菲斯',NULL,0,0),(317,'',0,'USA','菲斯',NULL,0,0),(318,'',0,'USA','菲斯',NULL,0,0),(319,'',0,'USA','菲斯',NULL,0,0),(320,'',0,'USA','菲斯',NULL,0,0),(321,'',0,'USA','舍夫沙万',NULL,0,0),(322,'',0,'USA','舍夫沙万',NULL,0,0),(323,'',0,'USA','舍夫沙万',NULL,0,0),(324,'',0,'USA','丹吉尔',NULL,0,0),(325,'',0,'USA','丹吉尔',NULL,0,0),(326,'',0,'USA','艾西拉 ',NULL,0,0),(327,'',0,'USA','卡萨布兰卡',NULL,0,0),(328,'',0,'USA','卡萨布兰卡',NULL,0,0),(329,'',0,'USA','卡萨布兰卡',NULL,0,0),(330,'',0,'1','普吉岛',NULL,0,0),(331,'',0,'1','普吉岛',NULL,0,0),(332,'',0,'1','曼谷',NULL,0,0),(333,'',0,'1','曼谷',NULL,0,0),(334,'',0,'1','曼谷',NULL,0,0),(335,'',0,'1','曼谷',NULL,0,0),(336,'',0,'1','曼谷',NULL,0,0),(337,'',0,'1','普吉岛',NULL,0,0),(338,'',0,'USA','索维拉',NULL,0,0),(339,'',0,'USA','索维拉',NULL,0,0),(340,'',0,'USA','索维拉',NULL,0,0),(341,'',0,'USA','马拉喀什',NULL,0,0),(342,'',0,'USA','马拉喀什',NULL,0,0),(343,'',0,'USA','马拉喀什',NULL,0,0),(344,'',0,'USA','马拉喀什',NULL,0,0),(345,'',0,'USA','马拉喀什',NULL,0,0),(346,'',0,'USA','梅尔祖卡',NULL,0,0),(347,'',0,'USA','梅克内斯',NULL,0,0),(348,'',0,'USA','梅克内斯',NULL,0,0),(349,'',0,'USA','梅克内斯',NULL,0,0),(350,'',0,'USA','梅克内斯',NULL,0,0),(351,'',0,'USA','菲斯',NULL,0,0),(352,'',0,'USA','菲斯',NULL,0,0),(353,'',0,'USA','菲斯',NULL,0,0),(354,'',0,'USA','菲斯',NULL,0,0),(355,'',0,'USA','菲斯',NULL,0,0),(356,'',0,'USA','菲斯',NULL,0,0),(357,'',0,'USA','菲斯',NULL,0,0),(358,'',0,'USA','舍夫沙万',NULL,0,0),(359,'',0,'USA','舍夫沙万',NULL,0,0),(360,'',0,'USA','舍夫沙万',NULL,0,0),(361,'',0,'USA','丹吉尔',NULL,0,0),(362,'',0,'USA','丹吉尔',NULL,0,0),(363,'',0,'USA','艾西拉 ',NULL,0,0),(364,'',0,'USA','卡萨布兰卡',NULL,0,0),(365,'',0,'USA','卡萨布兰卡',NULL,0,0),(366,'',0,'USA','卡萨布兰卡',NULL,0,0),(367,'',0,'1','啥地方',NULL,0,0),(368,'',0,'1','普吉岛',NULL,0,0),(369,'',0,'1','曼谷',NULL,0,0),(370,'',0,'1','曼谷',NULL,0,0),(371,'',0,'1','普吉岛',NULL,0,0),(372,'',0,'USA','索维拉',NULL,0,0),(373,'',0,'USA','索维拉',NULL,0,0),(374,'',0,'USA','索维拉',NULL,0,0),(375,'',0,'USA','马拉喀什',NULL,0,0),(376,'',0,'USA','马拉喀什',NULL,0,0),(377,'',0,'USA','马拉喀什',NULL,0,0),(378,'',0,'USA','马拉喀什',NULL,0,0),(379,'',0,'USA','马拉喀什',NULL,0,0),(380,'',0,'USA','梅尔祖卡',NULL,0,0),(381,'',0,'USA','梅克内斯',NULL,0,0),(382,'',0,'USA','梅克内斯',NULL,0,0),(383,'',0,'USA','梅克内斯',NULL,0,0),(384,'',0,'USA','梅克内斯',NULL,0,0),(385,'',0,'USA','菲斯',NULL,0,0),(386,'',0,'USA','菲斯',NULL,0,0),(387,'',0,'USA','菲斯',NULL,0,0),(388,'',0,'USA','菲斯',NULL,0,0),(389,'',0,'USA','菲斯',NULL,0,0),(390,'',0,'USA','菲斯',NULL,0,0),(391,'',0,'USA','菲斯',NULL,0,0),(392,'',0,'USA','舍夫沙万',NULL,0,0),(393,'',0,'USA','舍夫沙万',NULL,0,0),(394,'',0,'USA','舍夫沙万',NULL,0,0),(395,'',0,'USA','丹吉尔',NULL,0,0),(396,'',0,'USA','丹吉尔',NULL,0,0),(397,'',0,'USA','艾西拉 ',NULL,0,0),(398,'',0,'USA','卡萨布兰卡',NULL,0,0),(399,'',0,'USA','卡萨布兰卡',NULL,0,0),(400,'',0,'USA','卡萨布兰卡',NULL,0,0),(401,'',0,'1','普吉岛',NULL,0,0),(402,'',0,'1','普吉岛',NULL,0,0),(403,'',0,'1','曼谷',NULL,0,0),(404,'',0,'1','曼谷',NULL,0,0),(405,'',0,'1','曼谷',NULL,0,0),(406,'',0,'1','曼谷',NULL,0,0),(407,'',0,'1','曼谷',NULL,0,0),(408,'',0,'1','普吉岛',NULL,0,0),(409,'',0,'USA','索维拉',NULL,0,0),(410,'',0,'USA','索维拉',NULL,0,0),(411,'',0,'USA','索维拉',NULL,0,0),(412,'',0,'USA','马拉喀什',NULL,0,0),(413,'',0,'USA','马拉喀什',NULL,0,0),(414,'',0,'USA','马拉喀什',NULL,0,0),(415,'',0,'USA','马拉喀什',NULL,0,0),(416,'',0,'USA','马拉喀什',NULL,0,0),(417,'',0,'USA','梅尔祖卡',NULL,0,0),(418,'',0,'USA','梅克内斯',NULL,0,0),(419,'',0,'USA','梅克内斯',NULL,0,0),(420,'',0,'USA','梅克内斯',NULL,0,0),(421,'',0,'USA','梅克内斯',NULL,0,0),(422,'',0,'USA','菲斯',NULL,0,0),(423,'',0,'USA','菲斯',NULL,0,0),(424,'',0,'USA','菲斯',NULL,0,0),(425,'',0,'USA','菲斯',NULL,0,0),(426,'',0,'USA','菲斯',NULL,0,0),(427,'',0,'USA','菲斯',NULL,0,0),(428,'',0,'USA','菲斯',NULL,0,0),(429,'',0,'USA','舍夫沙万',NULL,0,0),(430,'',0,'USA','舍夫沙万',NULL,0,0),(431,'',0,'USA','舍夫沙万',NULL,0,0),(432,'',0,'USA','丹吉尔',NULL,0,0),(433,'',0,'USA','丹吉尔',NULL,0,0),(434,'',0,'USA','艾西拉 ',NULL,0,0),(435,'',0,'USA','卡萨布兰卡',NULL,0,0),(436,'',0,'USA','卡萨布兰卡',NULL,0,0),(437,'',0,'USA','卡萨布兰卡',NULL,0,0),(438,'',0,'1','普吉岛',NULL,0,0),(439,'',0,'1','普吉岛',NULL,0,0),(440,'',0,'1','曼谷',NULL,0,0),(441,'',0,'1','曼谷',NULL,0,0),(442,'',0,'1','曼谷',NULL,0,0),(443,'',0,'1','曼谷',NULL,0,0),(444,'',0,'1','曼谷',NULL,0,0),(445,'',0,'1','普吉岛',NULL,0,0),(446,'',0,'USA','索维拉',NULL,0,0),(447,'',0,'USA','索维拉',NULL,0,0),(448,'',0,'USA','索维拉',NULL,0,0),(449,'',0,'USA','马拉喀什',NULL,0,0),(450,'',0,'USA','马拉喀什',NULL,0,0),(451,'',0,'USA','马拉喀什',NULL,0,0),(452,'',0,'USA','马拉喀什',NULL,0,0),(453,'',0,'USA','马拉喀什',NULL,0,0),(454,'',0,'USA','梅尔祖卡',NULL,0,0),(455,'',0,'USA','梅克内斯',NULL,0,0),(456,'',0,'USA','梅克内斯',NULL,0,0),(457,'',0,'USA','梅克内斯',NULL,0,0),(458,'',0,'USA','梅克内斯',NULL,0,0),(459,'',0,'USA','菲斯',NULL,0,0),(460,'',0,'USA','菲斯',NULL,0,0),(461,'',0,'USA','菲斯',NULL,0,0),(462,'',0,'USA','菲斯',NULL,0,0),(463,'',0,'USA','菲斯',NULL,0,0),(464,'',0,'USA','菲斯',NULL,0,0),(465,'',0,'USA','菲斯',NULL,0,0),(466,'',0,'USA','舍夫沙万',NULL,0,0),(467,'',0,'USA','舍夫沙万',NULL,0,0),(468,'',0,'USA','舍夫沙万',NULL,0,0),(469,'',0,'USA','丹吉尔',NULL,0,0),(470,'',0,'USA','丹吉尔',NULL,0,0),(471,'',0,'USA','艾西拉 ',NULL,0,0),(472,'',0,'USA','卡萨布兰卡',NULL,0,0),(473,'',0,'USA','卡萨布兰卡',NULL,0,0),(474,'',0,'USA','卡萨布兰卡',NULL,0,0),(475,'',0,'1','啥地方',NULL,0,0),(476,'',0,'1','普吉岛',NULL,0,0),(477,'',0,'1','曼谷',NULL,0,0),(478,'',0,'1','曼谷',NULL,0,0),(479,'',0,'1','普吉岛',NULL,0,0),(480,'',0,'USA','索维拉',NULL,0,0),(481,'',0,'USA','索维拉',NULL,0,0),(482,'',0,'USA','索维拉',NULL,0,0),(483,'',0,'USA','马拉喀什',NULL,0,0),(484,'',0,'USA','马拉喀什',NULL,0,0),(485,'',0,'USA','马拉喀什',NULL,0,0),(486,'',0,'USA','马拉喀什',NULL,0,0),(487,'',0,'USA','马拉喀什',NULL,0,0),(488,'',0,'USA','梅尔祖卡',NULL,0,0),(489,'',0,'USA','梅克内斯',NULL,0,0),(490,'',0,'USA','梅克内斯',NULL,0,0),(491,'',0,'USA','梅克内斯',NULL,0,0),(492,'',0,'USA','梅克内斯',NULL,0,0),(493,'',0,'USA','菲斯',NULL,0,0),(494,'',0,'USA','菲斯',NULL,0,0),(495,'',0,'USA','菲斯',NULL,0,0),(496,'',0,'USA','菲斯',NULL,0,0),(497,'',0,'USA','菲斯',NULL,0,0),(498,'',0,'USA','菲斯',NULL,0,0),(499,'',0,'USA','菲斯',NULL,0,0),(500,'',0,'USA','舍夫沙万',NULL,0,0),(501,'',0,'USA','舍夫沙万',NULL,0,0),(502,'',0,'USA','舍夫沙万',NULL,0,0),(503,'',0,'USA','丹吉尔',NULL,0,0),(504,'',0,'USA','丹吉尔',NULL,0,0),(505,'',0,'USA','艾西拉 ',NULL,0,0),(506,'',0,'USA','卡萨布兰卡',NULL,0,0),(507,'',0,'USA','卡萨布兰卡',NULL,0,0),(508,'',0,'USA','卡萨布兰卡',NULL,0,0),(509,'',0,'1','普吉岛',NULL,0,0),(510,'',0,'1','普吉岛',NULL,0,0),(511,'',0,'1','曼谷',NULL,0,0),(512,'',0,'1','曼谷',NULL,0,0),(513,'',0,'1','曼谷',NULL,0,0),(514,'',0,'1','曼谷',NULL,0,0),(515,'',0,'1','曼谷',NULL,0,0),(516,'',0,'1','普吉岛',NULL,0,0),(517,'',0,'USA','索维拉',NULL,0,0),(518,'',0,'USA','索维拉',NULL,0,0),(519,'',0,'USA','索维拉',NULL,0,0),(520,'',0,'USA','马拉喀什',NULL,0,0),(521,'',0,'USA','马拉喀什',NULL,0,0),(522,'',0,'USA','马拉喀什',NULL,0,0),(523,'',0,'USA','马拉喀什',NULL,0,0),(524,'',0,'USA','马拉喀什',NULL,0,0),(525,'',0,'USA','梅尔祖卡',NULL,0,0),(526,'',0,'USA','梅克内斯',NULL,0,0),(527,'',0,'USA','梅克内斯',NULL,0,0),(528,'',0,'USA','梅克内斯',NULL,0,0),(529,'',0,'USA','梅克内斯',NULL,0,0),(530,'',0,'USA','菲斯',NULL,0,0),(531,'',0,'USA','菲斯',NULL,0,0),(532,'',0,'USA','菲斯',NULL,0,0),(533,'',0,'USA','菲斯',NULL,0,0),(534,'',0,'USA','菲斯',NULL,0,0),(535,'',0,'USA','菲斯',NULL,0,0),(536,'',0,'USA','菲斯',NULL,0,0),(537,'',0,'USA','舍夫沙万',NULL,0,0),(538,'',0,'USA','舍夫沙万',NULL,0,0),(539,'',0,'USA','舍夫沙万',NULL,0,0),(540,'',0,'USA','丹吉尔',NULL,0,0),(541,'',0,'USA','丹吉尔',NULL,0,0),(542,'',0,'USA','艾西拉 ',NULL,0,0),(543,'',0,'USA','卡萨布兰卡',NULL,0,0),(544,'',0,'USA','卡萨布兰卡',NULL,0,0),(545,'',0,'USA','卡萨布兰卡',NULL,0,0),(546,'',0,'1','普吉岛',NULL,0,0),(547,'',0,'1','普吉岛',NULL,0,0),(548,'',0,'1','曼谷',NULL,0,0),(549,'',0,'1','曼谷',NULL,0,0),(550,'',0,'1','曼谷',NULL,0,0),(551,'',0,'1','曼谷',NULL,0,0),(552,'',0,'1','曼谷',NULL,0,0),(553,'',0,'1','普吉岛',NULL,0,0),(554,'',0,'USA','索维拉',NULL,0,0),(555,'',0,'USA','索维拉',NULL,0,0),(556,'',0,'USA','索维拉',NULL,0,0),(557,'',0,'USA','马拉喀什',NULL,0,0),(558,'',0,'USA','马拉喀什',NULL,0,0),(559,'',0,'USA','马拉喀什',NULL,0,0),(560,'',0,'USA','马拉喀什',NULL,0,0),(561,'',0,'USA','马拉喀什',NULL,0,0),(562,'',0,'USA','梅尔祖卡',NULL,0,0),(563,'',0,'USA','梅克内斯',NULL,0,0),(564,'',0,'USA','梅克内斯',NULL,0,0),(565,'',0,'USA','梅克内斯',NULL,0,0),(566,'',0,'USA','梅克内斯',NULL,0,0),(567,'',0,'USA','菲斯',NULL,0,0),(568,'',0,'USA','菲斯',NULL,0,0),(569,'',0,'USA','菲斯',NULL,0,0),(570,'',0,'USA','菲斯',NULL,0,0),(571,'',0,'USA','菲斯',NULL,0,0),(572,'',0,'USA','菲斯',NULL,0,0),(573,'',0,'USA','菲斯',NULL,0,0),(574,'',0,'USA','舍夫沙万',NULL,0,0),(575,'',0,'USA','舍夫沙万',NULL,0,0),(576,'',0,'USA','舍夫沙万',NULL,0,0),(577,'',0,'USA','丹吉尔',NULL,0,0),(578,'',0,'USA','丹吉尔',NULL,0,0),(579,'',0,'USA','艾西拉 ',NULL,0,0),(580,'',0,'USA','卡萨布兰卡',NULL,0,0),(581,'',0,'USA','卡萨布兰卡',NULL,0,0),(582,'',0,'USA','卡萨布兰卡',NULL,0,0),(583,'',0,'1','新地方',NULL,0,0),(584,'',0,'1','好地方',NULL,0,0);
/*!40000 ALTER TABLE `Cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ComboLocations`
--

DROP TABLE IF EXISTS `ComboLocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ComboLocations` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ltype` int(10) NOT NULL DEFAULT '0',
  `nation` varchar(45) DEFAULT NULL,
  `city` varchar(48) DEFAULT '',
  `area` varchar(48) DEFAULT '',
  `title` varchar(255) DEFAULT '',
  `local_title` varchar(255) DEFAULT '',
  `img` varchar(255) DEFAULT '',
  `address` varchar(1020) DEFAULT '',
  `local_address` varchar(1020) DEFAULT '',
  `latlng` varchar(255) DEFAULT '',
  `route` varchar(510) DEFAULT '',
  `contact` varchar(255) DEFAULT '',
  `open_at` datetime DEFAULT NULL,
  `close_at` datetime DEFAULT NULL,
  `open_close_more` varchar(512) DEFAULT '',
  `ticket` varchar(1024) DEFAULT '',
  `room` varchar(510) DEFAULT '',
  `dinner` varchar(510) DEFAULT '',
  `wifi` varchar(48) DEFAULT '',
  `parking` varchar(48) DEFAULT '',
  `reception` varchar(48) DEFAULT '',
  `kitchen` varchar(512) DEFAULT '',
  `dishes` varchar(1024) DEFAULT '',
  `recommended_dishes` varchar(1024) DEFAULT '',
  `tips` varchar(1020) DEFAULT '',
  `guidance` varchar(1020) DEFAULT '',
  PRIMARY KEY (`id`),
  KEY `ltype` (`ltype`)
) ENGINE=InnoDB AUTO_INCREMENT=869 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ComboLocations`
--

LOCK TABLES `ComboLocations` WRITE;
/*!40000 ALTER TABLE `ComboLocations` DISABLE KEYS */;
INSERT INTO `ComboLocations` VALUES (1,0,NULL,'','','这是一个空白页','','','','','','','',NULL,NULL,'','','','','','','','','','','','');
/*!40000 ALTER TABLE `ComboLocations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Customers`
--

DROP TABLE IF EXISTS `Customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL COMMENT '姓名',
  `gender` varchar(45) DEFAULT NULL COMMENT '性别',
  `birthday` datetime DEFAULT NULL COMMENT '生日',
  `enname` varchar(128) DEFAULT NULL COMMENT '英文姓名',
  `passport` varchar(45) DEFAULT NULL COMMENT '护照号码',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Customers`
--

LOCK TABLES `Customers` WRITE;
/*!40000 ALTER TABLE `Customers` DISABLE KEYS */;
/*!40000 ALTER TABLE `Customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DayLocations`
--

DROP TABLE IF EXISTS `DayLocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `DayLocations` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `RelatedId` int(10) NOT NULL DEFAULT '0',
  `RelatedType` varchar(45) DEFAULT NULL,
  `day` int(10) NOT NULL DEFAULT '0',
  `position` int(11) NOT NULL DEFAULT '0',
  `trip_id` int(11) NOT NULL DEFAULT '0',
  `location_id` int(11) NOT NULL DEFAULT '0',
  `day_id` int(11) NOT NULL DEFAULT '0',
  `start_at` datetime DEFAULT NULL,
  `end_at` datetime DEFAULT NULL,
  `cover_id` int(11) NOT NULL DEFAULT '0' COMMENT '封面图片',
  `schedule` varchar(2048) DEFAULT NULL COMMENT '行程计划\n无法仅仅使用每天行程作为每一项, 比如, 仅仅有景点浏览开始时间,没有离开酒店的出发时间.\n或者何时去机场,火车站等.这是一个自定义项  时间||活动//时间||活动',
  PRIMARY KEY (`id`),
  KEY `trip_id_idx` (`trip_id`),
  KEY `day_id_idx` (`day_id`),
  CONSTRAINT `fk_day_id` FOREIGN KEY (`day_id`) REFERENCES `TripDays` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=131 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `Dinings`
--

DROP TABLE IF EXISTS `Dinings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Dinings` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `nation` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `area` varchar(45) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `dishes` varchar(45) DEFAULT NULL,
  `img` varchar(45) DEFAULT NULL,
  `latlng` varchar(45) DEFAULT NULL,
  `reach` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `recommendedDishes` varchar(45) DEFAULT NULL,
  `tips` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Dinings`
--

LOCK TABLES `Dinings` WRITE;
/*!40000 ALTER TABLE `Dinings` DISABLE KEYS */;
/*!40000 ALTER TABLE `Dinings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Hotels`
--

DROP TABLE IF EXISTS `Hotels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Hotels` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `nation` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `localTitle` varchar(45) DEFAULT NULL,
  `img` varchar(45) DEFAULT NULL,
  `room` varchar(45) DEFAULT NULL,
  `dinner` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `latlng` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `wifi` varchar(45) DEFAULT NULL,
  `parking` varchar(45) DEFAULT NULL,
  `reception` varchar(45) DEFAULT NULL,
  `kitchen` varchar(45) DEFAULT NULL,
  `tips` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Hotels`
--

LOCK TABLES `Hotels` WRITE;
/*!40000 ALTER TABLE `Hotels` DISABLE KEYS */;
/*!40000 ALTER TABLE `Hotels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `LocationImages`
--

DROP TABLE IF EXISTS `LocationImages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `LocationImages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `location_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL COMMENT '文件名',
  `memo` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_location_idx` (`location_id`),
  CONSTRAINT `fk_location` FOREIGN KEY (`location_id`) REFERENCES `ComboLocations` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `LocationImages`
--

LOCK TABLES `LocationImages` WRITE;
/*!40000 ALTER TABLE `LocationImages` DISABLE KEYS */;
/*!40000 ALTER TABLE `LocationImages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Nations`
--

DROP TABLE IF EXISTS `Nations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Nations` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(12) DEFAULT '',
  `title` varchar(45) NOT NULL DEFAULT '',
  `localTitle` varchar(45) DEFAULT '',
  `enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=241 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Nations`
--

LOCK TABLES `Nations` WRITE;
/*!40000 ALTER TABLE `Nations` DISABLE KEYS */;
INSERT INTO `Nations` VALUES (1,'1','中国','',1),(2,'ALB','阿尔巴尼亚','',0),(3,'DZA','阿尔及利亚','',0),(4,'AFG','阿富汗','',0),(5,'ARG','阿根廷','',0),(6,'ARE','阿拉伯联合酋长国','',0),(7,'ABW','阿鲁巴','',0),(8,'OMN','阿曼','',0),(9,'AZE','阿塞拜疆','',0),(10,'ASC','阿森松岛','',0),(11,'EGY','埃及','',0),(12,'ETH','埃塞俄比亚','',0),(13,'IRL','爱尔兰','',0),(14,'EST','爱沙尼亚','',0),(15,'AND','安道尔','',0),(16,'AGO','安哥拉','',0),(17,'AIA','安圭拉','',0),(18,'ATG','安提瓜岛和巴布达','',0),(19,'AUT','奥地利','',0),(20,'ALA','奥兰群岛','',0),(21,'AUS','澳大利亚','',0),(22,'BRB','巴巴多斯岛','',0),(23,'PNG','巴布亚新几内亚','',0),(24,'BHS','巴哈马','',0),(25,'PAK','巴基斯坦','',0),(26,'PRY','巴拉圭','',0),(27,'PSE','巴勒斯坦','',0),(28,'BHR','巴林','',0),(29,'PAN','巴拿马','',0),(30,'BRA','巴西','',0),(31,'BLR','白俄罗斯','',0),(32,'BMU','百慕大','',0),(33,'BGR','保加利亚','',0),(34,'MNP','北马里亚纳群岛','',0),(35,'BEN','贝宁','',0),(36,'BEL','比利时','',0),(37,'ISL','冰岛','',0),(38,'PRI','波多黎各','',0),(39,'POL','波兰','',0),(40,'BIH','波斯尼亚和黑塞哥维那','',0),(41,'BOL','玻利维亚','',0),(42,'BLZ','伯利兹','',0),(43,'BWA','博茨瓦纳','',0),(44,'BTN','不丹','',0),(45,'BFA','布基纳法索','',0),(46,'BDI','布隆迪','',0),(47,'BVT','布韦岛','',0),(48,'PRK','朝鲜','',0),(49,'DNK','丹麦','',0),(50,'DEU','德国','',0),(51,'TLS','东帝汶','',0),(52,'TGO','多哥','',0),(53,'DMA','多米尼加','',0),(54,'DOM','多米尼加共和国','',0),(55,'RUS','俄罗斯','',0),(56,'ECU','厄瓜多尔','',0),(57,'ERI','厄立特里亚','',0),(58,'FRA','法国','',0),(59,'FRO','法罗群岛','',0),(60,'PYF','法属波利尼西亚','',0),(61,'GUF','法属圭亚那','',0),(62,'ATF','法属南部领地','',0),(63,'VAT','梵蒂冈','',0),(64,'PHL','菲律宾','',0),(65,'FJI','斐济','',0),(66,'FIN','芬兰','',0),(67,'CPV','佛得角','',0),(68,'FLK','弗兰克群岛','',0),(69,'GMB','冈比亚','',0),(70,'COG','刚果','',0),(71,'COD','刚果民主共和国','',0),(72,'COL','哥伦比亚','',0),(73,'CRI','哥斯达黎加','',0),(74,'GGY','格恩西岛','',0),(75,'GRD','格林纳达','',0),(76,'GRL','格陵兰','',0),(77,'CUB','古巴','',0),(78,'GLP','瓜德罗普','',0),(79,'GUM','关岛','',0),(80,'GUY','圭亚那','',0),(81,'KAZ','哈萨克斯坦','',0),(82,'HTI','海地','',0),(83,'KOR','韩国','',0),(84,'NLD','荷兰','',0),(85,'ANT','荷属安地列斯','',0),(86,'HMD','赫德和麦克唐纳群岛','',0),(87,'HND','洪都拉斯','',0),(88,'KIR','基里巴斯','',0),(89,'DJI','吉布提','',0),(90,'KGZ','吉尔吉斯斯坦','',0),(91,'GIN','几内亚','',0),(92,'GNB','几内亚比绍','',0),(93,'CAN','加拿大','',0),(94,'GHA','加纳','',0),(95,'GAB','加蓬','',0),(96,'KHM','柬埔寨','',0),(97,'CZE','捷克共和国','',0),(98,'ZWE','津巴布韦','',0),(99,'CMR','喀麦隆','',0),(100,'QAT','卡塔尔','',0),(101,'CYM','开曼群岛','',0),(102,'CCK','科科斯群岛','',0),(103,'COM','科摩罗','',0),(104,'CIV','科特迪瓦','',0),(105,'KWT','科威特','',0),(106,'HRV','克罗地亚','',0),(107,'KEN','肯尼亚','',0),(108,'COK','库克群岛','',0),(109,'LVA','拉脱维亚','',0),(110,'LSO','莱索托','',0),(111,'LAO','老挝','',0),(112,'LBN','黎巴嫩','',0),(113,'LTU','立陶宛','',0),(114,'LBR','利比里亚','',0),(115,'LBY','利比亚','',0),(116,'LIE','列支敦士登','',0),(117,'REU','留尼旺岛','',0),(118,'LUX','卢森堡','',0),(119,'RWA','卢旺达','',0),(120,'ROU','罗马尼亚','',0),(121,'MDG','马达加斯加','',0),(122,'MDV','马尔代夫','',0),(123,'MLT','马耳他','',0),(124,'MWI','马拉维','',0),(125,'MYS','马来西亚','',0),(126,'MLI','马里','',0),(127,'MKD','马其顿','',0),(128,'MHL','马绍尔群岛','',0),(129,'MTQ','马提尼克','',0),(130,'MYT','马约特岛','',0),(131,'IMN','曼岛','',0),(132,'MUS','毛里求斯','',0),(133,'MRT','毛里塔尼亚','',0),(134,'USA','美国','',1),(135,'ASM','美属萨摩亚','',0),(136,'UMI','美属外岛','',0),(137,'MNG','蒙古','',0),(138,'MSR','蒙特塞拉特','',0),(139,'BGD','孟加拉','',0),(140,'PER','秘鲁','',0),(141,'FSM','密克罗尼西亚','',0),(142,'MMR','缅甸','',0),(143,'MDA','摩尔多瓦','',0),(144,'MAR','摩洛哥','',0),(145,'MCO','摩纳哥','',0),(146,'MOZ','莫桑比克','',0),(147,'MEX','墨西哥','',0),(148,'NAM','纳米比亚','',0),(149,'ZAF','南非','',0),(150,'ATA','南极洲','',0),(151,'SGS','南乔治亚和南桑德威奇群岛','',0),(152,'NRU','瑙鲁','',0),(153,'NPL','尼泊尔','',0),(154,'NIC','尼加拉瓜','',0),(155,'NER','尼日尔','',0),(156,'NGA','尼日利亚','',0),(157,'NIU','纽埃','',0),(158,'NOR','挪威','',0),(159,'NFK','诺福克','',0),(160,'PLW','帕劳群岛','',0),(161,'PCN','皮特凯恩','',0),(162,'PRT','葡萄牙','',0),(163,'GEO','乔治亚','',0),(164,'JPN','日本','',0),(165,'SWE','瑞典','',0),(166,'CHE','瑞士','',0),(167,'SLV','萨尔瓦多','',0),(168,'WSM','萨摩亚','',0),(169,'SCG','塞尔维亚,黑山','',0),(170,'SLE','塞拉利昂','',0),(171,'SEN','塞内加尔','',0),(172,'CYP','塞浦路斯','',0),(173,'SYC','塞舌尔','',0),(174,'SAU','沙特阿拉伯','',0),(175,'CXR','圣诞岛','',0),(176,'STP','圣多美和普林西比','',0),(177,'SHN','圣赫勒拿','',0),(178,'KNA','圣基茨和尼维斯','',0),(179,'LCA','圣卢西亚','',0),(180,'SMR','圣马力诺','',0),(181,'SPM','圣皮埃尔和米克隆群岛','',0),(182,'VCT','圣文森特和格林纳丁斯','',0),(183,'LKA','斯里兰卡','',0),(184,'SVK','斯洛伐克','',0),(185,'SVN','斯洛文尼亚','',0),(186,'SJM','斯瓦尔巴和扬马廷','',0),(187,'SWZ','斯威士兰','',0),(188,'SDN','苏丹','',0),(189,'SUR','苏里南','',0),(190,'SLB','所罗门群岛','',0),(191,'SOM','索马里','',0),(192,'TJK','塔吉克斯坦','',0),(193,'THA','泰国','',0),(194,'TZA','坦桑尼亚','',0),(195,'TON','汤加','',0),(196,'TCA','特克斯和凯克特斯群岛','',0),(197,'TAA','特里斯坦达昆哈','',0),(198,'TTO','特立尼达和多巴哥','',0),(199,'TUN','突尼斯','',0),(200,'TUV','图瓦卢','',0),(201,'TUR','土耳其','',0),(202,'TKM','土库曼斯坦','',0),(203,'TKL','托克劳','',0),(204,'WLF','瓦利斯和福图纳','',0),(205,'VUT','瓦努阿图','',0),(206,'GTM','危地马拉','',0),(207,'VIR','维尔京群岛，美属','',0),(208,'VGB','维尔京群岛，英属','',0),(209,'VEN','委内瑞拉','',0),(210,'BRN','文莱','',0),(211,'UGA','乌干达','',0),(212,'UKR','乌克兰','',0),(213,'URY','乌拉圭','',0),(214,'UZB','乌兹别克斯坦','',0),(215,'ESP','西班牙','',0),(216,'GRC','希腊','',0),(217,'SGP','新加坡','',0),(218,'NCL','新喀里多尼亚','',0),(219,'NZL','新西兰','',1),(220,'HUN','匈牙利','',0),(221,'SYR','叙利亚','',0),(222,'JAM','牙买加','',0),(223,'ARM','亚美尼亚','',0),(224,'YEM','也门','',0),(225,'IRQ','伊拉克','',0),(226,'IRN','伊朗','',0),(227,'ISR','以色列','',0),(228,'ITA','意大利','',0),(229,'IND','印度','',0),(230,'IDN','印度尼西亚','',0),(231,'GBR','英国','',0),(232,'IOT','英属印度洋领地','',0),(233,'JOR','约旦','',0),(234,'VNM','越南','',0),(235,'ZMB','赞比亚','',0),(236,'JEY','泽西岛','',0),(237,'TCD','乍得','',0),(238,'GIB','直布罗陀','',0),(239,'CHL','智利','',0),(240,'CAF','中非共和国','',0);
/*!40000 ALTER TABLE `Nations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Scenics`
--

DROP TABLE IF EXISTS `Scenics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Scenics` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `nation` varchar(45) DEFAULT '',
  `city` varchar(45) DEFAULT NULL,
  `title` varchar(1024) DEFAULT NULL,
  `localTitle` varchar(45) DEFAULT NULL,
  `img` varchar(45) DEFAULT NULL,
  `latlng` varchar(45) DEFAULT NULL,
  `localAdd` varchar(45) DEFAULT NULL,
  `openAt` datetime DEFAULT NULL,
  `closeAt` datetime DEFAULT NULL,
  `ticket` varchar(45) DEFAULT NULL,
  `tips` varchar(1024) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `TripDays`
--

DROP TABLE IF EXISTS `TripDays`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TripDays` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `trip_id` int(10) NOT NULL DEFAULT '0',
  `title` varchar(256) DEFAULT NULL,
  `day` int(11) NOT NULL DEFAULT '0',
  `memo` varchar(512) DEFAULT NULL,
  `tips` varchar(1024) DEFAULT NULL COMMENT '小贴士',
  `schedule` varchar(2048) DEFAULT NULL COMMENT '行程计划\n无法仅仅使用每天行程作为每一项, 比如, 仅仅有景点浏览开始时间,没有离开酒店的出发时间.\n或者何时去机场,火车站等.这是一个自定义项  时间||活动//时间||活动',
  `cover_id` int(11) NOT NULL DEFAULT '0' COMMENT '封面图片',
  PRIMARY KEY (`id`),
  KEY `tripdays_idx` (`trip_id`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `Trips`
--

DROP TABLE IF EXISTS `Trips`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Trips` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(1024) NOT NULL DEFAULT '',
  `memo` varchar(1024) DEFAULT NULL,
  `days` int(11) NOT NULL DEFAULT '0',
  `word_created_at` datetime DEFAULT NULL COMMENT 'Word文件生成时间',
  `customer_id` int(11) NOT NULL DEFAULT '0' COMMENT '客户ID',
  `start_at` datetime DEFAULT NULL COMMENT '行程开始时间',
  `end_at` datetime DEFAULT NULL COMMENT '行程结束时间',
  `cover_id` int(11) NOT NULL DEFAULT '0' COMMENT '封面图片',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_customer_idx` (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-30 22:51:16
