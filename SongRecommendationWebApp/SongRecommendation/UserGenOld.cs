using SongRecommendation.Data;
using SongRecommendation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation
{
    public class UsersGenOld
    {
        private readonly ApplicationDbContext _db;
        private Random randomGen;

        public UsersGenOld(ApplicationDbContext db)
        {
            _db = db;
            randomGen = new Random();
        }

        public void GenerateUsers()
        {
            //wczytanie gatunków z bazy do tablicy
            IEnumerable<SongsDb> Songs = _db.SongsDb;
            IEnumerable<Genre> Genres = _db.Genres;
            Random idGen = new Random();

            //wielkosći szacujące częstotliwość wyboru utworu
            //double pop = 6;
            //double classic = 3;
            //double rocky = 4;
            //double strange = 1;
            //double electro = 2;
            var lastUser = (from u in _db.UserRates
                            orderby u.Id descending
                            select u).Take(1).SingleOrDefault();
            var userId = lastUser.UserId + 1;
            int currentId = lastUser.Id + 1;
            //var userId = 1;
            //int currentId = 1;

            //List<genreClassification> genreCounter = new List<genreClassification>();
            //genreCounter.Add(new genreClassification() { genre = "Rocky", count = 0 });
            //genreCounter.Add(new genreClassification() { genre = "Rappy", count = 0 });
            //genreCounter.Add(new genreClassification() { genre = "Strange", count = 0 });
            //genreCounter.Add(new genreClassification() { genre = "Electro", count = 0 });
            //genreCounter.Add(new genreClassification() { genre = "Classic", count = 0 });
            //genreCounter.Add(new genreClassification() { genre = "Pop", count = 0 });

            //int Id = 1;

            for (int i = 1; i < 15000; i++)
            {
                int[] usedId = new int[20];
                for (int j = 0; j < 20; j++)
                {
                    int songId = idGen.Next(0, Songs.Count());
                    //int counter = 0;
                    var song = _db.SongsDb.Find(Convert.ToInt16(songId));

                        while (usedId.Contains<int>(songId) || songId==0)
                        {

                            songId = idGen.Next(0, Songs.Count());
                            if(songId==0)
                            {
                                songId = idGen.Next(1, Songs.Count());
                            }
                            song = _db.SongsDb.Find(Convert.ToInt16(songId));
                        }


                    usedId[j] = songId;

                    //pobranie genre z utworu i podanie typu, aby właściwie obliczono szanse
                    var genre = _db.Genres.SingleOrDefault((Genre => Genre.Genre1 == song.Terms));

                    //wylosowanie oceny na podstawie statystyk
                    int songGrade = getGrade(genre.Type);

                    //zapisanie wyników do obiektu przeznaczonego do zapisania w bazie
                    UserRate user = new UserRate();
                    user.Id = currentId;
                    user.UserId = userId;
                    user.SongId = songId;
                    user.Rate = songGrade;

                    //zapisanie w bazie obiektu
                    _db.UserRates.Add(user);
                    _db.SaveChanges();
                    //Id++;
                    currentId++;
                }
                userId++;

            }


        }
        public int getGrade(string type)
        {
            int grade = 0;
            double chance = randomGen.Next(1, 101);
                if (type.Equals("Pop"))
                {
                    if (chance > 62)
                        grade = 5;
                    else if (chance > 28 && chance <= 62)
                        grade = 4;
                    else if (chance > 20 && chance <= 28)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Rappy"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 53 && chance <= 90)
                        grade = 4;
                    else if (chance > 17 && chance <= 53)
                        grade = 3;
                    else if (chance > 10 && chance <= 17)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Rocky"))
                {
                    if (chance > 61)
                        grade = 5;
                    else if (chance > 28 && chance <= 61)
                        grade = 4;
                    else if (chance > 20 && chance <= 28)
                        grade = 3;
                    else if (chance > 10 && chance <= 20)
                        grade = 2;
                    else if (chance <= 10)
                        grade = 1;
                }
                if (type.Equals("Classic"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 52 && chance <= 90)
                        grade = 4;
                    else if (chance > 18 && chance <= 52)
                        grade = 3;
                    else if (chance > 8 && chance <= 18)
                        grade = 2;
                    else if (chance <= 8)
                        grade = 1;
                }
                if (type.Equals("Electro"))
                {
                    if (chance > 90)
                        grade = 5;
                    else if (chance > 80 && chance <= 90)
                        grade = 4;
                    else if (chance > 70 && chance <= 80)
                        grade = 3;
                    else if (chance > 30 && chance <= 70)
                        grade = 2;
                    else if (chance <= 30)
                        grade = 1;
                }
                if (type.Equals("Strange"))
                {
                    if (chance > 94)
                        grade = 5;
                    else if (chance > 87 && chance <= 94)
                        grade = 4;
                    else if (chance > 80 && chance <= 87)
                        grade = 3;
                    else if (chance > 40 && chance <= 80)
                        grade = 2;
                    else if (chance <= 40)
                        grade = 1;
                }
                return grade;
        }
        public IEnumerable<SongsDb> getSongsToChoose()
        {
            List<SongsDb> songs = new List<SongsDb>();
            string[] releaseIds = new string[10];
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
            for (int i = 0; i < 10; i++)
            {
                var song = _db.SongsDb.SingleOrDefault(SongsDb => SongsDb.SongId == releaseIds[i]);
                songs.Add(song);
            }


            return songs.AsEnumerable();
        }
    }
}