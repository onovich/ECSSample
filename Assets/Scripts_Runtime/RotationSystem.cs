using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace HelloCube {
    public partial struct RotationSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            state.RequireForUpdate<MainComponentBaker>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (transform, speed) in
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotationSpeedComponent>>()) {
                transform.ValueRW = transform.ValueRO.RotateY(
                speed.ValueRO.RadiansPerSecond * deltaTime);
            }
        }
    }
}
