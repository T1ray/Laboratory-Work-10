namespace Lab10;

public interface IInit : IComparable<IInit>
{
    string Name { get; set; }
    void Init();
    void RandomInit();
}