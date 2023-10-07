using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class BownlingTest
    {
        [Fact]
        public void DefaultTest()
        {
            var game = new Game();

            game.Roll(5);
            game.Roll(3);
            Assert.Equal(8, game.GetScore());
            Assert.Equal(1, game.Frames);
        }

        [Fact]
        public void FullGameDefaultTest()
        {
            var game = new Game();

            game.Roll(5);
            game.Roll(3);

            game.Roll(4);
            game.Roll(4);

            game.Roll(3);
            game.Roll(2);

            Assert.Equal(21, game.GetScore());
            Assert.Equal(3, game.Frames);
        }

        [Fact]
        public void SpareTest()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(5);

            game.Roll(3);
            game.Roll(3);

            Assert.Equal(19, game.GetScore());
            Assert.Equal(2, game.Frames);   
        }

        [Fact]
        public void SpareInFullGameTest()
        {
            var game = new Game();
            game.Roll(3);
            game.Roll(3);

            game.Roll(5);
            game.Roll(5);

            game.Roll(3);
            game.Roll(4);

            Assert.Equal(26, game.GetScore());
            Assert.Equal(3, game.Frames);
        }

        [Fact]
        public void StrikeTest()
        {
            var game = new Game();
            game.Roll(10);

            game.Roll(5);
            game.Roll(3);

            Assert.Equal(26, game.GetScore());
            Assert.Equal(2, game.Frames);
        }

        [Fact]
        public void StrikeInFullGameTest()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(3);

            game.Roll(10);

            game.Roll(3);
            game.Roll(3);

            Assert.Equal(30, game.GetScore());
            Assert.Equal(3, game.Frames);
        }

        [Fact]
        public void StrikeWithSpareGameTest()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(3);

            game.Roll(10);

            game.Roll(2);
            game.Roll(2);

            game.Roll(5);
            game.Roll(5);

            game.Roll(1);
            game.Roll(1);

            Assert.Equal(39, game.GetScore());
            Assert.Equal(5, game.Frames);
        }
    }
}
