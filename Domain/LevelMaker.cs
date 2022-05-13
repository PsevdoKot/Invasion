using Invasion.Domain.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain
{
    public class LevelMaker
    {
		public static Level[] Levels = new Level[7];

		public static Level LoadLevelFromFolder(DirectoryInfo folder, int levelNumber)
		{
			var levelFile = folder.GetFiles($"Level_{levelNumber}.txt", SearchOption.AllDirectories).Single();
			var levelInputData = File.ReadAllText(levelFile.FullName);
			return LoadLevelFromInputData(levelInputData.Split('|'), levelNumber);
		}

		private static Level LoadLevelFromInputData(string[] inputData, int levelNumber)
		{
			var cannonPosition = MakeVectorsFromData(inputData[0]).FirstOrDefault();
			var ammunition = inputData[1].Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1]
				.Split(' ').Select(int.Parse).ToArray();
			var cannon = new Cannon(cannonPosition, ammunition);

			var controlCenterPosition = MakeVectorsFromData(inputData[2]).FirstOrDefault();
			var supplyCentersPositions = MakeVectorsFromData(inputData[3]).ToList();
			var wallsPositions = new List<IGameObject>(); //MakeVectorsFromData(inputData[4]).ToList();
			var droneAppearanceTime = int.Parse(inputData[5].Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1]);
			
			var level = new Level(cannon, controlCenterPosition, supplyCentersPositions, wallsPositions, droneAppearanceTime);
			Levels[levelNumber] = level;
			return level;
		}

		private static Vector MakeVector(string positionData)
        {
			var positionXY = positionData.Split(' ');
			return new Vector(int.Parse(positionXY[0]), int.Parse(positionXY[1]));
		}

		private static IEnumerable<Vector> MakeVectorsFromData(string positionData)
		{
			var positionsXY = positionData.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			return positionsXY
				.Skip(1)
				.Select(xy => MakeVector(xy));
		}
	}
}
