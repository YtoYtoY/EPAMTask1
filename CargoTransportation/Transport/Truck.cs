using CargoTransportation.Constants;
using System;
using System.Collections.Generic;

namespace CargoTransportation.Transport
{
    /// <summary>
    /// Класс описывает седельный тягач
    /// </summary>
    public abstract class Truck
    {
        /// <summary>
        /// Пара ключ-значение (номер для чтения данных и тип тягача)
        /// </summary>
        protected KeyValuePair<int, string> specificType { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="weight">Максимальная грузоподъемность</param>
        public Truck(double weight)
        {
            PermissibleWeight = weight;
            ConnectedSemitrailer = null;
        }

        /// <summary>
        /// Расход топлива
        /// </summary>
        public double FuelConsumption { get; private set; }

        /// <summary>
        /// Коэфициент расхода топлива (устанавливается в конструкторе наследника)
        /// </summary>
        public double ValueConsumption { get; set; }

        /// <summary>
        /// Максимальная грузоподъемность
        /// </summary>
        private double PermissibleWeight { get; set; }

        /// <summary>
        /// Метод добавления полуприцепа к тягачу
        /// </summary>
        /// <param name="semitrailer">Полуприцеп</param>
        public void AddSemitrailer(Semitrailer semitrailer)
        {
            if (ConnectedSemitrailer == null)
            {
                if (semitrailer.GetWeight() > PermissibleWeight)
                {
                    throw new Exception(Exceptions.DifferentWeightException);
                }
                ConnectedSemitrailer = semitrailer;
            }
            else throw new Exception(Exceptions.TruckConnectionException);
        }

        /// <summary>
        /// Метод удаления полуприцепа от тягача
        /// </summary>
        public void RemoveSemitrailer()
        {
            ConnectedSemitrailer = null;
        }
        
        /// <summary>
        /// Поле хранит текущий подключенный полуприцеп
        /// </summary>
        public Semitrailer ConnectedSemitrailer { get; set; }

        /// <summary>
        /// Метод расчета расхода топлива
        /// </summary>
        public void CalculateFuelConsumption()
        {
            // How to count it ? \\
            FuelConsumption = ValueConsumption / Constants.Constants.DistanceTraveled * Constants.Constants.Kilometers;
        }

        /// <summary>
        /// Метод получения типа трака
        /// </summary>
        /// <returns>KeyValuePair<int, string> specificType</returns>
        public virtual KeyValuePair<int, string> GetModel()
        {
            return specificType;
        }

        /// <summary>
        /// Метод получения максимальной грузоподъемности (для записи в файл)
        /// </summary>
        /// <returns>double PermissibleWeight</returns>
        public double GetWeight()
        {
            return PermissibleWeight;
        }

        public override string ToString()
        {
            return this.specificType.Value + "; " + this.PermissibleWeight + "; " + this.FuelConsumption;
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
