namespace Controllers.BuildingController
{
    public interface IConsumable : IBuilding
    {
        bool Consume();
    }
}