CREATE DATABASE  IF NOT EXISTS `scifusion` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `scifusion`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: scifusion
-- ------------------------------------------------------
-- Server version	5.6.19

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
-- Table structure for table `area`
--

DROP TABLE IF EXISTS `area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `area` (
  `AreaID` int(11) NOT NULL AUTO_INCREMENT,
  `FieldName` varchar(20) NOT NULL,
  `Description` varchar(20) NOT NULL,
  `Speciality` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`AreaID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `area`
--

LOCK TABLES `area` WRITE;
/*!40000 ALTER TABLE `area` DISABLE KEYS */;
INSERT INTO `area` VALUES (1,'Physics','Particle Physics','Quantum Mechanics'),(2,'Mathematics','Langrange\'s Theorem','Calculus'),(3,'Chemistry','Mass Spectrometry','Molecular Chemistry'),(4,'Physics','Plancs Constant','Quantum Mechanics'),(5,'Biology','Human Anatomy','Human System'),(6,'Physics','Atomic Model','Bohr\'s Model'),(7,'Mathematics','Game Theory','Probability'),(8,'Chemistry','Hybridization','Nuclear Chemistry'),(9,'Mathematics','Area of the curve','Integral Calculus'),(10,'Biology','Nerve Receptors','Neurobiology');
/*!40000 ALTER TABLE `area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipment` (
  `EquipmentID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) NOT NULL,
  `YearsInUse` varchar(20) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `University_UniversityID` int(11) NOT NULL,
  PRIMARY KEY (`EquipmentID`),
  KEY `Equip_UniversityId_FK` (`University_UniversityID`),
  CONSTRAINT `Equip_UniversityId_FK` FOREIGN KEY (`University_UniversityID`) REFERENCES `university` (`UniversityID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (1,'Cyclotron','5','Particle Accelerator',5),(2,'Hadron Collider','2','Particle Accelerator',14),(3,'Double Split','2','Interferometer',6),(4,'Laser','2','Laser',7),(5,'maser','5','Optics',2),(6,'MATLAB','4','Software',10),(7,'Hubble 101','4','Telescope',6),(8,'Accel51','1','Accelerometer',1),(9,'Inclinometer','3','Inclinometer',3),(10,'Michelsons Interferometer','2','Interferometer',9),(11,'Michelsons Interferometer','4','Interferometer',7),(12,'Cyclotron','1','Particle Accelerator',2),(13,'Mass Spectrometer','7','Spectrometer',1);
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `UserName` varchar(10) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Researcher_ResearcherID` int(11) NOT NULL,
  PRIMARY KEY (`UserName`),
  KEY `Login_ResearcherID_idx` (`Researcher_ResearcherID`),
  CONSTRAINT `Login_ResearcherID` FOREIGN KEY (`Researcher_ResearcherID`) REFERENCES `researcher` (`ResearcherID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES ('aeinstein','1234',1),('anobel','1234',7),('cgauss','1234',8),('efermi','1234',5),('eruther','1234',6),('mplanc','1234',2),('pdirac','1234',4),('wpauli','1234',3);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researchareaassociation`
--

DROP TABLE IF EXISTS `researchareaassociation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researchareaassociation` (
  `Area_AreaID` int(11) NOT NULL,
  `Researcher_ResearcherID` int(11) NOT NULL,
  PRIMARY KEY (`Area_AreaID`,`Researcher_ResearcherID`),
  KEY `RAA_Researcher_FK` (`Researcher_ResearcherID`),
  CONSTRAINT `RAA_Area_FK` FOREIGN KEY (`Area_AreaID`) REFERENCES `area` (`AreaID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `RAA_Researcher_FK` FOREIGN KEY (`Researcher_ResearcherID`) REFERENCES `area` (`AreaID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researchareaassociation`
--

LOCK TABLES `researchareaassociation` WRITE;
/*!40000 ALTER TABLE `researchareaassociation` DISABLE KEYS */;
INSERT INTO `researchareaassociation` VALUES (1,1),(3,1),(5,1),(3,2),(4,3),(6,3),(7,4),(8,5),(9,5),(1,6),(2,6),(9,6),(1,7),(9,7),(10,7),(2,8),(3,8),(5,8),(5,9);
/*!40000 ALTER TABLE `researchareaassociation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researcher`
--

DROP TABLE IF EXISTS `researcher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researcher` (
  `ResearcherID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(20) NOT NULL,
  `LastName` varchar(20) NOT NULL,
  `Email` varchar(20) NOT NULL,
  `ContactNumber` varchar(20) NOT NULL,
  `Type` varchar(20) NOT NULL,
  `State` varchar(20) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `Major` varchar(20) DEFAULT NULL,
  `LatestDegree` varchar(20) DEFAULT NULL,
  `TotalRators` int(11) DEFAULT NULL,
  `TotalRatings` int(11) DEFAULT NULL,
  `University_UniversityID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ResearcherID`),
  KEY `Research_UniversityId_FK` (`University_UniversityID`),
  CONSTRAINT `Research_UniversityId_FK` FOREIGN KEY (`University_UniversityID`) REFERENCES `university` (`UniversityID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researcher`
--

LOCK TABLES `researcher` WRITE;
/*!40000 ALTER TABLE `researcher` DISABLE KEYS */;
INSERT INTO `researcher` VALUES (1,'Albert','Einstien','ae@ph.co','8878','P','Tx','Houston','Physics','phd',3,34,1),(2,'Max','Planc','mp@ph.co','33456','S','VA','McLean','Physics','Ms',2,12,2),(3,'Wolfgang','Pauli','wp@ph.co','220091','P','CA','LA','Physics','Mtech',4,22,1),(4,'Paul','Dirac','pd@ph.co','200912','P','CA','San Diago','Quantum Th.','phd',5,20,3),(5,'Enrico','Fermi','ef@ph.co','211990202','S','NY','NY','Nuclear Ph.','Phd',3,11,8),(6,'Ernest','Rutherford','er@chem.co','112003998','P','VA','Fairfax','CHemistry','MS',8,33,10),(7,'Alfred','Nobel','an@chem.co','979889220','P','AZ','Phoenix','Chemistry','Phd',9,11,9),(8,'Carl','Gauss','cg@math.co','828333998','P','CO','Denver','Mathematics','Phd',8,30,2),(9,'default','Target','gm@abc.com','','','','college station','','',0,0,3);
/*!40000 ALTER TABLE `researcher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researchwork`
--

DROP TABLE IF EXISTS `researchwork`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researchwork` (
  `WorkID` int(11) NOT NULL AUTO_INCREMENT,
  `Links` varchar(25) DEFAULT NULL,
  `University_UniversityID` int(11) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`WorkID`),
  KEY `Work_UniversityId_FK` (`University_UniversityID`),
  CONSTRAINT `Work_UniversityId_FK` FOREIGN KEY (`University_UniversityID`) REFERENCES `university` (`UniversityID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researchwork`
--

LOCK TABLES `researchwork` WRITE;
/*!40000 ALTER TABLE `researchwork` DISABLE KEYS */;
INSERT INTO `researchwork` VALUES (1,'www.google.com',3,'abcd'),(2,'www.facebook.com',7,'efgh'),(3,'www.orkut.com',4,'ijkl'),(4,'www.bookmyshow.com',9,'mnop'),(5,'www.cricinfo.com',3,'yuuo'),(6,'www.tamu.edu',6,'poiu'),(7,'www.msd.com',2,'efgh'),(8,'www.nike.com',7,'olkm'),(9,'www.reebok.com',3,'yyhb'),(10,'www.puma.com',8,'qwer'),(11,'www.adidas.com',5,'xsdc'),(12,'www.physics.com',3,'bhui'),(13,NULL,1,NULL),(14,NULL,7,NULL),(15,NULL,10,NULL),(16,NULL,9,NULL),(17,NULL,4,NULL);
/*!40000 ALTER TABLE `researchwork` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researchworkassociation`
--

DROP TABLE IF EXISTS `researchworkassociation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `researchworkassociation` (
  `ResearchWork_WorkID` int(11) NOT NULL,
  `Researcher_ResearcherID` int(11) NOT NULL,
  PRIMARY KEY (`ResearchWork_WorkID`,`Researcher_ResearcherID`),
  KEY `RWA_Researcher_FK_idx` (`Researcher_ResearcherID`),
  CONSTRAINT `RWA_Researcher_FK` FOREIGN KEY (`Researcher_ResearcherID`) REFERENCES `researcher` (`ResearcherID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `RWA_Work_FK` FOREIGN KEY (`ResearchWork_WorkID`) REFERENCES `researchwork` (`WorkID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researchworkassociation`
--

LOCK TABLES `researchworkassociation` WRITE;
/*!40000 ALTER TABLE `researchworkassociation` DISABLE KEYS */;
INSERT INTO `researchworkassociation` VALUES (1,2),(5,2),(12,2),(7,3),(2,4),(7,4),(2,5),(6,5),(7,7),(9,7),(9,8),(7,9);
/*!40000 ALTER TABLE `researchworkassociation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `university`
--

DROP TABLE IF EXISTS `university`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `university` (
  `UniversityID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) NOT NULL,
  `City` varchar(20) NOT NULL,
  `State` varchar(20) NOT NULL,
  `Country` varchar(20) NOT NULL,
  `Web` varchar(20) NOT NULL,
  PRIMARY KEY (`UniversityID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `university`
--

LOCK TABLES `university` WRITE;
/*!40000 ALTER TABLE `university` DISABLE KEYS */;
INSERT INTO `university` VALUES (1,'MIT','Boston','NY','USA','www.mit.edu'),(2,'TAMU','CS','TX','USA','www.tamu.edu'),(3,'Harvard','Boston','Massachusetts','USA','www.harvard.edu'),(4,'TU Delft','Delft','CN','Netherlands','www.tudelft.nl'),(5,'Univ. of S. California','Los Angeles','California','USA','www.usc.edu'),(6,'Univ. of Texas','Austin','Texas','USA','www.ut.edu'),(7,'NCSU','Raleigh','North Carolina','USA','www.ncsu.edu'),(8,'UPenn','Pheladelphia','Pennsylvania','USA','www.upenn.edu'),(9,'Columbia Univ.','New York','New York','USA','www.columbia.edu'),(10,'Univ. Of California','Berkeley','California','USA','www.ucb.edu'),(11,'IIT','Bombay','Maharashtra','India','www.iitb.ac.in'),(12,'IITD','Delhi','Delhi','India','www.iitd.ac.in'),(13,'SVNIT','Surat','Gujarat','India','www.svnit.ac.in'),(14,'VNIT','Nagpur','Maharashtra','India','www.vnit.ac.in');
/*!40000 ALTER TABLE `university` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workareaassociation`
--

DROP TABLE IF EXISTS `workareaassociation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workareaassociation` (
  `Area_AreaID` int(11) NOT NULL,
  `ResearchWork_WorkID` int(11) NOT NULL,
  PRIMARY KEY (`Area_AreaID`,`ResearchWork_WorkID`),
  KEY `WAA_Work_FK` (`ResearchWork_WorkID`),
  CONSTRAINT `WAA_Area_FK` FOREIGN KEY (`Area_AreaID`) REFERENCES `area` (`AreaID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `WAA_Work_FK` FOREIGN KEY (`ResearchWork_WorkID`) REFERENCES `researchwork` (`WorkID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workareaassociation`
--

LOCK TABLES `workareaassociation` WRITE;
/*!40000 ALTER TABLE `workareaassociation` DISABLE KEYS */;
INSERT INTO `workareaassociation` VALUES (1,1),(2,1),(2,2),(3,2),(4,3),(8,3),(5,4),(8,4),(7,5),(2,6),(7,7),(3,8),(9,8),(5,9),(9,10),(2,11),(6,12),(7,13),(4,14),(9,15),(8,16),(3,17);
/*!40000 ALTER TABLE `workareaassociation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workequipmentassociation`
--

DROP TABLE IF EXISTS `workequipmentassociation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workequipmentassociation` (
  `ResearchWork_WorkID` int(11) NOT NULL,
  `Equipment_EquipmentID` int(11) NOT NULL,
  PRIMARY KEY (`ResearchWork_WorkID`,`Equipment_EquipmentID`),
  KEY `WEA_Equip_FK` (`Equipment_EquipmentID`),
  CONSTRAINT `WEA_Equip_FK` FOREIGN KEY (`Equipment_EquipmentID`) REFERENCES `equipment` (`EquipmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `WEA_Work_FK` FOREIGN KEY (`ResearchWork_WorkID`) REFERENCES `researchwork` (`WorkID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workequipmentassociation`
--

LOCK TABLES `workequipmentassociation` WRITE;
/*!40000 ALTER TABLE `workequipmentassociation` DISABLE KEYS */;
INSERT INTO `workequipmentassociation` VALUES (6,2),(6,5),(2,7),(1,8),(2,9);
/*!40000 ALTER TABLE `workequipmentassociation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-12-01 17:27:20
