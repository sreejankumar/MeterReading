# MeterReading
An API to submit meter reading. 

## Set Up Database
1. Open the Folder 'Database' in VS CODE
2. Make sure Docker is running. 
3. Open the terminal and type in the below 
4. `docker-compose down`
5. `docker-compose build`
6. `docker-compose Up`
7. Make sure to check the container is up. Once its up, to verify the MySQL is running , open a new terminal and type in below
8. `docker exec -it database-mysql-1 bash`
9. `mysql -uroot -p`
10. The password is in the env file. 
11. Once in, type in below
12.  `show databases;`
13. `USE meter-reading`

Once the above are done and you can see the DB up, open the code base in Visual Studio and run it normally. 

## Testing
In the tests folder, i have included a post man collection, that can be used to set the difference scenarios  mnetioned in the AC. 







