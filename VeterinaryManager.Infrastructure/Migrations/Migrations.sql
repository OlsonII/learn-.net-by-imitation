CREATE TABLE DOCTOR
(
    Id    TEXT PRIMARY KEY,
    Name  TEXT NOT NULL,
    Phone TEXT NOT NULL
);

CREATE TABLE OWNER
(
    Id      TEXT PRIMARY KEY,
    Name    TEXT NOT NULL,
    Phone   TEXT NOT NULL,
    Address TEXT NOT NULL
);

CREATE TABLE PET
(
    Id      SERIAL PRIMARY KEY,
    Name    TEXT NOT NULL,
    Type    INT  NOT NULL,
    Gender  INT  NOT NULL,
    OwnerId TEXT NOT NULL
);

CREATE TABLE SERVICE
(
    Id      SERIAL PRIMARY KEY,
    Service INT  NOT NULL,
    PetId INT NOT NULL,
    DoctorId TEXT NOT NULL,
    Date    DATE NOT NULL,
    Price   DOUBLE NOT NULL
);