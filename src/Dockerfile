
#Use your choice of image as base. Mine is alpine! 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "ZCommerce.Api/ZCommerce.Api.csproj"
WORKDIR "/src/."
COPY . .
RUN dotnet build "ZCommerce.Api/ZCommerce.Api.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "ZCommerce.Api/ZCommerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5010
ENTRYPOINT ["dotnet", "ZCommerce.Api.dll"]

# FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS publish
# WORKDIR /src
# COPY ZCommerce.Api/ZCommerce.Api.csproj ./
# COPY ZCommerce.Domain/ZCommerce.Domain.csproj ./
# COPY ZCommerce.Infrastructure/ZCommerce.Infrastructure.csproj ./
# COPY ZCommerce.Application/ZCommerce.Application.csproj ./


# #COPY appsettings.json ./
# ENV PATH="${PATH}:/root/.dotnet/tools"
# RUN dotnet restore "ZCommerce.Api.csproj" --runtime alpine-x64

# COPY . .
# RUN dotnet publish "ZCommerce.Api.csproj" -c Release -o /app/publish \
#     --no-restore \
#     --runtime alpine-x64 \
#     --self-contained true \
#     /p:PublishTrimmed=true \
#     /p:PublishSingleFile=true

# FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine AS final

# RUN adduser --disabled-password \
#     --home /app \
#     --gecos '' dotnetuser && chown -R dotnetuser /app

# # upgrade musl to remove potential vulnerability
# RUN apk upgrade musl

# USER dotnetuser
# WORKDIR /app
# EXPOSE 5010
# COPY --from=publish /app/publish .

# ENTRYPOINT ["./ZCommerce.Api", "--urls", "http://0.0.0.0:5010"]