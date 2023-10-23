# Scripts

## workload-install

This script installs the Mosa workload manifest files and packs to the installed dotnet sdk.

### Usage
On Linux / macOS:
```
workload-install.sh [-v <Version>] [-d <Dotnet SDK Location>] [-t <Dotnet Version Band Target Folder>]
```

On Windows:
```
workload-install.ps1 [-v <Version>] [-d <Dotnet SDK Location>] [-t <Dotnet Version Band Target Folder>]
```

> The `-t` option for an install script is only for testing and verifying a next dotnet version band. <br />
> For example, a developer can install a workload(`1.0.0.0`) of dotnet 8.0.1xx version band to 8.0.2xx destination version band folder.<br />
> workload-install.ps1 -v 1.0.0.0 -t 8.0.200

If this script is executed in CI environment, you can use `curl` to download the script and execute it.
```
curl -sSL https://raw.githubusercontent.com/Samsung/Mosa.NET/main/workload/scripts/workload-install.sh | bash
```
or
```
curl -sSL https://raw.githubusercontent.com/Samsung/Mosa.NET/main/workload/scripts/workload-install.sh | bash -s -- -v <version> -d <dotnet sdk location>
```
