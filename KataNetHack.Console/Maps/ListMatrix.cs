using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataNetHack.Console.Maps
{
    public class ListMatrix : Matrix
    {

        private readonly char[] _mapItems;

        public IEnumerable<char> MapItems => _mapItems;

        public ListMatrix(IEnumerable<char> mapItems, int width = 10, int height = 10)
        {
            this.Capacity = width*height;
            if (mapItems == null)
            {
                throw new ArgumentNullException(nameof(mapItems));
            }

            this._mapItems = mapItems.ToArray();

            Width = width;
            Height = height;

            if (Capacity != _mapItems.Length)
            {
                throw new ArgumentException(
                    $"The number of elements in mapItems must match with the number of items required from the width and height. Width is {Width} and height is {Height} so the required capacity is {Capacity} but was only {_mapItems.Length}", 
                    nameof(mapItems)
                    );
            }
        }
        
        public override Element ElementAt(int column, int row)
        {
            int position = Position(row, column, Width, Capacity);
            var item = _mapItems[position];
            var tileType = GetTileType(item);
            return new Element() { Type = tileType };
        }

        public override Location SpawnLocation()
        {
            int pos = -1;
            pos = Array.IndexOf(_mapItems, ElementConstants.SpawnPoint);

            if (pos == -1)
                pos = Array.IndexOf(_mapItems, ElementConstants.Passageway);

            if (pos == -1)
                pos = 0;

            return LocationOfPosition(pos);
        }

        private Location LocationOfPosition(int position)
        {
            //calculation is zero based
            int y = (position/Width);
            int x = position - (y*Width);

            return new Location(++x, ++y);
        }

        public int Position(int column, int row)
        {
            return Position(column, row, Width, Capacity);
        }


        public static int Position(int column, int row, int width, int capacity)
        {
            int x = column - 1;
            int y = row - 1;
            int position = 0;

            position = (y * width) + (x);

            if (position >= capacity)
                throw new ArgumentOutOfRangeException();

            return position;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Capacity);
            var lines = Capacity / Width;
            for (int i = 0; i < lines; i++)
            {
                var start = i*Width;
                var lineArr = new char[Width];
                Array.Copy(_mapItems, start, lineArr, 0, Width);

                sb.AppendLine(new string(lineArr));
            }

            return sb.ToString();
        }
    }

    public abstract class Matrix
    {
        public abstract Element ElementAt(int column, int row);
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public int Capacity { get; protected set; }

        protected ElementType GetTileType(char item)
        {
            if (item == '=') { return ElementType.Wall;}
            if (item == '*') { return ElementType.Exit;}
            if (item == '!') { return ElementType.SpawnPoint; }

            return ElementType.PassageWay;

        }

        public abstract Location SpawnLocation();
    }
}
