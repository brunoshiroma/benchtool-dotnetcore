FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as basebuild

WORKDIR /bench

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release --runtime linux-musl-x64 --self-contained true -o .

#runtime
FROM alpine:latest as runtime

RUN apk add --no-cache libstdc++

WORKDIR /bench
COPY --from=basebuild /bench .

ENTRYPOINT ["./benchtool-dotnetcore"]

