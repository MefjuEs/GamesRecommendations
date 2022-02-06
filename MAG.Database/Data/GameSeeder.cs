using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAG.Database
{
    public class GameSeeder
    {
        public static void Seed(GameDbContext db)
        {
            db.Database.Migrate();

            List<Game> games = new List<Game>
            {
                new Game
                {
                    Title = "Wiedźmin 3: Dziki Gon",
                    Description = "Trzecia część przygód Geralta z Rivii oparta na prozie Andrzeja Sapkowskiego. Gra rozpoczyna się pół roku po wydarzeniach z poprzedniej części. " +
                    "Wiedźmin Geralt odzyskuje pamięć i rusza na poszukiwanie swoich bliskich, Yennefer z Vengerbergu oraz Ciri. Drogę Geraltowi utrudniają Dziki Gon oraz tocząca się " +
                    "w tle wojna Królestw Północy z Cesarstwem Nilfgaardu.",
                    ReleaseYear = new DateTime(2015, 5, 19),
                    Publisher = "CD Projekt RED",
                    Producer = "CD Projekt RED",
                    Image = "Game_1.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Grand Theft Auto V",
                    Description = "Grand Theft Auto V – kolejna odsłona kultowej serii gangsterskich gier akcji studia Rockstar North – zabiera nas do świata wzorowanego na Kalifornii. " +
                    "W uniwersum Grand Theft Auto stan nosi nazwę San Andreas i składa się między innymi z miasta Los Santos, które stanowi główne miejsce akcji piątki. Tworząc swój świat " +
                    "Rockstar jeszcze raz postanowił sparodiować znaną nam rzeczywistość, ośmieszając ideologie, produkty, zjawiska i zachowania ludzi. Jednocześnie twórcy GTA V " +
                    "postarali się o rozbudowanie swojej produkcji pod każdym względem w stosunku do poprzednich odsłon cyklu.",
                    ReleaseYear = new DateTime(2013, 9, 7),
                    Publisher = "Rockstar Games",
                    Producer = "Rockstar Games",
                    Image = "Game_2.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Mass Effect 2",
                    Description = "Kontynuacja hitowej gry role-playing z 2007 roku. Wydarzenia dzieją się w odległej przyszłości, dwa lata po pierwszej odsłonie serii, a więc w roku 2185. " +
                    "Komandor Shepard po raz kolejny musi stawić czoła zagrożeniu ze strony inteligentnej rasy starożytynch maszyn zwanych Żniwiarzami. Okazuje się, że z obrzeży galaktyki znikają " +
                    "ludzkie kolonie. Głowna postać zmuszona zostaje do zawarcia wątpliwego sojuszu z bezwzględną organizacją Cerberus i wyrusza na samobójczą misję celem odkrycia przyczyn zniknięć wspomnianych planet. ",
                    ReleaseYear = new DateTime(2010, 1, 26),
                    Publisher = "Electronic Arts",
                    Producer = "Bioware",
                    Image = "Game_3.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Star Wars: Battlefront II",
                    Description = "Star Wars: Battlefront II to sequel taktycznej gry akcji, inspirowanej popularnymi produktami spod znaku Battlefield czy Operation Flashpoint. " +
                    "Rozgrywka traktuje o militarnej rywalizacji m.in. Imperium Galaktycznego, Sojuszu Rebeliantów, Galaktycznej Republiki czy Armii Separatystów. W czasie rozgrywki " +
                    "gracz odwiedzi planety z uniwersum Gwiezdnych Wojen, będzie mógł wcielić się w kultowego szturmowca, latać klasycznymi myśliwcami takimi jak X-Wing czy TIE-Fighter, " +
                    "a nawet zostać legendarnym Rycerzem Jedi.",
                    ReleaseYear = new DateTime(2005, 10, 31),
                    Publisher = "LucasArts",
                    Producer = "Pandemic Studios",
                    Image = "Game_4.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Counter Strike: Global Offensive",
                    Description = "Counter-Strike: Global Offensive to kolejna, po Counter-Strike: Source, próba odświeżenia tej popularnej strzelanki, która zaczynała jako modyfikacja " +
                    "Half-Life. Mimo upływu lat, nie zmienia się filozofia rozgrywki - nadal do czynienia mamy z drużynową grą akcji. Naprzeciw stają dwa zespoły - terroryści oraz próbujące " +
                    "ich powstrzymać siły specjalne. Za każdego wyeliminowanego przeciwnika nagradzani jesteśmy gotówką, za którą na początku kolejnej rundy możemy kupić lepszą broń i uzbrojenie.",
                    ReleaseYear = new DateTime(2012, 8, 21),
                    Publisher = "Valve",
                    Producer = "Valve",
                    Image = "Game_5.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Heroes of the Storm",
                    Description = "Heroes of the Storm to odpowiedź firmy Blizzard Entertainment na cieszące się dużą popularnością gry z gatunku MOBA (League of Legends, Dota 2 i inne). " +
                    "Akcja Heroes of the Storm toczy się w fikcyjnej krainie Nexus, w którym zderzają się uniwersa serii Diablo, StarCraft, Warcraft oraz inne, znane z gier Blizzarda. Zgodnie " +
                    "z regułą gatunku, zabawa skupia się na pojedynkach kilkuosobowych zespołów. Zadaniem każdej drużyn jest przedrzeć się przez fortyfikacje przeciwnika i zniszczyć jego bazę, " +
                    "a także nie dopuścić, by podobna sztuka udała się rywalom. W grze każdy z graczy kontroluje poczynania jednej postaci z galerii herosów, w której znaleźli się klasyczni " +
                    "bohaterowie z tytułów Blizzarda, m.in. Jim Raynor ze Starcrafta, Deckard Cain z Diablo czy też Arthas i Illidan z uniwersum Warcrafta.",
                    ReleaseYear = new DateTime(2015, 6, 2),
                    Publisher = "Blizzard Entertainment",
                    Producer = "Blizzard Entertainment",
                    Image = "Game_6.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "World of Warcraft: Cataclysm",
                    Description = "WoW: Cataclysm to trzecie fabularne rozszerzenie do bestselerowej gry MMORPG firmy Blizzard Entertainment. Świat Azeroth ulega zmianie po tym jak tytułowy kataklizm " +
                    "sprowadza nań pradawny smok, Deathwing. Bestia dotychczas spoczywała głęboko pod ziemią, jednak tajemnicza moc obudziła w niej gniew i furię. Jego przebudzeniu towarzyszyły potworne " +
                    "burze, sztormy oraz erupcje wulkanów. Wszystko to przyniosło do świata Azeroth zniszczenie, które dotknęło praktycznie wszystkich części uniwersum stworzonego przez Blizzarda.",
                    ReleaseYear = new DateTime(2010, 12, 7),
                    Publisher = "Blizzard Entertainment",
                    Producer = "Blizzard Entertainment",
                    Image = "Game_7.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Call of Duty 4: Modern Warfare",
                    Description = "Call of Duty 4: Modern Warfare to kolejna gra z gatunku FPS, należąca do bestsellerowego cyklu, kojarzonego pierwotnie wyłącznie z II Wojną Światową. " +
                    "W przypadku czwórki utalentowani developerzy z firmy Infinity Ward postanowili jednak zerwać z tradycją, serwując nam konflikt zbrojny z przełomu XX i XXI wieku. " +
                    "Za tą wojenną zawieruchą stoi rosyjski skrajny nacjonalista z nazwiskiem Zakajew, inspirujący światowy terroryzm, celem odwrócenia uwagi mocarstw od swojej próby zagarnięcia " +
                    "władzy w ojczyźnie.",
                    ReleaseYear = new DateTime(2007, 11, 6),
                    Publisher = "Activision",
                    Producer = "Infinity Ward",
                    Image = "Game_8.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Enter the Gungeon",
                    Description = "Enter the Gungeon to dwumiarowe połączenie strzelanki oraz klasycznego dungeon crawlera, w którym przemierzamy losowo generowane podziemia. Za stworzenie tytułu " +
                    "odpowiada debiutujące amerykańskie studio Dodge Roll. W skład pięcioosobowego zespołu wchodzą weterani branży, który postanowili rozpocząć działalność na własny rachunek, " +
                    "tworząc w pełni oryginalną grę. Enter the Gungeon powstało we współpracy z firmą Devolver Digital, jednym z najważniejszych niezależnych wydawców, którzy specjalizują się w " +
                    "produkcjach indie.",
                    ReleaseYear = new DateTime(2016, 4, 5),
                    Publisher = "Devolver Digital",
                    Producer = "Dodge Roll",
                    Image = "Game_9.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Wiedźmin 2: Zabójcy Królów",
                    Description = "Kontynuacja przygód wiedźmina Geralta oparta na prozie Andrzeja Sapkowskiego. Królestwa Północy pogrążają się w chaosie po tym jak zamordowany zostaje król Demawend z Aedirn, " +
                    "a wkrótce potem Foltest z Temerii. Zaistniałą sytuację postanawiają wykorzystać Radowid z Redanii i Henselt z Kaedwen, wszczynając tarcia graniczne z innymi królestwami, wszystkiemu także " +
                    "przygląda się z cienia Cesarstwo Nilfgaardu. W te wydarzenia zamieszany zostaje Geralt z Rivii, który w trakcie historii przedstawionej w grze spróbuje ujawnić kim jest tajemniczy królobójca. " +
                    "W czasie fabuły legendarny Biały Wilk zostanie wciągnięty w zawiłą i pełną niebezpieczeństw polityczną intrygę, a jego decyzje zaważą o losach Królestw Północy.",
                    ReleaseYear = new DateTime(2011, 4, 17),
                    Publisher = "CD Projekt RED",
                    Producer = "CD Projekt RED",
                    Image = "Game_10.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Total War: THREE KINGDOMS",
                    Description = "Total War: THREE KINGDOMS to pierwsza gra w wielokrotnie nagradzanej serii strategii przedstawiająca epicki konflikt w starożytnych Chinach. Gra łączy znane z poprzednich " +
                    "odsłon serii turowe budowanie imperium i zarządzanie państwem z podbojami i oszałamiającymi bitwami w czasie rzeczywistym. Fabularnie przenosimy się do Chin w 190 roku naszej ery, " +
                    "czyli do początku okresu Trzech Królestw, epoki legendarnych podbojów i bohaterów. Wciel się w takie osławione legendami postacie jak Cao Cao, Liu Bei czy Lu Bu i zjednocz pogrążone w wojnie " +
                    "domowej Chiny.",
                    ReleaseYear = new DateTime(2019, 5, 23),
                    Publisher = "SEGA",
                    Producer = "Creative Assembly",
                    Image = "Game_11.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Dark Souls III",
                    Description = "Utrzymana w konwencji dark fantasy gra z gatunku RPG akcji wyprodukowana przez japońskie studio From Software. Akcja Dark Souls toczy się w uniwersum utrzymanym w stylistyce " +
                    "średniowiecznego fantasy i inspirowanym kilkoma motywami. Ponownie są to takie aspekty jak rycerze i królowie, śmierć i podziemia, czy chociażby ogień i chaos.",
                    ReleaseYear = new DateTime(2016, 3, 24),
                    Publisher = "Namco Bandai Entertainment",
                    Producer = "From Software",
                    Image = "Game_12.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "F1 2020",
                    Description = "F1 2020 to najbardziej wszechstronna gra o F1 w historii. Wciska graczy prosto w fotel kierowcy, by mogli się ścigać z najlepszymi zawodnikami świata takimi jak Lewis Hamilton " +
                    "czy Max Verstappen. Po raz pierwszy możesz założyć własny zespół F1® – stworzyć kierowcę, wybrać sponsora i dostawcę silnika, a następnie zatrudnić drugiego kierowcę i wspólnie stanąć " +
                    "w szranki jako jedenasta stajnia. Rozbudowuj siedzibę i rozwijaj zespół, by z czasem stanąć na szczycie.",
                    ReleaseYear = new DateTime(2020, 7, 9),
                    Publisher = "Codemasters",
                    Producer = "Codemasters",
                    Image = "Game_13.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Football Manager 2020",
                    Description = "Szesnasta głowna odsłona cyklu serii menadżerów piłkarskich stworzona przez studio Sports Interactive. W grze wcielamy się w menadżera piłkarskiego wybranego klubu i odpowiadamy " +
                    "za każdy aspekt jego funkcjonowania. Do wyboru mamy ponad 2500 klubów z 50 krajów. Podczas rozgrywki pozyskujemy i sprzedajemy piłkarzy, których w grze jest ponad pół miliona, ustalamy " +
                    "reżimy treningowe zawodników i dobieramy taktykę na kolejne spotkania. Sprawdzianem naszych umiejętności menadżerskich są symulowane mecze, podczas których przeprowadzamy zmiany i motywujemy " +
                    "naszych piłkarzy do lepszej gry, co nie zawsze może im się podobać.",
                    ReleaseYear = new DateTime(2019, 11, 19),
                    Publisher = "SEGA",
                    Producer = "Sports Interactive",
                    Image = "Game_14.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Halo: Combat Evolved",
                    Description = "Każda epicka przygoda ma swój początek. Pierwsza odsłona cyklu przygód Master Chiefa - jednego z najbardziej rozpoznawalnych bohaterów gier wideo. Futurystyczna gra akcji, " +
                    "której fabuła opowiada o konflikcie między ludźmi i obcymi. Gracz staje się członkiem elitarnej formacji bojowej Spartan, która cały czas zbrojnie zmaga się ze śmiertelnie niebezpiecznym " +
                    "dla ludzi obcym imperium. W czasie gry walki toczą się na mistycznym świecie - pierścieniu, tytułowym Halo. Gracz ma za zadanie odkryć tajemnice owego świata.",
                    ReleaseYear = new DateTime(2001, 11, 15),
                    Publisher = "Microsoft Studios",
                    Producer = "Bungie Software",
                    Image = "Game_15.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Left 4 Dead",
                    Description = "Ukierunkowana na zabawę w trybie kooperacji pierwszoosobowa gra akcji, stanowiąca oryginalne połącznie koncepcji sieciowych strzelanek pokroju Counter-Strike'a z elementami " +
                    "popularnych survival horrorów. Fabuła toczy się w Stanach Zjednoczonych ogarniętych chaosem po tym jak złośliwy wirus wyrwał się spod kontroli i zaatakował ludzkość zamieniając ludzi w " +
                    "popularne zombie. W grze wcielamy się w jedną z czterech dostępnych postaci, które są odporne na zaraze, a naszym zadaniem jest wydostanie się z opresji. Do wyboru mamy rozegranie kilku " +
                    "kampanii fabularnych, z których każda toczy się w innej scenerii.",
                    ReleaseYear = new DateTime(2008, 11, 18),
                    Publisher = "Valve",
                    Producer = "Turtle Rock",
                    Image = "Game_16.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "League of Legends",
                    Description = "Ciesząca się olbrzymią popularnością gra typu MOBA, wyprodukowana przez studio Riot Games. Akcja League of Legends osadzona została w fantastycznym świecie Valoran, którym " +
                    "przez wieki targały krwawe wojny. W grze akcję obserwujemy z prespektywy izometrycznej. Zabawa zaczyna się od wybrania bohatera, którym będziemy kierowali w danym starciu. Do wyboru mamy " +
                    "ponad stu bohaterów, a każdy z nich dysponuje innymi umiejętnościami. Następnie trafiamy na zamkniętą arenę, gdzie w towarzystwie kilku innych graczy ścieramy się z przeciwną drużyną.",
                    ReleaseYear = new DateTime(2009, 10, 6),
                    Publisher = "Riot Games",
                    Producer = "Riot Games",
                    Image = "Game_17.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "StarCraft",
                    Description = "StarCraft jest pierwszą odsłoną serii strategii czasu rzeczywistego osadzonej w dalekiej przyszłości, wyprodukowaną przez studio Blizzard. Akcja została osadzona w daleko leżącym " +
                    "od naszej planety Sektorze Koprulu, w którym o wpływy walczą ze sobą trzy frakcje - reprezentująca ludzkość Konfederacja Terran, wyniosła i tajemnicza rasa Protossów oraz pożerający wszelkie " +
                    "życie Zergowie. Do naszej dyspozycji oddano trzy kampanie fabularne opowiadające wydarzenia z perspektywy kolejno wcześniej wymienionych frakcji. Wielowątkowa historia jest przepełniona zwrotami " +
                    "akcji, a opowieści zaprezentowane w każdej kampanii wzajemnie się uzupełniając, wspólnie tworząc obszerny, spójny scenariusz.",
                    ReleaseYear = new DateTime(1998, 3, 28),
                    Publisher = "Blizzard Entertainment",
                    Producer = "Blizzard Entertainment",
                    Image = "Game_18.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Portal 2",
                    Description = "Druga część oryginalnej, pierwszoosobowej gry logicznej studia Valve. Akcja tytułu rozgrywa się kilkaset lat po wydarzeniach znanych z pierwszej odsłony. Nasze akcje z pierwszej " +
                    "części gry spowodowały przebudzenie dziesiątek rdzeni osobowości, jednym z takich SI jest Wheatley, który znudzony monotonią Aperture Laboratories postanawia wydostać się na zewnątrz. W tym celu " +
                    "budzi Chell, bohaterkę z pierwszego Portala, w którą ponownie wciela się gracz, i proponuje nam wspólną ucieczkę. Niestety sytuacja szybko wymyka się spod kontroli, a duet bohaterów " +
                    "znów zostaje poddany logicznym testom znanym z poprzedniej odsłony serii.",
                    ReleaseYear = new DateTime(2011, 4, 19),
                    Publisher = "Electronic Arts",
                    Producer = "Valve",
                    Image = "Game_19.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
                new Game
                {
                    Title = "Call of Duty: Modern Warfare 2",
                    Description = "Kontynuacja wydarzeń znanych z Call of Duty 4 z 2007 roku. Akcja ponownie przenosi nas do fikcyjnego konfliktu zbrojnego rozgrywającego się na świecie w XXI wieku. " +
                    "Po wydarzeniach z poprzedniej odsłony, władzę w Rosji zdobywają ultranacjonaliści, którzy pod pretekstem rzekomo dokonanej na moskiewskim lotnisku rzezi przez amerykańskich agentów " +
                    "doprowadzają do otwartej wojny i inwazji Rosji na Stany Zjednoczone. W czasie gdy amerykańska armia odpiera inwazję, specjalna międzynarodowa jednostka Task Force 141 otrzymuje rozkaz " +
                    "wytropienia przywódcy terrorystów odpowiedzialnych za konflikt, Władimira Makarowa.",
                    ReleaseYear = new DateTime(2009, 11, 5),
                    Publisher = "Activision",
                    Producer = "Infinity Ward",
                    Image = "Game_20.jpg",
                    AverageRating = 0.0,
                    NumberOfVotes = 0,
                },
            };

            List<Genre> genres = new List<Genre>
            {
                new Genre()
                {
                    Name = "RPG",
                    Icon = "fa fa-magic"
                },
                new Genre()
                {
                    Name = "Fantasy",
                    Icon = "fa fa-hat-wizard"
                },
                new Genre()
                {
                    Name = "FPP",
                    Icon = "fa fa-eye"
                },
                new Genre()
                {
                    Name = "TPP",
                    Icon = "fa fa-street-view"
                },
                new Genre()
                {
                    Name = "Shooter",
                    Icon = "fa fa-bullseye"
                },
                new Genre()
                {
                    Name = "Action",
                    Icon = "fa fa-rocket"
                },
                new Genre()
                {
                    Name = "Multiplayer",
                    Icon = "fa fa-people-carry"
                },
                new Genre()
                {
                    Name = "Science Fiction",
                    Icon = "fa fa-hand-spock"
                },
                new Genre()
                {
                    Name = "RTS",
                    Icon = "fa fa-industry"
                },
                new Genre()
                {
                    Name = "MOBA",
                    Icon = "fa fa-dice-d6"
                },
                new Genre()
                {
                    Name = "MMO",
                    Icon = "fa fa-globe"
                },
                new Genre()
                {
                    Name = "Arcade",
                    Icon = "fa fa-gamepad"
                },
                new Genre()
                {
                    Name = "Sport",
                    Icon = "fa fa-gamepad"
                },
                new Genre()
                {
                    Name = "Racing",
                    Icon = "fa fa-gamepad"
                },
                new Genre()
                {
                    Name = "Simulator",
                    Icon = "fa fa-gamepad"
                },
            };

            List<Platform> platforms = new List<Platform>
            {
                new Platform()
                {
                    Name = "PC",
                    Icon = "fas fa-desktop"
                },
                new Platform()
                {
                    Name = "Xbox ONE",
                    Icon = "fab fa-xbox"
                },
                new Platform()
                {
                    Name = "Xbox 360",
                    Icon = "fab fa-xbox"
                },
                new Platform()
                {
                    Name = "PS2",
                    Icon = "fab fa-playstation"
                },
                new Platform()
                {
                    Name = "PS3",
                    Icon = "fab fa-playstation"
                },
                new Platform()
                {
                    Name = "PS4",
                    Icon = "fab fa-playstation"
                },
            };

            List<GameGenre> gameGenres = new List<GameGenre>
            {
                #region Wiedzmin 3
                new GameGenre()
                {
                    Game = games[0],
                    Genre = genres[0]
                },
                new GameGenre()
                {
                    Game = games[0],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[0],
                    Genre = genres[3]
                },
                #endregion

                #region GTA 5
                new GameGenre()
                {
                    Game = games[1],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[1],
                    Genre = genres[3]
                },
                new GameGenre()
                {
                    Game = games[1],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[1],
                    Genre = genres[6]
                },
                #endregion

                #region Mass Effect 2
                new GameGenre()
                {
                    Game = games[2],
                    Genre = genres[0]
                },
                new GameGenre()
                {
                    Game = games[2],
                    Genre = genres[3]
                },
                new GameGenre()
                {
                    Game = games[2],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[2],
                    Genre = genres[7]
                },
                #endregion

                #region SW Battlefront 2
                new GameGenre()
                {
                    Game = games[3],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[3],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[3],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[3],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[3],
                    Genre = genres[7]
                },
                #endregion

                #region CS GO
                new GameGenre()
                {
                    Game = games[4],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[4],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[4],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[4],
                    Genre = genres[6]
                },
                #endregion

                #region HotS
                new GameGenre()
                {
                    Game = games[5],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[5],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[5],
                    Genre = genres[9]
                },
                #endregion

                #region WoW Cataclysm
                new GameGenre()
                {
                    Game = games[6],
                    Genre = genres[0]
                },
                new GameGenre()
                {
                    Game = games[6],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[6],
                    Genre = genres[3]
                },
                new GameGenre()
                {
                    Game = games[6],
                    Genre = genres[10]
                },
                #endregion

                #region CoD 4
                new GameGenre()
                {
                    Game = games[7],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[7],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[7],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[7],
                    Genre = genres[6]
                },
                #endregion

                #region Gungeon
                new GameGenre()
                {
                    Game = games[8],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[8],
                    Genre = genres[7]
                },
                new GameGenre()
                {
                    Game = games[8],
                    Genre = genres[11]
                },
                #endregion

                #region Wiedzmin 2
                new GameGenre()
                {
                    Game = games[9],
                    Genre = genres[0]
                },
                new GameGenre()
                {
                    Game = games[9],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[9],
                    Genre = genres[3]
                },
                #endregion

                #region Three Kingdoms
                new GameGenre()
                {
                    Game = games[10],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[10],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[10],
                    Genre = genres[8]
                },
                #endregion

                #region Dark Souls
                new GameGenre()
                {
                    Game = games[11],
                    Genre = genres[0]
                },
                new GameGenre()
                {
                    Game = games[11],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[11],
                    Genre = genres[3]
                },
                new GameGenre()
                {
                    Game = games[11],
                    Genre = genres[6]
                },
                #endregion

                #region F1 2020
                new GameGenre()
                {
                    Game = games[12],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[12],
                    Genre = genres[13]
                },
                new GameGenre()
                {
                    Game = games[12],
                    Genre = genres[14]
                },
                #endregion

                #region FM2020
                new GameGenre()
                {
                    Game = games[13],
                    Genre = genres[12]
                },
                new GameGenre()
                {
                    Game = games[13],
                    Genre = genres[14]
                },
                #endregion

                #region Halo CE
                new GameGenre()
                {
                    Game = games[14],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[14],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[14],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[14],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[14],
                    Genre = genres[7]
                },
                #endregion

                #region Left 4 Dead
                new GameGenre()
                {
                    Game = games[15],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[15],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[15],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[15],
                    Genre = genres[6]
                },
                #endregion

                #region LoL
                new GameGenre()
                {
                    Game = games[16],
                    Genre = genres[1]
                },
                new GameGenre()
                {
                    Game = games[16],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[16],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[16],
                    Genre = genres[9]
                },
                #endregion

                #region Starcraft
                new GameGenre()
                {
                    Game = games[17],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[17],
                    Genre = genres[7]
                },
                new GameGenre()
                {
                    Game = games[17],
                    Genre = genres[8]
                },
                #endregion

                #region Portal 2
                new GameGenre()
                {
                    Game = games[18],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[18],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[18],
                    Genre = genres[6]
                },
                new GameGenre()
                {
                    Game = games[18],
                    Genre = genres[7]
                },
                new GameGenre()
                {
                    Game = games[18],
                    Genre = genres[11]
                },
                #endregion

                #region CoD MW2
                new GameGenre()
                {
                    Game = games[19],
                    Genre = genres[2]
                },
                new GameGenre()
                {
                    Game = games[19],
                    Genre = genres[4]
                },
                new GameGenre()
                {
                    Game = games[19],
                    Genre = genres[5]
                },
                new GameGenre()
                {
                    Game = games[19],
                    Genre = genres[6]
                }
                #endregion
            };

            List<GamePlatform> gamePlatforms = new List<GamePlatform>
            {
                #region Wiedzmin 3
                new GamePlatform()
                {
                    Game = games[0],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[0],
                    Platform = platforms[1]
                },
                new GamePlatform()
                {
                    Game = games[0],
                    Platform = platforms[5]
                },
                #endregion

                #region GTA 5
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[1]
                },
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[3]
                },
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[4]
                },
                new GamePlatform()
                {
                    Game = games[1],
                    Platform = platforms[5]
                },
                #endregion

                #region Mass Effect 2
                new GamePlatform()
                {
                    Game = games[2],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[2],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[2],
                    Platform = platforms[4]
                },
                #endregion

                #region SW Battlefront 2
                new GamePlatform()
                {
                    Game = games[3],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[3],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[3],
                    Platform = platforms[3]
                },
                #endregion

                #region CS GO
                new GamePlatform()
                {
                    Game = games[4],
                    Platform = platforms[0]
                },
                #endregion

                #region HotS
                new GamePlatform()
                {
                    Game = games[5],
                    Platform = platforms[0]
                },
                #endregion

                #region WoW Cataclysm
                new GamePlatform()
                {
                    Game = games[6],
                    Platform = platforms[0]
                },
                #endregion

                #region CoD 4
                new GamePlatform()
                {
                    Game = games[7],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[7],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[7],
                    Platform = platforms[4]
                },
                #endregion

                #region Gungeon
                new GamePlatform()
                {
                    Game = games[8],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[8],
                    Platform = platforms[1]
                },
                new GamePlatform()
                {
                    Game = games[8],
                    Platform = platforms[5]
                },
                #endregion

                #region Wiedzmin 2
                new GamePlatform()
                {
                    Game = games[9],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[9],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[9],
                    Platform = platforms[4]
                },
                #endregion

                #region Three Kingdoms
                new GamePlatform()
                {
                    Game = games[10],
                    Platform = platforms[0]
                },
                #endregion

                #region Dark Souls
                new GamePlatform()
                {
                    Game = games[11],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[11],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[11],
                    Platform = platforms[4]
                },
                #endregion

                #region F1 2020
                new GamePlatform()
                {
                    Game = games[12],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[12],
                    Platform = platforms[1]
                },
                new GamePlatform()
                {
                    Game = games[12],
                    Platform = platforms[5]
                },
                #endregion

                #region FM2020
                new GamePlatform()
                {
                    Game = games[13],
                    Platform = platforms[0]
                },
                #endregion

                #region Halo CE
                new GamePlatform()
                {
                    Game = games[14],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[14],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[14],
                    Platform = platforms[3]
                },
                #endregion

                #region Left 4 Dead
                new GamePlatform()
                {
                    Game = games[15],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[15],
                    Platform = platforms[2]
                },
                #endregion

                #region LoL
                new GamePlatform()
                {
                    Game = games[16],
                    Platform = platforms[0]
                },
                #endregion

                #region StarCraft
                new GamePlatform()
                {
                    Game = games[17],
                    Platform = platforms[0]
                },
                #endregion

                #region Portal 2
                new GamePlatform()
                {
                    Game = games[18],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[18],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[18],
                    Platform = platforms[4]
                },
                #endregion

                #region CoD MW2
                new GamePlatform()
                {
                    Game = games[19],
                    Platform = platforms[0]
                },
                new GamePlatform()
                {
                    Game = games[19],
                    Platform = platforms[2]
                },
                new GamePlatform()
                {
                    Game = games[19],
                    Platform = platforms[4]
                },
                #endregion
            };

            if (!db.Games.Any())
            {
                db.AddRange(games);
                db.SaveChanges();
            }

            if (!db.Genres.Any())
            {
                db.AddRange(genres);
                db.SaveChanges();
            }

            if (!db.Platforms.Any())
            {
                db.AddRange(platforms);
                db.SaveChanges();
            }

            if (!db.GameGenres.Any())
            {
                db.AddRange(gameGenres);
                db.SaveChanges();
            }

            if (!db.GamePlatforms.Any())
            {
                db.AddRange(gamePlatforms);
                db.SaveChanges();
            }
        }
    }
}
