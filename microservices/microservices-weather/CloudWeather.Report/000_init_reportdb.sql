CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220507175016_Initial') THEN
    CREATE TABLE "weatherReport" (
        "Id" uuid NOT NULL,
        "CreatedOn" timestamp with time zone NOT NULL,
        "AverageHighC" numeric NOT NULL,
        "AverageLowC" numeric NOT NULL,
        "RainfallTotalCentimetres" numeric NOT NULL,
        "SnowTotalCentimetres" numeric NOT NULL,
        "PostCode" text NOT NULL,
        CONSTRAINT "PK_weatherReport" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220507175016_Initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220507175016_Initial', '6.0.3');
    END IF;
END $EF$;
COMMIT;