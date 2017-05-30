ALTER TABLE `dcts_dev`.`Trips` 
ADD COLUMN `customer_id` INT NOT NULL DEFAULT 0 AFTER `word_created_at`;
