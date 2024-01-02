# knygnesys
Paslauga skaitytojui

## Backend (IntelliJIdea)
Server for calculations and interactions with the database. Right now has a small test for database interaction.

### Database
Using MariaDB (easily adjustable to MySQL). Not connected with frontend yet. Will be able to run localy with frontend for testing later on.

## Frontend (Android studio)
Aplication for writing inputs, using functions, viewing data and results. If frontend will need to do heavy calculations or get data from the database, it will be connected to the server, where the Backend program will be at. Frontend will call for functions (like getBook() or smth.) and receive the information.
