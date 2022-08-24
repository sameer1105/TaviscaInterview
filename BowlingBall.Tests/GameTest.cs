using System;
using Xunit;

namespace BowlingWithFrame
{
    public class BowlingTest
    {
        [Fact]
        public void GutterBalls()
        {
            //Arrange
            BowlingGame game = new BowlingGame();
            for (int frameNumber = 0; frameNumber < 10; frameNumber++)
                game.OpenFrame(0, 0);
            //ManyOpenFrames(10, 0, 0);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(0, score);
        }

        [Fact]
        public void Threes()
        {
            //Arrange
            BowlingGame game = new BowlingGame();
            for (int frameNumber = 0; frameNumber < 10; frameNumber++)
                game.OpenFrame(3, 3);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(60, score);
        }

        [Fact]
        public void Spare()
        {
            //Arrange
            BowlingGame game = new BowlingGame();
            game.Spare(4, 6);
            for (int frameNumber = 0; frameNumber < 9; frameNumber++)
                game.OpenFrame(3, 3);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(67, score);
           
        }

        [Fact]
        public void Strike()
        {
            //Arrange
            BowlingGame game = new BowlingGame();
            game.Strike();
            game.OpenFrame(5, 3);
            for (int frameNumber = 0; frameNumber < 8; frameNumber++)
                game.OpenFrame(0, 0);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(26, score);
        }

        [Fact]
        public void StrikeFinalFrame()
        {
            //Arrange
            BowlingGame game = new BowlingGame();
            for (int frameNumber = 0; frameNumber < 9; frameNumber++)
                game.OpenFrame(0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(18, score);
        }

        [Fact]
        public void SpareFinalFrame()
        {
            BowlingGame game = new BowlingGame();
            for (int frameNumber = 0; frameNumber < 9; frameNumber++)
                game.OpenFrame(0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(15, score);
        }

        [Fact]
        public void Perfect()
        {
            BowlingGame game = new BowlingGame();
            for (int i = 0; i < 10; i++)
                game.Strike();
            game.BonusRoll(10);
            game.BonusRoll(10);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(300, score);
        }

        [Fact]
        public void Alternating()
        {
            BowlingGame game = new BowlingGame();
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);
            //Act
            int score = game.Score();
            //Assert
            Assert.Equal(200, score);
        }

    }
}