-- CREATE USER weather_stage WITH PASSWORD 'cloud_weather_stage';
-- CREATE DATABASE cloud_weather_temperature;
-- CREATE DATABASE cloud_weather_precipitation;
-- CREATE DATABASE cloud_weather_report;

-- GRANT ALL PRIVILEGES ON DATABASE cloud_weather_precipitation TO weather_stage;
-- GRANT ALL PRIVILEGES ON DATABASE cloud_weather_temperature TO weather_stage;
-- GRANT ALL PRIVILEGES ON DATABASE cloud_weather_report TO weather_stage;

-- Run for each database:
-- GRANT SELECT, INSERT, UPDATE, DELETE 
-- ON ALL TABLES IN SCHEMA public 
-- TO weather_stage;

-- SELECT grantee, privilege_type 
-- FROM information_schema.role_table_grants __EFMigrationsHistory 
-- WHERE table_name='temperature';

-- Run each EF script on each database:
-- dotnet ef migrations script --idempotent -o 000_init_temperaturedb.sql
-- dotnet ef migrations script --idempotent -o 000_init_precipitationdb.sql
-- dotnet ef migrations script --idempotent -o 000_init_reportdb.sql
