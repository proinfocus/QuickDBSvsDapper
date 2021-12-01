# QuickDBS vs Dapper
This repo demonstrates the performance for creating and reading records from Employee table of a SQLite database "employee.db"

### The performance is measured in milliseconds for 2 basic tasks given below.
1. Creating 100 random employee records.
2. Reading those records, displaying it.

### Test results

**Round 1 (starting with QuickDBS):**

| Task                     | Time taken by QuickDBS | Time taken by Dapper |
|--------------------------|------------------------|----------------------|
| Create100RandomEmployees | 25 ms                  | 800 ms               |
| ReadFromTableAndDisplay  | 33 ms                  | 66 ms                |


**Round 2 (starting with Dapper):**

| Task                     | Time taken by QuickDBS | Time taken by Dapper |
|--------------------------|------------------------|----------------------|
| Create100RandomEmployees | 10 ms                  | 481 ms               |
| ReadFromTableAndDisplay  | 85 ms                  | 35 ms                |


**Round 3 (starting with QuickDBS):**

| Task                     | Time taken by QuickDBS | Time taken by Dapper |
|--------------------------|------------------------|----------------------|
| Create100RandomEmployees | 8 ms                   | 380 ms               |
| ReadFromTableAndDisplay  | 63 ms                  | 93 ms                |



### Features
1. QuickDBS is very minimalistic compared to Dapper. Check out the codes for both the libraries.
2. QuickDBS also has the capability to create database on the fly, create tables from given models which isn't possible with Dapper.
3. QuickDBS uses model to table mapping CRUD operations, which Dapper needs sql or store procedures provided to complete the same task.

### Let me know your thoughts on this.
Email to github@proinfocus.com with your thoughts or anything I am missing, so that I can correct it.
Thank you.
