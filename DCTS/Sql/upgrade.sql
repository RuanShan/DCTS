DELIMITER $$
CREATE PROCEDURE AddColCities() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='cities' AND TABLE_NAME='TripDays'
)
THEN
    ALTER TABLE `TripDays`
    ADD COLUMN `cities` varchar(256) default NULL;
END IF;
END$$
DELIMITER ; 
CALL AddColCities();
DROP PROCEDURE AddColCities;

DELIMITER $$
CREATE PROCEDURE AddColRoom() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='room' AND TABLE_NAME='Tickets'
)
THEN
    ALTER TABLE `Tickets`
    ADD COLUMN `room` varchar(256) default NULL;
END IF;
END$$
DELIMITER ; 
CALL AddColRoom();
DROP PROCEDURE AddColRoom;

DELIMITER $$
CREATE PROCEDURE AddColTripID() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='trip_id' AND TABLE_NAME='Schedules'
)
THEN
    ALTER TABLE `Schedules`
    ADD COLUMN `trip_id` int(11) NOT NULL DEFAULT '0';
END IF;
END$$
DELIMITER ; 
CALL AddColTripID();
DROP PROCEDURE AddColTripID;


--添加 提车详细地址,还车详细地址
DELIMITER $$
CREATE PROCEDURE AddTicketFromAddress() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='from_address' AND TABLE_NAME='Tickets'
)
THEN
    ALTER TABLE `Tickets`
    ADD COLUMN `from_address` varchar(256) default NULL,
	ADD COLUMN `to_address` varchar(256) default NULL;
END IF;
END$$
DELIMITER ; 
CALL AddTicketFromAddress();
DROP PROCEDURE AddTicketFromAddress;

--添加 提车经纬度,还车经纬度
DELIMITER $$
CREATE PROCEDURE AddTicketFromLatlng() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='from_latlng' AND TABLE_NAME='Tickets'
)
THEN
    ALTER TABLE `Tickets`
    ADD COLUMN `from_latlng` varchar(128) default NULL,
	ADD COLUMN `to_latlng` varchar(128) default NULL;
END IF;
END$$
DELIMITER ; 
CALL AddTicketFromLatlng();
DROP PROCEDURE AddTicketFromLatlng;


--添加 location 图片名字,图片相对路径
DELIMITER $$
CREATE PROCEDURE AddLocationImagePath() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='image_path' AND TABLE_NAME='ComboLocations'
)
THEN
    ALTER TABLE `ComboLocations`
    ADD COLUMN `image_path` varchar(128) default NULL,
	ADD COLUMN `image_name` varchar(128) default NULL;

	ALTER TABLE `Trips`
    ADD COLUMN `image_path` varchar(128) default NULL;

	ALTER TABLE `TripDays`
    ADD COLUMN `image_path` varchar(128) default NULL;
	ALTER TABLE `Suppliers`
    ADD COLUMN `image_path` varchar(128) default NULL;

END IF;
END$$
DELIMITER ; 
CALL AddLocationImagePath();
DROP PROCEDURE AddLocationImagePath;


--添加 签证国家,出行方式
DELIMITER $$
CREATE PROCEDURE AddTripVisa() BEGIN
IF NOT EXISTS(
SELECT * FROM information_schema.COLUMNS
WHERE COLUMN_NAME='national_visa' AND TABLE_NAME='Trips'
)
THEN
    ALTER TABLE `Trips`
    ADD COLUMN `national_visa` varchar(64) default NULL,
	ADD COLUMN `travel_style` varchar(24) default NULL;
END IF;
END$$
DELIMITER ; 
CALL AddTripVisa();
DROP PROCEDURE AddTripVisa;