using System.Collections.Generic;
using System.Globalization;
using KataNetHack.Console.Maps;

namespace KataNetHack.Tests
{
    public class StageItemBuilder
    {
        private int NumberItems => _width*_height;
        private int _exitPosition;
        private int _startPosition;
        private int _width = 10;
        private int _height = 10;

        public StageItemBuilder WithWidth(int width)
        {
            _width = width;
            return this;
        }

        public StageItemBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public StageItemBuilder WithStartPosition(int x, int y)
        {
            _startPosition = ListMatrix.Position(x, y, _width, NumberItems);
            return this;
        }

        public IEnumerable<char> Build()
        {
            if (_startPosition == 0)
            {
                _startPosition = CalculateAnStartPoistion();
            }
            if (_exitPosition == 0)
            {
                _exitPosition = CalculateAnExitPoistion();
            }
            for (int i = 0; i < NumberItems; i++)
            {
                if (IsTopWall(i) || IsBottomWall(i) || IsLeftWall(i) || IsRightWall(i))
                {
                    yield return '=';
                }
                else if (i == _exitPosition)
                {
                    yield return '*';
                }
                else if (i == _startPosition)
                {
                    yield return '!';
                }
                else
                {
                    yield return ' ';
                }
            }

        }

        private int CalculateAnStartPoistion()
        {
            if (_height <= 1 && _width > 2)
                return 0;
            if (_height <= 1 && _width > 2)
                return 1;
            return _width + 1;
        }

        private int CalculateAnExitPoistion()
        {
            return NumberItems - _width - 2;// 1 for zero based index and 1 for rigt side wall
        }


        private bool IsLeftWall(int i)
        {
            return i % _width == 0;
        }

        private bool IsRightWall(int i)
        {
            var row = i/_width;
            var sub = row*_width;
            var diff = i - sub;
            var b = (diff + 1) == _width;
            return b;
        }

        private bool IsBottomWall(int i)
        {
            return i > ( NumberItems - _width - 1 );
        }

        private bool IsTopWall(int i)
        {
            return i < _width;
        }
    }
}
