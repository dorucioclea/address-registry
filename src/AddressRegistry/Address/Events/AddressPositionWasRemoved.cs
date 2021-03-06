namespace AddressRegistry.Address.Events
{
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Be.Vlaanderen.Basisregisters.GrAr.Provenance;
    using Newtonsoft.Json;
    using System;

    [EventName("AddressPositionWasRemoved")]
    [EventDescription("De adrespositie werd verwijderd.")]
    public class AddressPositionWasRemoved : IHasProvenance, ISetProvenance
    {
        public Guid AddressId { get; }
        public ProvenanceData Provenance { get; private set; }

        public AddressPositionWasRemoved(AddressId addressId) => AddressId = addressId;

        [JsonConstructor]
        private AddressPositionWasRemoved(
            Guid addressId,
            ProvenanceData provenance)
            : this(
                new AddressId(addressId))
                => ((ISetProvenance)this).SetProvenance(provenance.ToProvenance());

        void ISetProvenance.SetProvenance(Provenance provenance) => Provenance = new ProvenanceData(provenance);
    }
}
