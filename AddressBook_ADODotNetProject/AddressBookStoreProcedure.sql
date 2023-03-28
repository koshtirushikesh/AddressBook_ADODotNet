-- stored procedure is prepaird a sql code that we can re use over and over again.
-- 
CREATE PROCEDURE SpAddingNewData
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Address VARCHAR(100),
@City VARCHAR(20),
@State VARCHAR(20),
@Zip INT,
@PhoneNUmber BIGINT,
@Email VARCHAR(50)
)

AS BEGIN

INSERT INTO AddressBook_Table(FirstName,LastName,Address ,City ,State ,Zip ,PhoneNUmber,Email)
VALUES
(@FirstName,@LastName,@Address ,@City ,@State ,@Zip ,@PhoneNUmber,@Email)

END

CREATE PROCEDURE SpGetAllDataFromDB
AS BEGIN
SELECT * FROM AddressBook_Table
END


CREATE PROCEDURE SpUpdateSpecificData
(        
@FirstName VARCHAR(30),
@LastName VARCHAR(30)
)
AS BEGIN
UPDATE AddressBook_Table SET FirstName = @FirstName WHERE LastName = @LastName;
END

ALTER PROCEDURE SpDeleteSpecificData
(        
@FirstName VARCHAR(30),
@LastName VARCHAR(30)
)
AS BEGIN
DELETE FROM AddressBook_Table WHERE FirstName = @FirstName AND LastName = @LastName;
END
