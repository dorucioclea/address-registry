namespace AddressRegistry.Address.Events
{
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Be.Vlaanderen.Basisregisters.GrAr.Provenance;
    using Newtonsoft.Json;
    using System;

    [EventName("AddressHouseNumberWasCorrected")]
    [EventDescription("Het huisnummer van het adres werd gecorrigeerd.")]
    public class AddressHouseNumberWasCorrected : IHasProvenance, ISetProvenance
    {
        public Guid AddressId { get; }
        public string HouseNumber { get; }
        public ProvenanceData Provenance { get; private set; }

        public AddressHouseNumberWasCorrected(
            AddressId addressId,
            HouseNumber houseNumber)
        {
            AddressId = addressId;
            HouseNumber = houseNumber;
        }

        [JsonConstructor]
        private AddressHouseNumberWasCorrected(
            Guid addressId,
            string houseNumber,
            ProvenanceData provenance)
            : this(
                new AddressId(addressId),
                new HouseNumber(houseNumber))
                => ((ISetProvenance)this).SetProvenance(provenance.ToProvenance());

        void ISetProvenance.SetProvenance(Provenance provenance) => Provenance = new ProvenanceData(provenance);
    }
}
