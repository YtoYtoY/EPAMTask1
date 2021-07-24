namespace CargoTransportation.Parser
{
    /// <summary>
    /// Интерфейс реализующий чтение и запись данных
    /// </summary>
    public interface IParse
    {
        void DataRead(string path);
        void DataWrite(string path);
    }
}
