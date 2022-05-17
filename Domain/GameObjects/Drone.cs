using Invasion.Domain.Walls;
using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Invasion.Domain.GameObjects
{
    public class Drone : IGameObject
    {
        public Image Image { get; } = Resources.drone;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(40, 40);
        public Rectangle Collision
        {
            get
            {
                var colSize = new Size(Size.Width + 15, Size.Height + 15);
                return new Rectangle(Position.AsPoint().Add(-colSize.Width / 2, -colSize.Height / 2), colSize);
            }
        }

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 20;

        public SinglyLinkedList<Vector> Movement { get; set; }

        public bool IsCrashed { get; set; }

        //public Drone(Vector dronePos, Vector cannonPos)
        //{
        //    Position = dronePos.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
        //    Direction = (cannonPos - Position).Angle * 180 / Math.PI;
        //    MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        //}

        //public void Move()
        //{
        //    Position += MoveVector;
        //}

        private ValueTuple<int, int>[] moves = new[] {
            (20, 0), (0, 20), (-20, 0), (0, -20) };

        public Drone(Vector dronePos, Rectangle battleGround, List<IWall> walls, Rectangle cannonCollision)
        {
            Position = dronePos.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));

            var backMovement = FindBestPath(battleGround, walls, Position, cannonCollision);
            Movement = backMovement.Reverse();
        }

        public void Move()
        {
            Direction = (Movement.Value - Position).Angle * 180 / Math.PI;
            Position = Movement.Value;
            Movement = Movement.Previous;
        }

        public SinglyLinkedList<Vector> FindBestPath(Rectangle battleGround, List<IWall> walls, Vector start, Rectangle cannonCollision)
        {
            SinglyLinkedList<Vector> currentElement;
            Vector currentPosition;
            Vector newPosition;
            var visited = new HashSet<Vector>();
            var queue = new Queue<SinglyLinkedList<Vector>>();
            queue.Enqueue(new SinglyLinkedList<Vector>(start));
            visited.Add(start);
            while (queue.Count > 0)
            {
                currentElement = queue.Dequeue();
                currentPosition = currentElement.Value;
                foreach (var move in moves)
                {
                    newPosition = new Vector(currentPosition.X + move.Item1, currentPosition.Y + move.Item2);
                    var currentCollision = new Rectangle(currentPosition.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
                    if (currentCollision.IntersectsWith(cannonCollision))
                        return new SinglyLinkedList<Vector>(newPosition, currentElement);
                    else if (!visited.Contains(newPosition) 
                        && (newPosition.X > 0 && newPosition.X < battleGround.Width && newPosition.Y >= 0 && newPosition.Y < battleGround.Height)
                        && !walls.Any(wall => currentCollision.IntersectsWith(wall.Collision)))
                    {
                        queue.Enqueue(new SinglyLinkedList<Vector>(newPosition, currentElement));
                        visited.Add(newPosition);
                    }
                }
            }
            return new SinglyLinkedList<Vector>(start);
        }
    }
}
