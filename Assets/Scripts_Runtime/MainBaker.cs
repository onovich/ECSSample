using Unity.Entities;
using UnityEngine;

namespace HelloCube {
    public class MainBaker : MonoBehaviour {
        class Baker : Baker<MainBaker> {
            public override void Bake(MainBaker authoring) {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<MainComponent>(entity);
            }
        }
    }

    public struct MainComponent : IComponentData {
    }

}