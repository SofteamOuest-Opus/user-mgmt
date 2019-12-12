-- This SQL script only creates the database schema and users
-- All the rest (tables and data) are created by EntityFramework

CREATE USER user_mgmt_private WITH ENCRYPTED PASSWORD '******';
CREATE DATABASE user_mgmt_private_db;
GRANT ALL PRIVILEGES ON DATABASE user_mgmt_private_db TO user_mgmt_private;
