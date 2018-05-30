public class Tuple<T, U, P>
{
    public Tuple(T itemOne, U itemTwo, P itemThree)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = itemTwo;
        this.ItemThree = itemThree;
    }

    public T ItemOne { get; private set; }
    public U ItemTwo { get; private set; }
    public P ItemThree { get; private set; }

    public override string ToString()
    {
        return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
    }
}