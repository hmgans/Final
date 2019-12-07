using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class DBSeeder
    {
        public static void Initialize(DataBaseContext context, ApplicationDbContext userContext)
        {

            userContext.Database.EnsureDeleted();
            context.Database.EnsureDeleted();

            context.Database.Migrate();
            context.Database.EnsureCreated();

            userContext.Database.Migrate();
            userContext.Database.EnsureCreated();

            string[] roles = new string[] { "Player", "Administrator"};

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(userContext);
                
                if (!userContext.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            IdentityUser[] users = new IdentityUser[] { 
                new IdentityUser() {UserName= "admin_erin@cs.utah.edu", Email="admin_erin@cs.utah.edu", EmailConfirmed=true}
            };
            foreach (IdentityUser user in users)
            {
                var userStore = new UserStore<IdentityUser>(userContext);
                if (!userContext.Users.Any(r => r.Email == user.Email))
                {
                    userStore.CreateAsync(user);
                    userStore.AddToRoleAsync(user, "Player");
                }
                
            }





            if (context.Levels.Any())
            {
                return;   // DB has been seeded
            }
            var levels = new Level[]
            {
                new Level{BackGroundImage="File1.txt", LevelObsticles="File1.txt" },
                new Level{BackGroundImage="File2.txt", LevelObsticles="File2.txt" },
                new Level{BackGroundImage="File3.txt", LevelObsticles="File3.txt" },
                new Level{BackGroundImage="File4.txt", LevelObsticles="File4.txt" },
                new Level{BackGroundImage="File5.txt", LevelObsticles="File5.txt" },
            };
            foreach (Level s in levels)
            {
                context.Levels.Add(s);
            }
            context.SaveChanges();

            var bots = new Bot[]
            {
                new Bot{LevelID=1,Recording="Recording1.txt",time=100},
                new Bot{LevelID=1,Recording="Recording2.txt",time=200},
                new Bot{LevelID=1,Recording="Recording3.txt",time=300},
                new Bot{LevelID=2,Recording="Recording4.txt",time=100},
                new Bot{LevelID=2,Recording="Recording5.txt",time=200},
                new Bot{LevelID=2,Recording="Recording6.txt",time=300},
                new Bot{LevelID=3,Recording="Recording7.txt",time=100},
                new Bot{LevelID=3,Recording="Recording8.txt",time=200},
                new Bot{LevelID=3,Recording="Recording9.txt",time=300},
                new Bot{LevelID=4,Recording="Recording10.txt",time=100},
                new Bot{LevelID=4,Recording="Recording11.txt",time=200},
                new Bot{LevelID=4,Recording="Recording12.txt",time=300},
                new Bot{LevelID=5,Recording="Recording13.txt",time=100},
                new Bot{LevelID=5,Recording="Recording14.txt",time=200},
                new Bot{LevelID=5,Recording="Recording15.txt",time=300},
            };
            foreach (Bot s in bots)
            {
                context.Bots.Add(s);
            }
            context.SaveChanges();

            var highscores = new HighScore[]
            {
                new HighScore{LevelID=1,recording="Recording16.txt",time=100,UserID=1},
                new HighScore{LevelID=1,recording="Recording17.txt",time=200,UserID=2},
                new HighScore{LevelID=1,recording="Recording18.txt",time=300,UserID=3},
                new HighScore{LevelID=2,recording="Recording19.txt",time=100,UserID=3},
                new HighScore{LevelID=2,recording="Recording20.txt",time=200,UserID=2},
                new HighScore{LevelID=2,recording="Recording21.txt",time=300,UserID=1},
                new HighScore{LevelID=3,recording="Recording22.txt",time=100,UserID=1},
                new HighScore{LevelID=3,recording="Recording23.txt",time=200,UserID=2},
                new HighScore{LevelID=3,recording="Recording24.txt",time=300,UserID=3},
                new HighScore{LevelID=4,recording="Recording25.txt",time=100,UserID=3},
                new HighScore{LevelID=4,recording="Recording26.txt",time=200,UserID=2},
                new HighScore{LevelID=4,recording="Recording27.txt",time=300,UserID=1},
                new HighScore{LevelID=5,recording="Recording28.txt",time=100,UserID=1},
                new HighScore{LevelID=5,recording="Recording29.txt",time=200,UserID=2},
                new HighScore{LevelID=5,recording="Recording30.txt",time=300,UserID=3},
            };
            foreach (HighScore s in highscores)
            {
                context.HighScores.Add(s);
            }
            context.SaveChanges();

            var users1 = new User[]
            {
                new User{Email="h@c.com",Role="Player",UserName="Player1",CurrentLevel=3,NosContainers=0,Nos=false,SkinBlue=false,SkinRed=true,SkinChrome=false,SkinGreen=false,SkinPurple=false,Cash=0},
                new User{Email="h@c.com",Role="Player",UserName="Player2",CurrentLevel=3,NosContainers=1,Nos=true,SkinBlue=true,SkinRed=true,SkinChrome=false,SkinGreen=false,SkinPurple=false,Cash=500},
                new User{Email="h@c.com",Role="Player",UserName="Player3",CurrentLevel=3,NosContainers=10,Nos=true,SkinBlue=false,SkinRed=true,SkinChrome=false,SkinGreen=true,SkinPurple=false,Cash=1000},
            };
            foreach (User s in users1)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();





        }
    }
}
