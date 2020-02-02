using PlatformHandles;
using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformType platformType;

    public PlatformType PlatformType => platformType;

    void Reset()
    {
        
    }

    public class Pool : MonoMemoryPool<Platform>
    {
        public PlatformType PlatformType { get; }

        public Pool(PlatformType platformType)
        {
            PlatformType = platformType;
        }

        protected override void Reinitialize(Platform platform)
        {
            platform.Reset();
        }
    }
}