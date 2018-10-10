FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 4640
EXPOSE 44349

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/MicroFlow.Mvc/MicroFlow.Mvc.csproj", "src/MicroFlow.Mvc/"]
RUN dotnet restore "src/MicroFlow.Mvc/MicroFlow.Mvc.csproj"
COPY . .
WORKDIR "/src/src/MicroFlow.Mvc"
RUN dotnet build "MicroFlow.Mvc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicroFlow.Mvc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroFlow.Mvc.dll"]