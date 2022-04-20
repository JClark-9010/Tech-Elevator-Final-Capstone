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
	landmark_image nvarchar(500),
	CONSTRAINT PK_landmark PRIMARY KEY (landmark_id)
)

CREATE TABLE itineraries (
	itinerary_id int IDENTITY(1,1) NOT NULL,
	user_id int REFERENCES users (user_id),
	itinerary_name varchar(50) NOT NULL
	CONSTRAINT PK_itinerary PRIMARY KEY (itinerary_id)
)

CREATE TABLE itineraries_landmarks_user (
	itinerary_id int REFERENCES itineraries (itinerary_id),
	landmark_id int REFERENCES landmarks (landmark_id),
	user_id int REFERENCES users (user_id),
	PRIMARY KEY (itinerary_id, landmark_id, user_id)
)

CREATE TABLE reviews (
	review_id int IDENTITY(1,1) NOT NULL,
	landmark_id int REFERENCES landmarks (landmark_id),
	review_description varchar(300) NOT NULL
	CONSTRAINT PK_review PRIMARY KEY (review_id)
)



--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');



INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Columbus Zoo and Aquarium', '40.15609', '-83.11795','The Columbus Zoo and Aquarium is one of the top things to do in Columbus because of its expansive collection of animals, educational programs, and changing exhibits. With habitats like Asia Quest, Congo Expedition, Heart of Africa, and Shores & Aquarium, a day at the Columbus Zoo takes you to every continent to explore more than 10,000 animals.', 'https://cdn.cnn.com/cnnnext/dam/assets/210311232158-columbus-zoo-and-aquarium-super-tease.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Columbus Museum of Art', '39.9641','-82.9879', 'The Columbus Museum of Art is an art museum in downtown Columbus, Ohio. Formed in 1878 as the Columbus Gallery of Fine Arts, it was the first art museum to register its charter with the state of Ohio.', 'https://media.architecturaldigest.com/photos/564fa15353d639997adbc1c0/2:1/w_5400,h_2700,c_limit/columbus-museum-of-art-adds-bold-new-expansion-to-1931-building-01.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Field of Corn', '39.9598','-83.0070', 'Field of Corn is a publicly funded art installation in the city of Dublin, Ohio. The installation consists of 109 concrete ears of corn positioned in rows and standing upright in a grassy field. At one end of the field are two rows of Osage-orange trees, one pre-existing and the other planted for the project.', 'https://ohiomagazine.azureedge.net/sitefinity/images/default-source/articles/2015/2---february-2015/field-of-corn-sculptures.jpg?sfvrsn=b950ad38_2');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Center of Science and Industry (COSI)', '40.0850','-83.1235', 'The Center of Science and Industry has been a Columbus institution for decades, inspiring adults and children about the wonders of science in our world. Hands-on exhibits throughout COSI educate about outer space, energy, cultural progress, and even an expansive dinosaur gallery in partnership with the American Museum of Natural History.', 'https://scienceonscreen.org/assets/theaters/_1600x900_crop_center-center_75_none/COSI.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Franklin Park Conservatory and Botanical Gardens', '39.96117','-82.99879', 'You can explore a paradise of flora and fauna at the Franklin Park Conservatory and Botanical Gardens. The Conservatory features hundreds of species of plants from around the world in towering glass greenhouses. Walk through the rainforest, desert, orchid collection, and the grand Palm House, where you might spot a wedding in progress on the weekend.', 'https://www.planetware.com/photos-large/USOH/ohio-columbus-franklin-park-conservatory-2.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Easton Town Center', '40.0505','-82.9153', 'In stark contrast to the old-country aura of German Village, Easton is the most modern neighborhood in the city, its architecturally contemporary town center drawing shoppers and tourists to an array of nationally and regionally known stores, plentiful restaurants and varied entertainment.', 'https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0f/7e/ed/e0/photo1jpg.jpg?w=1200&h=-1&s=1');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('North Market', '39.5818','-83.0155', 'North Market is a 145-year-old vibrant public market made up of Ohio’s best independent merchants, farmers, and makers. We invite you to eat, drink, shop, and enjoy the best of what’s local, fresh, and authentic.', 'https://dynamic-media-cdn.tripadvisor.com/media/photo-o/18/0d/de/ad/20190623-131850-largejpg.jpg?w=1000&h=-1&s=1');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('National Veterans Memorial and Museum', '39.5743','-83.029', 'The National Veterans Memorial and Museum is the United States national museum for veterans of the U.S. Armed Forces. The museum is located in Columbus, Ohio, along the Scioto River between Franklinton and Downtown Columbus. The museums main focus is on the personal stories of U.S. veterans, in contrast to other war museums that are dedicated to the conflicts themselves.', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_f0eeWz5eIh8C11dLu55Cdt8Ti-sa7gQxhg9BGUUyAw&s');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Ohio Stadium', '40.0017','-83.0197', 'Nestled snugly on the banks of the Olentangy River, stately Ohio Stadium is one of the most recognizable landmarks in all of college athletics. With its present seating capacity of 102,780, Ohio Stadium is the fourth-largest on-campus facility in the nation. Since the opening game against Ohio Wesleyan on Oct. 7, 1922, more than 36 million fans have streamed through the stadium’s portals.', 'https://cmg-cmg-tv-10040-prod.cdn.arcpublishing.com/resizer/kvlZ8QB9XyjOCkMa_O5aAbu2mMQ=/1440x810/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/cmg/XS6OY4I3MCMM35QM7CWOHVFSKU.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Ohio History Center', '40.0049','-82.9875', 'The Ohio History Center is a history museum and research center in Columbus Oh. It is the primary museum for the history of Ohio and is the headquaters, offices and library of th Ohio History Connection.', 'http://eatplaycbus.com/wp-content/uploads/2016/06/13502082_1378173255532211_4736129357759984982_n.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Ohio Statehouse', '39.9601','-82.9995', 'The Ohio Statehouse is the state capitol building and seat of government for the U.S. state of Ohio. The Greek Revival building is located on Capitol Square in Downtown Columbus. The capitol houses the Ohio General Assembly, consisting of the House of Representatives and the Senate.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/Ohio_Statehouse_03.jpg/1200px-Ohio_Statehouse_03.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Wexner Center for the Arts', '40.0001', '-83.0034','The Wexner Center for the Arts is one of the nation’s premiere cultural gems--an internationally known contemporary arts center at The Ohio State University. The Center offers exhibitions, performances, films, artistic residencies and educational programs. The building, a landmark of postmodern architecture, houses galleries, performance spaces, a film video theater, a store and a cafe. From the intimate, cabaret-style concerts in our black box theater to large-scale events in or 2,500 seat Mershon Auditorium, the Wexner Center offers a wide variety of performances – dance, theater, jazz, world music, electronica and more. In the Wexner Center Film/Video Theater, you can watch rarely screened movies from near and far, the latest independent features and classics from Hollywood and abroad.', 'https://wexarts.org/sites/default/files/2020-12/su20exh_cc_gallery_1_chrisburden_wexnercastle.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Ohio Village', '40.0065', '-82.9869','Ohio Village is a living history museum in Columbus, Ohio, United States. It is operated by the non-profit Ohio History Connection. The village, intended to provide a firsthand view of life in Ohio during the American Civil War, opened July 27, 1974, on 15 acres adjacent to the Ohio History Center in north Columbus', 'https://i0.wp.com/www.columbusonthecheap.com/lotc-cms/wp-content/uploads/2016/11/dickens-of-a-christmas-2.jpg?fit=960%2C640&ssl=1');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('Topiary Park', '39,57400', '-82.59152','Topiary Park is a 9.2-acre public park and garden in the Discovery District of Columbus, Ohio. The topiary garden, officially the Topiary Garden at Old Deaf School Park, is designed to depict figures from an 1884 painting by Georges Seurat, A Sunday Afternoon on the Island of La Grande Jatte.', 'https://img.atlasobscura.com/KQ3fMhSuqIrRDeNuPUBzywT07cOUSNrTzw65Quk8LJA/rs:fill:580:580:1/g:ce/q:81/sm:1/scp:1/ar:1/aHR0cHM6Ly9hdGxh/cy1kZXYuczMuYW1h/em9uYXdzLmNvbS91/cGxvYWRzL3BsYWNl/X2ltYWdlcy80Zjgy/YmQ1ZC1iNjkwLTQ0/NDktODYxMy1hYTE5/ODQ3OGQyMTMwMWUz/NjVlYmYyYTNlMDlj/YjVfR2V0dHlJbWFn/ZXMtNTkwNjM3Mjgz/LmpwZw.jpg');
INSERT INTO landmarks (landmark_name, landmark_lat, landmark_lng, description, landmark_image) VALUES ('German Village Society', '39.9504', '-82.9869','The German Village Society is a 501(c)3 non-profit organization. Members of the German Village Society serve as Caretakers of A Legacy, dedicated to retaining the character and distinction of the past while creating a thriving and contemporary community in German Village.', 'https://germanvillage.com/wp-content/uploads//2015/10/Red-with-X-Band-Logo-6-e1602533887384.png');






