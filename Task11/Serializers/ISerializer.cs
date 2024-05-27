namespace Task11.Serializers;

public interface ISerializer<T>
{
    public T BuildInstance();
    public T UpdateInstance(T instance);
    public static abstract ISerializer<T>[] SerializeList(IList<T> objects);
}