using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invasion.Domain;
using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;

namespace Invasion.Domain
{
	public class Level
    {
		public Cannon Cannon;
		public ControlCenter ControlCenter;
		public List<SupplyCenter> SupplyCenters;
		public List<Drone> Drones;
		public List<IGameObject> GameObjects;
		public List<IProjectile> Projectiles;
		public Vector RocketTargetPosition;

		public bool IsCompleted => ControlCenter.IsCrashed;

		public Level(Cannon cannon, Vector cotrolCenterPos, List<Vector> supplyCenterPositions, List<IGameObject> walls)
		{
			Cannon = cannon;
			ControlCenter = new ControlCenter(cotrolCenterPos);
			SupplyCenters = new List<SupplyCenter>();
			foreach (var scPosition in supplyCenterPositions)
				SupplyCenters.Add(new SupplyCenter(scPosition));
			GameObjects = walls;
			Drones = new List<Drone>();
			Projectiles = new List<IProjectile>();
		}
	}
}
