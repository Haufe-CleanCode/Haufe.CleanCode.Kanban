using kanbanboard.contracts;
using System;
using System.IO;

namespace kanbanboard.boardconfig
{
    public class BoardConfigProvider : IBoardConfigProvider
    {
        public BoardConfig LoadBoardConfig()
        {
            var boardConfig = new BoardConfig();
            var fileContent = File.ReadAllLines("bin/Debug/net5.0/Board.Config");
            foreach(var line in fileContent)
            {
                var newColumn = new BoardConfigColumn();
                if (line.Contains(";"))
                {
                    var semikolonPositionIndex = line.IndexOf(";", StringComparison.CurrentCulture);
                    newColumn.Header = line.Substring(0, semikolonPositionIndex);
                    var wip = line.Substring(semikolonPositionIndex + 1, line.Length - semikolonPositionIndex - 1);
                    newColumn.WIPLimit = int.Parse(wip);
                }
                else
                {
                    newColumn.Header = line;
                }
                boardConfig.Columns.Add(newColumn);
            }

            return boardConfig;
        }
    }
}
