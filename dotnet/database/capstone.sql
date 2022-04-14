USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE landmarks (
	landmark_id int IDENTITY(1,1) NOT NULL,
	landmark_name varchar(50) NOT NULL,
	landmark_lat varchar(9) NOT NULL,
	landmark_lng varchar(9) NOT NULL,
	description varchar(500) NOT NULL,
	CONSTRAINT PK_landmark PRIMARY KEY (landmark_id)
)



--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description) VALUES ('Columbus Zoo and Aquarium', '40.15609', '-83.11795','The Columbus Zoo and Aquarium is one of the top things to do in Columbus because of its expansive collection of animals, educational programs, and changing exhibits. With habitats like Asia Quest, Congo Expedition, Heart of Africa, and Shores & Aquarium, a day at the Columbus Zoo takes you to every continent to explore more than 10,000 animals.');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description) VALUES('Columbus Museum of Art', '39.9641','-82.9879', 'The Columbus Museum of Art is an art museum in downtown Columbus, Ohio. Formed in 1878 as the Columbus Gallery of Fine Arts, it was the first art museum to register its charter with the state of Ohio.');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description) VALUES ('Field of Corn', '39.9598','-83.0070', 'Field of Corn is a publicly funded art installation in the city of Dublin, Ohio. The installation consists of 109 concrete ears of corn positioned in rows and standing upright in a grassy field. At one end of the field are two rows of Osage-orange trees, one pre-existing and the other planted for the project.');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description) VALUES ('Center of Science and Industry (COSI)', '40.0850','-83.1235', 'The Center of Science and Industry has been a Columbus institution for decades, inspiring adults and children about the wonders of science in our world. Hands-on exhibits throughout COSI educate about outer space, energy, cultural progress, and even an expansive dinosaur gallery in partnership with the American Museum of Natural History.');
GO