INSERT INTO itineraries (itinerary_name, user_id) VALUES ('test-itineary 1', 1)
INSERT INTO itineraries (itinerary_name, user_id) VALUES ('test-itineary 2', 1)
INSERT INTO itineraries (itinerary_name, user_id) VALUES ('test-itineary 3', 1)
INSERT INTO itineraries (itinerary_name, user_id) VALUES ('test-itineary 4', 1)

INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (1, 1, 1)
INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (2, 2, 1)
INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (3, 3, 1)
INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (4, 4, 1)

INSERT INTO reviews (landmark_id, review_description) VALUES (1, 'This zoo is the best! It has a 150 million dollar indoor museum with outer walls made of pure glass.. Incredible!')
INSERT INTO reviews (landmark_id, review_description) VALUES (2, 'Could be better... could be worse... where is the Mona Lisa?')
INSERT INTO reviews (landmark_id, review_description) VALUES (3, 'This must be the most ridiculous sight-seeing attraction in the midwest')
INSERT INTO reviews (landmark_id, review_description) VALUES (4, 'Way better as a kid... went there as an adult and it seemed too expensive.. maybe I am just getting old.')
INSERT INTO reviews (landmark_id, review_description) VALUES (5, 'Dem some cool butterflies')
INSERT INTO reviews (landmark_id, review_description) VALUES (6, 'OOOOOOoooooEEEEEEE I love to shop and this place is da bomb... the food here hits different too!')
INSERT INTO reviews (landmark_id, review_description) VALUES (7, 'Yall really like food too much tbh')
INSERT INTO reviews (landmark_id, review_description) VALUES (8, 'Proud to be an American.')


GO