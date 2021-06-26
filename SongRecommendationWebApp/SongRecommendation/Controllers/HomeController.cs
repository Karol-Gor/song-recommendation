using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongRecommendation.Data;
using SongRecommendation.Model;
using SongRecommendation.Models;
using SongRecommendation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SongRecommendationML.Model;
using ClassificationML.Model;
using ModelInputMatrix = SongRecommendationML.Model.ModelInput;

namespace SongRecommendation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
           UsersGen generator = new UsersGen(_db);
           //generator.GenerateUsers();

            IEnumerable<SongsDb> songList = generator.getSongsToChoose();
            var songRate = new SongRateViewModel();
            songRate.Songs = songList;
            return View(songRate);
        }



        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SongRateViewModel obj)
        {
            //dodanie do bazy danych obiektu, który został stowrzony na stronie


            obj.Songs = new UsersGen(_db).getSongsToChoose();
            var lastUser = (from u in _db.UserRates
                            orderby u.Id descending
                            select u).Take(1).SingleOrDefault();
            var userId = lastUser.UserId + 1;
            int currentId = lastUser.Id + 1;
            int[] songIds = new int[10];
            int i = 0;
            foreach (var chosenSong in obj.Songs)
            {
                UserRate user = new UserRate();
                user.UserId = userId;
                user.SongId = chosenSong.Id;
                user.Id = currentId;
                if (i == 0)
                {
                    user.Rate = Convert.ToInt32(obj.Rate0);
                }
                if (i == 1)
                {
                    user.Rate = Convert.ToInt32(obj.Rate1);
                }
                if (i == 2)
                {
                    user.Rate = Convert.ToInt32(obj.Rate2);
                }
                if (i == 3)
                {
                    user.Rate = Convert.ToInt32(obj.Rate3);
                }
                if (i == 4)
                {
                    user.Rate = Convert.ToInt32(obj.Rate4);
                }

                if (i == 5)
                {
                    user.Rate = Convert.ToInt32(obj.Rate5);
                }
                if (i == 6)
                {
                    user.Rate = Convert.ToInt32(obj.Rate6);
                }
                if (i == 7)
                {
                    user.Rate = Convert.ToInt32(obj.Rate7);
                }
                if (i == 8)
                {
                    user.Rate = Convert.ToInt32(obj.Rate8);
                }
                if (i == 9)
                {
                    user.Rate = Convert.ToInt32(obj.Rate9);
                }
                _db.UserRates.Add(user);
                _db.SaveChanges();
                i++;
                currentId++;
            }

            if (obj.algorithm == "matrix")
            {
                return RedirectToAction("Recommend");
            }
            else
            {
                return RedirectToAction("Recommend_Classification");
            }
            
        }

        public IActionResult Recommend()
        {
            var songList = _db.SongsDb.ToList<SongsDb>();
            var lastUser = (from u in _db.UserRates
                            orderby u.Id descending
                            select u).Take(1).SingleOrDefault();
            var LastUserId = lastUser.UserId;
            var top10 = (from s in songList
                         let p = SongRecommendationML.Model.ConsumeModel.Predict(
                            new ModelInputMatrix()
                            {
                                UserId = (float)LastUserId,
                                SongId = s.Id
                            })
                         orderby p.Score descending
                         select (SongId: s.Id, Rate: p.Score)).Take(10);
            List<SongsDb> recommendedSongs = new List<SongsDb>();
            foreach (var s in top10)
            {
                var song = _db.SongsDb.SingleOrDefault(SongsDb => SongsDb.Id == s.SongId);
                recommendedSongs.Add(song);
            }

            Debug.WriteLine(recommendedSongs.Count.ToString());

            return View(recommendedSongs.AsEnumerable());
            //return View();
        }

        public IActionResult Recommend_Classification()
        {
            var songList = _db.SongsDb.ToList<SongsDb>();
            var lastUser = (from u in _db.UserRates
                            orderby u.Id descending
                            select u).Take(1).SingleOrDefault();
            var LastUserId = lastUser.UserId;
            //var input = new ClassificationML.Model.ModelInput();
            //var songtemp = songList.ElementAt(123);
            //input.SongId = songtemp.Id;
            //input.UserId = (float)lastUser.UserId;
            //var recommendation = ClassificationML.Model.ConsumeModel.Predict(input);

            List<SongsDb> recommendedSongs = new List<SongsDb>();
            var top10 = (from s in songList
                         let p = ClassificationML.Model.ConsumeModel.Predict(
                            new ClassificationML.Model.ModelInput()
                            {
                                UserId = (float)LastUserId,
                                SongId = s.Id
                            })
                         orderby p.Prediction descending
                         select (SongId: s.Id, Rate: p.Prediction)).Take(10);

            foreach (var s in top10)
            {
                var song = _db.SongsDb.SingleOrDefault(SongsDb => SongsDb.Id == s.SongId);
                recommendedSongs.Add(song);
            }

            Debug.WriteLine(recommendedSongs.Count.ToString());

            return View(recommendedSongs.AsEnumerable());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
