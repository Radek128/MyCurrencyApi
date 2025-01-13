# MyCurrency
Aplikacja do obsługi kursów walut.

## Jak uruchomić aplikację?

### 1. Klonowanie repozytorium
Najpierw sklonuj to repozytorium:
git clone https://github.com/Radek128/MyCurrencyApi.git
cd MyCurrencyApi

### 2. Podłączenie bazy
Uruchom kontener postgresa:
docker-compose up -d

### 3. Uruchomienie aplikacji
Aplikację można uruchomić na dwa sposoby:

- Otwórz projekt w preferowanej IDE (np. Visual Studio, Visual Studio Code).
- Skonfiguruj środowisko (jeśli to konieczne).
- Kliknij **Start** lub użyj skrótu `F5`, aby uruchomić aplikację.

Aby uruchomić aplikację z poziomu terminala, wykonaj następujące kroki:
1. Otwórz terminal (cmd, PowerShell, Terminal, etc.).
2. Przejdź do katalogu, w którym znajduje się plik projektu.
3. Wpisz polecenie dotnet run.

przykład zapytania: "http://localhost:5291/api/CurrencyRates?currencyCode=USD&dateTime=2024-12-30"


