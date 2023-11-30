# Use the official .NET Core SDK as a parent image
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the rest of the application code
COPY . ./
RUN dotnet restore --arch $TARGETARCH

# Publish the application
RUN dotnet publish --arch $TARGETARCH -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port your application will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "AquaBrainAPI.dll"]