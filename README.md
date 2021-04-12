# cosmos-db-gaspode

The wonder dog of all your Cosmos DB needs and wants.

Azure Cosmos is a great database, but it does not have a lot of tooling, especially compared to Sql Server.
This project aims to help with that.

It simplifies creating and running common bulk operations like Create/Update/Delete that are easy to do in Sql Server using regular sql commands, but require a lot of work in Cosmos DB.


Features:

* Create bulk records
* Update bulk records
* Delete bulk records
* Copy records from one container to another


Microsoft [introduced](https://devblogs.microsoft.com/cosmosdb/introducing-bulk-support-in-the-net-sdk) bulk support directly in Azure Cosmos DSDK 3.4, but it has several problems:

* you need to write code every time you want to do any DDL changes
* your code will be buggy and slow 
* you may slow down your database if you miscalculate number of threads or how much RUs operations are using


So if you would like to use a proven, fast and well-tested product, go ahead and give Gaspod a try.



## Licensing

For open source, non profits and startups with less then 20 employees and less then 10 million a year revenue:
MIT License

For all other companies, you can buy a yearly unlimited license for $1499.00
If you are interested, please send email to support@entechsolutions.com.



