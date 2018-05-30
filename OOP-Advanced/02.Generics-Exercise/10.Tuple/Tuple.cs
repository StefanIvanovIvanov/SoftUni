public class Tuple<T, U>
{
    public Tuple(T itemOne, U ItemTwo)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = ItemTwo;
    }

    public T ItemOne { get; protected set; }
    public U ItemTwo { get; protected set; }

    public override string ToString()
    {
        return $"{this.ItemOne} -> {this.ItemTwo}";
    }
}