using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public enum Status
{
  Available,
  Occupied,
  Canceled,
  Rescheduled
}
public class VacancyModel
{
  [BsonId]
  public ObjectId Id { get; set; }

  [BsonElement("available_hour")]
  [DisplayName("Horário disponível")]
  public DateTime AvailableHour { get; set; }

  [BsonElement("patient")]
  [DisplayName("Paciente")]
  public ObjectId? PatientId { get; set; }

  [BsonElement("professional")]
  [DisplayName("Profissional")]
  public ObjectId? ProfessionalId { get; set; }

  [BsonElement("reserved_by")]
  [DisplayName("Reservado por")]
  public ObjectId? ReservedById { get; set; }

  [BsonElement("created_by")]
  [DisplayName("Criado por")]
  public ObjectId? CreatedById { get; set; }

  [BsonElement("status")]
  [DisplayName("Status")]
  [BsonRepresentation(BsonType.String)]
  public Status Status { get; set; }
}