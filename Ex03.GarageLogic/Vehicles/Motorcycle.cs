namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle
    {
        public enum eLicenseClass
        {
            A1,
            A2,
            B1,
            B2
        }

        public eLicenseClass LicenseClass { get; set; } = k_LicenseClassDefaultValue;
        public int EngineVolumeInCubicCentimeters { get; set; } = k_EngineVolumeDefaultValue;
        private const eLicenseClass k_LicenseClassDefaultValue = eLicenseClass.A1;
        private const int k_EngineVolumeDefaultValue = 0;
    }
}