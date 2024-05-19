# Online-Shopping-Platform-finalproject_TAP
Aceasta este o aplicație de comerț electronic dezvoltată folosind .NET pentru backend și Blazor pentru frontend.

Features
Afișare Produse: Produsele sunt afișate cu imagini, descrieri și prețuri.
Coș de Cumpărături: Utilizatorii pot adăuga și elimina articole din coșul de cumpărături.
Plasare Comenzi și Plăți: Utilizatorii pot plasa comenzi și efectua plăți securizate.

Getting started

*Clonarea repository-ului
*Configurarea Bazei de Date:

Asigură-te că SQL Server este instalat și configurat.
Creează o bază de date nouă numită Shop3 în SSMS.
Actualizează string-ul de conexiune din appsettings.json pentru a se potrivi cu configurația ta locală.

*Pentru a deschide proiectul, selectati Multiple Startup Projects in Visual Studio.
Aplicatia prezinta un Magazin Online, avand expuse o parte din toate categoriile de produse in pagina principala, iar, separat, dand click pe fiecare categorie in parte, aceastea pot fi vazute in intregime.
Pentru procesarea platii trebuie apasat pe butonul cu Debit Card, in care adaugati datele urmatorului card fictiv generat in PayPal Developer:
*Card number: 4020029138779241
*Expiry date: 01/2028
*CVC code: 212
(Butonul din partea dreapta sus cu ShoppingCart nu functioneaza, pentru a accesa cosul de cumparaturi, apasati ShoppingCart din partea stanga a paginii, aflat sub categoriile de produse)

