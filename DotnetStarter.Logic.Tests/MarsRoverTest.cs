using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class MarsRoverTest
    {
        private readonly Tuple<List<int>, List<int>> map = 
            new (new List<int> { 1, 2, 3, 4 }, new List<int> { 1, 2, 3, 4 });

        [Fact]
        public void MoveRoverForward()
        {
            char[] commands = { 'f', 'f' };
            Rover rover = new Rover(1, 1, map);
            rover.Move(commands);

            Assert.Equal(1, rover.x);
            Assert.Equal(3, rover.y);
        }

        [Fact]
        public void MoveRoverBackward()
        {
            char[] commands = { 'b', 'b' };
            Rover rover = new Rover(1, 3, map);
            rover.Move(commands);

            Assert.Equal(1, rover.x);
            Assert.Equal(1, rover.y);
        }

        [Fact]
        public void MoveRoverLeft()
        {
            char[] commands = { 'l', 'l' };
            Rover rover = new Rover(3, 1, map);
            rover.Move(commands);

            Assert.Equal(1, rover.x);
            Assert.Equal(1, rover.y);
        }

        [Fact]
        public void MoveRoverRight()
        {
            char[] commands = { 'r', 'r' };
            Rover rover = new Rover(1, 1, map);
            rover.Move(commands);

            Assert.Equal(3, rover.x);
            Assert.Equal(1, rover.y);
        }

        [Fact]
        public void MoveRoverForwardWrappingEdges()
        {
            char[] commands = { 'f' };
            Rover rover = new Rover(1, 4, map);
            rover.Move(commands);

            Assert.Equal(1, rover.x);
            Assert.Equal(1, rover.y);
        }

        [Fact]
        public void MoveRoverBackwardWrappingEdges()
        {
            char[] commands = { 'b', 'b' };
            Rover rover = new Rover(1, 1, map);
            rover.Move(commands);

            Assert.Equal(1, rover.x);
            Assert.Equal(3, rover.y);
        }

        [Fact]
        public void MoveRoverLeftWrappingEdges()
        {
            char[] commands = { 'l' };
            Rover rover = new Rover(1, 1, map);
            rover.Move(commands);

            Assert.Equal(4, rover.x);
            Assert.Equal(1, rover.y);
        }

        [Fact]
        public void MoveRoverRightWrappingEdges()
        {
            char[] commands = { 'r', 'r' };
            Rover rover = new Rover(4, 1, map);
            rover.Move(commands);

            Assert.Equal(2, rover.x);
            Assert.Equal(1, rover.y);
        }
    }
}
