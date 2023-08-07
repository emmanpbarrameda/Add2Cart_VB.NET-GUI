CREATE DATABASE  IF NOT EXISTS `ciello_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ciello_db`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: ciello_db
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_products`
--

DROP TABLE IF EXISTS `tbl_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_products` (
  `id` int NOT NULL,
  `PRODUCTNAME` varchar(45) DEFAULT NULL,
  `PRICERANGE` varchar(45) DEFAULT NULL,
  `QUANTITY` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_products`
--

LOCK TABLES `tbl_products` WRITE;
/*!40000 ALTER TABLE `tbl_products` DISABLE KEYS */;
INSERT INTO `tbl_products` VALUES (1,'Product1','350',10),(2,'Product2','500',15),(3,'Product3','100',5),(4,'Product4','50',20);
/*!40000 ALTER TABLE `tbl_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_transactions`
--

DROP TABLE IF EXISTS `tbl_transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_transactions` (
  `id` int NOT NULL,
  `CUSTOMERNAME` varchar(45) DEFAULT NULL,
  `PAYMENTTYPE` varchar(45) DEFAULT NULL,
  `OVERALLTOTAL` varchar(45) DEFAULT NULL,
  `TENDERED` varchar(45) DEFAULT NULL,
  `CHANGEMONEY` varchar(45) DEFAULT NULL,
  `DATE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_transactions`
--

LOCK TABLES `tbl_transactions` WRITE;
/*!40000 ALTER TABLE `tbl_transactions` DISABLE KEYS */;
INSERT INTO `tbl_transactions` VALUES (10291,'Emms',NULL,'1050','2000','950','2023-05-10 00:00:00'),(10642,'Emman','CASH','850','1000','150','2023-05-02, 11:51 am'),(12570,'Emman','COD','850','1000','150','2023-05-02, 10:29 pm'),(14656,'gdh','CASH','850','1000','150','2023-05-02, 09:23 pm'),(16169,'sfg','COD','850','900','50','2023-05-02, 11:12 am'),(16219,'vc','COD','350','400','50','2023-05-02, 10:29 pm'),(17533,'Emman','CASH','850','1000','150','2023-05-02, 09:47 pm'),(18319,'sir','COD','1850','2000','150','2023-05-03, 12:50 pm'),(19495,'dbf','CASH','1000','1000','0','2023-05-02, 09:24 pm'),(19942,'dtsh','CASH','2500','5000','2500','2023-05-05, 11:22 am'),(24864,'gg','CASH','850','1000','150','2023-05-02, 10:35 pm'),(25260,'fdb','COD','350','350','0','2023-05-02, 06:45 pm'),(25388,'gfs','CASH','500','500','0','2023-05-02, 10:24 pm'),(25936,'hf','CASH','850','1000','150','2023-05-02, 04:34 pm'),(28298,'fb','COD','1000','1000','0','2023-05-03, 12:47 am'),(32308,'sf','COD','1200','500','0','2023-05-02, 10:54 am'),(32419,'fg','COD','350','500','150','2023-05-02, 08:51 pm'),(32438,'v','CASH','850','851','1','2023-05-02, 10:57 am'),(32889,'fd','CASH','500','500','0','2023-05-05, 05:22 pm'),(33144,'df','CASH','500','500','0','2023-05-03, 12:12 am'),(33213,'sdg','COD','350','500','150','2023-05-02, 11:07 am'),(33865,'Guard','COD','2500','3000','500','2023-05-02, 11:07 am'),(35308,'dfbhg','CASH','1350','1400','50','2023-05-02, 11:48 am'),(35593,'vbv','CASH','1000','1500','500','2023-05-03, 12:47 am'),(36634,'Emman',NULL,'700','800','100','2023-05-10 00:00:00'),(39953,'dsf','CASH','1000','10000','9000','2023-05-02, 11:42 pm'),(41463,'g','CASH','1700','2000','300','2023-05-02, 10:55 pm'),(41510,'dg','CASH','500','500','0','2023-05-02, 10:20 pm'),(42595,'Emman',NULL,'700','800','100','2023-05-10 00:00:00'),(42903,'bfd','CASH','500','500','0','2023-05-03, 12:09 am'),(43422,'sfg','COD','500','500','0','2023-05-02'),(44705,'dbf','CASH','500','600','100','2023-05-02, 09:27 pm'),(44824,'sfdfsdfhf','CASH','350','500','150','2023-05-02, 09:04 pm'),(45004,'gh','CASH','350','500','150','2023-05-02, 11:42 pm'),(45233,'Emman',NULL,'500','500','0','2023-05-10 00:00:00'),(45778,'sd','COD','350','500','150','2023-05-03, 12:32 am'),(48600,'bg','CASH','850','1000','150','2023-05-02, 12:31 pm'),(48688,'ffgg','CASH','1000','1000','0','2023-05-02, 11:54 am'),(49740,'ghm','CASH','850','1000','150','2023-05-02, 12:39 pm'),(50463,'df','CASH','500','500','0','2023-05-02, 10:52 pm'),(52964,'sfgfd','CASH','1700','2000','300','2023-05-02, 11:54 am'),(53238,'fg','CASH','500','600','100','YYYY-05-DD'),(53245,'sd','CASH','500','500','0','2023-05-03, 08:37 am'),(54385,'Emman',NULL,'550','600','50','2023-05-10 00:00:00'),(56072,'fd','COD','700','800','100','2023-05-03, 12:18 am'),(56823,'yhy','COD','350','400','50','2023-05-03, 12:50 pm'),(57275,'gb','COD','350','500','150','2023-05-03, 12:31 am'),(58388,'gfsg','COD','350','400','50','2023-05-03, 12:43 am'),(58785,'vxvc','COD','850','1000','150','2023-05-02, 12:36 pm'),(59174,'bg','CASH','350','400','50','2023-05-02, 10:49 pm'),(59700,'Emmn','COD','350','500','150','2023-05-02, 11:48 am'),(60623,'hfjghjk','CASH','500','600','100','2023-05-02, 09:26 pm'),(60864,'sdgs','COD','500','600','100','2023-05-02'),(61381,'dfb','CASH','350','500','150','2023-05-02, 10:25 pm'),(62223,'gds','COD','700','701','1','2023-05-02'),(62631,'bvc','CASH','500','500','0','2023-05-02, 10:56 am'),(67381,'svdg','COD','850','1000','150','2023-05-02, 12:28 pm'),(67634,' c','CASH','500','500','0','2023-05-02, 09:34 pm'),(68090,'Levi','COD','500','501','1','2023-05-02, 10:09 am'),(68393,'sgf','CASH','350','500','150','2023-05-03, 12:36 am'),(69881,'vadgs','CASH','2050','5000','2950','2023-05-02, 11:54 am'),(70071,'df','CASH','500','600','100','2023-05-02, 08:56 pm'),(71605,'sf','COD','850','1000','150','2023-05-02, 06:53 pm'),(72852,'Ion','COD','1700','5000','3300','2023-05-02, 10:29 am'),(72920,'vv','CASH','500','5000','4500','2023-05-02, 10:22 pm'),(73905,'ds','CASH','500','600','100','2023-05-03, 01:28 am'),(75056,'df','CASH','350','400','50','2023-05-02, 11:53 pm'),(75230,'b','CASH','700','800','100','2023-05-02, 10:37 pm'),(76053,'avd','CASH','850','1000','150','2023-05-02, 12:29 pm'),(76081,'fagsfdh',NULL,'1800','2000','200','2023-05-10 00:00:00'),(77497,'fgh','CASH','500','600','100','2023-05-02, 09:33 pm'),(80051,'yves','CASH','500','1000','500','2023-05-03, 12:02 pm'),(80601,'sgfg','CASH','500','600','100','2023-05-02, 10:19 pm'),(82065,'fd','CASH','500','500','0','2023-05-02, 10:24 pm'),(83022,'bggf','COD','350','350','0','2023-05-02, 09:29 pm'),(83172,'f','CASH','700','700','0','2023-05-03, 12:22 am'),(84895,'Ion','COD','2050','2100','50','2023-05-02, 09:36 pm'),(86223,'hg','CASH','500','500','0','2023-05-02, 11:30 pm'),(90987,'jyghj','CASH','850','851','1','2023-05-02, 10:26 am'),(91548,'cx','CASH','350','500','150','2023-05-02, 10:59 am'),(91635,'hm','CASH','500','600','100','2023-05-02, 11:04 pm'),(91907,'f','COD','350','500','150','2023-05-02, 11:47 pm'),(92125,'fd','CASH','700','800','100','2023-05-02, 10:41 pm'),(93031,'rg','CASH','1000','1000','0','2023-05-03, 12:56 am'),(93803,'gdh','COD','700','800','100','2023-05-02, 10:45 pm'),(94586,'Emman','COD','350','500','150','2023-05-02, 02:31 pm'),(95913,'th','CASH','500','5000','4500','2023-05-03, 12:06 am'),(96256,'fs','CASH','500','1000','500','2023-05-03, 01:00 am'),(96802,'fg','CASH','350','500','150','2023-05-02, 09:19 pm'),(98234,'fff','CASH','1350','1500','150','2023-05-02, 11:51 am'),(98495,'Ion','CASH','1200','1500','300','2023-05-02, 10:09 am');
/*!40000 ALTER TABLE `tbl_transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-10 14:59:28
