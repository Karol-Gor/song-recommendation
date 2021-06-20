using SongRecommendation.Data;
using SongRecommendation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation
{
    public class genreClassification
        {
        public string genre { get; set; }
        public int count { get; set; }
        }
    public class UsersGen
    {
        private readonly ApplicationDbContext _db;
        private IEnumerable<SongsDb> Songs;
        IEnumerable<Genre> Genres;
        Random randomGen;

        public UsersGen(ApplicationDbContext db)
        {
            _db = db;
            Songs = _db.SongsDb;
            Genres = _db.Genres;
            randomGen = new Random();
        }

        public void GenerateUsers()
        {
            //wczytanie gatunków z bazy do tablicy


            //wielkosći szacujące częstotliwość wyboru utworu
            //double pop = 6;
            //double classic = 3;
            //double rocky = 4;
            //double strange = 1;
            //double electro = 2;

            int Id = 1;

            var lastUser = (from u in _db.UserRates
                            orderby u.Id descending
                            select u).Take(1).SingleOrDefault();
            var userId = lastUser.UserId + 1;
            //var userId = 1;
            int currentId = lastUser.Id + 1;
            //int currentId = 1;

            Trace.WriteLine("Tworzenie bazy danych\n\n");
            Trace.WriteLine("Poniżej zostaną wypisane kolejne id rekordów w bazie \n");
            Trace.WriteLine("Będą to kolejno: ID, USER ID, SONG ID, RATE");




            for (int i = 1; i < 4500; i++)
            {
                List<genreClassification> genreCounter = new List<genreClassification>();
                genreCounter.Add(new genreClassification() { genre = "Rocky", count = 0 });
                genreCounter.Add(new genreClassification() { genre = "Rappy", count = 0 });
                genreCounter.Add(new genreClassification() { genre = "Strange", count = 0 });
                genreCounter.Add(new genreClassification() { genre = "Electro", count = 0 });
                genreCounter.Add(new genreClassification() { genre = "Classic", count = 0 });
                genreCounter.Add(new genreClassification() { genre = "Pop", count = 0 });

                int[] usedId = new int[20];
                string userType = getUserType();
                for (int j = 0; j < 20; j++)
                {
                    int songId = randomGen.Next(0, Songs.Count()-3000);

                    //pobranie utworu na podstawie id z op
                    var song = _db.SongsDb.Find(Convert.ToInt16(songId));

                    int counter = 0;
                    while (usedId.Contains<int>(songId) ||  genreCounter.Find(x => x.genre == _db.Genres.SingleOrDefault((Genre => Genre.Genre1 == song.Terms)).Type).count >= 4)
                    {
                        songId = randomGen.Next(0, Songs.Count()-3000);
                        song = _db.SongsDb.Find(Convert.ToInt16(songId));
                        genreCounter.Find(x => x.genre == _db.Genres.SingleOrDefault((Genre => Genre.Genre1 == song.Terms)).Type).count++;
                    }
                    usedId[j] = songId;


                    //pobranie genre z utworu i podanie typu, aby właściwie obliczono szanse
                    var genre = _db.Genres.SingleOrDefault((Genre => Genre.Genre1 == song.Terms));
                    //wylosowanie oceny na podstawie statystyk
                    int songGrade = getGrade(genre.Type, userType);

                    //zapisanie wyników do obiektu przeznaczonego do zapisania w bazie
                    UserRate user = new UserRate();
                    //user.Id = Id;
                    //user.UserId = i;
                    user.Id = currentId;
                    user.UserId = userId;
                    user.SongId = songId;
                    user.Rate = songGrade;

                    Debug.WriteLine($"{Id}, {i}, {songId}, {songGrade}");

                    //zapisanie w bazie obiektu
                    _db.UserRates.Add(user);
                    _db.SaveChanges();

                    //Id++;
                    currentId++;
                    
                }
                userId++;
            }


        }

        public string getUserType()
        {
            int chance = randomGen.Next(1, 101);
            string userType = "";

            if (chance > 83)
                userType = "Rappy";
            else if (chance > 66 && chance <= 83)
                userType = "Rocky";
            else if (chance > 50 && chance <= 66)
                userType = "Pop";
            else if (chance > 25 && chance <= 50)
                userType = "Classic";
            else if (chance > 12 && chance <= 25)
                userType = "Electro";
            else if (chance <= 12)
                userType = "Strange";

            return userType;

        }

        public int getGrade (string type, string userType)
        {
            int grade = 0;
            Random rand = new Random();
            double chance = rand.Next(1, 101);
            if (userType.Equals("Pop"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 46 && chance <= 70)
                        grade = 3;
                    else if (chance > 23 && chance <= 46)
                        grade = 2;
                    else if (chance <= 23)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 40 && chance <= 60)
                        grade = 3;
                    else if (chance > 20 && chance <= 40)
                        grade = 2;
                    else if (chance <= 20)
                        grade = 1;
                }
                if (type.Equals("Classic"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 47 && chance <= 70)
                        grade = 3;
                    else if (chance > 24 && chance <= 47)
                        grade = 2;
                    else if (chance <= 24)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 54 && chance <= 80)
                        grade = 3;
                    else if (chance > 28 && chance <= 54)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 60 && chance <= 90)
                        grade = 3;
                    else if (chance > 30 && chance <= 60)
                        grade = 2;
                    else if (chance <= 30)
                        grade = 1;
                }
            }
            if (userType.Equals("Rappy"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 46 && chance <= 70)
                        grade = 3;
                    else if (chance > 23 && chance <= 46)
                        grade = 2;
                    else if (chance <= 23)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 40 && chance <= 60)
                        grade = 3;
                    else if (chance > 20 && chance <= 40)
                        grade = 2;
                    else if (chance <= 20)
                        grade = 1;
                }
                if (type.Equals("Classic"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 47 && chance <= 70)
                        grade = 3;
                    else if (chance > 24 && chance <= 47)
                        grade = 2;
                    else if (chance <= 24)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 60 && chance <= 90)
                        grade = 3;
                    else if (chance > 30 && chance <= 60)
                        grade = 2;
                    else if (chance <= 30)
                        grade = 1;
                }
            }
            if (userType.Equals("Rocky"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 56 && chance <= 80)
                        grade = 3;
                    else if (chance > 27 && chance <= 56)
                        grade = 2;
                    else if (chance <= 27)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Classic"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 46 && chance <= 70)
                        grade = 3;
                    else if (chance > 23 && chance <= 46)
                        grade = 2;
                    else if (chance <= 23)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 60 && chance <= 90)
                        grade = 3;
                    else if (chance > 30 && chance <= 60)
                        grade = 2;
                    else if (chance <= 30)
                        grade = 1;
                }
            }
            if (userType.Equals("Classic"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 70 && chance <= 90)
                        grade = 3;
                    else if (chance > 35 && chance <= 70)
                        grade = 2;
                    else if (chance <= 35)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;

                }
                if (type.Equals("Classic"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 85)
                        grade = 5;
                    else if (chance > 70 && chance <= 85)
                        grade = 4;
                    else if (chance > 46 && chance <= 70)
                        grade = 3;
                    else if (chance > 23 && chance <= 46)
                        grade = 2;
                    else if (chance <= 23)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 60 && chance <= 90)
                        grade = 3;
                    else if (chance > 30 && chance <= 60)
                        grade = 2;
                    else if (chance <= 30)
                        grade = 1;
                }
            }
            if (userType.Equals("Electro"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 40 && chance <= 60)
                        grade = 3;
                    else if (chance > 20 && chance <= 40)
                        grade = 2;
                    else if (chance <= 20)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 54 && chance <= 80)
                        grade = 3;
                    else if (chance > 28 && chance <= 54)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;

                }
                if (type.Equals("Classic"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 70 && chance <= 90)
                        grade = 3;
                    else if (chance > 35 && chance <= 70)
                        grade = 2;
                    else if (chance <= 35)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
            }
            if (userType.Equals("Strange"))
            {
                if (type.Equals("Pop"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 54 && chance <= 80)
                        grade = 3;
                    else if (chance > 28 && chance <= 54)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 54 && chance <= 80)
                        grade = 3;
                    else if (chance > 28 && chance <= 54)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 54 && chance <= 80)
                        grade = 3;
                    else if (chance > 28 && chance <= 54)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;

                }
                if (type.Equals("Classic"))
                {
                    if (chance > 95)
                        grade = 5;
                    else if (chance > 90 && chance <= 95)
                        grade = 4;
                    else if (chance > 70 && chance <= 90)
                        grade = 3;
                    else if (chance > 35 && chance <= 70)
                        grade = 2;
                    else if (chance <= 35)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 80)
                        grade = 5;
                    else if (chance > 60 && chance <= 80)
                        grade = 4;
                    else if (chance > 50 && chance <= 60)
                        grade = 3;
                    else if (chance > 28 && chance <= 50)
                        grade = 2;
                    else if (chance <= 28)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 65)
                        grade = 5;
                    else if (chance > 30 && chance <= 65)
                        grade = 4;
                    else if (chance > 20 && chance <= 30)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
            }
            return grade;
        }

        public IEnumerable<SongsDb> getRandomSongs ()
        {
            List<SongsDb> randomSongs = new List<SongsDb>();
            int[] usedSongs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int songId = randomGen.Next(0, Songs.Count());

                while (usedSongs.Contains<int>(songId))
                {
                    songId = randomGen.Next(0, Songs.Count());
                }

                var song = _db.SongsDb.Find(Convert.ToInt16(songId));
                randomSongs.Add(song);
            }
            return randomSongs.AsEnumerable();
        }

         public IEnumerable<SongsDb> getSongsToChoose()
        {
            List<SongsDb> songs = new List<SongsDb>();
            string [] releaseIds = new string[10];
            releaseIds[0] = "SODOLVO12B0B80B2F4";
            releaseIds[1] = "SOLRYQR12A670215BF";
            releaseIds[2] = "SOVQWEN12A8C141BD9";
            releaseIds[3] = "SOGWZBN12A6D4F6AB2";
            releaseIds[4] = "SOBNTXB12A8C1428BA";
            releaseIds[5] = "SOQCUBJ12A8C13FEC6";
            releaseIds[6] = "SOPPEBK12A8C13B9CE";
            releaseIds[7] = "SOMXWZX12A58A7B385";
            releaseIds[8] = "SOMTXLN12AB018977B";
            releaseIds[9] = "SOQIDEF12A8C139B23";
            for (int i =0; i<10; i++)
            {
                var song = _db.SongsDb.SingleOrDefault(SongsDb => SongsDb.SongId == releaseIds[i]);
                songs.Add(song);
            }


            return songs.AsEnumerable();
        }
    }
}

