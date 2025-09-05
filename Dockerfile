FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS basebuild

WORKDIR /bench

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release --self-contained true -o .

#runtime
FROM alpine:latest AS runtime

RUN apk add --no-cache libstdc++

WORKDIR /bench
COPY --from=basebuild /bench .

ENTRYPOINT ["./benchtool-dotnetcore"]

