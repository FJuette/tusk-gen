
# tusk-gen
tusk-ms code generation dotnet tool

## Nupkg erstellen & installieren
Schritt 1:

    dotnet pack

Schritt 2:

    dotnet tool install --global --add-source ./nupkg tusk-gen
    
## Beispiel

    gen c CreateFahrzeug Fahrzeug

oder

    gen q GetFahrzeug Fahrzeug
    
## Nupkg entfernen

    dotnet tool uninstall tusk-gen -g
    
 
