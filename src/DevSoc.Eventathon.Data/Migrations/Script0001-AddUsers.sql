CREATE TABLE Users (
    "id" varchar(40) PRIMARY KEY,
    "username" varchar(40) UNIQUE,
    "hashedPassword" varchar(100),
    "salt" varchar(100)
)
