using System.Collections.Generic;

namespace CargoTransportation.Transport
{
    /// <summary>
    /// Клас описывает полуприцеп
    /// </summary>
    public abstract class Semitrailer
    {
        /// <summary>
        /// Пара ключ-значение (номер для чтения данных и тип полуприцепа)
        /// </summary>
        protected KeyValuePair<int, string> specificType { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="maxWeight">Максимальная грузоподъемность</param>
        /// <param name="value">доступный объём (?)</param>
        public Semitrailer(double maxWeight, double value)
        {
            MaxWeight = maxWeight;
            Value = value;
            CurrentProducts = null;
            CurrentWeight = 0;
        }

        /// <summary>
        /// Список товаров в полуприцепе
        /// </summary>
        public List<Cargo.Cargo> CurrentProducts { get; set; }

        /// <summary>
        /// Текущяя масса товаров в полуприцепе
        /// </summary>
        public double CurrentWeight { get; set; }
        public double Value { get; set; }  

        private double MaxWeight;

        /// <summary>
        /// Абстрактный метод для загрузки в полуприцеп товара
        /// </summary>
        /// <param name="obj">Груз</param>
        public abstract void LoaddSemiTrailer(Cargo.Cargo obj);

        /// <summary>
        /// Абстрактный метод для разгруки из полуприцепа товара
        /// </summary>
        /// <param name="obj">Груз</param>
        public abstract void UnloadSemitrailer(Cargo.Cargo obj);


        /// <summary>
        /// Метод для получения типа полуприцепа
        /// </summary>
        /// <returns>KeyValuePair<int, string> specificType</returns>
        public KeyValuePair<int, string> GetTrailerType()
        {
            return specificType;
        }

        /// <summary>
        /// Метод для получения значения максимальной грузоподъемности
        /// </summary>
        /// <returns>double MaxWeight</returns>
        public double GetWeight()
        {
            return MaxWeight;
        }


        public override string ToString()
        {
            return this.specificType.Value + "; [ " + this.CurrentWeight + " / " + this.MaxWeight + " ]; " + this.Value;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
