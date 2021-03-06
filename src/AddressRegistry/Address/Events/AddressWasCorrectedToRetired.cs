namespace AddressRegistry.Address.Events
{
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Be.Vlaanderen.Basisregisters.GrAr.Provenance;
    using Newtonsoft.Json;
    using System;

    [EventName("AddressWasCorrectedToRetired")]
    [EventDescription("Het adres werd gehistoreerd via correctie.")]
    public class AddressWasCorrectedToRetired : IHasProvenance, ISetProvenance
    {
        public Guid AddressId { get; }
        public ProvenanceData Provenance { get; private set; }

        public AddressWasCorrectedToRetired(AddressId addressId) => AddressId = addressId;

        [JsonConstructor]
        private AddressWasCorrectedToRetired(
            Guid addressId,
            ProvenanceData provenance)
            : this(
                new AddressId(addressId))
                => ((ISetProvenance)this).SetProvenance(provenance.ToProvenance());

        void ISetProvenance.SetProvenance(Provenance provenance) => Provenance = new ProvenanceData(provenance);
    }
}
