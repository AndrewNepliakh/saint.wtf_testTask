namespace Controllers.BuildingController
{
    public interface IBuilding
    {
        BuildingType Type { get; }
        void Init(BuildingType type);
        void Consume();
        void Produce();
    }
}