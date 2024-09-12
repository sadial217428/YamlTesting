# Use Windows-based .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build

# Install MAUI workload in the build stage
RUN dotnet workload install maui

# Set the working directory inside the container
WORKDIR /app

# Copy your project files into the container
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Build the project
RUN dotnet build -c Release

# ---- Final Image ----
# Use a smaller base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022 AS final

# Install Node.js in the final image
RUN powershell -Command "Invoke-WebRequest -Uri https://nodejs.org/dist/v18.16.0/node-v18.16.0-x64.msi -OutFile nodejs.msi; Start-Process msiexec.exe -ArgumentList '/i', 'nodejs.msi', '/quiet', '/norestart' -NoNewWindow -Wait"

# Install Appium and Appium Windows Driver in the final image
RUN npm install -g appium && \
    appium driver install --source=npm appium-windows-driver

# Copy build artifacts from the previous stage
COPY --from=build /app /app

# Set the working directory
WORKDIR /app

# Expose the Appium port if necessary
EXPOSE 4723

# Set the entry point for running the tests
ENTRYPOINT ["dotnet", "test"]
