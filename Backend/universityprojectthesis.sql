-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 06, 2023 at 12:25 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `universityprojectthesis`
--

-- --------------------------------------------------------

--
-- Table structure for table `studentsgrades`
--

CREATE TABLE `studentsgrades` (
  `Name` varchar(60) NOT NULL,
  `Surname` varchar(60) NOT NULL,
  `Subject` varchar(80) NOT NULL,
  `Grade` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentsgrades`
--

INSERT INTO `studentsgrades` (`Name`, `Surname`, `Subject`, `Grade`) VALUES
('nome', 'cognome', 'Matematica', '10');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Username` varchar(60) NOT NULL,
  `Password` varchar(25) NOT NULL,
  `IsEducator` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Username`, `Password`, `IsEducator`) VALUES
('professore@email', 'InsertPassword', 1),
('studente2@email', 'InsertPassword', 0),
('studente@email', 'InsertPassword', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `studentsgrades`
--
ALTER TABLE `studentsgrades`
  ADD PRIMARY KEY (`Surname`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
