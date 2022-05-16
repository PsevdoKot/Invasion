using Invasion.Domain.GameObjects;
using Invasion.Domain.Walls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain
{
	public class LevelMaker
	{
		//private static Level[] Levels = new Level[7];

		//public static Level GetLevel(int levelNumber)
		//{
		//	return Levels[levelNumber] ?? LoadLevelFromFolder(Folders.Levels, levelNumber);
		//}

		public static Level LoadLevelFromFolder(DirectoryInfo folder, int levelNumber)
		{
			var levelFile = folder.GetFiles($"Level_{levelNumber}.txt", SearchOption.AllDirectories).Single();
			var levelInputData = File.ReadAllText(levelFile.FullName);
			return LoadLevelFromInputData(levelInputData.Split('|'), levelNumber);
		}

		private static Level LoadLevelFromInputData(string[] inputData, int levelNumber)
		{
			var cannonPosition = MakeVectorsFromData(inputData[0]).FirstOrDefault();
			var ammunition = inputData[1].Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)[1]
				.Split(' ').Select(int.Parse).ToArray();
			var cannon = new Cannon(cannonPosition, ammunition);

			var controlCenterPosition = MakeVectorsFromData(inputData[2]).FirstOrDefault();
			var supplyCentersPositions = MakeVectorsFromData(inputData[3]).ToList();
			var wallsPositions = MakeWallsFromData(inputData[4]);
			var droneAppearanceTime = int.Parse(inputData[5].Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)[1]);

			//Levels[levelNumber] = new Level(cannon, controlCenterPosition, supplyCentersPositions, wallsPositions, droneAppearanceTime);
			//return new Level(Levels[levelNumber]);
			return new Level(cannon, controlCenterPosition, supplyCentersPositions, wallsPositions, droneAppearanceTime);
		}

        private static Vector MakeVector(string positionData)
        {
			var positionXY = positionData.Split(' ');
			return new Vector(int.Parse(positionXY[0]), int.Parse(positionXY[1]));
		}

		private static IEnumerable<Vector> MakeVectorsFromData(string positionData)
		{
			var positionsXY = positionData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			return positionsXY
				.Skip(1)
				.Select(xy => MakeVector(xy));
		}

		private static List<IWall> MakeWallsFromData(string inputData)
		{
			var wallsData = inputData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			return wallsData
				.Skip(1)
				.Select(data => data.Split(';'))
				.Select(parts => 
                    {
						var wallData = GetWallData(parts);
						switch (parts[3])
                        {
							default:
							case "solid":
								return new SolidWall(wallData);
							case "fragile":
								return new FragileWall(wallData);
							case "reflective":
								return (IWall)new ReflectiveWall(wallData);
						}
                    })
				.ToList();
		}

        private static (Vector, Size, double) GetWallData(string[] inputData)
        {
			var widthHeight = inputData[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			var size = new Size(int.Parse(widthHeight[0]), int.Parse(widthHeight[1]));
			return (MakeVector(inputData[0]), size, 
				double.Parse(inputData[2].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()));
        }
    }
}
