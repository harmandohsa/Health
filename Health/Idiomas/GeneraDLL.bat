@set path=%path%;C:\Program Files (x86)\Microsoft Visual Studio 10.0\SDK\v3.5\Bin;C:\Windows\Microsoft.NET\Framework\v3.5;C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools
@del *.resources
@for %%f in (*.resx) do @resgen %%f
@echo /t:lib > a.txt
@for %%f in (*.resources) do @echo /v:1.0.1.13 /comp:"QHealth" /prod:"QHealth" /embed:%%f,%%f >> a.txt
@echo /culture:es-GT >> a.txt /out:QHealth.resources.dll >> a.txt

del QHealth.resources.dll
al @a.txt

pause
