FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as basebuild

WORKDIR /bench

COPY . .

FROM basebuild

RUN dotnet publish -f netcoreapp3.1 -c Release -r linux-x64 -o .

ENTRYPOINT ["./benchtool-dotnetcore"]
