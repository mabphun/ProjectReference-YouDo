# Projekt beüzemelése
Az alkalmazás futtatásához szükséges szoftverek:
- **Visual Studio** (backend alkalmazás futtatása)
- **Visual Studio Code** (frontend alkalmazás futtatása)

Az alkalmazás futtatásához szükséges eszközök:
- **node** (v18.13 vagy újabb)
- **Angular** (v17)
- **Angular CLI** (v17)
- **.NET 6**

# Projekt indítása
- **Backend**
  - Navigálás a `/Backend` mappába és `Backend.sln` megnyitása
  - `update-database` parancs futtatása a Package Manager Console-ban
  - Alkalmazás indítása az `F5` vagy a `Ctrl+F5` billentyűkombinációval
- **Frontend**
  - Navigálás a `Frontend/Frontend` mappába a `cd Frontend/Frontend` paranccsal
  - `npm install` parancs futtatása
  - `ng serve` parancs futtatása

Sikeres indítás után az alkalmazás felületei a következő elérési utakon érhető el:
- **Backend:** `http://localhost:5152/swagger/` [(Link)](http://localhost:5152/swagger/)
- **Frontend:** `http://localhost:4200/` [(Link)](http://localhost:4200/)

# Előre generált belépési adatok
| Felhasználónév | Jelszó |
|---|---|
| john.doe | user1234 |
| sarah.smith | user1234 |
| mike.jones | user1234 |
| emily.williams | user1234 |
