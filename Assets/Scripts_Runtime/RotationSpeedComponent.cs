using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace HelloCube {

    public struct RotationSpeedComponent : IComponentData {
        public float RadiansPerSecond;
    }
}