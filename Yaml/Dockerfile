# Use Windows-based .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS base

# Install MAUI workload
RUN dotnet workload install maui

# Install Node.js
RUN powershell -Command "Invoke-WebRequest -Uri https://nodejs.org/dist/v18.16.0/node-v18.16.0-x64.msi -OutFile nodejs.msi; Start-Process msiexec.exe -ArgumentList '/i', 'nodejs.msi', '/quiet', '/norestart' -NoNewWindow -Wait"

# Install Appium and Appium Windows Driver
RUN npm install -g appium && \
    appium driver install --source=npm appium-windows-driver

# Set the working directory inside the container
WORKDIR /app

# Copy your project files into the container
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Build the project
RUN dotnet build -c Release

# Expose the Appium port if necessary
EXPOSE 4723

# Set the entry point for running the tests
ENTRYPOINT ["dotnet", "test"]
