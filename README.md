### Klasy i metody w Exchange_Rate_API

#### Klasa `DbExchangeData`
- Zawiera informacje o danych wymiany walut w bazie danych.
- **Właściwości:**
  - `Id` (typ: `int`): Identyfikator danych wymiany.
  - `key` (typ: `string?`): Klucz waluty.
  - `value` (typ: `decimal`): Wartość waluty.
  - `timestamp` (typ: `long`): Znacznik czasu.
- **Metoda `ToString()`:**
  - Przeciążenie metody `ToString()`, zwraca tekstową reprezentację obiektu.

#### Klasa `DataExchange`
- Reprezentuje wymianę danych walutowych.
- **Właściwości:**
  - `timestamp` (typ: `long`): Znacznik czasu.
  - `rates` (typ: `Dictionary<string, decimal>`): Słownik zawierający kursy walut.

#### Klasa `ExchangeHouse`
- Dziedziczy po `DbContext` z biblioteki Entity Framework Core.
- Reprezentuje dom wymiany walut.
- **Właściwości:**
  - `ExchangeData` (typ: `DbSet<DbExchangeData>`): Zbiór danych wymiany.
- **Metody:**
  - `OnConfiguring(DbContextOptionsBuilder options)`: Konfiguruje opcje bazy danych.
  - `OnModelCreating(ModelBuilder modelBuilder)`: Konfiguruje model danych w bazie.
  - `ExchangeHouse()`: Konstruktor, zapewnia utworzenie bazy danych przy jej braku.

#### Klasa `Form1`
- Implementuje interfejs użytkownika aplikacji.
- **Właściwości:**
  - `client` (typ: `HttpClient`): Klient HTTP do komunikacji z API.
  - `_dataExchanges` (typ: `DataExchange`): Wymiana danych walutowych.
  - `_unixTimeSeconds` (typ: `long`): Czas w formacie Unix.
  - `_house` (typ: `ExchangeHouse`): Dom wymiany walut.
- **Metody:**
  - `get_Api()`: Pobiera dane z zewnętrznego API.
  - `print_date()`: Wyświetla datę pobrania danych.
  - `button1_Click(object sender, EventArgs e)`: Obsługuje kliknięcie przycisku do odświeżania danych.
  - `button2_Click(object sender, EventArgs e)`: Obsługuje kliknięcie przycisku do przeliczania walut.
  - `button3_Click(object sender, EventArgs e)`: Obsługuje kliknięcie przycisku do czyszczenia listy.
  - `button4_Click(object sender, EventArgs e)`: Obsługuje kliknięcie przycisku do dodawania danych do bazy.
  - `button5_Click(object sender, EventArgs e)`: Obsługuje kliknięcie przycisku do usuwania wszystkich danych z bazy.
