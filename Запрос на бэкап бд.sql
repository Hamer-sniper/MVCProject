BACKUP DATABASE MSSQLLocalDemo
TO DISK = 'c:\tmp\MSSQLLocalDemo.bak'
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of SQLTestDB';
GO