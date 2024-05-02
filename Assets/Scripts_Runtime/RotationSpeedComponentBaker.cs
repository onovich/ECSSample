using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace HelloCube {

    public class RotationSpeedComponentBaker : MonoBehaviour {

        class Baker : Baker<RotationSpeedEM> {
            public override void Bake(RotationSpeedEM tm) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotationSpeedComponent {
                    RadiansPerSecond = math.radians(tm.DegreesPerSecond)
                });
            }
        }
    }

}