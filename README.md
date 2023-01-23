# aplikacja_zdjecia_z_wakacji

Zamys³em aplikacji jest wrzucanie w³asnych zdjêæ z wakacji na stronê. Inni u¿ytkownicy mog¹ polubiæ oraz komentowaæ wstawione zdjêcia.

# Przygotowanie aplikacji do uruchomienia

W pierwszej kolejnoœci nale¿y okreœliæ nazwê serwera oraz nazwê bazy danych w pliku appsettings.json

![appsettings](wwwroot/Images/readme/appsettings.jpg "appsettings")

Nastêpnie w konsoli za pomoc¹ komend

* add-migration InitialCreate -context AppDbContext
* update-database -context AppDbContext
* add-migration UserInit -context UserContext
* update-database -context UserContext

tworzymy migracje i wysy³amy dane do bazy tworz¹c encje

W Microsoft Sql Server Management Studio powinny utworzyæ siê tabele

![baza_danych_tabele](wwwroot/Images/readme/baza_danych_tabele.jpg "baza_danych_tabele")

Teraz aplikacja jest gotowa do uruchomienia

# Funkcjonalnoœæ aplikacji dla u¿ytkownika

W prawym górnym rogu widniej¹ przyciski do logowania oraz rejestracji

![logowanie_i_rejestracja](wwwroot/Images/readme/logowanie_i_rejestracja.jpg "logowanie_i_rejestracja")

Po zarejestrowaniu u¿ytkownika zostaje on zapisany do bazy danych, mo¿na wtedy przyst¹piæ do logowania.

Po zalogowaniu w prawym górnym rogu aplikacji widnieje nazwa zalogowanego u¿ytkownika. Po jego klikniêciu otwiera siê okno edycji u¿ytkownika.

![user](wwwroot/Images/readme/user.jpg "user")

W celu dodania w³asnego zdjêcia na stronê u¿ytkownik musi klikn¹æ przycisk "Dodaj w³asne zdjêcie" na g³ównej stronie.

![dodawanie_zdjecia](wwwroot/Images/readme/dodawanie_zdjecia.jpg "dodawanie_zdjecia")

Po jego klikniêciu ukazuje siê formularz, po którego wype³nieniu nale¿y klikn¹æ przycisk "Dodaj". 
W ten sposób u¿ytkownik dodaje swoje zdjêcie na stronê. 
Je¿eli dane nie zostan¹ wprowadzone, b¹dŸ wprowadzone b³êdnie (_przyk³adowo zbyt du¿a liczba znaków_) zostanie zwrócony odpowiedni komuniktat.

![formularz_dodawanie_zdjecia](wwwroot/Images/readme/formularz_dodawanie_zdjecia.jpg "formularz_dodawanie_zdjecia")

U¿ytkownik mo¿e polubiæ zdjêcia innych u¿ytkowników. Ko³o przycisku "Polub" wyœwietla siê liczba polubieñ danego zdjêcia. 
Je¿eli u¿ytkownik ponownie kliknie na ten przycisk polubienie zostanie odebrane.

![polubienie](wwwroot/Images/readme/polubienie.jpg "polubienie")

Kolejn¹ mo¿liwoœci¹ u¿ytkownika jest dodawanie komentarzy. Aby dodaæ komentarz nale¿y klikn¹æ przycisk "Dodaj komentarz" pod postem.
Po jego klikniêciu pojawia siê formularz do wype³nienia treœci komentarza. 
Obok przycisku dodania komentarza znajduje siê przycisk "Komentarze" do wyœwietlania komentarzy danego zdjêcia.

![komentarze](wwwroot/Images/readme/komentarze.jpg "komentarze")

Po klikniêciu przycisku "Komentarze" otwiera siê widok wyœwietlaj¹cy komentarze danego zdjêcia. U¿ytkownicy posiadaj¹ tak¿e mo¿liwoœæ polubienia komentarzy.

![wyswietlanie_komentarzy](wwwroot/Images/readme/wyswietlanie_komentarzy.jpg "wyswietlanie_komentarzy")

Warto równie¿ wspomnieæ, ¿e strona posiada mechanizm stronnicowania, dziêki czemu na stronie wyœwietlaj¹ siê jedynie trzy zdjêcia, a aby zobaczyæ kolejne trzy nale¿y przejœæ na kolejn¹ stronê.

![stronnicowanie](wwwroot/Images/readme/stronnicowanie.jpg "stronnicowanie")

# Funkcjonalnoœæ aplikacji dla administratora

## Konfiguracja roli admina na serwerze SQL

W pierwszej kolejnoœci za pomoc¹ przycisku do rejestracji tworzymy nowego u¿ytkownika, który bêdzie posiada³ rolê administratora.

W programie do obs³ugi serwera SQL (_w moim przypadku Microsoft SQL Server Management Studio 18_) w tabeli AspNetRoles dodajemy rolê o nazwie "admin".

![rola_admin](wwwroot/Images/readme/rola_admin.jpg "rola_admin")

Nastêpnie z tabeli AspNetUsers kopiujemy identyfikator u¿ytkownika, któremy chcemy przypisaæ rolê administratora.
W tabeli AspNetUserRoles przypisujemy danemu identyfikatorowi u¿ytkownika rolê admin.

![przypisanie_roli](wwwroot/Images/readme/przypisanie_roli.jpg "przypisanie_roli")

W ten sposób przypisaliœmy danemu u¿ytkownikowi rolê administratora.

## Mo¿liwoœci administratora w aplikacji

Na samej górze strony obok przycisku do dodawania zdjêcia widnieje przycisk "statystyki", który mo¿e klikn¹æ jedynie u¿ytkownik z rol¹ administratora.

![statystyki](wwwroot/Images/readme/statystyki.jpg "statystyki")

Po jego klikniêciu pojawia siê widok z list¹ wszystkich zdjêæ posortowanych po ID wraz z ich informacjami.
W ka¿dym wierszy obok zdjêæ widniej¹ przyciski "Edytuj" oraz "Usuñ".
Po klikniêciu przycisku do edycji, administratorowi wyœwietla siê wype³niony formularz do edycji wybranego zdjêcia (_dane wyœwietlane automatycznie w formularzu s¹ starymi danymi zdjêcia_).
Natomiast po klikniêciu przycisku "Usuñ" dane zdjêcie zostanie usuniête z bazy danych.

![statystyki_zdjec](wwwroot/Images/readme/statystyki_zdjec.jpg "statystyki_zdjec")

# API

Aplikacja obs³uguje równie¿ technologiê API.

Najproœciej przetestowaæ dzia³anie API w rozszerzeniu do przegl¹darki - narzêdziu Boomerang.

* GET wszystkich zdjêæ

![get](wwwroot/Images/readme/get.jpg "get")

* GET konkretnego zdjêcia

![get_by_id](wwwroot/Images/readme/get_by_id.jpg "get_by_id")

* POST

![post](wwwroot/Images/readme/post.jpg "post")

* PUT

![put](wwwroot/Images/readme/put.jpg "put")

* DELETE

![delete](wwwroot/Images/readme/delete.jpg "delete")

# Testowanie aplikacji

W projekcie s¹ równie¿ przygotowane testy jednostkowe kontrolera API. Aby je uruchomiæ nale¿y prawym przyciskiem myszy klikn¹æ na PhotosControllerTest i wybraæ opcjê "Uruchom testy".

![testowanie](wwwroot/Images/readme/testowanie.jpg "testowanie")