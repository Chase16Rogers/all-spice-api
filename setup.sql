use datachase;
-- CREATE TABLE recipes (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   imgUrl VARCHAR(255),
--   steps VARCHAR (255),
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE ingredients (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   quantity VARCHAR(255),
--   recipeId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (recipeId)
--     REFERENCES recipes (id)
--     ON DELETE CASCADE
-- );
