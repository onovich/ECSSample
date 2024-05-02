using Unity.Entities;
using UnityEngine;

namespace HelloCube {
    public class MainComponentBaker : MonoBehaviour {

        class Baker : Baker<MainComponentBaker> {
            public override void Bake(MainComponentBaker authoring) {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<MainComponent>(entity);
            }
        }
        
    }

    public struct MainComponent : IComponentData {
    }

}
