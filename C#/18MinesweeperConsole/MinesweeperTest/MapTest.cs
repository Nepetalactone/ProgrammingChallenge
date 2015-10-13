using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _18MinesweeperConsole.GameEnvironment;

namespace MinesweeperTest
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void isNeighbourWorksProperly()
        {
            Map map = new Map();
            PrivateObject accessor = new PrivateObject(map);
            Tuple<int, int> t1 = new Tuple<int, int>(0, 0);
            Tuple<int, int> t2 = new Tuple<int, int>(0, 1);
            Boolean isNeighbour = (Boolean)accessor.Invoke("areNeighbours", new Object[] { new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 1) });
            Assert.IsTrue(isNeighbour);
        }
    }
}
