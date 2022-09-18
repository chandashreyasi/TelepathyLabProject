# TelepathyLabProject

Script for table creation.

CREATE TABLE Reels (
    id UNIQUEIDENTIFIER  PRIMARY KEY ,
    name VARCHAR (400) NOT NULL,
    description VARCHAR (4000) NOT NULL ,
    standard VARCHAR(20) NULL,
    definition VARCHAR(20) NULL,
    start_timecode VARCHAR (200), 
    end_timecode VARCHAR (200)
);