namespace Observer.Interfaces
{
    public interface IObserver<T>
    {
        public void UpdateObserver(T data);
    }
}
