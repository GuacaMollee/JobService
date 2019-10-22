# Build image
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /sln
COPY ./JobService.sln ./

# Copy all the csproj files and restore to cache the layer for faster builds
# The dotnet_build.sh script does this anyway, so superfluous, but docker can 
# cache the intermediate images so _much_ faster
COPY ./JobService/JobService.API.csproj ./JobService/JobService.API.csproj
COPY ./JobService.Core/JobService.Core.csproj ./JobService.Core/JobService.Core.csproj
COPY ./JobService.Common/JobService.Common.csproj ./JobService.Common/JobService.Common.csproj
COPY ./JobService.Infra/JobService.Infra.csproj ./JobService.Infra/JobService.Infra.csproj
COPY ./JobService.Dashboard/JobService.Dashboard.csproj ./JobService.Dashboard/JobService.Dashboard.csproj
RUN dotnet restore

COPY ./ ./

RUN set ASPNETCORE_ENVIRONMENT=Development

RUN dotnet build -c Release --no-restore

RUN dotnet publish "./JobService/JobService.API.csproj" -c Release -o "../dist" --no-restore

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT Local
ENTRYPOINT ["dotnet", "JobService.API.dll"]
COPY --from=build /sln/dist .