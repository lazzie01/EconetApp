# EconetApp

# First Steps
To run the App
1 Clone the repository
2. Makesure .Net Core 3.1, SQL server and Visual Studio 2019 are installed on the PC
3. Open Nuget Package Console under Tools and run the command Update-Database to apply database migrations, the app will create and seed the database named AreaDB (if database creation fails, edit the connection string in **appsettings.json** file ensuring that you pass correct database server credetials)
4. Run the application

# Final Steps
API urls:
1. To get any particular use GET api/shop/{shop id}, i.e api/shop/1
2. To create a shop use POST api/shop/ and pass Shop object from body
3. To search for a particular shop in an area use GET api/shop/serach?name={area name} i.e GET api/shop/serach?name=harare cbd
