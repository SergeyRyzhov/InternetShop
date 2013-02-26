@echo off
attrib -h *.suo
del /s /q *.suo
del /s /q *.user
del /s /q *.log

rmdir /s /q CommonLibrary\bin
rmdir /s /q CommonLibrary\obj

rmdir /s /q InternetShopService\bin
rmdir /s /q InternetShopService\obj

rmdir /s /q MainSite\bin
rmdir /s /q MainSite\obj

rmdir /s /q DynamicSite\bin
rmdir /s /q DynamicSite\obj

rmdir /s /q Scribblers\bin
rmdir /s /q Scribblers\obj

pause