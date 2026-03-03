CREATE DATABASE EventDb1;
USE EventDb1;

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,

    UserName VARCHAR(50) NOT NULL
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    Role VARCHAR(20) NOT NULL
        CHECK (Role IN ('Admin', 'Participant')),

    Password VARCHAR(20) NOT NULL
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY IDENTITY(1,1),

    EventName VARCHAR(50) NOT NULL
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    EventCategory VARCHAR(50) NOT NULL
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    EventDate DATETIME NOT NULL,

    Description VARCHAR(255) NULL,

    Status VARCHAR(20)
        CHECK (Status IN ('Active', 'In-Active'))
);

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY IDENTITY(1,1),

    SpeakerName VARCHAR(50) NOT NULL
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY IDENTITY(1,1),

    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    SpeakerId INT NOT NULL,

    Description VARCHAR(255) NULL,

    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,

    SessionUrl VARCHAR(255) NULL,

    CONSTRAINT FK_Session_Event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker
        FOREIGN KEY (SpeakerId)
        REFERENCES SpeakersDetails(SpeakerId)
);

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY IDENTITY(1,1),

    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,

    IsAttended BIT
        CHECK (IsAttended IN (0,1)),

    CONSTRAINT FK_Participant_User
        FOREIGN KEY (ParticipantEmailId)
        REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session
        FOREIGN KEY (SessionId)
        REFERENCES SessionInfo(SessionId)
);

INSERT INTO UserInfo VALUES
('admin@mail.com','AdminUser','Admin','admin123'),
('user1@mail.com','Rahul','Participant','pass123');

INSERT INTO EventDetails (EventName, EventCategory, EventDate, Description, Status)
VALUES
('Tech Summit','Technology','2026-05-10','Annual Tech Event','Active');

INSERT INTO SpeakersDetails (SpeakerName)
VALUES ('Dr. Sharma');

INSERT INTO SessionInfo
(EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl)
VALUES
(1,'AI Trends',1,'Discussion on AI','2026-05-10 10:00','2026-05-10 12:00','http://sessionlink.com');

INSERT INTO ParticipantEventDetails
(ParticipantEmailId, EventId, SessionId, IsAttended)
VALUES
('user1@mail.com',1,1,1);

SELECT 
    e.EventName,
    s.SessionTitle,
    sp.SpeakerName,
    s.SessionStart,
    s.SessionEnd
FROM EventDetails e
JOIN SessionInfo s ON e.EventId = s.EventId
JOIN SpeakersDetails sp ON s.SpeakerId = sp.SpeakerId;

SELECT 
    u.UserName,
    e.EventName,
    s.SessionTitle,
    p.IsAttended
FROM ParticipantEventDetails p
JOIN UserInfo u ON p.ParticipantEmailId = u.EmailId
JOIN EventDetails e ON p.EventId = e.EventId
JOIN SessionInfo s ON p.SessionId = s.SessionId;

SELECT 
    u.EmailId,
    u.UserName,
    u.Role,
    e.EventName,
    e.EventDate,
    s.SessionTitle,
    sp.SpeakerName,
    p.IsAttended
FROM ParticipantEventDetails p
JOIN UserInfo u 
    ON p.ParticipantEmailId = u.EmailId
JOIN EventDetails e 
    ON p.EventId = e.EventId
JOIN SessionInfo s 
    ON p.SessionId = s.SessionId
JOIN SpeakersDetails sp 
    ON s.SpeakerId = sp.SpeakerId;