--commands for creating a Rescue Rangers database

CREATE TABLE "Adopters"
(
    "Id" INTEGER,
    "FirstName" TEXT,
    "LastName" TEXT,
    "Address" TEXT,
    "City" TEXT,
    "State" TEXT,
    "PostalCode" TEXT,
    "PhoneNo" TEXT,
    PRIMARY KEY("Id")
);

CREATE TABLE "Adoptions"
(
    "Id" INTEGER,
    "AnimalId" INTEGER NOT NULL,
    "AdopterId" INTEGER NOT NULL,
    "Date" NUMERIC,
    PRIMARY KEY("Id"),
    FOREIGN KEY("AdopterId") REFERENCES "Adopters"("Id"),
    FOREIGN KEY("AnimalId") REFERENCES "Animals"("Id")
);

CREATE TABLE "Animals"
(
    "Id" INTEGER UNIQUE,
    "Name" TEXT NOT NULL,
    "Species" TEXT,
    "ImageUrl" TEXT,
    "Gender" TEXT,
    "Description" TEXT,
    "IsAdopted" INTEGER,
    "AdoptionId" INTEGER,
    "ShelterId" INTEGER,
    PRIMARY KEY("Id")
)