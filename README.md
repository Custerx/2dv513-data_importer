# NDJSON CONVERTER

## Usage
1. Save the program into a local folder.
2. Open a terminal and type "dotnet new"
3. Run the program with "dotnet run"

## Adjustments
In FileHandler.cs replace the string in FilePath() with the path the your NDJSON file. Also set the location you want to save your files in the method FilePathSave(int savePath) by adjusting the string.

const int MaxRowsFile = 1300000;
This constant might need to be adjusted. The number of rows that the program can process depends on your hardware. This was done on 24gb RAM, I5 3.4 ghz processor.

## Import the files to the SQL-database
See InsertJSONtoSQL.sql.

Replace 'C:\JSON\RC_2011-07_08' with your file path. All your files needs to be inserted this way. Don't do the assignment query task untill you got all your files inserted into the database.

You can delete the files after they been inserted into the SQL database. Now perform queries to finish of the assignment.
