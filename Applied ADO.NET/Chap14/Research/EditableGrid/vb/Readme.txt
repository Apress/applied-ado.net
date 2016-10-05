Prior to run this code do the following:

1) Compile the MyEditableGrid.vb class into an assembly. This can be done opening a DOS box and running the c.bat batch file or creating a new VB Class Library project in VS and adding the .VB file to the empty project

2) The assembly must be made available to the sample ASPX page. The attached batch already copies the DLL in the c:\inetpub\wwwroot\bin folder. Modify it if you happen to have a different path. If you create a virtual directory, make sure you copy the DLL in the virtual folde's BIN subfolder rather than the Web server root's BIN folder.

3) Depending on your ASP.NET security settings, you may run into a "Updateable Query" error when interacting with the sample Access database. In this case, change the security settings of the sample MDB file. Select the file in Explorer, display the Properties and click the Security tab. Here, add <your_machine>\ASPNET as a user and make sure it has the rights to write and modify the file.

4) Refresh the ASPX page. (Notice that nothing of the kind would happen if you use a SQL Server table. The problem raises because Access databases are primarily Web server's local files.)

5) If you already installed the C# version of this control, remove the DLL from the BIN folder. The two DLLs cannot be available at the same time because of some internal classes (event classes) that have not been renamed so they would conflict. 



 