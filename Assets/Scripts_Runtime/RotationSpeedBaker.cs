using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace HelloCube {
    public class RotationSpeedBaker : MonoBehaviour {
        public float DegreesPerSecond = 360.0f;

        class Baker : Baker<RotationSpeedBaker> {
            public override void Bake(RotationSpeedBaker authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotSpeedComponent {
                    RadiansPerSecond = math.radians(authoring.DegreesPerSecond)
                });
            }
        }
    }

    public struct RotSpeedComponent : IComponentData {
        public float RadiansPerSecond;
    }
}