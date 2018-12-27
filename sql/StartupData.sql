DELETE FROM Client;

DECLARE @lastClientId INT;

INSERT INTO Client(UserName,Password,FirstName,LastName,Country,Region,City,Address) VALUES('alberto',HASHBYTES('SHA2_512','changeit'),'Alberto','Illobre','ES','Galicia','Santiago','Travesa dos Basquiños');

SELECT @lastClientId = @@IDENTITY;

INSERT INTO Account(ClientId,Number,Description) VALUES(@lastClientId,'02407454164596279353','First account (alberto)');
INSERT INTO Account(ClientId,Number,Description) VALUES(@lastClientId,'30080783423035664426','Second account (alberto)');
INSERT INTO Account(ClientId,Number,Description) VALUES(@lastClientId,'20717997569298946546','Third account (alberto)');


INSERT INTO Client(UserName,Password,FirstName,LastName,Country,Region,City,Address) VALUES('jesus',HASHBYTES('SHA2_512','password'),'Jesus','Davila','ES','Galicia','Santiago','Polígono Tambre');

SELECT @lastClientId = @@IDENTITY;

INSERT INTO Account(ClientId,Number,Description) VALUES(@lastClientId,'31083541797599122300','First account (jesus)');
INSERT INTO Account(ClientId,Number,Description) VALUES(@lastClientId,'02114346724562678779','Second account (jesus)');