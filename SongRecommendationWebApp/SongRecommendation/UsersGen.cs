using SongRecommendation.Data;
using SongRecommendation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation
{
    public class UsersGen
    {
        private readonly ApplicationDbContext _db;
        private IEnumerable<SongsDb> Songs;
        IEnumerable<Genre> Genres;

        public UsersGen(ApplicationDbContext db)
        {
            _db = db;
            Songs = _db.SongsDb;
            Genres = _db.Genres;
        }

        public void GenerateUsers ()
        {
            //wczytanie gatunków z bazy do tablicy


            //wielkosći szacujące częstotliwość wyboru utworu
            //double pop = 6;
            //double classic = 3;
            //double rocky = 4;
            //double strange = 1;
            //double electro = 2;

            Random idGen = new Random();
            Random gradeGen = new Random();
            int Id = 1;

            Trace.WriteLine("Tworzenie bazy danych\n\n");
            Trace.WriteLine("Poniżej zostaną wypisane kolejne id rekordów w bazie \n");
            Trace.WriteLine("Będą to kolejno: ID, USER ID, SONG ID, RATE");

            for (int i = 1; i < 501; i++)
            {
                int[] usedId = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    int songId = idGen.Next(0, Songs.Count());
                    while (usedId.Contains<int>(songId))
                    {
                        songId = idGen.Next(0, Songs.Count());
                    }
                    usedId[j] = songId;
                    //pobranie utworu na podstawie id z op
                    var song = _db.SongsDb.Find(Convert.ToInt16(songId));

                    //pobranie genre z utworu i podanie typu, aby właściwie obliczono szanse
                    var genre = _db.Genres.SingleOrDefault((Genre => Genre.Genre1 == song.Terms));

                    //wylosowanie oceny na podstawie statystyk
                    int songGrade = getGrade(genre.Type);

                    //zapisanie wyników do obiektu przeznaczonego do zapisania w bazie
                    UserRate user = new UserRate();
                    user.Id = Id;
                    user.UserId = i;
                    user.SongId = songId;
                    user.Rate = songGrade;

                    Debug.WriteLine($"{Id}, {i}, {songId}, {songGrade}");

                    //zapisanie w bazie obiektu
                    _db.UserRates.Add(user);
                    _db.SaveChanges();

                    Id++;
                }

            }


        }
        public int getGrade (string type)
        {
            int grade = 0;
            Random rand = new Random();
            double chance = rand.Next(1, 101);
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
                if (chance > 70)
                    grade = 5;
                else if (chance > 40 && chance <= 70)
                    grade = 4;
                else if (chance > 27 && chance <= 40)
                    grade = 3;
                else if (chance > 14 && chance <= 27)
                    grade = 2;
                else if (chance <= 14)
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
            return grade;
        }

        public IEnumerable<SongsDb> getRandomSongs ()
        {
            List<SongsDb> randomSongs = new List<SongsDb>();
            Random rand = new Random();
            int[] usedSongs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int songId = rand.Next(0, Songs.Count());

                while (usedSongs.Contains<int>(songId))
                {
                    songId = rand.Next(0, Songs.Count());
                }

                var song = _db.SongsDb.Find(Convert.ToInt16(songId));
                randomSongs.Add(song);
            }
            return randomSongs.AsEnumerable();
        }
    }
}

