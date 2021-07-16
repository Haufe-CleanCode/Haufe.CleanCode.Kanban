using NUnit.Framework;
using kanbanboard.boardconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kanbanboard.boardconfig.Tests
{
    [TestFixture()]
    public class BoardConfigProviderTests
    {
        [Test()]
        public void LoadBoardConfigTest()
        {
            var boardConfigProvider = new BoardConfigProvider();
            var content = boardConfigProvider.LoadBoardConfig();
            var contentHeader = content.Columns.Select(h => h.Header).ToList();
            var contentWip = content.Columns.Select(w => w.WIPLimit).ToList();
            var expectedHeader = new List<string>() { "To do", "In progress", "Done" };
            var expectedWip = new List<int>() {0, 3, 0};
            Assert.Multiple(() =>
                {
                    Assert.That(contentHeader, Is.EqualTo(expectedHeader));
                    Assert.That(contentWip, Is.EqualTo(expectedWip));
                }
            );
        }
    }
}