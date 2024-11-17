using System.ComponentModel;

namespace FinalDataLoader
{
    class Incident
    {
        public int Seqnos { get; set; }
        public DateTime? DateTimeReceived { get; set; }
        public DateTime? DateTimeComplete { get; set; }
        public string CallType { get; set; }
        public string ResponsibleCity { get; set; }
        public string ResponsibleState { get; set; }
        public string ResponsibleZip { get; set; }
        public string DescriptionOfIncident { get; set; }
        public string TypeOfIncident { get; set; }
        public string IncidentCause { get; set; }
        public int? InjuryCount { get; set; }
        public int? HospitalizationCount { get; set; }
        public int? FatalityCount { get; set; }
        public Company ResponsibleCompany { get; set; }
        public int? ResponsibleCompanyId { get; set; }
        public int? RailroadId { get; set; }
        public int? IncidentTrainId { get; set; }
    }
}