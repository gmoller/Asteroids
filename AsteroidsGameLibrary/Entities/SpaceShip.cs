﻿using System;
using System.Numerics;
using CollisionDetectionLibrary;
using GeneralUtilities;
using ShapesLibrary;

namespace AsteroidsGameLibrary.Entities
{
    public class SpaceShip
    {
        private readonly Lasers _lasers;

        private float _thrust;
        private Vector2 _motionVectorTo;
        private readonly SpaceShipEngine _engine;

        public Vector2 Position { get; private set; } // center of spaceship
        public Vector2 Size { get; }
        public Vector2 Origin { get; }
        public float RotationInRadians { get; private set; }
        public int TextureId { get; }
        public SpaceShipEngine Engine => _engine;

        public Lasers Lasers => _lasers;

        public CollisionBoundary CollisionBoundary
        {
            get
            {
                var shape1 = new OrientedRectangle(new Vector2(Position.X, Position.Y), new Vector2(Size.X / 2.0f, Size.Y / 2.0f), RotationInRadians.ToDegrees());
                var cb = new CollisionBoundary(shape1);

                return cb;
            }
        }

        public Vector2 MotionVectorCurrent { get; private set; }

        public SpaceShip(Vector2 position, float rotationInDegrees, int textureId, int particleTextureId)
        {
            Position = position;
            Size = new Vector2(50.0f, 50.0f);
            Origin = new Vector2(720 / 2.0f, 713 / 2.0f); // texture is 720x713
            RotationInRadians = rotationInDegrees.ToRadians();
            TextureId = textureId;
            MotionVectorCurrent = Vector2.Zero;
            _motionVectorTo = Vector2.Zero;

            //front: new Vector2(0.0f, -50.0f)
            //_laser1 = new Laser(new Vector2(10.0f, -10.0f), new GeneralUtilities.Color(255, 0, 0, 255), particleTextureId); // red
            //_laser2 = new Laser(new Vector2(-10.0f, -10.0f), new GeneralUtilities.Color(0, 0, 255, 255), particleTextureId); // blue
            _lasers = new Lasers
            {
                new Laser(new Vector2(0.0f, -Size.X / 2.0f), Color.Red, particleTextureId),
                new Laser(new Vector2(0.0f, -Size.X / 2.0f), Color.Blue, particleTextureId),
                new Laser(new Vector2(0.0f, -Size.X / 2.0f), Color.Green, particleTextureId),
                new Laser(new Vector2(0.0f, -Size.X / 2.0f), Color.Gray, particleTextureId)
            };

            _engine = new SpaceShipEngine(this, particleTextureId);
        }

        public void RotateLeft(float f)
        { 
            RotationInRadians -= f;
        }

        public void RotateRight(float f)
        {
            RotationInRadians += f;
        }

        public void IncreaseThrust(float f)
        {
            _thrust += f;
            //var direction = new Vector2((float)Math.Sin(RotationInRadians), -(float)Math.Cos(RotationInRadians));
            //_motionVectorTo = direction;

            _engine.Start(Position);
        }

        public void ShootGun()
        {
            foreach (Laser laser in _lasers)
            {
                if (laser.CanShoot)
                {
                    bool laserFired = laser.Shoot(Position, RotationInRadians);
                    if (laserFired)
                    {
                        break;
                    }
                }
            }
        }

        public void Update(float deltaTime)
        {
            var direction = new Vector2((float)Math.Sin(RotationInRadians), -(float)Math.Cos(RotationInRadians));
            _motionVectorTo = direction;

            MotionVectorCurrent = MotionVectorCurrent.Lerp(_motionVectorTo, deltaTime);

            Move(deltaTime);

            DecreaseThrust(20.0f * deltaTime);

            ClampThrust();

            foreach (Laser laser in _lasers)
            {
                laser.Update(deltaTime);
            }

            _engine.Update(deltaTime);
        }

        private void Move(float deltaTime)
        {
            float thrustForFrame = _thrust * deltaTime;
            Position = new Vector2(Position.X + MotionVectorCurrent.X * thrustForFrame, Position.Y + MotionVectorCurrent.Y * thrustForFrame);

            Position = Helper.WrapAround(Position, GameSettings.Resolution);
        }

        private void DecreaseThrust(float f)
        {
            _thrust -= f;
        }

        private void ClampThrust()
        {
            var range = new Range<float>(0.0f, 1000.0f);
            _thrust = _thrust.ClampOnRange(range);
        }
    }
}