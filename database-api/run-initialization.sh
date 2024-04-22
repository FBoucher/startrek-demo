/opt/mssql/bin/sqlservr
# Wait to be sure that SQL Server is up
sleep 30
# Execute setup script to create the DB and Data
/opt/mssql-tools/bin/sqlcmd -U sa -P $MSSQL_SA_PASSWORD -d master -i startrek.sql