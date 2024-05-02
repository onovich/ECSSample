using UnityEngine;
using Unity.Entities;

namespace HelloCube {

    public class MainComponentBaker : MonoBehaviour {
        class Baker : Baker<RotationSpeedEM> {
            public override void Bake(RotationSpeedEM tm) {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<MainComponentBaker>(entity);
            }
        }
    }

}