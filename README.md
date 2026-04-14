MyDictionaryApp – Projekt Áttekintés
A MyDictionaryApp egy modern, többrétegű webes alkalmazás, amelynek célja a hatékony nyelvtanulás és szótárkezelés támogatása.
Az alkalmazás nem csupán egy digitális szójegyzék, hanem egy skálázható platform, amely a legújabb fejlesztési paradigmákat (Microservices-lite, Containerization) követi.

✨ Főbb Funkciók (CRUD műveletek)
Dinamikus Szótárkezelés: Felhasználóbarát felületen keresztül történő adatbevitel (Hozzáadás), valós idejű módosítás és törlés.
Hatékony Lekérdezés: Gyors keresési és listázási funkciók, amelyek nagy adatmennyiség esetén is stabil teljesítményt nyújtanak.
Adatperzisztencia: Integrált PostgreSQL adatbázis-kezelő, amely garantálja az adatok integritását és biztonságát.

🛠️ Technikai Architektúra és Biztonság
Dockerizált Környezet: Az alkalmazás teljes infrastruktúrája (Frontend, API, Adatbázis) Docker konténerekbe van csomagolva, biztosítva a platformfüggetlen futtatást ("Write once, run anywhere").
Adatvédelem: A rendszer Docker Volume-okat használ az adatok elkülönített és biztonságos tárolására. Ez garantálja, hogy a konténerek frissítése vagy újraindítása során a felhasználói adatok soha nem vesznek el.
CI/CD Integráció: GitHub Actions alapú automatizált build folyamat, amely biztosítja a kód folyamatos minőségét és naprakész telepítését.

🚀 Jövőbeni Fejlesztési Irányok (Roadmap)
A projektet úgy terveztük, hogy a moduláris felépítésnek köszönhetően könnyen bővíthető legyen az alábbi funkciókkal:

1. Személyre szabott Felhasználókezelés
Identity Provider: JWT alapú hitelesítés és jogosultságkezelés implementálása.
Privát Szótárak: Minden felhasználó saját, jelszóval védett szólistákat hozhasson létre.

2. Gamifikáció és Tanulás-támogatás
Szókitalálós játék: Interaktív kvízmód, ahol a rendszer véletlenszerűen generál kérdéseket a tárolt szavakból.
Intelligens algoritmus: A nehezebben megjegyezhető szavak gyakrabban kerülnek elő a játék során (Spaced Repetition elv).

3. Statisztika és Analitika
Tudásellenőrző pontrendszer: A sikeres válaszok után járó pontok gyűjtése és vizuális visszajelzése.
Haladási Napló: Grafikonos megjelenítés és százalékos statisztika a megtanult szavak arányáról és a fejlődési görbéről.

Telepítési útmutató: 
Letöltés:
Töltsd le a GitHub oldalamról a "docker-compose.prod.yml" fájlt.
Nyiss egy PowerShell ablakot abban a mappában, ahová a fájlt mentetted, majd futtasd az alábbi parancsot a konténerek letöltéséhez:
docker compose -f docker-compose.prod.yml pull

Indítás:
PowerShell
docker compose -f docker-compose.prod.yml up -d

Ellenőrzés:
Várj kb. 15-20 másodpercet, hogy a healthcheck lefusson, majd nézd meg a státuszt:
PowerShell
docker compose -f docker-compose.prod.yml ps
Ha a dictionary_db mellett ott a (healthy) felirat, és a többi Up, akkor sikeresen települt a program!
