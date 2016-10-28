using System;
using System.Collections.Generic;

using KataNetHack.Console;
using KataNetHack.Console.Renderer;

using Moq;

namespace KataNetHack.Tests
{
    public class RendererBuilder
    {
        private Mock<IMap> Map { get; } = new Mock<IMap>();
        public IReadOnlyList<string> OutputLines => _lines;
        private readonly List<string> _lines = new List<string>();
        private Action _clearScreenAction = () => { };

        public RendererBuilder()
        {
            Map.Setup(obj => obj.GetElementType(It.IsAny<int>(), It.IsAny<int>()))
               .Returns(ElementType.PassageWay);
        }

        public RendererBuilder WithWallAt(int x, int y)
        {
            Map.Setup(obj => obj.GetElementType(x, y))
               .Returns(ElementType.Wall);

            return this;
        }

        public RendererBuilder WithCellAt(int x, int y, ElementType type)
        {
            Map.Setup(obj => obj.GetElementType(x, y))
               .Returns(type);

            return this;
        }

        public RendererBuilder WhenClearingScreenDo(Action action)
        {
            _clearScreenAction = action;

            return this;
        }

        public Renderer Build()
        {
            return new Renderer(Map.Object)
                   {
                       WriteLine = line => _lines.Add(line),
                       ClearScreen = _clearScreenAction
                   };
        }
    }
}