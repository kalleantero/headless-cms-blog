FROM microsoft/dotnet
 
WORKDIR /home/app
 
COPY . .
 
RUN dotnet restore
 
RUN dotnet publish *.csproj -o /publish/
 
WORKDIR /publish
 
ENTRYPOINT ["dotnet", "HeadlessBlog.Web.dll"]

EXPOSE 22938