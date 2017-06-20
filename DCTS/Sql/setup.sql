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
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `code` varchar(24) DEFAULT '',
  `nationId` int(10) unsigned NOT NULL DEFAULT '0',
  `nationCode` varchar(12) NOT NULL DEFAULT '',
  `title` varchar(45) DEFAULT NULL,
  `localTitle` varchar(45) DEFAULT NULL,
  `position` int(11) NOT NULL DEFAULT '0',
  `enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=637 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



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
  `word` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ltype` (`ltype`)
) ENGINE=InnoDB AUTO_INCREMENT=1261 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


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
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



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
  `flight_no` varchar(45) DEFAULT NULL,
  `flight_from` varchar(45) DEFAULT NULL COMMENT '飞机出发地点/提车地点',
  `flight_to` varchar(45) DEFAULT NULL COMMENT '飞机到达地/还车地点',
  `flight_layover` tinyint(1) NOT NULL DEFAULT '0',
  `flight_start_at` datetime DEFAULT NULL COMMENT '飞机出发时间/提车时间',
  `flight_end_at` datetime DEFAULT NULL COMMENT '航班到达时间/还车时间',
  `flight2_start_at` datetime DEFAULT NULL,
  `flight2_end_at` datetime DEFAULT NULL,
  `flight2_from` varchar(45) DEFAULT NULL,
  `flight2_to` varchar(45) DEFAULT NULL,
  `flight2_no` varchar(45) DEFAULT NULL,
  `airport_from` varchar(45) DEFAULT NULL COMMENT '飞机出发机场/提车详细地址',
  `airport_to` varchar(45) DEFAULT NULL COMMENT '航班到达机场/还车详细地址',
  `airport2_from` varchar(45) DEFAULT NULL,
  `airport2_to` varchar(45) DEFAULT NULL,
  `flight_ticket` varchar(45) DEFAULT NULL COMMENT '租车凭证号',
  `flight_company` int(11) NOT NULL DEFAULT '0',
  `tips` varchar(1024) DEFAULT NULL,
  `memo` varchar(1024) DEFAULT NULL,
  `route` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `trip_id_idx` (`trip_id`),
  KEY `day_id_idx` (`day_id`),
  CONSTRAINT `fk_day_id` FOREIGN KEY (`day_id`) REFERENCES `TripDays` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=146 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `LocationImages`
--

DROP TABLE IF EXISTS `LocationImages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `LocationImages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `location_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL COMMENT '文件名',
  `memo` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_location_idx` (`location_id`),
  CONSTRAINT `fk_location` FOREIGN KEY (`location_id`) REFERENCES `ComboLocations` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `Nations`
--

DROP TABLE IF EXISTS `Nations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Nations` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `code` varchar(12) DEFAULT '',
  `title` varchar(45) NOT NULL DEFAULT '',
  `localTitle` varchar(45) DEFAULT '',
  `enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=241 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `Schedules`
--

DROP TABLE IF EXISTS `Schedules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Schedules` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tripday_id` int(11) NOT NULL DEFAULT '0',
  `start_at` datetime DEFAULT NULL,
  `end_at` datetime DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `desc` varchar(1024) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tripday_idx` (`tripday_id`),
  CONSTRAINT `fk_tripday` FOREIGN KEY (`tripday_id`) REFERENCES `TripDays` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `Suppliers`
--

DROP TABLE IF EXISTS `Suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Suppliers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stype` int(11) NOT NULL DEFAULT '0',
  `name` varchar(45) DEFAULT NULL,
  `img` varchar(45) DEFAULT NULL,
  `csh` varchar(45) DEFAULT NULL,
  `memo` varchar(1024) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `baggage_weight_limit` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `Tickets`
--

DROP TABLE IF EXISTS `Tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tickets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `daylocation_id` int(11) NOT NULL DEFAULT '0',
  `customer_id` int(11) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `trip_id` int(11) NOT NULL,
  `ttype` int(11) NOT NULL DEFAULT '0' COMMENT '为了快速找到某一类型的票',
  `title` varchar(45) DEFAULT NULL,
  `num` varchar(45) DEFAULT NULL,
  `route` varchar(1024) DEFAULT NULL,
  `memo` varchar(1024) DEFAULT NULL,
  `requirement` varchar(1024) DEFAULT NULL,
  `service_no` varchar(45) DEFAULT NULL,
  `overlay` tinyint(1) DEFAULT NULL,
  `overlay_sign` int(11) NOT NULL DEFAULT '0',
  `start_at` datetime DEFAULT NULL,
  `end_at` datetime DEFAULT NULL,
  `from_place` varchar(45) DEFAULT NULL,
  `to_place` varchar(45) DEFAULT NULL,
  `from_location_id` int(11) NOT NULL DEFAULT '0',
  `to_location_id` int(11) NOT NULL DEFAULT '0',
  `rules` varchar(1024) DEFAULT NULL,
  `days` int(11) NOT NULL DEFAULT '0',
  `city` varchar(45) DEFAULT NULL,
  `breakfirst` varchar(45) DEFAULT NULL,
  `parking` varchar(45) DEFAULT NULL,
  `baggage_weight_limit` varchar(45) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_customer_idx` (`customer_id`),
  KEY `fk_supplier_idx` (`supplier_id`),
  KEY `fk_ticket_trip_idx` (`trip_id`),
  CONSTRAINT `fk_customer` FOREIGN KEY (`customer_id`) REFERENCES `Customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `Suppliers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ticket_trip` FOREIGN KEY (`trip_id`) REFERENCES `Trips` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `TripCustomers`
--

DROP TABLE IF EXISTS `TripCustomers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TripCustomers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `trip_id` int(11) NOT NULL DEFAULT '0',
  `customer_id` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_customer_idx` (`customer_id`),
  KEY `fk_trip_idx` (`trip_id`),
  CONSTRAINT `fk_tripcustomer_customer` FOREIGN KEY (`customer_id`) REFERENCES `Customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tripcustomer_trip` FOREIGN KEY (`trip_id`) REFERENCES `Trips` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
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
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8;
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
  `countries` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_customer_idx` (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-20 17:30:59
