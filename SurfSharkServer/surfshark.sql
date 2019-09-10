-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 10, 2019 at 08:53 AM
-- Server version: 5.5.39
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `surfshark`
--

-- --------------------------------------------------------

--
-- Table structure for table `useraccounts`
--

CREATE TABLE IF NOT EXISTS `useraccounts` (
`UserId` int(22) NOT NULL,
  `userName` varchar(64) DEFAULT NULL,
  `passWord` varchar(64) NOT NULL DEFAULT '',
  `ip` varchar(64) DEFAULT NULL,
  `lastKnownIp` varchar(32) DEFAULT NULL,
  `MemberType` int(1) NOT NULL DEFAULT '0',
  `hwid` varchar(60) DEFAULT NULL,
  `credits` int(22) NOT NULL DEFAULT '0',
  `createTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `loginTime` timestamp NULL DEFAULT NULL,
  `logoutTime` timestamp NULL DEFAULT NULL,
  `loginSessionId` varchar(60) DEFAULT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `useraccounts`
--

INSERT INTO `useraccounts` (`UserId`, `userName`, `passWord`, `ip`, `lastKnownIp`, `MemberType`, `hwid`, `credits`, `createTime`, `loginTime`, `logoutTime`, `loginSessionId`) VALUES
(1, 'root', 'XINkzrXqA41u32BnughuZWHnLQ+xYUpn', '127.0.0.1', '127.0.0.1', 0, NULL, 0, '2019-09-09 03:38:29', '2019-09-10 03:51:42', '0000-00-00 00:00:00', NULL),
(2, 'root', 'XINkzrXqA41u32BnughuZWHnLQ+xYUpn', '127.0.0.1', '127.0.0.1', 0, NULL, 0, '2019-09-09 03:38:29', '2019-09-10 02:50:49', '0000-00-00 00:00:00', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `userurls`
--

CREATE TABLE IF NOT EXISTS `userurls` (
`id` bigint(22) NOT NULL,
  `UID` int(22) NOT NULL,
  `WebsiteName` varchar(66) NOT NULL,
  `region` int(3) NOT NULL DEFAULT '0',
  `url` varchar(255) NOT NULL,
  `Referral` int(1) NOT NULL DEFAULT '0',
  `Time` int(5) NOT NULL DEFAULT '60',
  `ViewCount` int(22) NOT NULL,
  `IsActive` int(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `userurls`
--

INSERT INTO `userurls` (`id`, `UID`, `WebsiteName`, `region`, `url`, `Referral`, `Time`, `ViewCount`, `IsActive`) VALUES
(1, 1, 'Test', 0, 'https://www.google.com/', 0, 60, 0, 0),
(2, 1, 'test2', 0, 'https://gamejolt.com/games/Hex-Wars/421142', 0, 60, 323, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `useraccounts`
--
ALTER TABLE `useraccounts`
 ADD UNIQUE KEY `UserId` (`UserId`);

--
-- Indexes for table `userurls`
--
ALTER TABLE `userurls`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `useraccounts`
--
ALTER TABLE `useraccounts`
MODIFY `UserId` int(22) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `userurls`
--
ALTER TABLE `userurls`
MODIFY `id` bigint(22) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
