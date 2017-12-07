FROM microsoft/aspnetcore:2

WORKDIR /apiswagger
COPY /bin/Debug/netcoreapp2.0/publish .

ENTRYPOINT [ "dotnet","apiswagger.dll"]
