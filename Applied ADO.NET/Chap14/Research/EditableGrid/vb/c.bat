vbc /t:library /r:system.dll /r:system.web.dll /r:system.data.dll /out:MyEditableGrid.dll MyEditableGrid.vb
@echo off
copy MyEditableGrid.dll c:\inetpub\wwwroot\bin