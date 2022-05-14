using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invasion.Domain;
using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;
using Invasion.Domain.Walls;

namespace Invasion.Domain
{
	public class Level
    {
		public Cannon Cannon { get; }
		public ControlCenter ControlCenter { get; }
		public List<SupplyCenter> SupplyCenters { get; }
		public List<IWall> Walls { get; }
		public int DroneAppearanceTime { get; }

		public List<Drone> Drones { get; }
		public List<IProjectile> Projectiles { get; }
		public Vector RocketTargetPosition { get; set; }

		public bool IsCompleted => ControlCenter.IsCrashed;

		public Level(Cannon cannon, Vector controlCenterPosition, List<Vector> supplyCenterPositions,
			List<IWall> walls, int droneAppearanceTime)
		{
			Cannon = cannon;
			ControlCenter = new ControlCenter(controlCenterPosition);
			SupplyCenters = supplyCenterPositions.Select(position => new SupplyCenter(position)).ToList();
			Walls = walls;
			DroneAppearanceTime = droneAppearanceTime;
			Drones = new List<Drone>();
			Projectiles = new List<IProjectile>();
		}
	}
}
