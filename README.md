# Netwise recruitment task

- **.NET 10 SDK** version `10.0.x` is required

## Running from the command line

The following commands should be run from the repository root directory, which contains `netwise-recruitment-task.sln`.

### 1. Restoring dependencies

```powershell
dotnet restore 
```

### 2. Building the solution

```powershell
dotnet build 
```

### 3. Starting the server

```powershell
dotnet run --project netwise-recruitment-task\netwise-recruitment-task.csproj 
```
Try double backslash `\\` if the program says that the path is missing.

The `http` profile starts the application at:

```text
http://localhost:5116
```

To stop the server, press `Ctrl+C`.

### 4. Calling the API

To learn something new about cats, send the following request:

```text
GET http://localhost:5116/cat_fact
```
You can paste the URL above into a browser or use a command such as `curl`.

A new cat fact should be visible in a .txt file. 

 
### 5. Running the tests

```powershell
dotnet test 
```
