# aplikacja_zdjecia_z_wakacji

Zamysłem aplikacji jest wrzucanie własnych zdjęć z wakacji na stronę. Inni użytkownicy mogą polubić oraz komentować wstawione zdjęcia.

# Przygotowanie aplikacji do uruchomienia

W pierwszej kolejności należy określić nazwę serwera oraz nazwę bazy danych w pliku appsettings.json

![appsettings](https://user-images.githubusercontent.com/117681023/224831428-2efb6bce-7437-4be3-98a8-e63f067c4363.JPG)

Następnie w konsoli za pomocą komend

* add-migration InitialCreate -context AppDbContext
* update-database -context AppDbContext
* add-migration UserInit -context UserContext
* update-database -context UserContext

tworzymy migracje i wysyłamy dane do bazy tworząc encje

W Microsoft Sql Server Management Studio powinny utworzyć się tabele

![baza_danych_tabele](https://user-images.githubusercontent.com/117681023/224831492-e31e00ea-df08-4825-b270-9e3955df8f89.JPG)

Teraz aplikacja jest gotowa do uruchomienia

# Funkcjonalność aplikacji dla użytkownika

W prawym górnym rogu widnieją przyciski do logowania oraz rejestracji

![logowanie_i_rejestracja](https://user-images.githubusercontent.com/117681023/224831563-e9bec7f3-a823-48bf-9fdb-1f045902c9d3.JPG)

Po zarejestrowaniu użytkownika zostaje on zapisany do bazy danych, można wtedy przystąpić do logowania.

Po zalogowaniu w prawym górnym rogu aplikacji widnieje nazwa zalogowanego użytkownika. Po jego kliknięciu otwiera się okno edycji użytkownika.

![user](https://user-images.githubusercontent.com/117681023/224831607-1547f93c-23df-4333-8d98-08574cbc03b8.JPG)

W celu dodania własnego zdjęcia na stronę użytkownik musi kliknąć przycisk "Dodaj własne zdjęcie" na głównej stronie.

![dodawanie_zdjecia](https://user-images.githubusercontent.com/117681023/224831660-cbcd2654-4a0b-4f8e-befc-df39c39b00a9.JPG)

Po jego kliknięciu ukazuje się formularz, po którego wypełnieniu należy kliknąć przycisk "Dodaj". 
W ten sposób użytkownik dodaje swoje zdjęcie na stronę. 
Jeżeli dane nie zostaną wprowadzone, bądź wprowadzone błędnie (_przykładowo zbyt duża liczba znaków_) zostanie zwrócony odpowiedni komuniktat.

![formularz_dodawanie_zdjecia](https://user-images.githubusercontent.com/117681023/224831711-4c471141-6b0b-488d-b0a2-9fa7eb5b8665.JPG)

Użytkownik może polubić zdjęcia innych użytkowników. Koło przycisku "Polub" wyświetla się liczba polubień danego zdjęcia. 
Jeżeli użytkownik ponownie kliknie na ten przycisk polubienie zostanie odebrane.

![polubienie](https://user-images.githubusercontent.com/117681023/224831771-4ee9d3e2-1f06-46ed-b9a9-5b15f1b85bf7.JPG)

Kolejną możliwością użytkownika jest dodawanie komentarzy. Aby dodać komentarz należy kliknąć przycisk "Dodaj komentarz" pod postem.
Po jego kliknięciu pojawia się formularz do wypełnienia treści komentarza. 
Obok przycisku dodania komentarza znajduje się przycisk "Komentarze" do wyświetlania komentarzy danego zdjęcia.

![komentarze](https://user-images.githubusercontent.com/117681023/224831815-0168a681-2f65-4615-b2f5-da284f0943bb.JPG)

Po kliknięciu przycisku "Komentarze" otwiera się widok wyświetlający komentarze danego zdjęcia. Użytkownicy posiadają także możliwość polubienia komentarzy.

![wyswietlanie_komentarzy](https://user-images.githubusercontent.com/117681023/224831870-26ca28f3-5458-4545-8fc5-3443a5f182cb.JPG)

Warto również wspomnieć, że strona posiada mechanizm stronnicowania, dzięki czemu na stronie wyświetlają się jedynie trzy zdjęcia, a aby zobaczyć kolejne trzy należy przejść na kolejną stronę.

![stronnicowanie](https://user-images.githubusercontent.com/117681023/224831928-165e0ced-fca1-4e19-8057-798658e6f3f1.JPG)

# Funkcjonalność aplikacji dla administratora

## Konfiguracja roli admina na serwerze SQL

W pierwszej kolejności za pomocą przycisku do rejestracji tworzymy nowego użytkownika, który będzie posiadał rolę administratora.

W programie do obsługi serwera SQL (_w moim przypadku Microsoft SQL Server Management Studio 18_) w tabeli AspNetRoles dodajemy rolę o nazwie "admin".

![rola_admin](https://user-images.githubusercontent.com/117681023/224832009-25228114-7089-400a-9b2c-4c520ec9c63f.JPG)

Następnie z tabeli AspNetUsers kopiujemy identyfikator użytkownika, któremy chcemy przypisać rolę administratora.
W tabeli AspNetUserRoles przypisujemy danemu identyfikatorowi użytkownika rolę admin.

![przypisanie_roli](https://user-images.githubusercontent.com/117681023/224832073-f9fac5ef-4e60-4de5-806e-a902285cf64d.JPG)

W ten sposób przypisaliśmy danemu użytkownikowi rolę administratora.

## Możliwości administratora w aplikacji

Na samej górze strony obok przycisku do dodawania zdjęcia widnieje przycisk "statystyki", który może kliknąć jedynie użytkownik z rolą administratora.

![statystyki](https://user-images.githubusercontent.com/117681023/224832119-4bdf4582-e390-4a86-af89-4df4756fceee.JPG)

Po jego kliknięciu pojawia się widok z listą wszystkich zdjęć posortowanych po ID wraz z ich informacjami.
W każdym wierszy obok zdjęć widnieją przyciski "Edytuj" oraz "Usuń".
Po kliknięciu przycisku do edycji, administratorowi wyświetla się wypełniony formularz do edycji wybranego zdjęcia (_dane wyświetlane automatycznie w formularzu są starymi danymi zdjęcia_).
Natomiast po kliknięciu przycisku "Usuń" dane zdjęcie zostanie usunięte z bazy danych.

![statystyki_zdjec](https://user-images.githubusercontent.com/117681023/224832170-d3eb737a-fb75-4ab4-87b8-1fdb2cc4b3de.JPG)

# API

Aplikacja obsługuje również technologię API.

Najprościej przetestować działanie API w rozszerzeniu do przeglądarki - narzędziu Boomerang.

* GET wszystkich zdjęć

![get](https://user-images.githubusercontent.com/117681023/224832246-d06a53a8-3974-46b4-8e13-3409a3abc997.JPG)

* GET konkretnego zdjęcia

![get_by_id](https://user-images.githubusercontent.com/117681023/224832290-e381366d-29da-4b2f-8dab-3e16f4b5080b.JPG)

* POST

![post](https://user-images.githubusercontent.com/117681023/224832346-258da519-90f9-4983-ab26-79ff5cc61d40.JPG)

* PUT

![put](https://user-images.githubusercontent.com/117681023/224832389-3aa4a079-8b04-48f7-bda5-54169219aa90.JPG)

* DELETE

![delete](https://user-images.githubusercontent.com/117681023/224832437-2dee0238-9b36-4c3b-8762-593d2f313535.JPG)

# Testowanie aplikacji

W projekcie są również przygotowane testy jednostkowe kontrolera API. Aby je uruchomić należy prawym przyciskiem myszy kliknąć na PhotosControllerTest i wybrać opcję "Uruchom testy".

![testowanie](https://user-images.githubusercontent.com/117681023/224832487-5e81d432-8233-443d-8a06-c53b971bcee8.JPG)
