using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Training;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingExercise : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrainingExerciseCategory Category { get; set; }
        public TrainingExerciseSubCategory SubCategory { get; set; }
        public string? MuscleGroups { get; set; }
        public string? Equipment { get; set; }
        public string? Instructions { get; set; }
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public int DifficultyLevel { get; set; }
        public decimal? EstimatedCalories { get; set; }
        public IEnumerable<SessionExercise>? SessionExercises { get; set; }
        public override void InitializeSlug() => Slug = Name.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingExercise>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingExercise>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingExercise>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingExercise>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingExercise>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
