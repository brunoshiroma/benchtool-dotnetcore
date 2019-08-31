# Benchtool - dotnet core

Simple benchmark, using:
 
  * dotnet core 2.2


### Example usage
For the loop bench
```
dotnet benchtool-dotnetcore.dll 1 99999
```

For the recursive bench ( Uses a loot of memory (~1GB))
```
dotnet benchtool-dotnetcore.dll 1 99999
```

### Params:
 1. the bench type 1 = loop, 2 = recursive
 2. the fibonacci ***n*** number to calculate 
