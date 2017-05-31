namespace jcHAP.SensorNode.Sensors
{
    public abstract class BaseSensor<T>
    {
        public abstract void Initialize();

        public abstract string GetData();
    }
}