# Wait to be sure that SQL Server is up
sleep 30s

# Execute setup script to create the DB and Data
/opt/mssql-tools/bin/sqlcmd -S sqltrek -U sa -P 1rootP@ssword -d master -i startrek.sql