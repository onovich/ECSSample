using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace HelloCube {
    public partial struct RotationSystem : ISystem {

        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            state.RequireForUpdate<MainComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            float deltaTime = SystemAPI.Time.DeltaTime;
            double elapsedTime = SystemAPI.Time.ElapsedTime;
            foreach (var (transform, speed) in
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotSpeedComponent>>()) {
                transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.RadiansPerSecond * deltaTime);
            }
            foreach (var movement in
                     SystemAPI.Query<VerticalMovementAspect>()) {
                movement.Move(elapsedTime);
            }
        }
    }

    readonly partial struct VerticalMovementAspect : IAspect {
        readonly RefRW<LocalTransform> m_Transform;
        readonly RefRO<RotSpeedComponent> m_Speed;

        public void Move(double elapsedTime) {
            m_Transform.ValueRW.Position.y = (float)math.sin(elapsedTime * m_Speed.ValueRO.RadiansPerSecond);
        }
    }

}