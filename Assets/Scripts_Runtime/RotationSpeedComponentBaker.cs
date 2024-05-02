using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace HelloCube {

    public class RotationSpeedComponentBaker : MonoBehaviour {
        public float DegreesPerSecond = 360.0f;

        class Baker : Baker<RotationSpeedComponentBaker> {
            public override void Bake(RotationSpeedComponentBaker authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotationSpeedComponent {
                    RadiansPerSecond = math.radians(authoring.DegreesPerSecond)
                });
            } 
        }
    }

    public struct RotationSpeedComponent : IComponentData {
        public float RadiansPerSecond;
    }

}