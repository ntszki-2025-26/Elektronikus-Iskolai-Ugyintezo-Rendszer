# Elektronikus-Iskolai-gyint-z-Rendszer
Elektronikus Iskolai Ügyintéző Rendszer


Szakdolgozat leírás

Cím/Téma: Elektronikus iskolai ügyintéző rendszer
Tagok: Flórián Dániel, Lendvai Tamás Gergely, Dorogi Márton András
Konzulens: Varga Gábor
Dátum: 2025. 10. 19

A szakdolgozat célja egy elektronikus iskolai ügyintéző rendszer fejlesztése, amely megkönnyíti a kommunikációt és az adminisztrációs folyamatokat a diákok és a titkárság között. A rendszer célja az iskolai ügyintézés digitalizálása, a papíralapú folyamatok csökkentése, valamint az automatizált státuszkövetés és engedélykezelés megvalósítása.

Általános funckiók:
Bejelentkezés és jogosultságkezelés (admin / titkárság / diák)
-	Ügyek létrehozása, követése, lezárása
-	Értesítések és státuszváltozások automatikus kezelése

-	Többnyelvű ügyintézési űrlapok kezelése
-	Adatbiztonság és jogosultsági szintek beépítése

A szakdoga felépítése:
Titkárság modul 
-	Ügylista
-	tanuló felvétel
o	Kréta export
-	Ügyintézés
-	státusz
-	Diák fiókok hozzáadása az adatbázishoz
  
Diák modul
-	Tanulók adatainak leírása
-	Ügyintézés példák:
-	Iskolalátogatási papír kérése több nyelven
-	Probléma jelentés
-	Ideiglenes igazolvány
-	Hiányzás előrejelzés

Admin modul
-	Titkár fiókok hozzáadása az adatbázishoz
-	Jogosultságok beállítása
-	Mindenhez van engedélye, de személy törléséhez nincs
-	Nem egy személy, hanem egy tulajdonos

További fejlesztési lehetőségek
-	Email értesítések
-	Push értesítések telefonra
-	Mobilalkalmazás fejlesztése
-	Dokumentumfeltöltés
-	Iskolai naptár


Használati útmutató:
1.Lépés
A repository-ban megtalálható SQL fájlt importáljuk be, és konfiguráljuk a connection stringet az appsettings.json-ben.

2.lépés
Futtassuk az alkalmazást, ez feltölti a fontos adatokkal az adatbázist.

3.lépés
Jelentkezzünk be az alap admin felhasználóval (email: admin@gmail.com, jelszó: admin). Változtassuk meg az admin emailjét és jelszavát az adatok biztonságának érdekében.

4.lépés
Adjuk hozzá a felhasználókat, javasolt minden szerepkörből egyet, és tesztelni a dolgokat.




