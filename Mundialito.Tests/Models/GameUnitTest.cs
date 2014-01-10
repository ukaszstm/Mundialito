﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mundialito.Models;

namespace Mundialito.Tests.Models
{
    [TestClass]
    public class GameUnitTest
    {
        [TestMethod]
        public void IsOpenSimpleTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(1));

            Assert.IsFalse(game.IsOpen, "Game should not be open");
        }

        [TestMethod]
        public void IsOpenSameDateTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(5));
            
            Assert.IsTrue(game.IsOpen, "Game should be open");
        }

        [TestMethod]
        public void IsOpenNotSameDateTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date.Subtract(TimeSpan.FromDays(1));
            game.Time = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(5));

            Assert.IsFalse(game.IsOpen, "Game should not be open");
        }

        [TestMethod]
        public void IsOpenNotSameDateTestPastTime()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date.Add(TimeSpan.FromDays(1));
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(5));

            Assert.IsTrue(game.IsOpen, "Game shouldb be open");
        }

        [TestMethod]
        public void MarkNotPlayedTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(5));

            Assert.AreEqual("Not Played", game.Mark);
        }
        
        [TestMethod]
        public void MarkDrawTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(5));
            game.HomeScore = 1;
            game.AwayScore = 1;

            Assert.AreEqual("X", game.Mark);
        }

        [TestMethod]
        public void MarkHomeWinTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(5));
            game.HomeScore = 2;
            game.AwayScore = 1;

            Assert.AreEqual("1", game.Mark);
        }

        [TestMethod]
        public void MarkAwayWinTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(5));
            game.HomeScore = 1;
            game.AwayScore = 2;

            Assert.AreEqual("2", game.Mark);
        }

        [TestMethod]
        public void MarkNotScoreTest()
        {
            var game = new Game();
            game.Date = DateTime.Now.Date;
            game.Time = DateTime.Now.TimeOfDay.Subtract(TimeSpan.FromMinutes(5));
            
            Assert.AreEqual("X", game.Mark);
        }

    }
}