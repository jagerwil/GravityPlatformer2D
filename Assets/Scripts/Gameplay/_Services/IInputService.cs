using JetBrains.Annotations;

namespace GravityPlatformer2D.Gameplay._Services {
    public interface IInputService : IInputProcessor {
        [CanBeNull]
        public T TryGetInputProcessor<T>() where T : class, IInputProcessor;
    }
}
