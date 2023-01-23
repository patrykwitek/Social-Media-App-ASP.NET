# aplikacja_zdjecia_z_wakacji

Zamys�em aplikacji jest wrzucanie w�asnych zdj�� z wakacji na stron�. Inni u�ytkownicy mog� polubi� oraz komentowa� wstawione zdj�cia.

# Przygotowanie aplikacji do uruchomienia

W pierwszej kolejno�ci nale�y okre�li� nazw� serwera oraz nazw� bazy danych w pliku appsettings.json

![appsettings](wwwroot/Images/readme/appsettings.jpg "appsettings")

Nast�pnie w konsoli za pomoc� komend

* add-migration InitialCreate -context AppDbContext
* update-database -context AppDbContext
* add-migration UserInit -context UserContext
* update-database -context UserContext

tworzymy migracje i wysy�amy dane do bazy tworz�c encje

W Microsoft Sql Server Management Studio powinny utworzy� si� tabele

![baza_danych_tabele](wwwroot/Images/readme/baza_danych_tabele.jpg "baza_danych_tabele")

Teraz aplikacja jest gotowa do uruchomienia

# Funkcjonalno�� aplikacji dla u�ytkownika

W prawym g�rnym rogu widniej� przyciski do logowania oraz rejestracji

![logowanie_i_rejestracja](wwwroot/Images/readme/logowanie_i_rejestracja.jpg "logowanie_i_rejestracja")

Po zarejestrowaniu u�ytkownika zostaje on zapisany do bazy danych, mo�na wtedy przyst�pi� do logowania.

Po zalogowaniu w prawym g�rnym rogu aplikacji widnieje nazwa zalogowanego u�ytkownika. Po jego klikni�ciu otwiera si� okno edycji u�ytkownika.

![user](wwwroot/Images/readme/user.jpg "user")

W celu dodania w�asnego zdj�cia na stron� u�ytkownik musi klikn�� przycisk "Dodaj w�asne zdj�cie" na g��wnej stronie.

![dodawanie_zdjecia](wwwroot/Images/readme/dodawanie_zdjecia.jpg "dodawanie_zdjecia")

Po jego klikni�ciu ukazuje si� formularz, po kt�rego wype�nieniu nale�y klikn�� przycisk "Dodaj". 
W ten spos�b u�ytkownik dodaje swoje zdj�cie na stron�. 
Je�eli dane nie zostan� wprowadzone, b�d� wprowadzone b��dnie (_przyk�adowo zbyt du�a liczba znak�w_) zostanie zwr�cony odpowiedni komuniktat.

![formularz_dodawanie_zdjecia](wwwroot/Images/readme/formularz_dodawanie_zdjecia.jpg "formularz_dodawanie_zdjecia")

U�ytkownik mo�e polubi� zdj�cia innych u�ytkownik�w. Ko�o przycisku "Polub" wy�wietla si� liczba polubie� danego zdj�cia. 
Je�eli u�ytkownik ponownie kliknie na ten przycisk polubienie zostanie odebrane.

![polubienie](wwwroot/Images/readme/polubienie.jpg "polubienie")

Kolejn� mo�liwo�ci� u�ytkownika jest dodawanie komentarzy. Aby doda� komentarz nale�y klikn�� przycisk "Dodaj komentarz" pod postem.
Po jego klikni�ciu pojawia si� formularz do wype�nienia tre�ci komentarza. 
Obok przycisku dodania komentarza znajduje si� przycisk "Komentarze" do wy�wietlania komentarzy danego zdj�cia.

![komentarze](wwwroot/Images/readme/komentarze.jpg "komentarze")

Po klikni�ciu przycisku "Komentarze" otwiera si� widok wy�wietlaj�cy komentarze danego zdj�cia. U�ytkownicy posiadaj� tak�e mo�liwo�� polubienia komentarzy.

![wyswietlanie_komentarzy](wwwroot/Images/readme/wyswietlanie_komentarzy.jpg "wyswietlanie_komentarzy")

Warto r�wnie� wspomnie�, �e strona posiada mechanizm stronnicowania, dzi�ki czemu na stronie wy�wietlaj� si� jedynie trzy zdj�cia, a aby zobaczy� kolejne trzy nale�y przej�� na kolejn� stron�.

![stronnicowanie](wwwroot/Images/readme/stronnicowanie.jpg "stronnicowanie")

# Funkcjonalno�� aplikacji dla administratora

## Konfiguracja roli admina na serwerze SQL

W pierwszej kolejno�ci za pomoc� przycisku do rejestracji tworzymy nowego u�ytkownika, kt�ry b�dzie posiada� rol� administratora.

W programie do obs�ugi serwera SQL (_w moim przypadku Microsoft SQL Server Management Studio 18_) w tabeli AspNetRoles dodajemy rol� o nazwie "admin".

![rola_admin](wwwroot/Images/readme/rola_admin.jpg "rola_admin")

Nast�pnie z tabeli AspNetUsers kopiujemy identyfikator u�ytkownika, kt�remy chcemy przypisa� rol� administratora.
W tabeli AspNetUserRoles przypisujemy danemu identyfikatorowi u�ytkownika rol� admin.

![przypisanie_roli](wwwroot/Images/readme/przypisanie_roli.jpg "przypisanie_roli")

W ten spos�b przypisali�my danemu u�ytkownikowi rol� administratora.

## Mo�liwo�ci administratora w aplikacji

Na samej g�rze strony obok przycisku do dodawania zdj�cia widnieje przycisk "statystyki", kt�ry mo�e klikn�� jedynie u�ytkownik z rol� administratora.

![statystyki](wwwroot/Images/readme/statystyki.jpg "statystyki")

Po jego klikni�ciu pojawia si� widok z list� wszystkich zdj�� posortowanych po ID wraz z ich informacjami.
W ka�dym wierszy obok zdj�� widniej� przyciski "Edytuj" oraz "Usu�".
Po klikni�ciu przycisku do edycji, administratorowi wy�wietla si� wype�niony formularz do edycji wybranego zdj�cia (_dane wy�wietlane automatycznie w formularzu s� starymi danymi zdj�cia_).
Natomiast po klikni�ciu przycisku "Usu�" dane zdj�cie zostanie usuni�te z bazy danych.

![statystyki_zdjec](wwwroot/Images/readme/statystyki_zdjec.jpg "statystyki_zdjec")

# API

Aplikacja obs�uguje r�wnie� technologi� API.

Najpro�ciej przetestowa� dzia�anie API w rozszerzeniu do przegl�darki - narz�dziu Boomerang.

* GET wszystkich zdj��

![get](wwwroot/Images/readme/get.jpg "get")

* GET konkretnego zdj�cia

![get_by_id](wwwroot/Images/readme/get_by_id.jpg "get_by_id")

* POST

![post](wwwroot/Images/readme/post.jpg "post")

* PUT

![put](wwwroot/Images/readme/put.jpg "put")

* DELETE

![delete](wwwroot/Images/readme/delete.jpg "delete")

# Testowanie aplikacji

W projekcie s� r�wnie� przygotowane testy jednostkowe kontrolera API. Aby je uruchomi� nale�y prawym przyciskiem myszy klikn�� na PhotosControllerTest i wybra� opcj� "Uruchom testy".

![testowanie](wwwroot/Images/readme/testowanie.jpg "testowanie")