# LocalMessenger – komunikator tekstowy w sieci lokalnej (C# / .NET / WinForms)

LocalMessenger to lekka aplikacja typu klient–serwer umożliwiająca wymianę wiadomości tekstowych w sieci lokalnej. Projekt został zrealizowany w technologii C# (.NET Framework) z wykorzystaniem WinForms oraz protokołu TCP. Komunikacja odbywa się w czasie rzeczywistym, a każda wiadomość jest natychmiast odbierana, przetwarzana i wyświetlana po obu stronach.

Aplikacja składa się z dwóch niezależnych modułów:

- Serwer – nasłuchuje na wybranym porcie, akceptuje połączenie i obsługuje odbiór oraz wysyłanie wiadomości.
- Klient – łączy się z serwerem, odbiera komunikaty i umożliwia wysyłanie wiadomości do serwera.

---

## Funkcjonalności

- Dwukierunkowa komunikacja tekstowa w czasie rzeczywistym.
- Połączenie oparte na TCP (TcpListener / TcpClient).
- Obsługa jednego klienta na instancję serwera.
- Buforowanie wiadomości i składanie ich z fragmentów.
- Prosty protokół komunikacyjny oparty na znaczniku końca wiadomości `<EOF>`.
- Powiadomienia systemowe (NotifyIcon) przy nadejściu nowej wiadomości.
- Interfejs graficzny w WinForms.
- Obsługa błędów połączenia i rozłączenia.
- Niestandardowe zaokrąglone okna po stronie klienta.

---

## Architektura i sposób działania

### 1. Warstwa sieciowa

Komunikacja opiera się na klasach:

- `TcpListener` – uruchamiany po stronie serwera, nasłuchuje na porcie 6001.
- `TcpClient` – używany przez klienta do nawiązania połączenia.
- `NetworkStream` – strumień danych wykorzystywany do odczytu i zapisu.

Serwer:

1. Uruchamia `TcpListener`.
2. Oczekuje na połączenie (`AcceptTcpClient`).
3. Po nawiązaniu połączenia otwiera `NetworkStream`.
4. W pętli odczytuje dane z bufora.
5. Składa wiadomość do momentu wykrycia `<EOF>`.
6. Wyświetla wiadomość i wysyła powiadomienie systemowe.

Klient:

1. Łączy się z serwerem pod wskazanym adresem IP.
2. Otwiera strumień i uruchamia asynchroniczny odbiór wiadomości.
3. Wysyła wiadomości zakończone `<EOF>`.
4. Wyświetla odebrane komunikaty i generuje powiadomienia.

---

## Protokół komunikacyjny

Aplikacja wykorzystuje prosty protokół oparty na znaczniku końca wiadomości:

```
<wiadomość><EOF>
```

Powód zastosowania `<EOF>`:

- TCP nie gwarantuje, że wiadomość dotrze w jednym pakiecie.
- Odbiór odbywa się w fragmentach, dlatego konieczne jest oznaczenie końca komunikatu.
- Serwer i klient składają wiadomość w `StringBuilder` do momentu wykrycia znacznika.

---

## Technologie i biblioteki

- **C# (.NET Framework)** – główny język aplikacji.
- **WinForms** – interfejs użytkownika.
- **System.Net.Sockets** – obsługa TCP.
- **System.Threading / Task Parallel Library** – wątek nasłuchujący i asynchroniczny odbiór wiadomości.
- **NotifyIcon** – powiadomienia systemowe.
- **GraphicsPath / Region** – zaokrąglone rogi okna klienta.

---

## Struktura projektu

### Serwer

- `TcpListener` uruchamiany w osobnym wątku.
- Odbiór wiadomości w pętli blokującej.
- Aktualizacja UI poprzez `Invoke`.
- Powiadomienia systemowe przy każdej wiadomości.
- Wysyłanie wiadomości do klienta po kliknięciu przycisku.

### Klient

- Połączenie z serwerem przy starcie aplikacji.
- Asynchroniczny odbiór wiadomości (`Task.Run`).
- Zaokrąglone okno tworzone dynamicznie.
- Powiadomienia systemowe.
- Obsługa przeciągania okna bez standardowego paska tytułu.

---

## Uruchomienie

### 1. Serwer

1. Uruchom aplikację Server.exe.
2. Serwer automatycznie rozpocznie nasłuch na porcie 6001.
3. Po połączeniu klienta status zmieni się na „Połączono”.

### 2. Klient

1. Uruchom Client.exe.
2. Klient automatycznie spróbuje połączyć się z serwerem pod adresem IP wpisanym w kodzie.
3. Po połączeniu można wymieniać wiadomości.

---

## Możliwe rozszerzenia

- Obsługa wielu klientów jednocześnie (TCP + threading).
- Logowanie wiadomości do pliku.
- Szyfrowanie komunikacji (np. AES).
- Konfigurowalny adres IP i port.
- Wsparcie dla UDP jako alternatywy.
- Wysyłanie plików.
- Wersja konsolowa lub webowa.

---

## Podsumowanie

LocalMessenger to prosty, ale w pełni funkcjonalny komunikator działający w sieci lokalnej. Projekt pokazuje praktyczne wykorzystanie TCP w C#, obsługę strumieni, wielowątkowość, integrację z WinForms oraz implementację własnego protokołu komunikacyjnego. Kod jest przejrzysty, modularny i łatwy do dalszej rozbudowy.
