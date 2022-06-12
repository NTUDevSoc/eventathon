CREATE TABLE Users (
    "Id" varchar(40) PRIMARY KEY,
    "Username" varchar(40) UNIQUE,
    "HashedPassword" varchar(100),
    "Salt" varchar(100)
)
